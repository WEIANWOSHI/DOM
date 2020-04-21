using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IBLL.SuperMarket;
using BLL.SuperMarket;

namespace BackstageManagementOfSupermarket
{
    public partial class FrmUpdatePwd : Form
    {
        public FrmUpdatePwd()
        {
            InitializeComponent();
        }
        IAdminManager manager = new AdminManager();
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtOldPwd.CheckNullOrEmpty() * txtNewPwd.CheckNullOrEmpty() * txtRePwd.CheckNullOrEmpty() != 0)
            {
                if (txtNewPwd.CheckData(@"^\S[6,12]$", "密码至少为6位！") != 0)
                {
                    if (txtOldPwd.Text.Trim().Equals(Program.CurrentAdmin.LoginPwd))
                    {
                        txtOldPwd.SetError(string.Empty);

                        //重复密码和新密码一致可以进行修改密码
                        if (txtNewPwd.Text.Trim().Equals(txtRePwd.Text.Trim()))
                        {
                            Program.CurrentAdmin.LoginPwd = txtNewPwd.Text.Trim();
                            if (manager.AdminUpdatePwd(Program.CurrentAdmin))
                            {
                                MessageBox.Show("密码修改成功！请重新登录", "提示");
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                                Application.Restart();
                            }
                            else
                            {
                                MessageBox.Show("密码修改失败！请稍后重试", "提示");
                            }
                        }
                        else
                        {
                            txtRePwd.SetError("重复密码和新密码输入不一致！");
                        }
                    }
                    else
                    {
                        txtOldPwd.SetError("原密码错误！");
                    }
                }
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
