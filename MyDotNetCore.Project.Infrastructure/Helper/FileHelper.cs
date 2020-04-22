using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyDotNetCore.Project.Infrastructure.Helper
{
    public class FileHelper
    {
        #region GetSolutionPath(得到解决方案目录适用于命令行控制台)
        public static string GetSolutionPath()
        {
            // return AppDomain.CurrentDomain.SetupInformation.ApplicationBase

            return Path.GetFullPath(@"../../../");
        }
        #endregion

        #region IsFileExists(检查某个文件是否真的存在)
        /// <summary>
        /// 检查某个文件是否真的存在
        /// </summary>
        /// <param name="path">需要检查的文件的路径(包括路径的文件全名)</param>
        /// <returns>返回true则表示存在，false为不存在</returns>
        public static bool IsFileExists(string path)
        {

            return File.Exists(path);

        }
        #endregion

        /// <summary>
        /// 创建文件
        /// </summary>
        public static void CreateFile(string path, string content)
        {
            FileInfo file = new FileInfo(path);

            using (FileStream stream = file.Create())
            {
                using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                {
                    writer.Write(content);
                    writer.Flush();
                }
            }
        }
    }
}
