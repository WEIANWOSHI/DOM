using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL.SuperMarket;
using Moder;
using DAL.SuperMarket;
using DAL.Cashier;
using IDAL.SuperMarket;
using IDAL.Cashier;
using System.Net;

namespace BLL.SuperMarket
{
    public class AdminManager : IAdminManager
    {
        ISuperAdminServer adminServer = new SuperAdminServer();
        SaleServer saleServer = new ICashierServer();
        public SysAdmins AdminLogin(SysAdmins admin)
        {
            SysAdmins sys = adminServer.AdminLogin(admin);
            if (sys != null && sys.AdminStatus == 1)
            {
                LoginLogs log = new LoginLogs()
                {
                    Loginid = sys.LoginId,
                    SPName = sys.AdminName,
                    ServerName = Dns.GetHostName()
                };
                //保存当前管理员登录日志的ID
                sys.LoginLogId = saleServer.WriteSalesLog(log);
            }
            else
            {
                sys = null;
            }
            return sys;
        }

        public bool AdminUpdatePwd(SysAdmins admin)
        {
            int res = adminServer.AdminUpdatePwd(admin);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<SysAdmins> GetAdmins()
        {
            //获取数据库中管理者的所有内容
            return adminServer.GetAdmins();
        }

        public List<SalesPerson> GetSales()
        {
            return adminServer.GetSales();
        }

        public SysAdmins InsertAdmin(SysAdmins admi)
        {
            return adminServer.InsertAdmin(admi);
        }

        public bool SetSysStatus(SysAdmins admin)
        {
            if (adminServer.SetSysStatus(admin) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SysAdmins UpdateAdmin(SysAdmins admin)
        {
            if (adminServer.UpdateAdmin(admin) > 0)
            {
                return admin;
            }
            else
            {
                return null;
            }
        }
        public SalesPerson InsertSales(SalesPerson person)
        {
            return adminServer.InsertSales(person);
        }
        /// <summary>
        /// 修改营业员
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public SalesPerson UpdateSales(SalesPerson person)
        {
            if (adminServer.UpdateSales(person) > 0)
            {
                return person;
            }
            else
            {
                return null;
            }
        }
    }
}
