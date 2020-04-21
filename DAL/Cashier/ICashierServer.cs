using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Moder;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Cashier
{
    /// <summary>
    /// 处理营业员管理
    /// </summary>
    public class ICashierServer : IDAL.Cashier.SaleServer
    {
        public SalesPerson SaleLogin(SalesPerson person)
        {
            string procName = "SaleLogIn";
            SqlParameter[] sp =
            {
                new SqlParameter("@LoginId",SqlDbType.Int),
                new SqlParameter("@LoginPwd",SqlDbType.NVarChar,50)
            };
            sp[0].Value = person.SalesPersonid;
            sp[1].Value = person.LoginPwd;
            SqlDataReader reader = SQLHelper.DataReader(procName,sp);
            SalesPerson sales = null;
            while (reader.Read())
            {
                sales = new SalesPerson()
                {
                    LoginPwd = reader["LoginPwd"].ToString(),
                    SPName = reader["SPName"].ToString(),
                    SalesPersonid = int.Parse(reader["SalesPersonid"].ToString())
                };
            }
            reader.Close();
            return sales;
        }

        public int WriteSalesExitLog(int Logid)
        {
            String procName = "ExitSysWriteLog";
            SqlParameter[] sp =
            {
                new SqlParameter("@LogId",SqlDbType.Int)
            };
            sp[0].Value = Logid;
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }

        public int WriteSalesLog(LoginLogs logs)
        {
            String procName = "WriteLog";
            SqlParameter[] sp =
            {
                new SqlParameter("@Loginid",SqlDbType.Int),
                new SqlParameter("@SPName",SqlDbType.NVarChar,50),
                new SqlParameter("@ServerName",SqlDbType.NVarChar,50),
            };
            sp[0].Value = logs.Loginid;
            sp[1].Value = logs.SPName;
            sp[2].Value = logs.ServerName;
            object res = SQLHelper.ExecuteScalar(procName,sp);
            if (res==null)
            {
                return -1;
            }
            return int.Parse(res.ToString());
        }
        public DateTime GetSysTime()
        {
            String procName = "GetSysTime";
            return Convert.ToDateTime(SQLHelper.ExecuteScalar(procName,null));
        }
    }
}
