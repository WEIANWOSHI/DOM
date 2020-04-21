using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagementSystem
{
    public class Log4net
    {
        static log4net.ILog logInfo = log4net.LogManager.GetLogger("Info");
        static log4net.ILog logError = log4net.LogManager.GetLogger("Error");
        public static void WriteInfo(string msg)
        {
            logInfo.Info(msg);
        }

        public static void WriteError(string msg)
        {
            logError.Error(msg);
        }
    }
}
