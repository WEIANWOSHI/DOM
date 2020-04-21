using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moder;

namespace IDAL.Cashier
{
    public interface SaleServer
    {
        SalesPerson SaleLogin(SalesPerson person);
        int WriteSalesLog(LoginLogs logs);
        int WriteSalesExitLog(int Logid);
        DateTime GetSysTime();
    }
}
