using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShop
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        public frmLogin()
        {
            InitializeComponent();
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
                        if (txtUsername.Text.Trim() == "admin77" && txtPassword.Text.Trim() == "7admin7")
                        {
                            ucDashboard x = new ucDashboard();
                            x.Dock = DockStyle.Fill;
                            frmMain.Instance.MetroContainer.Controls.Add(x);
                            frmMain.Instance.MetroContainer.Controls["ucDashboard"].BringToFront();
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
