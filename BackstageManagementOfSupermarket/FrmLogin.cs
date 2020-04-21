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
using Common;

namespace BackstageManagementOfSupermarket
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        IAdminManager adminManager = new AdminManager();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLoginId.CheckData(@"^\d+$", "账号输入有误！") * txtLoginPwd.CheckNullOrEmpty() != 0)
            {
                SysAdmins sys = new SysAdmins()
                {
                    LoginId = Convert.ToInt32(txtLoginId.Text.Trim()),
                    LoginPwd = txtLoginPwd.Text.Trim()
                };

                try
                {
                    sys = adminManager.AdminLogin(sys);
                    LogHelper.Info($"账号[{sys.LoginId}]开始登录");
                    if (sys != null)
                    {
                        if (sys.AdminStatus == 1)
                        {
                            LogHelper.Info($"[{sys.LoginId}]登录成功！");
                            Program.CurrentAdmin = sys;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            LogHelper.Info($"[{sys.LoginId}]账号被禁用");
                            MessageBox.Show("当前管理员账号已被禁用！", "登录提示");
                        }
                    }
                    else
                    {
                        LogHelper.Info($"[{sys.LoginId}]账号或密码错误登录失败");
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error($"[{sys.LoginId}]登录发生异常", ex);
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
