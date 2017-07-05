using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iShopClass;
using DGVPrinterHelper;

namespace iShop.Controls
{
    public partial class ucPrintReports : MetroFramework.Controls.MetroUserControl
    {
        public ucPrintReports()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            var i = clsReports.GetAllReports();
            dataGridView1.DataSource = i.ToList();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DGVPrinter p = new DGVPrinter();
                p.Title = string.Format("Transaction Report As @{0}",Convert.ToString(DateTime.Now.ToShortTimeString().ToString()));
                p.SubTitle = string.Format("Stock Inventory System Report");
                p.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                p.PageNumbers = true;
                p.PageNumberInHeader = false;
                p.PorportionalColumns = true;
                p.HeaderCellAlignment = StringAlignment.Near;
                p.Footer = "Restricted";
                p.printDocument.DefaultPageSettings.Landscape = true;
                p.PrintDataGridView(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void txtSearch_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    var i = clsReports.search(txtSearch.Text.Trim());
                    dataGridView1.DataSource = i.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
