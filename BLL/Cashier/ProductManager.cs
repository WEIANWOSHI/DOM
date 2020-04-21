using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using IBLL.Cashier;
using Moder;
using DAL.Cashier;
using IDAL.Cashier;

namespace BLL.Cashier
{
    public class ProductManager:IBLL.Cashier.ProductManager
    {
        IProductServer server = new ProductServer();

        public bool SaveSalerInfo(SalesList sales, SMMembers members)
        {
            return server.SaveSalerInfo(sales, members);
        }

        Products IBLL.Cashier.ProductManager.GetProductWithId(string productId)
        {
            return server.GetProductWithId(productId);
        }
    }
}
