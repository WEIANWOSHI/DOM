using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Moder;
using BLL.SuperMarket;
using IBLL.SuperMarket;
using Common;

namespace BackstageManagementOfSupermarket.AdminFrm
{
    public partial class FrmUpdateAdmin : Form
    {
        public FrmUpdateAdmin(SysAdmins admins)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            lblLogId.Text = admins.LoginId.ToString();
            this.Text = $"修改【{admins.AdminName}】信息";
            txtAdmName.Text = admins.AdminName;
            txtAdmPwd.Text = admins.LoginPwd;
            cmbAdminRole.SelectedIndex = admins.RoleId - 1;
            CurrentAdmin = admins;
            txtAdmName.Focus();
            txtAdmName.GotFocus += TxtAdmName_GotFocus;
            txtAdmPwd.GotFocus += TxtAdmName_GotFocus;
        }

        private void TxtAdmName_GotFocus(object sender, EventArgs e)
        {
            textbox1 text = sender as textbox1;
            //选定文本框的内容
            text.SelectAll();
        }
        IAdminManager adminManager = new AdminManager();
        public SysAdmins CurrentAdmin { get; set; }
        /// <summary>
        /// 确认修改
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
                CurrentAdmin.AdminName = txtAdmName.Text.Trim();
                CurrentAdmin.LoginPwd = txtAdmPwd.Text.Trim();
                CurrentAdmin.RoleId = cmbAdminRole.SelectedIndex + 1;
                CurrentAdmin = adminManager.UpdateAdmin(CurrentAdmin);
                if (CurrentAdmin == null)
                {
                    MessageBox.Show("修改失败！", "提示");
                }
                else
                {
                    MessageBox.Show("修改成功！", "提示");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        /// <summary>
        /// 取消修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
