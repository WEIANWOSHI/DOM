﻿using Moder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL.Cashier
{
    public interface IMemberManager
    {
        SMMembers GetMembersById(string id);
    }
}
