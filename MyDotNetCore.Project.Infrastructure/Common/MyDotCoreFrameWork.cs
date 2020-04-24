using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyDotNetCore.Project.Infrastructure.Repositories;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyDotNetCore.Project.Infrastructure.Common
{
    public static class MyDotNetCoreFrameWork
    {
        private static IConfiguration configuration;
        public static void InitMyDotNetCore(this IServiceCollection service)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();

            //初始化系统配置
            configuration.GetSection("SysConfig").Bind(new SysConfig());

            //注入数据对象
            service.AddScoped<ISqlSugarClient, MyDotNetCoreSqlSugarClient>();
        }

        public static string Get(string name)
        {
            string appSettings = configuration[name];
            return appSettings;
        }




    }
}
