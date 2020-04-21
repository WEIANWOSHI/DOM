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
using BLL;
using IBLL;
using System.Net;

namespace SupermarketManagementSystem
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }
        IBLL.Cashier.SaleManager manager = new BLL.Cashier.ICashierManager();
        private void btnLog_Click(object sender, EventArgs e)
        {
            //文本框验证为纯数字
            if (tetLogId.CheckData(@"^[1-9]\d*$","账号格式为纯数字！")*tetLogPwd.CheckNullOrEmpty()!=0)
            {
                //将登录账号和密码封装成收银员对象
                SalesPerson person = new SalesPerson()
                {
                    SalesPersonid = int.Parse(tetLogId.Text),
                    LoginPwd = tetLogPwd.Text.Trim()
                };
                //在数据库中将对账户和密码，如果登陆成功则将登陆对象保存到全局，并且保存到系统日志
                SalesPerson res = manager.SaleLogin(person);
                if (manager.SaleLogin(person)!=null)
                {
                    Program.Sale = res;
                    int Logid = manager.WriteSaleLog(new LoginLogs() { 
                    Loginid=res.SalesPersonid,
                    SPName=res.SPName,
                    ServerName=Dns.GetHostName()
                    });
                    Program.Sale.Logid = Logid;
                    this.DialogResult = DialogResult.OK;
                    Log4net.WriteInfo((string.Format("" + res + "")));
                    this.Close();


                }
                else
                {
                    Log4net.WriteInfo((string.Format("" + res + "")));
                    MessageBox.Show("账号或密码错误","登陆提示");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
