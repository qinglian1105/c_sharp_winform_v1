using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformDemoV01
{
    internal static class Program
    {        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            FormLogin formLogin = new FormLogin();

            GlobalFunc.Instance.formLogin = formLogin;
            Application.Run(formLogin);
        }
    }
}
