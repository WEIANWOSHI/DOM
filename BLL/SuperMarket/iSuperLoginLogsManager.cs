using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL.SuperMarket;
using Moder;
using DAL.SuperMarket;
using IDAL.SuperMarket;

namespace BLL.SuperMarket
{
    public class iSuperLoginLogsManager : SuperLoginLogsManager
    {
        ISuperLoginLogsServer server = new SuperLoginLogsServer();
        public List<LoginLogs> GetLoginLog()
        {
            return server.GetLoginLog();
        }

        public List<LoginLogs> GetLoginLogBy(DateTime starttime, DateTime endTime, string wheres, int check)
        {
            return server.GetLoginLogBy(starttime, endTime, wheres, check);
        }
    }
}
