using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Cashier;
using Common;
using IBLL.Cashier;
using Moder;

namespace BackstageManagementOfSupermarket
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            toollblUser.Text = $"【{Program.CurrentAdmin.AdminName}】";
            //将主窗体设置为MDI容器
            this.IsMdiContainer = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toollblTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaleManager saleManager = new ICashierManager();
            LogHelper.Info($"[{Program.CurrentAdmin.LoginId}]退出程序！");
            saleManager.WriteSalesExitLog(Program.CurrentAdmin.LoginLogId);
        }
        //记录当前开启的功能窗体
        Form currentMDIChild = null;
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath, "restart");
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolMenuUpdatePwd_Click(object sender, EventArgs e)
        {
            FrmUpdatePwd pwd = new FrmUpdatePwd();
            DialogResult Restart = pwd.ShowDialog();
            //密码修改成功，意味着需要重新登录
            if (Restart == DialogResult.OK)
            {
                LogHelper.Info($"[{Program.CurrentAdmin.LoginId}]成功修改密码");

                this.Close();
            }
        }
        /// <summary>
        /// 负责开启功能窗体
        /// </summary>
        /// <param name="mdiForm"></param>
        void ShowMDIChild(Form mdiForm)
        {
            if (currentMDIChild != null)
            {
                currentMDIChild.Close();
            }
            currentMDIChild = mdiForm;
            mdiForm.MdiParent = this;
            mdiForm.Parent = panel1;
            mdiForm.Left = panel1.Width / 2 - mdiForm.Width / 2;
            mdiForm.Top = panel1.Height / 2 - mdiForm.Height / 2;
            mdiForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            mdiForm.Show();
        }
       /// <summary>
       /// 营业管理员
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void toolyiny_Click(object sender, EventArgs e)
        {
            AdminFrm.FrmAdmin admin = new AdminFrm.FrmAdmin();
            ShowMDIChild(admin);
        }
        /// <summary>
        /// 系统管理员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolxit_Click(object sender, EventArgs e)
        {
            if (Program.CurrentAdmin.RoleId == 1)
            {
                AdminFrm.FrmAdmin admin = new AdminFrm.FrmAdmin();
                ShowMDIChild(admin);
            }
            else
            {
                MessageBox.Show("您无权限操作该功能！", "提示");
            }
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            FrmAddProduct addProduct = new FrmAddProduct();
            addProduct.FormClosed += AddProduct_FormClosed;
            ShowMDIChild(addProduct);
        }
        Products currentProduct = null;
        /// <summary>
        /// 商品入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmAddProduct frmAdd = sender as FrmAddProduct;
            if (frmAdd.DialogResult == DialogResult.OK)
            {
                currentProduct = frmAdd.Tag as Products;
                frmAdd.DialogResult = DialogResult.Cancel;
                btnIntoProduct_Click(frmAdd, null);
            }
        }

        private void btnIntoProduct_Click(FrmAddProduct frmAdd, object p)
        {
            FrmIntoProduct intoProduct = new FrmIntoProduct();
            if (currentProduct != null)
            {
                intoProduct.txtProductId.Text = currentProduct.Productid;
                intoProduct.txtProductName.Text = currentProduct.ProductName;
            }
            ShowMDIChild(intoProduct);
            currentProduct = null;
        }
        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMember_Click(object sender, EventArgs e)
        {
            FrmAddMember addMember = new FrmAddMember();
            ShowMDIChild(addMember);
        }
        /// <summary>
        /// 日志查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckLog_Click(object sender, EventArgs e)
        {
            AdminFrm.FrmLogCheck logCheck = new AdminFrm.FrmLogCheck();
            ShowMDIChild(logCheck);
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            ProducFrm.FrmProductProtrct productProtrct = new ProducFrm.FrmProductProtrct();
            //调用负责开启功能窗体
            ShowMDIChild(productProtrct);
        }
    }
}
