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
    public partial class textbox : TextBox
    {
        public textbox()
        {
            InitializeComponent();
        }

        public textbox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public bool CheckNullOrEmpty()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                errorProvider1.SetError(this, "必填项不能为空！");
                return true;
            }
            else
            {
                errorProvider1.SetError(this, string.Empty);
                return false;
            }
        }
        public int CheckData(string pattern, string msg)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (!regex.IsMatch(this.Text))
            {
                this.errorProvider1.SetError(this, msg);
                return 0;
            }
            else
            {
                this.errorProvider1.SetError(this, string.Empty);
                return 1;
            }
        }
    }
}
