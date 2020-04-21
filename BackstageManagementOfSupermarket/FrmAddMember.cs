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
using IBLL.SuperMarket;
using BLL.SuperMarket;

namespace BackstageManagementOfSupermarket
{
    public partial class FrmAddMember : Form
    {
        public FrmAddMember()
        {
            InitializeComponent();
            txtMemberName.Focus();
        }
        ISuperMemberManager memberManager = new SuperMemberManager();
        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtMemberName.CheckNullOrEmpty()*txtMemArr.CheckData(@"^1\d{10}$","手机号格式有误1")!=0)
            {
                if (memberManager.GetMemberByIdOrPhone(txtMemArr.Text.Trim())!=null)
                {
                    MessageBox.Show("该手机号已经被注册！");
                    return;
                }
                SMMembers member = new SMMembers()
                {
                    MemberName = txtMemberName.Text.Trim(),
                    PhoneNumber = txtMemArr.Text.Trim(),
                    MemberAddress = string.IsNullOrEmpty(txtAddress.Text.Trim()) ? "地址不详" : txtAddress.Text.Trim()
                };
                member = memberManager.AddMember(member);
                if (member != null)
                {
                    if (MessageBox.Show($"注册成功！会员账号是【{member.Memberid}】\r\n是否继续注册？", "提示", MessageBoxButtons.YesNo)==DialogResult.Yes) 
                    {
                        txtMemArr.Text = "";
                        txtMemberName.Text = "";
                        txtAddress.Text = "";
                        txtMemberName.Focus();
                    };
                }
                else
                {
                    MessageBox.Show("注册失败请稍后再试！");
                }
            }
        }
        /// <summary>
        /// 取消注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
