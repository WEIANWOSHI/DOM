using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly:log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace Common
{
    public static class LogHelper
    {
        public static readonly ILog log = LogManager.GetLogger("RollingLogFileAppender");
        static log4net.ILog logInfo = log4net.LogManager.GetLogger("Info");
        static log4net.ILog logError = log4net.LogManager.GetLogger("Error");
        public static void Debug(string msg)
        {
            log.Debug(msg);
        }

        public static void Debug(string msg, Exception ex)
        {
            log.Debug($"{msg}。错误记载：{ex.Message}");
        }

        public static void Info(string msg)
        {
            logInfo.Debug(msg);
        }

        public static void Info(string msg, Exception ex)
        {
            logInfo.Debug($"{msg}。错误记载：{ex.Message}");
        }

        public static void Error(string msg)
        {
            logError.Debug(msg);
        }

        public static void Error(string msg, Exception ex)
        {
            logError.Debug($"{msg}。错误记载：{ex.Message}");
        }

        public static void Fatal(string msg)
        {
            log.Debug(msg);
        }

        public static void Fatal(string msg, Exception ex)
        {
            log.Debug($"{msg}。错误记载：{ex.Message}");
        }
    }
}
