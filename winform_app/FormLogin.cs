using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinformDemoV01
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();            
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {                                  
            ApiHelper apihelper = new ApiHelper();
            JObject validateResult = apihelper.ValidateUser(textBoxAccount.Text, textBoxPassword.Text);
     
            if (validateResult["is_validated"].ToString()=="true")
            {                
                GlobalFunc.Instance.storeUsername = textBoxAccount.Text;
                GlobalFunc.Instance.storePassword = textBoxPassword.Text;
                GlobalFunc.Instance.storeAuthority = validateResult["authority"].ToString();
                                
                FormIndex home = new FormIndex();
                home.Show();                
                GlobalFunc.Instance.formLogin.Hide();
            }
            else
            {
                string MsgText = "Sorry, incorrect Account or Password...\n\n" + "Please retry.";
                string MsgCapton = "Information";
                MessageBox.Show(MsgText, MsgCapton, MessageBoxButtons.OK, MessageBoxIcon.Information);                                
                textBoxAccount.Text = "";
                textBoxPassword.Text = "";
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
