using AspectCore.Extensions.DependencyInjection;
using AspectCore.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyDotNetCore.Project.Infrastructure.Common;
using MyDotNetCore.Project.ScheduleTask;
using MyDotNetCore.Project.ScheduleTask.Extensions;
using MyDotNetCore.Project.ScheduleTask.Jobs;
using System;
using System.Threading.Tasks;

namespace MyDotNetCore.Project.Schedule
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var host = new HostBuilder().ConfigureServices((hostContext,services) => {

                services.AddQuartz();

                services.InitMyDotNetCore();

            })
            .UseServiceProviderFactory(new DynamicProxyServiceProviderFactory())
            .Build();

             var application = host.Services.GetRequiredService<Application>();

            await application.Start(AppDomain.CurrentDomain.BaseDirectory + "/JobConfig.xml");

            host.Run();
           
        }


    }
}
