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
    public partial class FrmSale : Form
    {
        public FrmSale()
        {
            InitializeComponent();
            //不能自动创建dataGridView1的列
            dataGridView1.AutoGenerateColumns = false;
            //调用数据库中营业员的所有数据
            InitializeSale();
            //封装器在当前绑定项更改时发生
            source.CurrentChanged += Source_CurrentChanged;
        }

        private void Source_CurrentChanged(object sender, EventArgs e)
        {
            //获取列表中的当前项
            Person = source.Current as SalesPerson;
        }

        IAdminManager adminManager = new AdminManager();
        public SalesPerson Person { get; set; }
        //营业员类泛型
        List<SalesPerson> list = null;
        //封装器
        BindingSource source = new BindingSource();
        private void InitializeSale()
        {
            //从数据库中获取营业员的全部内容，并显示在窗口中
            list = adminManager.GetSales();
            //用封装器装数据（可以防止修改添加及时更改）
            source.DataSource = list;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSysAdm_Click(object sender, EventArgs e)
        {
            FrmAddSale addSale = new FrmAddSale();
            addSale.ShowDialog();
            InitializeSale();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateSysAdm_Click(object sender, EventArgs e)
        {
            FrmUpdateSale updateSale = new FrmUpdateSale(Person);
            if (updateSale.ShowDialog() == DialogResult.OK)
            {
                //调用数据库中营业员的所有数据,并刷新
                InitializeSale();
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
