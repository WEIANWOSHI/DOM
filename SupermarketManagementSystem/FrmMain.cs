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
using Moder;
using Common;
using System.Drawing.Printing;

namespace SupermarketManagementSystem
{
    public partial class FrmMain : Form
    {
        IBLL.Cashier.SaleManager SaleManager = new BLL.Cashier.ICashierManager();
        IBLL.Cashier.ProductManager ProductManager = new BLL.Cashier.ProductManager();
        //购物车商品列表
        List<Products> Productslist = new List<Products>();
        //用来调解数据源和容器之间的数据变换关系，缓冲作用
        BindingSource bs = new BindingSource();
        public FrmMain()
        {
            InitializeComponent();
            this.FormClosing += FrmMain_FormClosing;
            toollblName.Text = $"收银员【{Program.Sale.SPName}】";
            dgvProductList.AutoGenerateColumns = false;
            //随机生成一个流水账号
            txtSerialNum .Text= CreateSeriaNum();
            txtProductId.KeyDown += TxtProductId_KeyDown;
            txtProductId.GotFocus += TxtProductId_GotFocus;
            txtProductId.LostFocus += TxtProductId_LostFocus;
            txtDiscount.GotFocus += TxtProductId_GotFocus;
            txtQuantity.GotFocus += TxtProductId_GotFocus;
            txtUnitPrice.GotFocus += TxtProductId_GotFocus;
            txtDiscount.LostFocus += TxtProductId_LostFocus;
            txtQuantity.LostFocus += TxtProductId_LostFocus;
            txtUnitPrice.LostFocus += TxtProductId_LostFocus;
        }

        private void TxtProductId_LostFocus(object sender, EventArgs e)
        {
            textbox1 text = sender as textbox1;
            text.BackColor = Color.White;
        }

        private void TxtProductId_GotFocus(object sender, EventArgs e)
        {
            textbox1 text = sender as textbox1;
            text.BackColor = Color.Cyan;
            text.SelectAll();
        }

        /// <summary>
        /// 焦点位于控件上时的按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtProductId_KeyDown(object sender, KeyEventArgs e)
        {
            //退出系统按键//查询商品编号对应商品
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("是否确认关闭系统", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            //商品添加
            else if (e.KeyCode == Keys.Enter)
            {
                BindProduct();
            }
            //向上移动
            else if (e.KeyCode == Keys.Up)
            {
                if (dgvProductList.RowCount == 0 || dgvProductList.RowCount == 1)
                {
                    return;
                }
                bs.MovePrevious();
            }
            //向下移动
            else if (e.KeyCode == Keys.Down)
            {
                if (dgvProductList.RowCount == 0 || dgvProductList.RowCount == 1)
                {
                    return;
                }
                bs.MoveNext();
            }
            //移除数据
            else if (e.KeyCode == Keys.Delete)
            {
                if (dgvProductList.RowCount == 0)
                {
                    return;
                }
                bs.RemoveCurrent();
                //刷新数据表
                dgvProductList.DataSource = null;
                //更新序号
                dgvProductList.DataSource = bs;
            }
            //F1键结算
            else if (e.KeyCode == Keys.F1)
            {
                if (dgvProductList.RowCount == 0)
                {
                    return;
                }
                else
                {
                    Balance();
                }
            }
        }
        /// <summary>
        /// 结算封装
        /// </summary>
        private void Balance()
        {
            FrmBalance frm = new FrmBalance(txtPay.Text);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                //放弃支付
                if (frm.Tag.ToString() == "Esc")
                {
                    RestForm();
                }
            }
            else
            {
                SMMembers members = null;
                //输入会员卡号
                if (frm.Tag.ToString().Contains("&"))
                {
                    string[] info = frm.Tag.ToString().Split('&');
                    txtAmount.Text = info[0];
                    members = new SMMembers()
                    {
                        Memberid = Convert.ToInt32(info[1]),
                        Points = (int)(Convert.ToDouble(txtPay.Text) / 10.0)
                    };
                }
                else
                {
                    txtAmount.Text = frm.Tag.ToString();
                }
                //找零
                txtChange.Text = (Convert.ToDecimal(txtAmount.Text) - Convert.ToDecimal(txtPay.Text)).ToString();
                //创建消费对象
                SalesList saleObj = new SalesList()
                {
                    SerialNum = txtSerialNum.Text,
                    TotalMoney = Convert.ToDecimal(txtPay.Text.Trim()),
                    RealReceive = Convert.ToDecimal(txtAmount.Text.Trim()),
                    ReturnMoney = Convert.ToDecimal(txtChange.Text.Trim()),
                    SalesPersonId = Program.Sale.SalesPersonid
                };
                //消费明细列表
                foreach (Products item in Productslist)
                {
                    saleObj.ListDetail.Add(
                        new SalesListDetail()
                        {
                            SerialNum = txtSerialNum.Text,
                            ProductId = item.Productid,
                            ProductName = item.ProductName,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrive,
                            Discount = item.Discount,
                            SubTotalMoney = item.SubTotal
                        }
                    );
                }
                try
                {
                    ProductManager.SaveSalerInfo(saleObj, members);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"保存销售数据的时候发生异常！{ex.Message}", "异常提示");
                    return;
                }
                printDocument1.Print();
                PrintPriview();
                RestForm();
            }
        }

        private void PrintPriview()
        {
            try
            {
                var printPriview = new PrintPreviewDialog
                {
                    Document = printDocument1,
                    WindowState = FormWindowState.Maximized
                };
                printPriview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印错误，请检查打印设置！");
            }
        }

        /// <summary>
        /// 支付完成重置界面
        /// </summary>
        void RestForm()
        {
            txtSerialNum.Text = CreateSeriaNum();
            dgvProductList.DataSource = null;
            Productslist.Clear();
            txtPay.Text = "0.00";
            txtProductId.Focus();
        }

