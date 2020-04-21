using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Moder;

namespace BackstageManagementOfSupermarket
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process[] processList = Process.GetProcesses();
            int currentCount = 0;
            foreach (Process item in processList)
            {
                if (item.ProcessName == Process.GetCurrentProcess().ProcessName)
                {
                    currentCount += 1;
                }
            }
            if (currentCount > 1)
            {
                Application.Exit();
                return;
            }
            FrmLogin frm = new FrmLogin();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                frm.DialogResult = DialogResult.No;
                Application.Run(new FrmMain());
            }
            else
            {
                Application.Exit();
            }
        }
        public static SysAdmins CurrentAdmin { get; set; } = null;
        public static ProductCategory ClockCategory { get; set; } = null;
    }
}
