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
    public partial class FrmAddSale : Form
    {
        public FrmAddSale()
        {
            InitializeComponent();
            txtAdmPwd.GotFocus += TxtAdmPwd_GotFocus;
        }
        IAdminManager adminManager = new AdminManager();
        private void TxtAdmPwd_GotFocus(object sender, EventArgs e)
        {
            txtAdmPwd.SelectAll();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtAdmName.CheckNullOrEmpty() * txtAdmPwd.CheckData(@"^\w{6,}$", "密码必须为6位字母、数字、下划线组合") == 0)
            {
                return;
            }
            else
            {
                SalesPerson person = new SalesPerson()
                {
                    LoginPwd = txtAdmPwd.Text.Trim(),
                    SPName = txtAdmName.Text.Trim()
                };
                //添加营业员的方法
                person = adminManager.InsertSales(person);
                if (person == null)
                {
                    MessageBox.Show("添加营业员失败！", "提示");
                }
                else
                {
                    if (MessageBox.Show($"添加营业员成功！\r\n编号：【{person.SalesPersonid}】\r\n是否继续添加", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtAdmName.Text = "";
                        txtAdmPwd.Text = "123456";
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
