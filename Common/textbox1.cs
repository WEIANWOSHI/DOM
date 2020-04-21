using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Common
{
    public partial class textbox1 : TextBox
    {
        public textbox1()
        {
            InitializeComponent();
        }

        public textbox1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public int CheckNullOrEmpty()
        {
            Text.Replace("\r\n", "");
            if (string.IsNullOrEmpty(this.Text))
            {
                this.errorProvider1.SetError(this, "必填项不能为空！");
                return 0;
            }
            else
            {
                errorProvider1.SetError(this, string.Empty);
                return 1;
            }
        }

        public int CheckData(string pattern, string msg)
        {
            if (CheckNullOrEmpty() == 0)
            {
                return 0;
            }
            Regex regex = new Regex(pattern);
            this.Text.Replace("\r\n", "");
            if (regex.IsMatch(this.Text))
            {
                errorProvider1.SetError(this, string.Empty);
                return 1;
            }
            else
            {
                errorProvider1.SetError(this, msg);
                return 0;
            }
        }
        public void SetError(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                errorProvider1.SetError(this, msg);
                return;
            }
        }
    }
}
