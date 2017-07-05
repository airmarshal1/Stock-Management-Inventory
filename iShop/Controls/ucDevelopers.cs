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
    public partial class ucDevelopers : MetroFramework.Controls.MetroUserControl
    {
        public ucDevelopers()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            var i = new clsDevelopers().GetAllDevelopers();
            foreach(var a in i.ToList())
            {
                ListViewItem x = new ListViewItem(a.FName.ToString());
                x.SubItems.Add(a.LName.ToString());
                x.SubItems.Add(a.Gender.ToString());
                x.SubItems.Add(a.Tel.ToString());
                x.SubItems.Add(a.Email.ToString());
                x.SubItems.Add(a.CState.ToString());
                x.SubItems.Add(a.Speciality.ToString());
                x.SubItems.Add(a.Hobbies.ToString());
                x.SubItems.Add(a.Remarks.ToString());
                x.SubItems.Add(a.CAddress.ToString());

                listView1.Items.Add(x);
            }
        }
    }
}
