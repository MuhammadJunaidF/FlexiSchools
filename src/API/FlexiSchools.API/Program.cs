using FlexiSchools.API.Headers;
using FlexiSchools.API.Middleware;
using FlexiSchools.Application.SchedulerService;
using FlexiSchools.Infrastructure;
using FlexiSchools.Infrastructure.Context;
using FlexiSchools.Infrastructure.Seed;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(config =>
{
   
    config.Filters.Add(new AuthAttribute());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.UseAllOfToExtendReferenceSchemas();
    c.OperationFilter<ApiHeader>();
});

builder.Services.AddApplication(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
    options.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ssZ";
});

builder.Services.AddCors(o => o.AddPolicy("AllowAllOrigins", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


builder.Services.ConfigurePersistence(builder.Configuration, builder.Environment);
builder.Services.AddMemoryCache();

//Initialize Logger
Log.Logger = new LoggerConfiguration().CreateLogger();
builder.Host.UseSerilog(((ctx, lc) => lc
.ReadFrom.Configuration(ctx.Configuration)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlexiSchools API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyOrigin());

SeedDatabase();

app.UseSerilogRequestLogging();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();

void SeedDatabase()
{
    using(var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<FlexiSchoolsDbContext>();
        if (dbContext.Database.IsSqlServer())
        {
            dbContext.Database.Migrate();
        }

        SeedHelper.SeedHostDb(dbContext);
    }
}
