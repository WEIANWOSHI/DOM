using Moder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.SuperMarket
{
    public interface ISuperAdminServer
    {
        SysAdmins AdminLogin(SysAdmins admin);
        int AdminUpdatePwd(SysAdmins admin);
        List<SysAdmins> GetAdmins();
        SysAdmins InsertAdmin(SysAdmins admi);
        int UpdateAdmin(SysAdmins admin);
        int SetSysStatus(SysAdmins admin);
        List<SalesPerson> GetSales();
        SalesPerson InsertSales(SalesPerson person);
        int UpdateSales(SalesPerson person);
    }
}
