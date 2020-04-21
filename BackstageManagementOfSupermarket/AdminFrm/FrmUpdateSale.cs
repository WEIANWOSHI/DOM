using Moder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.SuperMarket;
using IBLL.SuperMarket;

namespace BackstageManagementOfSupermarket.AdminFrm
{
    public partial class FrmUpdateSale : Form
    {
        public FrmUpdateSale(SalesPerson person)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Sales = person;
            txtAdmName.Text = person.SPName;
            txtAdmPwd.Text = person.LoginPwd;
        }
        IAdminManager adminManager = new AdminManager();
        public SalesPerson Sales { get; set; }
        /// <summary>
        /// 确认修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtAdmName.CheckNullOrEmpty() * txtAdmPwd.CheckData(@"^\w{6,}$", "密码必须为6位字母、数字、下划线组合") != 0)
            {
                Sales.SPName = txtAdmName.Text.Trim();
                Sales.LoginPwd = txtAdmPwd.Text.Trim();
                //修改营业员的方法
                if (adminManager.UpdateSales(Sales) != null)
                {
                    MessageBox.Show("修改成功！", "提示");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败！", "提示");
                }
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
