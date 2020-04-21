using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL.SuperMarket;
using Moder;
using DAL.SuperMarket;
using IDAL.SuperMarket;

namespace BLL.SuperMarket
{
    public class ProductManager : IProductManager
    {
        ISuperProductServer product = new SuperProductServer();
        public List<Products> GetAllProduct()
        {
            return product.GetAllProduct();
        }

        public List<ProductCategory> GetCategories()
        {
            return product.GetCategories();
        }

        public List<Products> GetProductsWithWhere(int categoryId, string where)
        {
            return product.GetProductsWithWhere(categoryId, where);
        }

        public Products GetProductWithId(string pid)
        {
            return product.GetProductWithId(pid);
        }

        public List<ProductUnit> GetUnit()
        {
            return product.GetUnit();
        }

        public bool InsertProduct(Products produt, ProductInventory inventory)
        {
            return product.InsertProduct(produt, inventory);
        }

        public bool InventoryProduct(string pid, int count)
        {
            if (product.InventoryProduct(pid, count) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetProductDiscount(string pid, float discount)
        {
            if (product.SetProductDiscount(pid, discount) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProduct(Products produts)
        {
            if (product.UpdateProduct(produts) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
