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
using IBLL.SuperMarket;
using BLL.SuperMarket;

namespace BackstageManagementOfSupermarket.AdminFrm
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            InitializeUser();
            //在当前绑定项更改时发生
            //source封装器
            source.CurrentChanged += Source_CurrentChanged;
        }

        private void Source_CurrentChanged(object sender, EventArgs e)
        {
            //获取列表中的当前项
            currentAdm = source.Current as SysAdmins;
        }

        IAdminManager adminManager = new AdminManager();
        //管理者的泛型储存
        List<SysAdmins> adminList = null;
        //source封装器
        BindingSource source = new BindingSource();
        SysAdmins currentAdm = null;
        private void InitializeUser()
        {
            adminList = adminManager.GetAdmins();
            source.DataSource = adminList;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSys_Click(object sender, EventArgs e)
        {
            FrmAddAdmin addAdmin = new FrmAddAdmin();
            addAdmin.ShowDialog();
            //调用管理者和营业员的表显示：相当于刷新dataGridView1里面的数据
            InitializeUser();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0 || currentAdm == null)
            {
                MessageBox.Show("请选择要修改的用户！");
                return;
            }
            //管理者的修改
            FrmUpdateAdmin updateAdmin = new FrmUpdateAdmin(currentAdm);
            if (updateAdmin.ShowDialog() == DialogResult.OK)
            {
                //调用管理者和营业员的表显示：相当于刷新dataGridView1里面的数据
                InitializeUser();
            }
        }
        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0 && currentAdm == null && currentAdm.RoleId == 1)
            {
                return;
            }
            //管理者当前状态1启0禁
            currentAdm.AdminStatus = 0;
            //在禁用状态时，进入数据库改成禁用状态
            if (adminManager.SetSysStatus(currentAdm))
            {
                //调用管理者和营业员的表显示：相当于刷新dataGridView1里面的数据
                InitializeUser();
            }
        }
        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0 && currentAdm == null && currentAdm.RoleId == 1)
            {
                return;
            }
            //管理者当前状态1启0禁
            currentAdm.AdminStatus = 1;
            //在禁用状态时，进入数据库改成禁用状态
            if (adminManager.SetSysStatus(currentAdm))
            {
                //调用管理者和营业员的表显示：相当于刷新dataGridView1里面的数据
                InitializeUser();
            }
        }
    }
}