        /// <summary>
        /// 商品添加
        /// </summary>
        private void BindProduct()
        {
            txtProductId.Text = txtProductId.Text.Replace("\r\n", "");
            if (txtProductId.CheckData(@"^[1-9]\d*$", "商品编号为10-15纯数字") != 0)
            {
                //检查购物车中是否有哦重复商品，如有则加数量
                var product = from p in Productslist
                              where p.Productid.Equals(txtProductId.Text.Trim())
                              select p;
                //未找到该商品则进行重新添加
                if (product.Count() == 0)
                {
                    AddNewProductToList();
                }
                //更新数量与小计
                else
                {
                    Products pro = product.FirstOrDefault();
                    pro.Quantity += Convert.ToInt32(txtQuantity.Text.Trim());
                    pro.SubTotal = pro.Quantity * pro.UnitPrive;
                    if (pro.Discount != 0)
                    {
                        pro.SubTotal *= (Convert.ToDecimal(pro.Discount) / 10);
                    }
                }
                //商品录入刷新界面
                bs.DataSource = Productslist;
                dgvProductList.DataSource = null;
                dgvProductList.DataSource = bs;
                txtPay.Text = (from p in Productslist select p.SubTotal).Sum().ToString();
                //清空相关信息
                txtProductId.Text = "";
                txtQuantity.Text = "1";
                txtDiscount.Text = "0";
                txtUnitPrice.Text = "0.00";
                txtAmount.Text = "0.00";
                txtChange.Text = "0.00";
                txtProductId.Focus();
            }
            else
            {
                MessageBox.Show("商品编号为10-15纯数字", "操作");
            }
        }

        /// <summary>
        /// 根据商品编号查询商品，添加商品到购物车列表
        /// </summary>
        /// <param name="product"></param>
        private void AddNewProductToList()
        {
            //根据商品编号查询
            Products obgProduct = ProductManager.GetProductWithId(txtProductId.Text.Trim());
            if (obgProduct==null)
            {
                //如为临时商品录入
                obgProduct = new Products()
                {
                    ProductName = "暂未提供商品名称",
                    Productid = txtProductId.Text.Trim(),
                    UnitPrive = Convert.ToDecimal(txtUnitPrice.Text.Trim()),
                    Discount = Convert.ToDouble(txtDiscount.Text.Trim())
                };
            }
            else
            {
                txtUnitPrice.Text = obgProduct.UnitPrive.ToString();
                txtDiscount.Text = obgProduct.Discount.ToString();
            }
            //根据商品的数量折扣计算小计金额
            obgProduct.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
            obgProduct.SubTotal = obgProduct.Quantity * obgProduct.UnitPrive;
            //检查这个商品是否计算折扣价
            if (obgProduct.Discount!=0)
            {
                obgProduct.SubTotal *= (Convert.ToDecimal(obgProduct.Discount) / 10);
            }
            //商品列表序号
            obgProduct.ProductNo = Productslist.Count + 1;
            Productslist.Add(obgProduct);
            //最新商品为选中项
            bs.MoveLast();
        }

        /// <summary>
        /// 生成流水账号
        /// </summary>
        private string CreateSeriaNum()
        {
            string selialNum = SaleManager.GetSysTime().ToString("yyyyMMddHHmmssms");
            Random random = new Random();
            selialNum += random.Next(10,99).ToString();
            return selialNum;
        }
        /// <summary>
        /// 主程序关闭时记录关闭时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaleManager.WriteSalesExitLog(Program.Sale.Logid);
        }
        /// <summary>
        /// 更新系统时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            toollblTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        /// <summary>
        /// 其他文本框功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Other_KeyDown(object sender, KeyEventArgs e)
        {
            textbox1 text = sender as textbox1;
            if (e.KeyCode== Keys.Enter)
            {
                if (text.Tag.ToString() == "quantity")
                {
                    if (text.CheckData(@"^[1-9]\d*$", "数量为整数") != 0)
                    {
                        BindProduct();
                    }
                    else
                    {
                        MessageBox.Show("数量为整数", "提示");
                    }
                    text.Text = "1";
                }
                else if (text.Tag.ToString() == "unitprice")
                {
                    if (text.CheckData(@"^(([1-9]\d*)|(\d*.\d{0,2}))$","价钱输入有误") !=0)
                    {
                        if (text.Text.Contains(".") & text.Text.IndexOf('.') == text.Text.Length - 1)
                        {
                            text.Text += "0";
                        }
                        decimal money = Convert.ToDecimal(text.Text.Trim());
                        text.Text = money.ToString("F2");
                        BindProduct();
                    }
                    else
                    {
                        MessageBox.Show("单价为数字","提示");
                    }
                    text.Text = "0.00";
                }
                else
                {
                    if (text.CheckData(@"^((\d)|(\d.\d))$", "折扣输入有误") != 0)
                    {
                        BindProduct();
                    }
                    else
                    {
                        MessageBox.Show("折扣输入有误", "提示");
                    }
                    text.Text = "0";
                }
                txtProductId.Focus();
            }
        }
        /// <summary>
        /// 移除一行更新序号，更新总金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProductList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            decimal money = (from p in Productslist select p.SubTotal).Sum();
            txtPay.Text = money == 0 ? "0.00" : money.ToString();
            for (int i = 0; i < Productslist.Count; i++)
            {
                Productslist[i].ProductNo = i + 1;
            }
        }
        /// <summary>
        /// 打印小票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            USBPrint.Print(e, Productslist, txtSerialNum.Text.Trim(), toollblName.Text.Trim());
        }
    }
}
