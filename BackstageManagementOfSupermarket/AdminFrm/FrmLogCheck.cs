using Common;
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

namespace BackstageManagementOfSupermarket.AdminFrm
{
    public partial class FrmLogCheck : Form
    {
        SuperLoginLogsManager logsManager = new iSuperLoginLogsManager();
        public FrmLogCheck()
        {
            InitializeComponent();
            starttime.Focus();
            txtwhere.GotFocus += Txtwhere_GotFocus;
            txtwhere.LostFocus += Txtwhere_LostFocus;
            loglist = logsManager.GetLoginLog();
            InitializePager();
        }
        List<LoginLogs> loglist = null;
        List<LoginLogs> currentPagelist = null;
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitializePager()
        {
            if (loglist==null)
            {
                MessageBox.Show("暂无任何登录信息!");
                return;
            }
            else
            {
                pageNav.RecordCount = loglist.Count;
                pageNav.CurrentPage = 1;
                pageNav.SortType = SortType.ASC;
                pageNav.PageSize = 8;
                pageNav.ExceuteSetPageEvent += PageNav_ExceuteSetPageEvent;
                pageNav.FirstSearh();
            }
        }
        BindingSource Source = new BindingSource();
        private void PageNav_ExceuteSetPageEvent(int currentPage)
        {
            if (loglist!=null)
            {
                currentPagelist = loglist.Skip((pageNav.CurrentPage - 1) * pageNav.PageSize).Take(pageNav.PageSize).ToList();
                Source.DataSource = currentPagelist;
                dataGridView1.DataSource = Source;
                pageNav.SetButtonEnable();
            }
        }

        /// <summary>
        /// 失去焦点时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txtwhere_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtwhere.Text))
            {
                txtwhere.Text = "姓名，账号，服务器名称";
                txtwhere.Tag = "1";
                txtwhere.ForeColor = Color.FromArgb(100, 100, 100);
            }
        }
        /// <summary>
        /// 获取焦点时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txtwhere_GotFocus(object sender, EventArgs e)
        {
            txtwhere.SelectAll();
            txtwhere.ForeColor = Color.Black;
        }
        /// <summary>
        /// 取消查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 开始查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncheck_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked==false&&txtwhere.Tag.ToString()=="1")
            {
                loglist = logsManager.GetLoginLog();
                pageNav.RecordCount = loglist.Count;
                pageNav.FirstSearh();
            }
            else
            {
                DateTime start=DateTime.Now;
                DateTime end= DateTime.Now;
                string where = "";
                int check = 0;
                if (checkBox1.Checked==true)
                {
                    check = 1;
                    if (starttime.Value == endtime.Value)
                    {
                        check = 2;
                        start = end = Convert.ToDateTime(starttime.Value.ToShortDateString());
                    }
                    else if (starttime.Value < endtime.Value)
                    {
                        start = Convert.ToDateTime(starttime.Value.ToShortDateString());
                        end = Convert.ToDateTime(endtime.Value.ToShortDateString()).AddDays(1);
                    }
                    else if (starttime.Value > endtime.Value)
                    {
                        check = -1;
                        start = Convert.ToDateTime(starttime.Value.ToShortDateString());
                    }
                    if (txtwhere.Tag.ToString() == "1")
                    {
                        where = "";
                    }
                    else
                    {
                        where = txtwhere.Text.Trim();
                    }
                }
                else
                {
                    check = 0;
                    where = txtwhere.Text.Trim();
                    
                }
                loglist = logsManager.GetLoginLogBy(start,end,where,check);
                pageNav.RecordCount = loglist.Count;
                pageNav.FirstSearh();
            }
        }
        private void txtwhere_TextChanged(object sender, EventArgs e)
        {
            txtwhere.Tag = "0";
        }
    }
}
