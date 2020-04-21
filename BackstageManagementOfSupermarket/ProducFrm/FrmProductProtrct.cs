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

namespace BackstageManagementOfSupermarket.ProducFrm
{
    public partial class FrmProductProtrct : Form
    {
        IProductManager productManager = new ProductManager();
        //装商品分类表的数据泛型
        List<ProductCategory> categories = null;
        //装商品表的数据泛型
        List<Products> list = null;
        //封装器：防止删除修改时直接的报错
        BindingSource source = new BindingSource();
        //商品表属性，属性可以返回值
        public Products CurrentProduct { get; set; }
        public FrmProductProtrct()
        {
            InitializeComponent();
            dgvProductList.AutoGenerateColumns = false;
            // List<ProductCategoryModel> categories = null;商品维护信息
            categories = productManager.GetCategories();
            //商品分类后面的combox为toolCmbType的名字，添加内容
            toolCmbType.Items.Add("所有");

            //把categories（商品分类）的内容全部遍历给ProductCategoryModel item（商品分类）里面
            foreach (ProductCategory item in categories)
            {
                //把商品分类的商品类型（名字）给商品分类后面的combox为toolCmbType的名字，添加商品类型名
                //Combox添加内容
                toolCmbType.Items.Add(item.CategoryName);
            }
            //Combox的选定当前的选定项的索引
            toolCmbType.SelectedIndex = 0;
            //从数据库中获取所有商品内容，并把商品Id进行排序,用list接收商品内容
            list = productManager.GetAllProduct();
            //数据库中【商品表】数据的实现和刷新
            InitializeProduct();
            source.CurrentChanged += Source_CurrentChanged;
            toolTxtWhere.TextChanged += ToolTxtWhere_TextChanged;
            //查询的文本框名字toolTxtWhere；GotFocus获取焦点时发生
            toolTxtWhere.GotFocus += ToolTxtWhere_GotFocus;
            //查询的文本框名字toolTxtWhere；LostFocus失去焦点时发生
            toolTxtWhere.LostFocus += ToolTxtWhere_LostFocus;
        }

        private void ToolTxtWhere_LostFocus(object sender, EventArgs e)
        {
            toolTxtWhere.ForeColor = Color.Black;
        }

        private void ToolTxtWhere_GotFocus(object sender, EventArgs e)
        {
            toolTxtWhere.SelectAll();
            //查询文本框toolTxtWhere获取焦点时改变文本框颜色
            toolTxtWhere.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void ToolTxtWhere_TextChanged(object sender, EventArgs e)
        {
            toolTxtWhere.Tag = "1";
        }

        private void Source_CurrentChanged(object sender, EventArgs e)
        {
            CurrentProduct = source.Current as Products;
        }

        private void InitializeProduct()
        {
            source.DataSource = list;
            //dgvProductList是dataGridView1的名字，把dataGridView1的内容清空
            dgvProductList.DataSource = null;
            //给dataGridView1里面添加商品表数据，通过封装器放进去的值
            dgvProductList.DataSource = source;
        }

        /// <summary>
        /// 商品入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnInto_Click(object sender, EventArgs e)
        {
            FrmIntoProduct intoProduct = new FrmIntoProduct();
            intoProduct.ShowDialog();//打开窗口
            //dataGridView1获取商品多表链接数据，刷新多表链接内容
            InitializeProduct();
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnAdd_Click(object sender, EventArgs e)
        {
            FrmAddProduct addProduct = new FrmAddProduct();
            addProduct.ShowDialog();//打开窗口
            //dataGridView1获取商品多表链接数据，刷新多表链接内容
            InitializeProduct();
        }
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnUpdate_Click(object sender, EventArgs e)
        {
            if (list.Count == 0 || CurrentProduct == null)
            {
                MessageBox.Show("请选择要修改的商品！");
                return;
            }
            //修改商品窗口，CurrentProduct的值获取来源是上面的按钮获取到商品中的数据，传递到修改商品窗口中
            FrmUpdateProduct updateProduct = new FrmUpdateProduct(CurrentProduct);
            if (updateProduct.ShowDialog() == DialogResult.OK)
            {
                //用list装商品表的数据泛型获取多表连接的商品表
                list = productManager.GetAllProduct();
                //dataGridView1获取商品多表链接数据，刷新多表链接内容
                InitializeProduct();
            }
        }
        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnDelete_Click(object sender, EventArgs e)
        {
            if (list.Count <= 0)
            {
                return;
            }
            dgvProductList.DataSource = null;
            dgvProductList.DataSource = source;
        }
        /// <summary>
        /// 提交查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnQuery_Click(object sender, EventArgs e)
        {
            var selectIndex = from item in categories where item.CategoryName == toolCmbType.SelectedItem.ToString() select item.CategoryId;
            int index = 0;
            //toolTxtWhere查询文本框内容
            string where = toolTxtWhere.Text.Trim();
            //没有查询文本框内容条件；selectIndex.FirstOrDefault() == 0表示选定的文本框
            if (toolTxtWhere.Tag.ToString() == "0" && selectIndex.FirstOrDefault() == 0)
            {
                //获取多表连接的内容给list存放
                list = productManager.GetAllProduct();
                //dataGridView1获取商品多表链接数据，刷新多表链接内容
                InitializeProduct();
                return;
            }
            //查询文本框的tag==0    and   选定文本框！=0
            else if (toolTxtWhere.Tag.ToString() == "0" && selectIndex.FirstOrDefault() != 0)
            {
                where = "";
                index = selectIndex.FirstOrDefault();
            }
            //查询文本框的tag!=0    and   选定文本框==0   :就是第一个条件不满足，第二个条件满足
            else if (toolTxtWhere.Tag.ToString() != "0" && selectIndex.FirstOrDefault() == 0)
            {
                where = toolTxtWhere.Text.Trim();
                index = 0;
            }
            //查询文本框的tag!=0    and   选定文本框==0   :就是第一个条件不满足，第二个条件不满足
            else if (toolTxtWhere.Tag.ToString() != "0" && selectIndex.FirstOrDefault() != 0)
            {
                where = toolTxtWhere.Text.Trim();
                index = selectIndex.FirstOrDefault();
            }
            //list获取商品的GetProductsWithWhere多表连接的【查询】
            list = productManager.GetProductsWithWhere(index, where);
            //dataGridView1获取商品多表链接数据，刷新多表链接内容
            InitializeProduct();

            toolTxtWhere.Text = "商品编号、商品名称";
            toolCmbType.SelectedIndex = 0;
            toolTxtWhere.Tag = "0";
        }
        /// <summary>
        /// 更新折扣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshDiscount_Click(object sender, EventArgs e)
        {
            if (txtDiscount.CheckData(@"^\d(.\d)?$", "输入有误") != 0)
            {
                if (CurrentProduct != null)
                {
                    //修改折扣：根据商品Id和商品从新更改的折扣，进行折扣修改
                    if (productManager.SetProductDiscount(CurrentProduct.Productid, Convert.ToSingle(txtDiscount.Text.Trim())))
                    {
                        //修改成功后，把修改后的折口，给商品表属性添加可以进行同步修改
                        CurrentProduct.Discount = Convert.ToSingle(txtDiscount.Text.Trim());
                        //dataGridView1获取商品多表链接数据，刷新多表链接内容
                        InitializeProduct();
                        txtDiscount.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("修改商品折扣失败！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请选择要更改折扣的商品！", "提示");
                }
            }
        }
    }
}
