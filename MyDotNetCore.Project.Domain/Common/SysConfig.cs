using System;
using System.Collections.Generic;
using System.Text;

namespace MyDotNetCore.Project.Domain.Common
{
    public class SysConfig
    {
        /// <summary>
        /// 得到ID的最后一个数字
        /// </summary>
        /// <returns></returns>
        public static string IdLastNum { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnectionMasterStr { get; set; }

    }
}
