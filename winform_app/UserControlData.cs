using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WinformDemoV01
{
    public partial class UserControlData : UserControl
    {
        public string fontName = "微軟正黑體";
        
        public UserControlData()
        {
            InitializeComponent();
        }

        private void UserControlData_Load(object sender, EventArgs e)
        {            
            this.Size = new System.Drawing.Size(834, 672);
            this.BackColor = SystemColors.InactiveBorder;

            label1.Text = "> Data";
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

            label4.Text = "Table - top etf (latest holding)";
            label4.Font = new Font(fontName, 14, FontStyle.Bold);
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label4.TextAlign = ContentAlignment.MiddleCenter;
        }
               
        private void Button1_Click(object sender, EventArgs e)
        {           
            label3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            label3.Font = new Font(fontName, 8, FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.Blue;            

            ApiHelper apihelper = new ApiHelper();
            JArray HoldingLatestRecords = apihelper.GetHoldingLatestRecords();

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
          
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(fontName, 9, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font(fontName, 8);
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            JObject firstObj = (JObject)HoldingLatestRecords[0];            
            var keys = firstObj.Properties().Select(p => p.Name).ToList();

            foreach (var key in keys)
            {
                dataGridView1.Columns.Add(key, key);  
            }

            foreach (JObject obj in HoldingLatestRecords)
            {
                var row = keys.Select(k => (obj[k] != null ? obj[k].ToString() : "")).ToArray();
                dataGridView1.Rows.Add(row);
            }      
        }
    }
}
