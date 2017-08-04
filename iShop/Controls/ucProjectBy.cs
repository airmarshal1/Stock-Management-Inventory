using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShop.Controls
{
    public partial class ucProjectBy : MetroFramework.Controls.MetroUserControl
    {
        public ucProjectBy()
        {
            InitializeComponent();
            showTitles();
        }

        private void showTitles()
        {
            lblFullname.Text = "Sunday Amadu Peter";
            lblState.Text = "Plateau";
            lblPhone.Text = "+2347069153892";
            lblEmail.Text = "petersundayamadu@gmail.com";
            lblProjectTopic.Text = "DESIGN & IMPLEMENT STOCK INVENTORY & SALES IN SUPERMARKET";
            lblAddress.Text = "Mangu Plateau State,Nigeria.";
            lblMatricNo.Text = "fcep/dp/sc/01/2010/3670";
            lblDept.Text = "Computer Science  ";
        }
    }
}
