using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformDemoV01
{
    public partial class UserControlHome : UserControl
    {
        public UserControlHome()
        {
            InitializeComponent();                                 
        }

        private void labelHomeUser_Click(object sender, EventArgs e)
        {

        }

        private void UserControlHome_Load(object sender, EventArgs e)
        {            
            this.Size = new System.Drawing.Size(834, 672);
            this.BackColor = SystemColors.InactiveBorder;

            label1.Text = "> Home";
            label1.Font = new Font("微軟正黑體",12, FontStyle.Bold);
            label1.Location = new Point(17, 15);
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            label2.Text = "          " + GlobalFunc.Instance.storeUsername;
            label2.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.Blue;
            label2.Location = new Point(713, 20);
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Image = Image.FromFile(Application.StartupPath + "\\images\\user.png");
            label2.ImageAlign = ContentAlignment.MiddleLeft;

            label3.Text = "Hi, very happy to welcome you.\nThis is a simplified platform developed by C#, FastAPI, PostgreSQL...";
            label3.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.Blue;
            label3.Location = new Point(17, 76);
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left;        
        }
    }
}
