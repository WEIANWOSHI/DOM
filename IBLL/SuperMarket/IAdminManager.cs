using Moder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL.SuperMarket
{
    public interface IAdminManager
    {
        SysAdmins AdminLogin(SysAdmins admin);
        bool AdminUpdatePwd(SysAdmins admin);
        List<SysAdmins> GetAdmins();
        SysAdmins InsertAdmin(SysAdmins admi);
        SysAdmins UpdateAdmin(SysAdmins admin);
        bool SetSysStatus(SysAdmins admin);
        List<SalesPerson> GetSales();
        SalesPerson InsertSales(SalesPerson person);

        SalesPerson UpdateSales(SalesPerson person);
    }
}
