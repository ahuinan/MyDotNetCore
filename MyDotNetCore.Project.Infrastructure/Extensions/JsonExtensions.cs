using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyDotNetCore.Project.Infrastructure.Extensions
{
    public static class JsonExtensions
    {
        /// <summary>
        /// 增加JSON扩展
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            if (obj == null) { return ""; }

            var str = JsonConvert.SerializeObject(obj);

            return str;
        }
    }
}
