using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using iShop.Controls;

namespace iShop
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        private static frmMain _instance;

        bool _logout;

        public static frmMain Instance {
            get {
                if (_instance == null)
                    _instance = new frmMain();
                return _instance;
            }
        }

        public MetroFramework.Controls.MetroPanel MetroContainer
        {
            get
            {
                return this.mPanel;
            }
            set
            {
                this.mPanel = value;
            }
        }

        public MetroFramework.Controls.MetroLink MetroBack
        {
            get
            {
                return this.mBack;
            }
            set
            {
                this.mBack = value;
            }
        }


        public frmMain()
        {
            try
            {
                Thread th = new Thread(new ThreadStart(loadSplashScreen));
                th.Start();
                InitializeComponent();
                lblDateTime.Text = string.Format("Copyright @ JINGBREEDS & GreatMinds Tech, {0}", DateTime.Now.Year.ToString());
                for (int i = 0; i <= 1000; i++)
                    Thread.Sleep(22);
                th.Abort();//finish loading thread
                loadLogin();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        void loadSplashScreen()
        {
            frmSplashScreen f = new frmSplashScreen();
            Application.Run(f);
        }

        void loadLogin()
        {
            try
            {
                mBack.Visible = false;
                _instance = this;
                ucLogin x = new ucLogin();
                x.Dock = DockStyle.Fill;
                mPanel.Controls.Add(x); 
            }
            catch (Exception)
            {
                throw;
            }           
        }

        private void mBack_Click(object sender, EventArgs e)
        {
            mPanel.Controls["ucDashboard"].BringToFront();
            mBack.Visible = false;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if ((MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to Exit the Application?", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Question)) == DialogResult.OK)
            {
                _logout = true;
                Application.Exit();
            }
           
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult iExit;
            iExit = MetroFramework.MetroMessageBox.Show(this, "Confirm you want to Exit the System?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                
            }
        }
    }
}
