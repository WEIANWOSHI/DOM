using Moder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL.SuperMarket
{
    public interface IProductManager
    {
        List<ProductCategory> GetCategories();
        List<ProductUnit> GetUnit();

        bool InsertProduct(Products produt, ProductInventory inventory);
        List<Products> GetAllProduct();

        Products GetProductWithId(string pid);
        bool InventoryProduct(string pid, int count);
        List<Products> GetProductsWithWhere(int categoryId, string where);
        bool SetProductDiscount(string pid, float discount);
        bool UpdateProduct(Products produts);
    }
}
