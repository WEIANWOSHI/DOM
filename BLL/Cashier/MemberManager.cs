using Moder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Cashier;
using IBLL.Cashier;
using IDAL.Cashier;
using DAL.Cashier;

namespace BLL.Cashier
{
    public class MemberManager:IMemberManager
    {
        IMemberServer server = new MemberServer();
        public SMMembers GetMembersById(string id)
        {
            return server.GetMembersById(id);
        }
    }
}
