using Microsoft.Extensions.DependencyInjection;
using MyDotNetCore.Project.ScheduleTask;
using MyDotNetCore.Project.ScheduleTask.Extensions;
using System;
using System.Threading.Tasks;

namespace MyDotNetCore.Project.Schedule
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().AddQuartz().BuildServiceProvider();
                
           
            //await Application(AppDomain.CurrentDomain.BaseDirectory + "/JobConfig.xml");

            Console.ReadKey();
        }
    }
}
