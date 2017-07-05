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
    public partial class ucCustomers : MetroFramework.Controls.MetroUserControl
    {
        public ucCustomers()
        {
            InitializeComponent();
            loadData();
        }

        void loadData()
        {
            txtFN.Focus();
            ddlGender.SelectedIndex = 0;
            //get all customers from database
            DataTable dt = (DataTable)new clsCustomers().GetAll_DataTable();
            dataGridView1.Rows.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = Convert.ToInt32(dr["ID"]);
                dataGridView1.Rows[n].Cells[1].Value = Convert.ToString(dr["FName"]);
                dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(dr["SName"]);
                dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(dr["Gender"]);
                dataGridView1.Rows[n].Cells[4].Value = Convert.ToString(dr["Tel"]);
                dataGridView1.Rows[n].Cells[5].Value = Convert.ToString(dr["Email"]);
                dataGridView1.Rows[n].Cells[6].Value = Convert.ToString(dr["City"]);
                dataGridView1.Rows[n].Cells[7].Value = Convert.ToString(dr["PinCode"]);
                dataGridView1.Rows[n].Cells[8].Value = Convert.ToString(dr["CAddress"]);
                dataGridView1.Rows[n].Cells[9].Value = Convert.ToString(dr["Remarks"]);
            }
        }

        void ResetTextFields()
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

        //txtSearch for a record
        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(metroTextBox1.Text.Trim()))
                {
                    loadData();
                }
                else
                {
                    if (e.KeyChar == (Char)13)
                    {
                        DataTable dt = (DataTable)new clsCustomers().Search_DataTable(metroTextBox1.Text.Trim());
                        dataGridView1.Rows.Clear();
                        foreach (DataRow dr in dt.Rows)
                        {
                            int n = dataGridView1.Rows.Add();
                            dataGridView1.Rows[n].Cells[0].Value = Convert.ToInt32(dr["ID"]);
                            dataGridView1.Rows[n].Cells[1].Value = Convert.ToString(dr["FName"]);
                            dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(dr["SName"]);
                            dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(dr["Gender"]);
                            dataGridView1.Rows[n].Cells[4].Value = Convert.ToString(dr["Tel"]);
                            dataGridView1.Rows[n].Cells[5].Value = Convert.ToString(dr["Email"]);
                            dataGridView1.Rows[n].Cells[6].Value = Convert.ToString(dr["City"]);
                            dataGridView1.Rows[n].Cells[7].Value = Convert.ToString(dr["PinCode"]);
                            dataGridView1.Rows[n].Cells[8].Value = Convert.ToString(dr["CAddress"]);
                            dataGridView1.Rows[n].Cells[9].Value = Convert.ToString(dr["Remarks"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ResetTextFields();
                loadData();
                txtFN.Focus();
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
                if (string.IsNullOrEmpty(txtFN.Text.Trim()))
                {
                    MetroFramework.MetroMessageBox.Show(this, "One or more Field(s) Empty.....", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtID.Text))
                    {
                        //update
                        if (Exist() == true)
                        {
                            clsCustomers x = new clsCustomers();
                            string jk = "Unknown";
                            x.ID = Convert.ToInt32(txtID.Text.Trim());
                            x.FName = Convert.ToString(txtFN.Text.Trim());
                            x.SName = Convert.ToString(txtLN.Text.Trim());
                            x.Gender = Convert.ToString(ddlGender.SelectedValue);
                            x.Tel = Convert.ToString(txtTel.Text.Trim());
                            x.Email = Convert.ToString(txtEmail.Text.Trim());
                            x.City = Convert.ToString(txtCity.Text.Trim());
                            x.PinCode = Convert.ToString(txtPinCode.Text.Trim());
                            x.CAddress = Convert.ToString(txtCA.Text.Trim());
                            x.Remarks = Convert.ToString(txtRemarks.Text.Trim());
                            x.Flag = jk;
                            int r = clsCustomers.update(x);
                            if (r > 0)
                            {
                                ResetTextFields();
                                loadData();
                                MetroFramework.MetroMessageBox.Show(this, "Hurray Record Successfully Updated.....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "An Error Occured While Updating Record.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "This record does not Exist in the Database......", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //insert
                        clsCustomers x = new clsCustomers();
                        string jk = "Unknown";
                        x.FName = Convert.ToString(txtFN.Text.Trim());
                        x.SName = Convert.ToString(txtLN.Text.Trim());
                        x.Gender = Convert.ToString(ddlGender.SelectedValue);
                        x.Tel = Convert.ToString(txtTel.Text.Trim());
                        x.Email = Convert.ToString(txtEmail.Text.Trim());
                        x.City = Convert.ToString(txtCity.Text.Trim());
                        x.PinCode = Convert.ToString(txtPinCode.Text.Trim());
                        x.CAddress = Convert.ToString(txtCA.Text.Trim());
                        x.Remarks = Convert.ToString(txtRemarks.Text.Trim());
                        x.Flag = jk;
                        int r = clsCustomers.insert(x);
                        if (r > 0)
                        {
                            ResetTextFields();
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
                        int i = clsCustomers.delete(Convert.ToInt32(txtID.Text));
                        if (i > 0)
                        {
                            ResetTextFields();
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

        private bool Exist()
        {
            var i = clsCustomers.Exists(Convert.ToInt32(txtID.Text));
            if (i == true)
                return true;
            else
                return false;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtID.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtFN.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                txtLN.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                ddlGender.SelectedText = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                txtTel.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtEmail.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                txtCity.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                txtPinCode.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                txtCA.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                txtRemarks.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
