using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moder;

namespace IDAL.SuperMarket
{
    public interface ISuperMemberServer
    {
        SMMembers GetMemberByIdOrPhone(string id);
        SMMembers AddMember(SMMembers member);
    }
}
