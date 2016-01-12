using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Weixin.Common
{
    public class LogHelper
    {
        private static readonly log4net.ILog log = null;
        static LogHelper()
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));
            log = log4net.LogManager.GetLogger("log");
        }
        #region ILog 成员

        public static log4net.ILog Log
        {
            get
            {
                return log;
            }
        }
        public static void Debug(object message, Exception exception)
        {
            log.Debug(message, exception);
        }

        public static void Debug(object message)
        {
            log.Debug(message);
        }

        public static void Error(object message, Exception exception)
        {
            log.Error(message, exception);
        }

        public static void Error(object message)
        {
            log.Error(message);
        }


        #endregion

        #region ILoggerWrapper 成员

        public log4net.Core.ILogger Logger
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}