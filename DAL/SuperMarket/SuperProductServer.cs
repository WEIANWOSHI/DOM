using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.SuperMarket;
using Moder;

namespace DAL.SuperMarket
{
    public class SuperProductServer : ISuperProductServer
    {
        public List<Products> GetAllProduct()
        {
            string procName = "GetAllProduct";
            List<Products> list = new List<Products>();
            SqlDataReader reader = SQLHelper.DataReader(procName, null);
            while (reader.Read())
            {
                list.Add(new Products()
                {
                    Productid = reader["Productid"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    Categoryid = Convert.ToInt32(reader["Categoryid"]),
                    Discount = Convert.ToSingle(reader["Discount"]),
                    Unit = reader["Unit"].ToString(),
                    UnitPrive = Convert.ToDecimal(reader["UnitPrive"])
                });
            }
            reader.Close();
            return list;
        }

        public List<ProductCategory> GetCategories()
        {
            string procName = "GetProductCategory";
            List<ProductCategory> list = new List<ProductCategory>();
            SqlDataReader reader = SQLHelper.DataReader(procName, null);
            while (reader.Read())
            {
                list.Add(new ProductCategory()
                {
                    CategoryId = Convert.ToInt32(reader["Categoryid"]),
                    CategoryName = reader["CategoryName"].ToString()
                });
            }
            reader.Close();
            return list;
        }

        public List<Products> GetProductsWithWhere(int categoryId, string where)
        {
            string procName = "GetProductsByWhere";
            SqlParameter[] sp =
            {
                new SqlParameter("@category",categoryId),
                new SqlParameter("@where",where)
            };
            List<Products> list = new List<Products>();
            SqlDataReader reader = SQLHelper.DataReader(procName, sp);
            while (reader.Read())
            {
                list.Add(new Products()
                {
                    Productid = reader["ProductId"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    Categoryid = Convert.ToInt32(reader["Categoryld"]),
                    Discount = Convert.ToSingle(reader["Discount"]),
                    Unit = reader["Unit"].ToString(),
                    UnitPrive = Convert.ToDecimal(reader["UnitPrice"]),
                    CategoryName = reader["CategoryName"].ToString(),
                    TotalCount = Convert.ToInt32(reader["TotalCount"])
                });
            }
            reader.Close();
            return list;
        }

        public Products GetProductWithId(string pid)
        {
            string procName = "GetProductWithId";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@productId",pid)
            };
            Products produt = null;
            SqlDataReader reader = SQLHelper.DataReader(procName, sp);
            while (reader.Read())
            {
                produt = new Products()
                {
                    Productid = reader["Productid"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    Discount = Convert.ToSingle(reader["Discount"]),
                    Categoryid = Convert.ToInt32(reader["Categoryid"]),
                    CategoryName = reader["CategoryName"].ToString(),
                    Unit = reader["Unit"].ToString(),
                    UnitPrive = Convert.ToDecimal(reader["UnitPrive"])
                };
            }
            reader.Close();
            return produt;
        }

        public List<ProductUnit> GetUnit()
        {
            string procName = "GetProductUnit";
            List<ProductUnit> list = new List<ProductUnit>();
            SqlDataReader reader = SQLHelper.DataReader(procName, null);
            while (reader.Read())
            {
                list.Add(new ProductUnit()
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Unit = reader["Unit"].ToString()
                });
            }
            reader.Close();
            return list;
        }

        public bool InsertProduct(Products produt, ProductInventory inventory)
        {
            List<string> procList = new List<string>()
            {
                "InsertProduct",
                "InsertInventory"
            };

            List<SqlParameter[]> psList = new List<SqlParameter[]>();
            SqlParameter[] prodPs = new SqlParameter[]
            {
                new SqlParameter("@Productid",produt.Productid),
                new SqlParameter("@ProductName",produt.ProductName),
                new SqlParameter("@UnitPrive",produt.UnitPrive),
                new SqlParameter("@Unit",produt.Unit),
                new SqlParameter("@Discount",produt.Discount),
                new SqlParameter("@Categoryid",produt.Categoryid)
            };

            SqlParameter[] inventPs = new SqlParameter[]
            {
                new SqlParameter("@Productid",inventory.ProductId),
                new SqlParameter("@TotalCount",inventory.TotalCount),
                new SqlParameter("@MinCount",inventory.MinCount),
                new SqlParameter("@MaxCount",inventory.MaxCount)
            };
            psList.Add(prodPs);
            psList.Add(inventPs);
            return SQLHelper.UpdateByTran(procList, psList);
        }

        public int InventoryProduct(string pid, int count)
        {
            string procName = "InventoryIn";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Productid",pid),
                new SqlParameter("@Count",count)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }

        public int SetProductDiscount(string pid, float discount)
        {
            string procName = "SetProductDiscount";
            SqlParameter[] sp =
            {
                new SqlParameter("@discount",discount),
                new SqlParameter("@productId",pid)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }

        public int UpdateProduct(Products produts)
        {
            string procName = "SetProductInfor";
            SqlParameter[] sp =
            {
                new SqlParameter("@productName",produts.ProductName),
                new SqlParameter("@unitPrice",produts.UnitPrive),
                new SqlParameter("@categoryId",produts.Categoryid),
                new SqlParameter("@unit",produts.Unit),
                new SqlParameter("@productId",produts.Productid)
            };
            return SQLHelper.ExecuteNonQuery(procName, sp);
        }
    }
}
