using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformDemoV01
{
    public partial class FormIndex : Form
    {                                
        public UserControlHome home;        
        public UserControlAnalytics analytics;
        public UserControlData data;        
        public UserControlAuth auth;
        public UserControlTest test;
        
        public FormIndex()
        {
            InitializeComponent();          
        }

        private bool isMenuCollapsed = false;
        private int menuExpandedWidth = 200; 
        private int menuCollapsedWidth = 50;         
        private int buttonHeight = 38;  

        private void sideMenuClosed()
        {            
            panelSideMenu.Width = menuCollapsedWidth;
            panelContent.Left = menuCollapsedWidth;
            panelContent.Width = this.ClientSize.Width - menuCollapsedWidth;
            isMenuCollapsed = true;

            btnHome.Size = new System.Drawing.Size(menuCollapsedWidth, buttonHeight);
            btnHome.ImageAlign = ContentAlignment.MiddleCenter;
            btnAnalytics.Size = new System.Drawing.Size(menuCollapsedWidth, buttonHeight);
            btnAnalytics.ImageAlign = ContentAlignment.MiddleCenter;
            btnData.Size = new System.Drawing.Size(menuCollapsedWidth, buttonHeight);
            btnData.ImageAlign = ContentAlignment.MiddleCenter;
            btnAuth.Size = new System.Drawing.Size(menuCollapsedWidth, buttonHeight);
            btnAuth.ImageAlign = ContentAlignment.MiddleCenter;
            btnTest.Size = new System.Drawing.Size(menuCollapsedWidth, buttonHeight);
            btnTest.ImageAlign = ContentAlignment.MiddleCenter;
            btnLogout.Size = new System.Drawing.Size(menuCollapsedWidth, buttonHeight);
            btnLogout.ImageAlign = ContentAlignment.MiddleCenter;

            btnMenuToggle.Size = new System.Drawing.Size(menuCollapsedWidth, buttonHeight);
            btnMenuToggle.ImageAlign = ContentAlignment.MiddleCenter;
        }

        private void sideMenuOpened()
        {            
            panelSideMenu.Width = menuExpandedWidth;
            panelContent.Left = menuExpandedWidth;
            panelContent.Width = this.ClientSize.Width - menuExpandedWidth;
            isMenuCollapsed = false;
           
            btnHome.Size = new System.Drawing.Size(menuExpandedWidth, buttonHeight);
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnalytics.Size = new System.Drawing.Size(menuExpandedWidth, buttonHeight);
            btnAnalytics.ImageAlign = ContentAlignment.MiddleLeft;
            btnData.Size = new System.Drawing.Size(menuExpandedWidth, buttonHeight);
            btnData.ImageAlign = ContentAlignment.MiddleLeft;
            btnAuth.Size = new System.Drawing.Size(menuExpandedWidth, buttonHeight);
            btnAuth.ImageAlign = ContentAlignment.MiddleLeft;
            btnTest.Size = new System.Drawing.Size(menuExpandedWidth, buttonHeight);
            btnTest.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Size = new System.Drawing.Size(menuExpandedWidth, buttonHeight);
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;

            btnMenuToggle.Size = new System.Drawing.Size(menuExpandedWidth, buttonHeight);
            btnMenuToggle.ImageAlign = ContentAlignment.MiddleLeft;
        }
                

        private void btnMenuToggle_Click(object sender, EventArgs e)
        {
            if (isMenuCollapsed)
            {               
                sideMenuOpened();
            }
            else
            {
                sideMenuClosed();
            }

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            home.Show();           
            panelContent.Controls.Clear();
            panelContent.Controls.Add(home);                   
        }


        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            analytics.Show();
            panelContent.Controls.Clear();
            panelContent.Controls.Add(analytics);

        }

        private void btnData_Click(object sender, EventArgs e)
        {
            data.Show();
            panelContent.Controls.Clear();
            panelContent.Controls.Add(data);
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            auth.Show();
            panelContent.Controls.Clear();
            panelContent.Controls.Add(auth);
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            test.Show();
            panelContent.Controls.Clear();
            panelContent.Controls.Add(test);
        }
        
        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }            
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormHome_Load(object sender, EventArgs e)
        {            
            home = new UserControlHome();
            analytics = new UserControlAnalytics();
            data = new UserControlData();
            auth = new UserControlAuth();
            test = new UserControlTest();
            home.Dock = DockStyle.Fill;
            analytics.Dock = DockStyle.Fill;
            data.Dock = DockStyle.Fill;
            auth.Dock = DockStyle.Fill;
            test.Dock = DockStyle.Fill;

            sideMenuClosed();
            
            label1.Text = "Hi, "+ GlobalFunc.Instance.storeUsername +".\n\nWelcome to Platform.\nPlease click upper left button to view menu.";
            label1.Font = new Font("微軟正黑體", 12, FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new Point(22, 32);
        }
        
    }
}