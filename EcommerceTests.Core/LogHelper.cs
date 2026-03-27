using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace EcommerceTests.Core
{
    public static class LogHelper
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(LogHelper));

         static LogHelper()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        public static void Info(string message) => _log.Info(message);
        public static void Error(string message) => _log.Error(message);
    }
}