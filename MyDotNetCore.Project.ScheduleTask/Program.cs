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

             serciceCollection.AddSingleton<JobHelper>();

            serciceCollection.AddScoped<EveryJob>();

            var serivceProvider = serciceCollection.BuildServiceProvider();



            // serviceProvider.

            //Application
            var application = serivceProvider.GetService<JobHelper>();

            await application.Execute();

            //await application(AppDomain.CurrentDomain.BaseDirectory + "/JobConfig.xml");

            Console.ReadKey();
        }
    }
}
