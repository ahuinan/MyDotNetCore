using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDotNetCore.Project.ScheduleTask.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQuartz(this IServiceCollection services)
        {
            services.AddSingleton<ISchedulerFactory, SchedulerFactory>();

            services.AddSingleton<ScopedJobFactory>();

            return services;
        }
    }
}
