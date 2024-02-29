using FlexiSchools.Application.Common.Interfaces;
using FlexiSchools.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace FlexiSchools.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDbContext<FlexiSchoolsDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(FlexiSchoolsDbContext).Assembly.FullName));
            });



            services.AddScoped<IFlexiSchoolsDbContext>(provider => provider.GetService<FlexiSchoolsDbContext>());

            var context = services.BuildServiceProvider().GetService<FlexiSchoolsDbContext>();
            //ask.Run(async () => await GeofenceDbContextSeed.Instance(context).SeedEverything(context));
            return services;
        }

    }
}