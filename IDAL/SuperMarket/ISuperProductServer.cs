using Moder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.SuperMarket
{
    public interface ISuperProductServer
    {
        List<ProductCategory> GetCategories();
        List<ProductUnit> GetUnit();
        bool InsertProduct(Products produt, ProductInventory inventory);

        List<Products> GetAllProduct();

        Products GetProductWithId(string pid);

        int InventoryProduct(string pid, int count);
        List<Products> GetProductsWithWhere(int categoryId, string where);
        int SetProductDiscount(string pid, float discount);
        int UpdateProduct(Products produts);
    }
}
