using Moder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.SuperMarket
{
    public interface ISuperLoginLogsServer
    {
        List<LoginLogs> GetLoginLog();
        List<LoginLogs> GetLoginLogBy(DateTime starttime,DateTime endTime,string wheres,int check);
    }
}
