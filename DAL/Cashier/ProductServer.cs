using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Moder;

namespace DAL.Cashier
{
    public class ProductServer : IDAL.Cashier.IProductServer
    {
        public Products GetProductWithId(string productId)
        {
            String procName = "GetProductWithId";
            SqlParameter[] sp =
            {
                new SqlParameter("@ProductId",SqlDbType.NVarChar,50)
            };
            sp[0].Value = productId;
            SqlDataReader reader = SQLHelper.DataReader(procName, sp);
            Products product = null;
            while (reader.Read())
            {
                product = new Products()
                {
                    Productid = reader["Productid"].ToString(),
                    ProductName = reader["ProductName"].ToString(),
                    UnitPrive = Convert.ToDecimal(reader["UnitPrive"]),
                    Discount = Convert.ToDouble(reader["Discount"]),
                    Categoryid = Convert.ToInt32(reader["Categoryid"]),
                    CategoryName = reader["CategoryName"].ToString(),
                    Unit = reader["Unit"].ToString()
                };
            }
            reader.Close();
            return product;
        }
        public bool SaveSalerInfo(SalesList sales, SMMembers members)
        {
            List<string> procList = new List<string>();
            List<SqlParameter[]> psList = new List<SqlParameter[]>();
            //给消费主表中添加数据
            procList.Add("AddSalesList");
            SqlParameter[] saleSp = new SqlParameter[] {
                new SqlParameter("@SerialNum", SqlDbType.NVarChar,50),
                new SqlParameter("@TotalMoney", SqlDbType.Decimal),
                new SqlParameter("@RealReceive", SqlDbType.Decimal),
                new SqlParameter("@ReturnMoney", SqlDbType.Decimal),
                new SqlParameter("@SalesPersonid", SqlDbType.Int)
            };
            saleSp[0].Value = sales.SerialNum;
            saleSp[1].Value = sales.TotalMoney;
            saleSp[2].Value = sales.RealReceive;
            saleSp[3].Value = sales.ReturnMoney;
            saleSp[4].Value = sales.SalesPersonId;
            psList.Add(saleSp);
            //给消费明细表中添加每次购物的详细数据
            foreach (SalesListDetail detail in sales.ListDetail)
            {
                procList.Add("AddSalesListDetail");
                SqlParameter[] detailList = new SqlParameter[] {
                  new SqlParameter("@SerialNum", SqlDbType.NVarChar,50),
                  new SqlParameter("@Productid", SqlDbType.NVarChar,50),
                  new SqlParameter("@ProductName", SqlDbType.NVarChar,50),
                  new SqlParameter("@UnitPrice", SqlDbType.Decimal),
                  new SqlParameter("@Discount", SqlDbType.Float),
                  new SqlParameter("@Quantity", SqlDbType.Int),
                  new SqlParameter("@SubTotalMoney", SqlDbType.Decimal)
                };
                detailList[0].Value = detail.SerialNum;
                detailList[1].Value = detail.ProductId;
                detailList[2].Value = detail.ProductName;
                detailList[3].Value = detail.UnitPrice;
                detailList[4].Value = detail.Discount;
                detailList[5].Value = detail.Quantity;
                detailList[6].Value = detail.SubTotalMoney;
                psList.Add(detailList);
                //更新库存数据
                procList.Add("InventoryOut");
                SqlParameter[] inventorySp = new SqlParameter[]
                {
                    new SqlParameter("@Productid", SqlDbType.NVarChar,50),
                    new SqlParameter("@TotalCount", SqlDbType.Int)
                };
                inventorySp[0].Value = detail.ProductId;
                inventorySp[1].Value = detail.Quantity;
                psList.Add(inventorySp);
            }
            //更新会员的积分
            if (members != null)
            {
                procList.Add("RefreshMemberPoint");
                SqlParameter[] memberSp = new SqlParameter[]
                {
                new SqlParameter("@Points", SqlDbType.Int),
                new SqlParameter("@Memberid", SqlDbType.Int)
                };
                memberSp[0].Value = members.Points;
                memberSp[1].Value = members.Memberid;
                psList.Add(memberSp);
            }
            return SQLHelper.UpdateByTran(procList, psList);
        }
    }
}
