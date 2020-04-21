using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.SuperMarket;
using Moder;

namespace DAL.SuperMarket
{
    public class SuperAdminServer : ISuperAdminServer
    {
        public SysAdmins AdminLogin(SysAdmins admin)
        {
            string procName = "SysAdminLogin";
            SqlParameter[] sp = new SqlParameter[] {
                    new SqlParameter("@logId",admin.LoginId),
                    new SqlParameter("@logPwd",admin.LoginPwd)
            };
            SqlDataReader reader = SQLHelper.DataReader(procName, sp);
            SysAdmins admins = null;
            while (reader.Read())
            {
                admins = new SysAdmins()
                {
                    AdminName = reader["AdminName"].ToString(),
                    LoginId = Convert.ToInt32(reader["LoginId"]),
                    LoginPwd = reader["LoginPwd"].ToString(),
                    RoleId = Convert.ToInt32(reader["RoleId"]),
                    AdminStatus = Convert.ToInt32(reader["AdminStatus"])
                };
            }
            reader.Close();
            return admins;
        }

        public int AdminUpdatePwd(SysAdmins admin)
        {
            string procName = "UpdateSysPwd";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@logId",admin.LoginId),
                new SqlParameter("@logPwd",admin.LoginPwd)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }
        public List<SysAdmins> GetAdmins()
        {
            //GetAllTables可以获取所有表的储存过程
            //获取这种表的存储过程
            string procName = "GetAllTables";
            SqlParameter[] sp =
            {
                //获取数据库中管理者的所有内容
                new SqlParameter("@tableName","SysAdmins")
            };
            SqlDataReader reader = SQLHelper.DataReader(procName, sp);
            List<SysAdmins> list = new List<SysAdmins>();
            while (reader.Read())
            {
                SysAdmins admins = new SysAdmins();
                admins.AdminName = reader["AdminName"].ToString();
                admins.LoginId = Convert.ToInt32(reader["LoginId"]);
                admins.LoginPwd = reader["LoginPwd"].ToString();
                admins.RoleId = Convert.ToInt32(reader["Roleld"]);
                admins.AdminStatus = Convert.ToInt32(reader["AdminStatus"]);
                admins.StatusName = admins.AdminStatus == 1 ? "启用" : "禁用";
                admins.RoleName = admins.RoleId == 1 ? "超级管理员" : "一般管理员";
                list.Add(admins);
            }
            reader.Close();
            return list;
        }

        public List<SalesPerson> GetSales()
        {
            string procName = "GetAllTables";
            SqlParameter[] sp =
            {
                new SqlParameter("@tableName","SelesPerson")
            };
            SqlDataReader reader = SQLHelper.DataReader(procName, sp);
            List<SalesPerson> list = new List<SalesPerson>();
            while (reader.Read())
            {
                SalesPerson admins = new SalesPerson();
                admins.SalesPersonid = Convert.ToInt32(reader["SalesPersonId"]);
                admins.LoginPwd = reader["LoginPwd"].ToString();
                admins.SPName = reader["SPName"].ToString();
                list.Add(admins);
            }
            reader.Close();
            return list;
        }

        public SysAdmins InsertAdmin(SysAdmins admi)
        {
            //添加管理者存储过程
            string procName = "InsertAdmin";
            SqlParameter[] sp =
            {
                new SqlParameter("@adminName",admi.AdminName),
                new SqlParameter("@loginPwd",admi.LoginPwd),
                new SqlParameter("@roleId",admi.RoleId)
            };
            object res = SQLHelper.ExecuteScalar(procName, sp);
            if (res != null)
            {
                admi.LoginId = Convert.ToInt32(res);
            }
            else
            {
                admi = null;
            }
            return admi;
        }

        public SalesPerson InsertSales(SalesPerson person)
        {
            string procName = "InsertSales";
            SqlParameter[] sp ={
                new SqlParameter("@spName",person.SPName),
                new SqlParameter("@loginPwd",person.LoginPwd)
            };
            object res = SQLHelper.ExecuteScalar(procName, sp);
            if (res != null)
            {
                person.SalesPersonid = Convert.ToInt32(res);
            }
            else
            {
                person = null;
            }
            return person;
        }

        public int SetSysStatus(SysAdmins admin)
        {
            string procName = "SetSysAdmStatus";
            SqlParameter[] sp =
            {
                new SqlParameter("@role",admin.AdminStatus),
                new SqlParameter("@id",admin.LoginId)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }

        public int UpdateAdmin(SysAdmins admin)
        {
            //修改管理者存储过程
            string procName = "UpdateAdmin";
            SqlParameter[] sp =
            {
                new SqlParameter("@adminName",admin.AdminName),
                new SqlParameter("@loginPwd",admin.LoginPwd),
                new SqlParameter("@roleId",admin.RoleId),
                new SqlParameter("@loginId",admin.LoginId)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }

        public int UpdateSales(SalesPerson person)
        {
            string procName = "UpdateSaleInfor";
            SqlParameter[] sp =
            {
                new SqlParameter("@saleName",person.SPName),
                new SqlParameter("@loginPwd",person.LoginPwd),
                new SqlParameter("@loginId",person.SalesPersonid)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }
    }
}
