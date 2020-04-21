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
    public class SuperLoginLogsServer : ISuperLoginLogsServer
    {
        public List<LoginLogs> GetLoginLog()
        {
            string proName = "GetLoginLogs";
            SqlDataReader reader = SQLHelper.DataReader(proName,null);
            List<LoginLogs> list = new List<LoginLogs>();
            while (reader.Read())
            {
                LoginLogs logs = new LoginLogs();
                logs.Logid = Convert.ToInt32(reader["Logid"]);
                if (string.IsNullOrEmpty(reader["ExitTime"].ToString()))
                {
                    logs.ExitTime = null;
                }
                else
                {
                    logs.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                }
                logs.Loginid = Convert.ToInt32(reader["Loginid"]);
                logs.SPName = reader["SPName"].ToString();
                logs.ServerName = reader["ServerName"].ToString();
                logs.LoginTime = Convert.ToDateTime(reader["LoginTime"]);
                list.Add(logs);
            }
            reader.Close();
            return list;
        }

        public List<LoginLogs> GetLoginLogBy(DateTime starttime, DateTime endTime, string wheres,int check)
        {
            string procName = "GetLoginLogBy";
            SqlParameter[] sp =
            {
                new SqlParameter("@StarTime",starttime),
                new SqlParameter("@endTime",endTime),
                new SqlParameter("@where",wheres),
                new SqlParameter("@check",check)
            };
            SqlDataReader reader = SQLHelper.DataReader(procName, sp);
            List<LoginLogs> list = new List<LoginLogs>();
            while (reader.Read())
            {
                LoginLogs logs = new LoginLogs();
                logs.Logid = Convert.ToInt32(reader["Logid"]);
                if (string.IsNullOrEmpty(reader["ExitTime"].ToString()))
                {
                    logs.ExitTime = null;
                }
                else
                {
                    logs.ExitTime = Convert.ToDateTime(reader["ExitTime"]);
                }
                logs.Loginid = Convert.ToInt32(reader["Loginid"]);
                logs.SPName = reader["SPName"].ToString();
                logs.ServerName = reader["ServerName"].ToString();
                logs.LoginTime = Convert.ToDateTime(reader["LoginTime"]);
                list.Add(logs);
            }
            reader.Close();
            return list;
        }
    }
}
