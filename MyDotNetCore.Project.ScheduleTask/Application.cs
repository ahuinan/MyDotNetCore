using MyDotNetCore.Project.Infrastructure.Extensions;
using MyDotNetCore.Project.Infrastructure.Helper;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyDotNetCore.Project.ScheduleTask
{
    public class Application
    {
		private static string ConfigFile = "";

		private static IScheduler sched = null;

		private ISchedulerFactory _schedulerFactory;

		public Application(ISchedulerFactory schedulerFactory)
		{
			_schedulerFactory = schedulerFactory;
		}

		public async Task Start(string _configPath)
		{
			ConfigFile = _configPath;

			var list = new List<jobinfo>();

			if (sched != null)
			{
				stop();
				sched = null;
			}
			sched = await _schedulerFactory.GetScheduler();

			XmlDocument document = new XmlDocument();

			document.Load(ConfigFile);

			XmlNode node = document.SelectSingleNode("Jobs");

			if (node.ChildNodes.Count == 0) { Console.WriteLine("暂未有计划任务开启");return; }
				
			foreach (XmlNode node2 in node.ChildNodes)
			{
				jobinfo item = new jobinfo
				{
					name = node2.Attributes["name"].Value,
					type = node2.Attributes["type"].Value,
					CronExpression = node2.Attributes["CronExpression"].Value,
					enabled = bool.Parse(node2.Attributes["enabled"].Value),
					runonce = bool.Parse(node2.Attributes["runonce"].Value)
				};

				if (!item.enabled) { continue; }
				
				list.Add(item);
				IJobDetail jobDetail = JobBuilder.Create(Type.GetType(item.type)).WithIdentity(item.name, item.name + "Group").Build();
				ITrigger trigger = null;

				if (!item.runonce)
				{
					trigger = TriggerBuilder.Create().WithIdentity(item.name, item.name + "Group").WithCronSchedule(item.CronExpression).Build();
				}
				else
				{
					trigger = TriggerBuilder.Create().WithIdentity(item.name, item.name + "Group").WithSimpleSchedule(x => x.WithIntervalInSeconds(1).WithRepeatCount(0)).Build();
				}
				await sched.ScheduleJob(jobDetail, trigger);
				
			}
			if (list.Count > 0)
			{
				await sched.Start();
			}
			else
			{
				Console.WriteLine("暂未有计划任务开启1");
			}
		
			
		}


		public static void stop()
		{
			try
			{
				if (sched != null)
				{
					sched.Shutdown(false);
					sched.Clear();
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine("关闭计划任务失败：" + exception.Message);
			}
		}

		private class jobinfo
		{
			public string CronExpression { get; set; }

			public bool enabled { get; set; }

			public string name { get; set; }

			public string type { get; set; }

			public bool runonce { get; set; }
		}
	}
}
