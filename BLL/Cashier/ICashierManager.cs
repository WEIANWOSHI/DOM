using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IDAL;
using DAL;
using Moder;

namespace BLL.Cashier
{
    public class ICashierManager : IBLL.Cashier.SaleManager
    {
        IDAL.Cashier.SaleServer SaleServer = new DAL.Cashier.ICashierServer();
        public SalesPerson SaleLogin(SalesPerson person)
        {
            return SaleServer.SaleLogin(person);
        }

        public int WriteSaleLog(LoginLogs logs)
        {
            return SaleServer.WriteSalesLog(logs);
        }

        public bool WriteSalesExitLog(int Logid)
        {
            if (SaleServer.WriteSalesExitLog(Logid)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DateTime GetSysTime()
        {
            return SaleServer.GetSysTime();
        }

       
    }
}
