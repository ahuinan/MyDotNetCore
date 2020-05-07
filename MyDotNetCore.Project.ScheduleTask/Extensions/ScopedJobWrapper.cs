using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyDotNetCore.Project.ScheduleTask.Extensions
{

    internal class ScopedJobWrapper : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly Type job;

        public ScopedJobWrapper(IServiceScopeFactory serviceScopeFactory, Type job)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.job = job;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                try
                {
                    if (scope.ServiceProvider.GetService(this.job) is IJob currentJob)
                    {
                        Console.WriteLine(DateTime.Now + " : Start to run the job - " + this.job.Name);

                        await currentJob.Execute(context);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    throw new JobExecutionException($"Failed to exexcute job '{context.JobDetail.Key}' of type '{context.JobDetail.JobType}", e);
                }
            }
        }
    }
}

