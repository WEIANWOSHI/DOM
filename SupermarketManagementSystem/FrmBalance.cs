using Common;
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
using IBLL;
using BLL;

namespace SupermarketManagementSystem
{
    public partial class FrmBalance : Form
    {
        IBLL.Cashier.IMemberManager memberManager = new BLL.Cashier.MemberManager();
        public FrmBalance(string totalMoney)
        {
            InitializeComponent();
            txtPay.Text = totalMoney;
            this.StartPosition = FormStartPosition.CenterScreen;
            txtVip.GotFocus += TxtVip_GotFocus;
            txtVip.LostFocus += TxtVip_LostFocus;
        }

        private void TxtVip_LostFocus(object sender, EventArgs e)
        {
            textbox1 txt = sender as textbox1;
            txt.BackColor = Color.White;
            if (txtAmount.Text.Contains(".") && txtAmount.Text.IndexOf(".") == txtAmount.Text.Length)
            {
                txtAmount.Text += "00";
            }
            else if (!txtAmount.Text.Contains("."))
            {
                txtAmount.Text += ".00";
            }
            txtAmount.Text = Convert.ToDecimal(txtAmount.Text).ToString("F2");
        }

        private void TxtVip_GotFocus(object sender, EventArgs e)
        {
            textbox1 txt = sender as textbox1;
            txt.BackColor = Color.Cyan;
            txt.SelectAll();
        }
        private void txtVip_KeyDown(object sender, KeyEventArgs e)
        {
            txtAmount.Text = txtAmount.Text.Replace("\r\n", "");
            txtVip.Text = txtVip.Text.Replace("\r\n", "");
            if (e.KeyCode == Keys.F1)
            {
                radMoney.Checked = true;
            }
            else if (e.KeyCode == Keys.F2)
            {
                radCard.Checked = true;
            }
            else if (e.KeyCode == Keys.F3)
            {
                radQRCode.Checked = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (txtAmount.CheckData(@"^(([1-9]\d*)|(\d*.\d{0,2}))$", "输入金额有误") != 0)
                {
                    if (txtAmount.Text.Contains(".") && txtAmount.Text.IndexOf(".") == txtAmount.Text.Length)
                    {
                        txtAmount.Text += "00";
                    }
                    else if (!txtAmount.Text.Contains("."))
                    {
                        txtAmount.Text += ".00";
                    }
                    txtAmount.Text = Convert.ToDecimal(txtAmount.Text).ToString("F2");
                    if (txtVip.Text.Length == 0)
                    {
                        this.Tag = txtAmount.Text.Trim();
                    }
                    else
                    {
                        if (txtVip.CheckData(@"^[1-9]\d*$", "会员卡号或手机号有误") != 0)
                        {
                            SMMembers members = memberManager.GetMembersById(int.Parse(txtVip.Text.Trim()));
                            if (members != null)
                            {
                                if (members.MemberStatus==1)
                                {
                                    this.Tag = $"{txtAmount.Text.Trim()}&{txtVip.Text.Trim()}";
                                }
                                else
                                {
                                    if (members.MemberStatus == 0)
                                    {
                                        MessageBox.Show($"会员【{txtVip.Text.Trim()}】账号被冻结，请联系管理员","提示");
                                    }
                                    else
                                    {
                                        MessageBox.Show($"会员【{txtVip.Text.Trim()}】账号被注销！", "提示");
                                    }
                                    txtVip.Text = "";
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show($"会员【{txtVip.Text.Trim()}】不存在，请检查账号！","提示");
                                txtVip.Text = "";
                                return;
                            }
                        }
                        else
                        {
                            this.Tag = txtAmount.Text.Trim();
                        }
                    }
                    if (Convert.ToDecimal(txtPay.Text) <= Convert.ToDecimal(txtAmount.Text))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("客户实际付款金额不足！", "注意");
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "Esc";
                this.Close();
            }
            else if (e.KeyCode == Keys.Tab)
            {

                textbox1 txt = sender as textbox1;
                if (txt.Tag.ToString() == "vip")
                {
                    txtAmount.Focus();
                }
                else if (txt.Tag.ToString() == "pay")
                {
                    txtVip.Focus();
                }
            }
        }
    }
}
