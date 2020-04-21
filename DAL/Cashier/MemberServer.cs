using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moder;

namespace DAL.Cashier
{
    public class MemberServer : IDAL.Cashier.IMemberServer
    {
        public SMMembers GetMembersById(string id)
        {
            string procName = "GetMembersById";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Memberid", System.Data.SqlDbType.Int),
                new SqlParameter("@PhoneNumber", System.Data.SqlDbType.NVarChar,50)
            };
            if (id.Length==11)
            {
                sp[0].Value = -1;
                sp[1].Value = id;
            }
            else
            {
                sp[0].Value = id;
                sp[1].Value = "";
            }
            SMMembers members = null;
            SqlDataReader reader = SQLHelper.DataReader(procName, sp);
            while (reader.Read())
            {
                members = new SMMembers()
                {
                    Memberid = Convert.ToInt32(reader["Memberid"]),
                    MemberAddress = reader["MemberAddress"].ToString(),
                    MemberName = reader["MemberName"].ToString(),
                    MemberStatus = Convert.ToInt32(reader["MemberStatus"]),
                    OpenTime = Convert.ToDateTime(reader["OpenTime"]),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Points = Convert.ToInt32(reader["Points"])
                };
            }
            reader.Close();
            return members;
        }
    }
}
