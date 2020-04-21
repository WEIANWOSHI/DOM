using Moder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL.Cashier
{
    public interface ProductManager
    {
        Products GetProductWithId(string productId);
        bool SaveSalerInfo(SalesList sales, SMMembers members);
    }
}
