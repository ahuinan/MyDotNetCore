using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyDotNetCore.Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyDotNetCore.Project.Infrastructure.Common
{
    public static class Config
    {
        private static IConfiguration configuration;
        static Config()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();

            //初始化系统配置
            configuration.GetSection("SysConfig").Bind(new SysConfig());


        }

        public static string Get(string name)
        {
            string appSettings = configuration[name];
            return appSettings;
        }




    }
}
