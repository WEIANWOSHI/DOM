using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moder;
using IBLL.SuperMarket;
using IDAL.SuperMarket;
using DAL.SuperMarket;

namespace BLL.SuperMarket
{
    public class SuperMemberManager : ISuperMemberManager
    {
        ISuperMemberServer memberServer = new SuperMemberServer();
        public SMMembers AddMember(SMMembers member)
        {
            return memberServer.AddMember(member);
        }

        public SMMembers GetMemberByIdOrPhone(string id)
        {
            return memberServer.GetMemberByIdOrPhone(id);
        }
    }
}
