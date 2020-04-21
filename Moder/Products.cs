using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moder
{
    [Serializable]
    public class Products
    {
        public string Productid { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrive { get; set; }
        public double Discount { get; set; }
        public int Categoryid { get; set; }
        public string Unit { get; set; }
        public int TotalCount { get; set; }
        //扩展属性
        public int ProductNo { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public string CategoryName { get; set; }
    }
}
