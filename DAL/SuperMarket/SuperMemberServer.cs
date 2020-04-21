using IDAL.SuperMarket;
using Moder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SuperMarket
{
    public class SuperMemberServer : ISuperMemberServer
    {
        public SMMembers AddMember(SMMembers member)
        {
            string procName = "AddMember";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@MemberName",member.MemberName),
                new SqlParameter("@PhoneNumber",member.PhoneNumber),
                new SqlParameter("@MemberAddress",member.MemberAddress)
            };
            object res = SQLHelper.ExecuteScalar(procName, sp);
            if (res!=null)
            {
                member.Memberid = Convert.ToInt32(res);
            }
            else
            {
                member = null;
            }
            return member;
        }

        public SMMembers GetMemberByIdOrPhone(string id)
        {
            Cashier.MemberServer server = new Cashier.MemberServer();
            return server.GetMembersById(id);
        }
    }
}
