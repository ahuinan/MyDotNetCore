using Microsoft.Extensions.DependencyInjection;
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
            var serciceCollection = new ServiceCollection();

            serciceCollection.InitMyDotNetCore();

            serciceCollection.AddQuartz();

            serciceCollection.AddSingleton<Application>();

            serciceCollection.AddScoped<EveryJob>();

            var serivceProvider = serciceCollection.BuildServiceProvider();

            var application = serivceProvider.GetService<Application>();

            await application.Start(AppDomain.CurrentDomain.BaseDirectory + "/JobConfig.xml");

            Console.ReadKey();
        }
    }
}
