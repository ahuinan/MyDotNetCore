using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetCore.Project.ScheduleTask.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQuartz(this IServiceCollection services)
        {
            services.AddSingleton<ISchedulerFactory, SchedulerFactory>();

            services.AddSingleton<ScopedJobFactory>();

            services.AddTransient<Application>();

            var jobAssemblyService = Assembly.Load("MyDotNetCore.Project.ScheduleTask");

            var types = jobAssemblyService.GetTypes().ToList().FindAll(p => p.Namespace == "MyDotNetCore.Project.ScheduleTask.Jobs");

            Parallel.ForEach(types,type => {

                services.AddTransient(type);
            });


            return services;
        }
    }
}
