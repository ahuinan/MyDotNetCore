using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetCore.Project.ScheduleTask.Jobs
{
    public class EveryJob:IJob
    {
        public EveryJob()
        { }

        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"EveryJob:{DateTime.Now}");

            return Task.CompletedTask;
        }

    }
}
