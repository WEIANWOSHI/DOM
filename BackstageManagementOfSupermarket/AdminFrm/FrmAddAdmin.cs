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

namespace BackstageManagementOfSupermarket.AdminFrm
{
    public partial class FrmAddAdmin : Form
    {
        public FrmAddAdmin()
        {
            InitializeComponent();
            txtAdmName.Focus();
            //下拉框Combox获取指定索引位置为0
            cmbAdminRole.SelectedIndex = 0;
            //密码获取焦点时触发
            txtAdmPwd.GotFocus += TxtAdmPwd_GotFocus;
        }
        IAdminManager adminManager = new AdminManager();
        private void TxtAdmPwd_GotFocus(object sender, EventArgs e)
        {
            txtAdmPwd.SelectAll();
        }

        /// <summary>
        /// 添加用户
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
                //通过管理者类获取窗口文本框
                SysAdmins admin = new SysAdmins()
                {
                    //管理者名字
                    AdminName = txtAdmName.Text.Trim(),
                    //管理员状态；当前状态1启0禁
                    AdminStatus = 1,
                    //管理者名字
                    LoginPwd = txtAdmPwd.Text.Trim(),
                    //角色类型1超级2一般
                    RoleId = cmbAdminRole.SelectedIndex + 1
                };
                //窗口中的值写入到数据库里面（添加管理者）,从新赋值在admin（SysAdminsModel）类里面，如果没拿到数据则admin（SysAdminsModel）为空
                admin = adminManager.InsertAdmin(admin);
                //如果SysAdminsModel类里面为空，则没拿数据库中返回的数据
                if (admin == null)
                {
                    MessageBox.Show("用户添加失败！", "提示");
                    return;
                }
                else
                {
                    //管理者添加成功
                    if (MessageBox.Show($"添加成功！登录账号为【{admin.LoginId}】\r\n是否继续添加", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //清空所有数据
                        txtAdmName.Text = "";
                        txtAdmPwd.Text = "123456";
                        cmbAdminRole.SelectedIndex = 0;
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
        /// <summary>
        /// 取消添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
