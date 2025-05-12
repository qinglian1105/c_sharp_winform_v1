using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WinformDemoV01
{
    public partial class UserControlAuth : UserControl
    {
        public string fontName = "微軟正黑體";
        
        public UserControlAuth()
        {
            InitializeComponent();
        }

        private void UserControlAuth_Load(object sender, EventArgs e)
        {            
            this.Size = new System.Drawing.Size(834, 672);
            this.BackColor = SystemColors.InactiveBorder;

            label1.Text = "> Auth";
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

            comboBox1.Items.Add(new { Key = 1, Value = "Create" });
            comboBox1.Items.Add(new { Key = 2, Value = "Update" });
            comboBox1.Items.Add(new { Key = 3, Value = "Delete" });
            comboBox1.DisplayMember = "Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            label4.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            label4.Font = new Font(fontName, 8, FontStyle.Bold);
            label4.ForeColor = System.Drawing.Color.Blue;

            ApiHelper apihelper = new ApiHelper();
            JArray AllUsers = apihelper.GetAllUsers();

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(fontName, 9, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font(fontName, 9);
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           
            JObject firstObj = (JObject)AllUsers[0];
            var keys = firstObj.Properties().Select(p => p.Name).ToList();

            foreach (var key in keys)
            {
                dataGridView1.Columns.Add(key, key);  
            }
            
            foreach (JObject obj in AllUsers)
            {
                var row = keys.Select(k => (obj[k] != null ? obj[k].ToString() : "")).ToArray();
                dataGridView1.Rows.Add(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "Choose an Action";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label5.Text = "";            
        }

        private int ParseOrDefault(string input)
        {
            return int.TryParse(input, out int value) ? value : 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            object ChooseItem = comboBox1.SelectedItem;
            object ChooseAction = comboBox1.GetItemText(ChooseItem);
            var user_id = ParseOrDefault(textBox1.Text);

            ApiHelper apihelper = new ApiHelper();
            JObject results = apihelper.ReviseUser(ChooseAction.ToString(), user_id, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            label5.Text = results["msg"].ToString();

        }
    }
}
