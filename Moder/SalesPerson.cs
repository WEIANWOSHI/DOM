using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moder
{
    [Serializable]
    public class SalesPerson
    {
        /// <summary>
        /// 销售员id
        /// </summary>
        public int SalesPersonid { get; set; }
        /// <summary>
        /// 销售员名
        /// </summary>
        public string SPName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string LoginPwd { get; set; }
        public int Logid { get; set; }
    }
}
