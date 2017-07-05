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
    public partial class ucDashboard : MetroFramework.Controls.MetroUserControl
    {
        public ucDashboard()
        {
            InitializeComponent();
            loadTimeStamp();
            timer1.Start();
        }

        void loadTimeStamp()
        {
            lblDay.Text = string.Format("{0}",DateTime.Now.DayOfWeek.ToString());
            lblDate.Text = string.Format("{0}",DateTime.Now.Day.ToString());
            lblFullDate.Text = string.Format("{0}, {1}",DateTime.Now.ToString("MMMM"),DateTime.Now.Year.ToString());
            lblTime.Text = string.Format("{0}",DateTime.Now.ToShortTimeString().ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadControls();
        }

        private void loadControls()
        {
            if (mtProductTypes.BackColor == System.Drawing.Color.Crimson)
            {
                mtProductTypes.Text = "Types of Products";
                mtProductTypes.BackColor = System.Drawing.Color.Purple;
            }
            else
            {
                mtProductTypes.Text = "Product Types";
                mtProductTypes.BackColor = System.Drawing.Color.Crimson;
                mtProductTypes.Refresh();
            }
            if (mtProducts.BackColor == System.Drawing.Color.Red)
            {
                mtProducts.Text = "Your Products";
                mtProducts.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                mtProducts.Text = "Product";
                mtProducts.BackColor = System.Drawing.Color.Red;
                mtProducts.Refresh();
            }
            if (mtSuppliers.BackColor == System.Drawing.Color.Blue)
            {
                mtSuppliers.Text = "Your Suppliers";
                mtSuppliers.BackColor = System.Drawing.Color.Chocolate;
            }
            else
            {
                mtSuppliers.Text = "Suppliers";
                mtSuppliers.BackColor = System.Drawing.Color.Blue;
                mtSuppliers.Refresh();
            }
            if (mtDebtors.BackColor == System.Drawing.Color.DeepSkyBlue)
            {
                mtDebtors.Text = "People Owing Debts";
                mtDebtors.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                mtDebtors.Text = "Debtors";
                mtDebtors.BackColor = System.Drawing.Color.DeepSkyBlue;
                mtDebtors.Refresh();
            }
            if (mtBilling.BackColor == System.Drawing.Color.DeepPink)
            {
                mtBilling.Text = "Bill Customers";
                mtBilling.BackColor = System.Drawing.Color.Blue;
            }
            else
            {
                mtBilling.Text = "Bill Your Customers";
                mtBilling.BackColor = System.Drawing.Color.DeepPink;
                mtBilling.Refresh();
            }
            if (mtCustomers.BackColor == System.Drawing.Color.DarkMagenta)
            {
                mtCustomers.Text = "Your Customers";
                mtCustomers.BackColor = System.Drawing.Color.DarkOrange;
            }
            else
            {
                mtCustomers.Text = "Customers";
                mtCustomers.BackColor = System.Drawing.Color.DarkMagenta;
                mtCustomers.Refresh();
            }
            if (mtPrintReciept.BackColor == System.Drawing.Color.Teal)
            {
                mtPrintReciept.Text = "Print Transactions";
                mtPrintReciept.BackColor = System.Drawing.Color.DarkCyan;
            }
            else
            {
                mtPrintReciept.Text = "Print Transactions";
                mtPrintReciept.BackColor = System.Drawing.Color.Teal;
                mtPrintReciept.Refresh();
            }
            if (mtTransactions.BackColor == System.Drawing.Color.PaleVioletRed)
            {
                mtTransactions.Text = "Transactions";
                mtTransactions.BackColor = System.Drawing.Color.Crimson;
            }
            else
            {
                mtTransactions.Text = "Your Transactions";
                mtTransactions.BackColor = System.Drawing.Color.PaleVioletRed;
                mtTransactions.Refresh();
            }
        }

        private void masterEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void debtorsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucDebtors"))
            {
                ucDebtors uc = new ucDebtors();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucDebtors"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucProducts"))
            {
                ucProducts uc = new ucProducts();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucProducts"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void companyInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucCompanyInfo"))
            {
                ucCompanyInfo uc = new ucCompanyInfo();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucCompanyInfo"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucCustomers"))
            {
                ucCustomers uc = new ucCustomers();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucCustomers"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void suppliersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucSuppliers"))
            {
                ucSuppliers uc = new ucSuppliers();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucSuppliers"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void productTypesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucProductTypes"))
            {
                ucProductTypes uc = new ucProductTypes();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucProductTypes"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucDevelopers"))
            {
                ucDevelopers uc = new ucDevelopers();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucDevelopers"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void mtProducts_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucProducts"))
            {
                ucProducts uc = new ucProducts();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucProducts"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void mtProductTypes_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucProductTypes"))
            {
                ucProductTypes uc = new ucProductTypes();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucProductTypes"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void mtSuppliers_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucSuppliers"))
            {
                ucSuppliers uc = new ucSuppliers();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucSuppliers"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void mtDebtors_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucDebtors"))
            {
                ucDebtors uc = new ucDebtors();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucDebtors"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void mtCustomers_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucCustomers"))
            {
                ucCustomers uc = new ucCustomers();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucCustomers"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void mtPrintReciept_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucPrintReports"))
            {
                ucPrintReports uc = new ucPrintReports();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucPrintReports"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void mtBilling_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucBilling"))
            {
                ucBilling uc = new ucBilling();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucBilling"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void mtTransactions_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucCheckReports"))
            {
                ucCheckReports uc = new ucCheckReports();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucCheckReports"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }

        private void projectByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!frmMain.Instance.MetroContainer.Controls.ContainsKey("ucProjectBy"))
            {
                ucProjectBy uc = new ucProjectBy();
                uc.Dock = DockStyle.Fill;
                frmMain.Instance.MetroContainer.Controls.Add(uc);
            }
            frmMain.Instance.MetroContainer.Controls["ucProjectBy"].BringToFront();
            frmMain.Instance.MetroBack.Visible = true;
        }
    }
}
