using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Common
{
    public enum SortType
    {
        DESC,
        ASC
    }
    public delegate void PagerQueryDelegate(int currentPage);
    public partial class PageNavigator : UserControl
    {
        public event PagerQueryDelegate ExceuteSetPageEvent;
        public PageNavigator()
        {
            InitializeComponent();
            //初始化控件
            FristBtn.Enabled = false;
            LastBtn.Enabled = false;
            NextBtn.Enabled = false;
            ReturnBtn.Enabled = false;
            UpBtn.Enabled = false;
        }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPage { get; set; } = 1;
        /// <summary>
        /// 查询分页的储存过程
        /// </summary>
        public string ProcName { get; set; }
        /// <summary>
        /// 排序查询
        /// </summary>
        public SortType SortType { get; set; } = SortType.ASC;
        /// <summary>
        /// 总数据条数
        /// </summary>
        public int RecordCount { get; set; }
        /// <summary>
        /// 每页的数量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 分页的表名
        /// </summary>
        public string TableName { get; set; }
        public int PageCount
        {
            get
            {
                if (RecordCount % PageSize == 0)
                {
                    return RecordCount / PageSize;
                }
                else
                {
                    return (RecordCount / PageSize) + 1;
                }
            }
        }
        void ShowInfor()
        {
            PageNum.Text = CurrentPage.ToString();
            lblpagecount.Text = PageCount.ToString();
        }
        /// <summary>
        /// 设置按钮的状态
        /// </summary>
        public void SetButtonEnable()
        {
            {
                ShowInfor();
                //如果总页数小于等于1
                if (PageCount <= 1)
                {
                    FristBtn.Enabled = false;
                    LastBtn.Enabled = false;
                    NextBtn.Enabled = false;
                    ReturnBtn.Enabled = false;
                    UpBtn.Enabled = false;
                    return;
                }
                //如果总页数大于1
                FristBtn.Enabled = true;
                LastBtn.Enabled = true;
                NextBtn.Enabled = true;
                ReturnBtn.Enabled = true;
                UpBtn.Enabled = true;
                //如果当前页数等于1或者等于总页数
                if (CurrentPage == 1)
                {
                    FristBtn.Enabled = false;
                    UpBtn.Enabled = false;
                }
                else if (CurrentPage == PageCount)
                {
                    LastBtn.Enabled = false;
                    NextBtn.Enabled = false;
                }
            }
        }
        SqlParameter[] GetParameters()
        {
            return new SqlParameter[]
            {
                new SqlParameter("@pageCount",PageSize),
                new SqlParameter("@pageInder",CurrentPage),
                new SqlParameter("@sortType",SortType)
            };
        }
        public void FirstSearh()
        {
            CurrentPage = 1;
            ExceuteSetPageEvent(CurrentPage);
        }

        private void FristBtn_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            ExceuteSetPageEvent(CurrentPage);
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            CurrentPage --;
            ExceuteSetPageEvent(CurrentPage);
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            ExceuteSetPageEvent(CurrentPage);
        }

        private void LastBtn_Click(object sender, EventArgs e)
        {
            CurrentPage = PageCount;
            ExceuteSetPageEvent(CurrentPage);
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            string input = txtNum.Text.Trim();
            if (input.Length >= 1)
            {
                if (txtNum.CheckData(@"^\d*$", "请输入有效数字！")==0)
                {
                    MessageBox.Show("请输入有效数字！", "提示");
                    txtNum.Text = "";
                    return;
                }
                else
                {
                    int pageIndex = Convert.ToInt32(input);
                    if (pageIndex > PageCount)
                    {
                        MessageBox.Show($"最大页数不能超出{PageCount}", "提示");
                        return;
                    }
                    else
                    {
                        CurrentPage = pageIndex;
                        ExceuteSetPageEvent(CurrentPage);
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}
