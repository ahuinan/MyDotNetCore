using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDotNetCore.Project.Infrastructure.Common
{
    public class SysConfig
    {
        /// <summary>
        /// 得到ID的最后一个数字
        /// </summary>
        /// <returns></returns>
        public static string IdLastNum = "";

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnectionMasterStr = "";

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="configuration"></param>
        public static void Init(IConfiguration configuration)
        {
            IdLastNum = configuration["IdLastNum"];

            ConnectionMasterStr = configuration["ConnectionMasterStr"];
        }



    }
}
