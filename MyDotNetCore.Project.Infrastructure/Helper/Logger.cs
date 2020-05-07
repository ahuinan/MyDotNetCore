using log4net;
using log4net.Config;
using log4net.Repository;
using MyDotNetCore.Project.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyDotNetCore.Project.Infrastructure.Helper
{
    public class LogHelper
    {
        private static ILog log;

        private static ILoggerRepository repository;

        static LogHelper()
        { 

            repository = LogManager.CreateRepository("MyDotNetCoreRepository");

            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));

            log = LogManager.GetLogger("MyDotNetCoreRepository", "");
        }

        #region Info(调试信息的数据)
        /// <summary>
        /// Info输出
        /// </summary>
        /// <param name="message"></param>
        public static void Info(object message)
        {
            log.Info(message.ToJson());
        }
        #endregion

        #region Info(Info输出)
        /// <summary>
        /// Info输出
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            log.Info(message);
        }
        #endregion

        #region Error(Error输出)
        /// <summary>
        /// Error输出
        /// </summary>
        /// <param name="message"></param>
        public static void Error(object message)
        {
            log.Error(message.ToJson());
        }
        #endregion

        #region Error(Error输出)
        /// <summary>
        /// Error输出
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            log.Error(message);
        }
        #endregion

        #region Error(输出错误)
        /// <summary>
        /// 输出错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void Error(string message, Exception ex)
        {
            log.Error(message,ex);
        }
        #endregion
    }
}
