using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MyDotNetCore.Project.Domain.Common;

namespace MyDotNetCore.Project.Infrastructure.Helper
{
    /// <summary>
    /// 生成主键id
    /// </summary>
    public class IdHelper
    {
        private static long NextId = 0;

        private static readonly object idLock = new object();

        /// <summary>
        /// 得到新主键ID，为bigint类型，最后数字为了区分分布式时使用
        /// </summary>
        /// <returns></returns>
        public static long GetNewId()
        {
            lock (idLock)
            {
                if (NextId == 0)
                {
                    NextId = Convert.ToInt64(DateTime.Now.ToString("yyMMddHHmmssfff"));
                }

                NextId = NextId + 1;

                return Convert.ToInt64(NextId.ToString() + SysConfig.IdLastNum);
            }


        }
    }
}
