using MyDotNetCore.Project.Infrastructure;
using MyDotNetCore.Project.Infrastructure.Common;
using MyDotNetCore.Project.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyDotNetCore.Project.GenerateCode.Template
{
    public class BaseTemplate
    {
        /// <summary>
        /// 表名
        /// </summary>
        private string _tableName;

        /// <summary>
        /// 要保存的路径
        /// </summary>
        protected string SavePath { get; set; }


        /// <summary>
        /// 模板内容
        /// </summary>
        protected string TemplateContent { get; set; }


        public BaseTemplate(string tableName)
        {
            _tableName = tableName;

          
        }


           /// <summary>
           /// 根据原始表格名得到驼峰格式的
           /// </summary>
           /// <param name="tableName"></param>
           /// <returns></returns>
            public string GetHumpTableName(string tableName)
        {
            var tableParts = tableName.Split('_');

            var str = "";

            foreach (var part in tableParts)
            {
                str += Utils.FirstCharToUpper(part);
            }

            return str;

        }

        /// <summary>
        /// 生成文件
        /// </summary>
        public void CreateFile() {

            if (!FileHelper.IsFileExists(SavePath))
            {
                FileHelper.CreateFile(SavePath, TemplateContent);
            }
        }




    }
}
