using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDotNetCore.Project.ScheduleTask.Extensions
{
    public class ScopedJobFactory : IJobFactory
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public ScopedJobFactory(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                return new ScopedJobWrapper(this.serviceScopeFactory, bundle.JobDetail.JobType);
            }
            catch (Exception e)
            {
                throw new SchedulerException($"Error instantiating class '{bundle.JobDetail.JobType}", e);
            }
        }

        public void ReturnJob(IJob job)
        {
            // nothing to do here, as the DI container will handle job lifecycles appropriately
        }
    }
}
