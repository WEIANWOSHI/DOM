using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moder;

namespace IBLL.Cashier
{
    public interface SaleManager
    {
        SalesPerson SaleLogin(SalesPerson person);
        int WriteSaleLog(LoginLogs logs);
        bool WriteSalesExitLog(int Logid);
        DateTime GetSysTime();
    }
}

