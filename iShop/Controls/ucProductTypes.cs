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
    public partial class ucProductTypes : MetroFramework.Controls.MetroUserControl
    {
        public ucProductTypes()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            txtProductType.Focus();
            DataTable dt = (DataTable)new clsPartTypes().GetAllPartTypes_DataTable();
            dataGridView1.Rows.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = Convert.ToInt32(dr["ID"].ToString());
                dataGridView1.Rows[n].Cells[1].Value = dr["Tag"].ToString();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtProductType.Focus();
            ResetTextboxes();
        }

        void ResetTextboxes()
        {
            Action<Control.ControlCollection> func = null;
            func = (x) => {
                foreach (Control c in x)
                    if (c is TextBox)
                        (c as TextBox).Text = "";
                    else
                        func(c.Controls);
            };
            func(Controls);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Please select a record to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (Exist() == true)
                    {
                        //delete
                        int i = clsPartTypes.delete(Convert.ToInt32(txtID.Text));
                        if (i > 0)
                        {
                            ResetTextboxes();
                            loadData();
                            MetroFramework.MetroMessageBox.Show(this, "Hurray Record Successfully Deleted.....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "An Error Occured While Deleting Record.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "This record does not Exist in the Database......", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProductType.Text.Trim()))
                {
                    MetroFramework.MetroMessageBox.Show(this, "One or more Field(s) Empty.....", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtID.Text))
                    {
                        if (Exist() == true)
                        {
                            //update
                            clsPartTypes x = new clsPartTypes();
                            x.ID = Convert.ToInt32(txtID.Text);
                            x.Tag = Convert.ToString(txtProductType.Text);
                            int i = clsPartTypes.update(x);
                            if (i > 0)
                            {
                                ResetTextboxes();
                                loadData();
                                MetroFramework.MetroMessageBox.Show(this, "Hurray Record Successfully Updated.....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "An Error Occured While Updating Record.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        //insert
                        clsPartTypes x = new clsPartTypes();
                        x.Tag = Convert.ToString(txtProductType.Text);
                        int i = clsPartTypes.insert(x);
                        if (i > 0)
                        {
                            ResetTextboxes();
                            loadData();
                            MetroFramework.MetroMessageBox.Show(this, "Hurray Record Successfully Inserted.....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "An Error Occured While Inserting Record.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Exist()
        {
            var i = clsPartTypes.Exists(Convert.ToInt32(txtID.Text));
            if (i == true)
                return true;
            else
                return false;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtID.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtProductType.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    loadData();
                }
                else
                {
                    DataTable dt = (DataTable)new clsPartTypes().Search_DataTable(txtSearch.Text.Trim());
                    dataGridView1.Rows.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = Convert.ToInt32(dr["ID"].ToString());
                        dataGridView1.Rows[n].Cells[1].Value = dr["Tag"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
