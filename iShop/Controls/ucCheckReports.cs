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

namespace iShop.Controls
{
    public partial class ucCheckReports : MetroFramework.Controls.MetroUserControl
    {
        public ucCheckReports()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            var i = clsReports.GetAllReports();
            dataGridView1.DataSource = i.ToList();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar == (char)13)
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
