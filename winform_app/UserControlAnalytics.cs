using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinformDemoV01
{
    public partial class UserControlAnalytics : UserControl
    {
        public string fontName = "微軟正黑體";
        
        public UserControlAnalytics()
        {
            InitializeComponent();
        }

        private void UserControlAnalytics_Load(object sender, EventArgs e)
        {            
            this.Size = new System.Drawing.Size(834, 672);
            this.BackColor = SystemColors.InactiveBorder;
            
            label1.Text = "> Analytics";
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
            
            label3.Text = "The Statistics of top ETFs in Taiwan";
            label3.Font = new Font(fontName, 14, FontStyle.Bold);
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            
            showTabIntroduction();

        }
        
        private void CreateTopEtfTable()
        {            
            string[] colNames = new string[] { "Num", "ETF Code", "ETF Name", "Market Value(億)" };
            string[][] topEtfs = new string[8][];
            topEtfs[0] = new string[] { "1", "0050", "元大台灣50", "4,771.13" };
            topEtfs[1] = new string[] { "2", "0056", "元大高股息", "4,021.91" };
            topEtfs[2] = new string[] { "3", "00878", "國泰永續高股息", "3,990.25" };
            topEtfs[3] = new string[] { "4", "00919", "群益台灣精選高息", "3,351.06" };
            topEtfs[4] = new string[] { "5", "006208", "富邦台50", "1,971.34" };
            topEtfs[5] = new string[] { "6", "00929", "復華台灣科技優息", "1,698.09" };
            topEtfs[6] = new string[] { "7", "00713", "元大台灣高息低波", "1,303.84" };
            topEtfs[7] = new string[] { "8", "00940", "元大台灣價值高息", "1,216.02" };
            
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(fontName, 11, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font(fontName, 10);
            dataGridView1.Size = new Size(791, 228);

            dataGridView1.ColumnCount = colNames.Length;
            for (int i = 0; i < colNames.Length; i++)
            {
                dataGridView1.Columns[i].Name = colNames[i];
            }
            
            foreach (string[] rowArray in topEtfs)
            {
                dataGridView1.Rows.Add(rowArray);
            }
        }

        
        private void showTabIntroduction()
        {            
            string topicName = "About this study";
            string text_one = "The main subject of this study is Equity ETFs in Taiwan's capital market, and some of them are Multi-Asset ETF.";
            string text_two = "Besides, the second selection criteria is that asset size of the ETF exceeds NT$100 billion.";
            string text_three = "Therefore, there are 8 ETFs that meet the conditions, and their information is shown in the table below.";
            label4.Text = topicName + "\n\n" + text_one + "\n" + text_two + "\n" + text_three;
            label4.Font = new Font(fontName, 12, FontStyle.Bold);
            label4.ForeColor = System.Drawing.Color.Blue;
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            
            CreateTopEtfTable();
        }


        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabIntroduction)
            {
                tabIntroduction.Show();                               
            } else if (tabControl1.SelectedTab == tabOverview)
            {
                tabOverview.Show();
                
                ApiHelper apihelper = new ApiHelper();
                JArray GetHoldingDates = apihelper.GetHoldingDates();

                for (int i=0; i<GetHoldingDates.Count; i++)
                {
                    comboBox1.Items.Add(new { Key = i
                        , Value = GetHoldingDates[i].ToString()
                    });
                }
                comboBox1.DisplayMember = "Value";                                                             
            }
            else
            {
                tabDistribution.Show();                
            }
        }

        private void LoadDoughnutChart(string ChooseDate)
        {
            ApiHelper apihelper = new ApiHelper();
            JObject jsonObject = apihelper.GetPercentageIndustry(ChooseDate.ToString());
                                    
            List<string> names = jsonObject["names"].ToObject<List<string>>();
            List<int> values = jsonObject["values"].ToObject<List<int>>();
            
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
           
            ChartArea chartArea = new ChartArea("DoughnutArea");
            chart1.ChartAreas.Add(chartArea);
            
            Series doughnutSeries = new Series("IndustryData");
            doughnutSeries.ChartType = SeriesChartType.Doughnut;
            doughnutSeries.ChartArea = "DoughnutArea";
            doughnutSeries.IsValueShownAsLabel = true; 
            doughnutSeries.LabelFormat = "#,##0";    
           
            doughnutSeries["DoughnutRadius"] = "50"; 
            
            for (int i = 0; i < names.Count; i++)
            {
                DataPoint point = new DataPoint();
                point.YValues[0] = values[i];
                point.Label = names[i];
                doughnutSeries.Points.Add(point);
            }
            
            chart1.Series.Add(doughnutSeries);
                                 
            chart1.Legends.Clear();             
          
            chart1.Titles.Clear();
            chart1.Titles.Add("Stock Investment Industry Distribution");
        }


        private void LoadBarChart(string ChooseDate)
        {
            ApiHelper apihelper = new ApiHelper();
            JObject jsonObject = apihelper.GetMvStockInEtfs(ChooseDate.ToString());

            List<string> names = jsonObject["ETF Code"].ToObject<List<string>>();
            List<int> values = jsonObject["Market Value"].ToObject<List<int>>();
           
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
           
            ChartArea chartArea = new ChartArea("BarchartArea");
            chart2.ChartAreas.Add(chartArea);
            
            chartArea.AxisY.Title = "Unit (M)";

            chart2.ChartAreas["BarchartArea"].AxisX.MajorGrid.LineWidth = 0;
            chart2.ChartAreas["BarchartArea"].AxisY.MajorGrid.LineWidth = 0;
           
            Series barSeries = new Series();
            barSeries.ChartType = SeriesChartType.Column;

            Color[] BarColors = { Color.Red, Color.Blue, Color.Green, Color.Orange,
                Color.Purple, Color.Wheat, Color.Brown, Color.Coral};
            
            for (int i = 0; i < names.Count; i++)
            {
                barSeries.Points.AddXY(names[i], values[i]);                                
            }
            
            chart2.Series.Add(barSeries);
           
            chart2.Legends.Clear(); 
           
            chart2.Titles.Clear();
            chart2.Titles.Add("Market Value (Stock) of ETF");           
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            object ChooseItem = comboBox1.SelectedItem;
            object ChooseDate = comboBox1.GetItemText(ChooseItem);
                                   
            ApiHelper apihelper = new ApiHelper();
                       
            JObject GetStockMv = apihelper.GetStockMv(ChooseDate.ToString());                        
            label5.Text = GetStockMv["stock"].ToString();
            label5.ForeColor = Color.Blue;
            label6.Text = GetStockMv["change"].ToString();
            if (label6.Text.Contains("▲"))
            {
                label6.ForeColor = Color.Red;

            } else if (label6.Text.Contains("▼")) {
                label6.ForeColor = Color.Green;
            } else {
                label6.ForeColor = Color.Black;
            }
            
            JObject GetStockCounts = apihelper.GetStockCounts(ChooseDate.ToString());
            label7.Text = GetStockCounts["stock_counts"].ToString();
            label7.ForeColor = Color.Indigo;
            label8.Text = GetStockCounts["change"].ToString();
            if (label8.Text.Contains("▲"))
            {
                label8.ForeColor = Color.Red;

            }
            else if (label8.Text.Contains("▼"))
            {
                label8.ForeColor = Color.Green;
            }
            else
            {
                label8.ForeColor = Color.Black;
            }

            JObject GetBondAmount = apihelper.GetBondAmount(ChooseDate.ToString());
            label9.Text = GetBondAmount["bond"].ToString();
            label9.ForeColor = Color.Orange;
            label10.Text = GetBondAmount["change"].ToString();
            if (label10.Text.Contains("▲"))
            {
                label10.ForeColor = Color.Red;

            }
            else if (label10.Text.Contains("▼"))
            {
                label10.ForeColor = Color.Green;
            }
            else
            {
                label10.ForeColor = Color.Black;
            }

            JObject GetCashAmount = apihelper.GetCashAmount(ChooseDate.ToString());
            label11.Text = GetCashAmount["cash"].ToString();
            label11.ForeColor = Color.DeepSkyBlue;
            label12.Text = GetCashAmount["change"].ToString();
            if (label12.Text.Contains("▲"))
            {
                label12.ForeColor = Color.Red;

            }
            else if (label12.Text.Contains("▼"))
            {
                label12.ForeColor = Color.Green;
            }
            else
            {
                label12.ForeColor = Color.Black;
            }                       
        
            LoadDoughnutChart(ChooseDate.ToString());
           
            LoadBarChart(ChooseDate.ToString());
        }
    }
}
