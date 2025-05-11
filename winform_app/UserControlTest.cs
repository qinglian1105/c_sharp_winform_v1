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
    public partial class UserControlTest : UserControl
    {
        public string fontName = "微軟正黑體";
        public UserControlTest()
        {
            InitializeComponent();
        }

        private void UserControlTest_Load(object sender, EventArgs e)
        {            
            this.Size = new System.Drawing.Size(834, 672);
            this.BackColor = SystemColors.InactiveBorder;

            label1.Text = "> Test";
            label1.Font = new Font(fontName, 12, FontStyle.Bold);
            label1.Location = new Point(17, 15);
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            label2.Text = "          " + GlobalFunc.Instance.storeUsername;
            label2.Font = new Font(fontName, 12, FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.Blue;
            label2.Location = new Point(713, 20);
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Image = Image.FromFile(Application.StartupPath + "\\images\\user.png");
            label2.ImageAlign = ContentAlignment.MiddleLeft;
        }
    }
}
