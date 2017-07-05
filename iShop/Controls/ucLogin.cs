using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iShop.Controls;

namespace iShop
{
    public partial class ucLogin : MetroFramework.Controls.MetroUserControl
    {
        public ucLogin()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Please Enter Your Username", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Please Enter Your Password", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        if (txtUsername.Text.Trim() == "admin" && txtPassword.Text.Trim() == "admin")
                        {
                            ucDashboard x = new ucDashboard();
                            x.Dock = DockStyle.Fill;
                            frmMain.Instance.MetroContainer.Controls.Add(x);
                            frmMain.Instance.MetroContainer.Controls["ucDashboard"].BringToFront();
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
