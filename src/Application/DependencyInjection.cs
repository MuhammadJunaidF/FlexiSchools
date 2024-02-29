
using FlexiSchools.Application.Lectures;
using FlexiSchools.Application.LectureTheatres;
using FlexiSchools.Application.Students;
using FlexiSchools.Application.Subjects;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace FlexiSchools.Application.SchedulerService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddScoped<IEmmSession, EmmSession>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<ILectureService, LectureService>();
            services.AddTransient<ILectureTheatreService, LectureTheatreService>();

            return services;
        }
    }
}