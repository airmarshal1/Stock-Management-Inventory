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
    public partial class ucDebtors : MetroFramework.Controls.MetroUserControl
    {
        public ucDebtors()
        {
            InitializeComponent();           
            loadProducts();
            loadData();
        }


        void loadData()
        {
            txtFN.Focus();
            ddlPN.SelectedIndex = 0;
            ddlIsP.SelectedIndex = 0;
            DataTable dt = (DataTable)new clsDebtors().GetAll_DataTable();
            dataGridView1.Rows.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = Convert.ToInt32(dr["ID"]);
                dataGridView1.Rows[n].Cells[1].Value = Convert.ToString(dr["DebtorNo"]);
                dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(dr["DebtorDate"]);
                dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(dr["PartName"]);
                dataGridView1.Rows[n].Cells[4].Value = Convert.ToString(dr["FName"]);
                dataGridView1.Rows[n].Cells[5].Value = Convert.ToString(dr["LName"]);
                dataGridView1.Rows[n].Cells[6].Value = Convert.ToString(dr["Tel"]);
                dataGridView1.Rows[n].Cells[7].Value = Convert.ToString(dr["Email"]);
                dataGridView1.Rows[n].Cells[8].Value = Convert.ToInt32(dr["Qty"]);                
                int i = Convert.ToInt32(dr["IsPaid"]);
                if (i == 0)
                {
                    dataGridView1.Rows[n].Cells[9].Value = "No";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[9].Value = "Yes";
                }
                dataGridView1.Rows[n].Cells[10].Value = Convert.ToString(dr["CAddress"]);
                dataGridView1.Rows[n].Cells[11].Value = Convert.ToString(dr["DRemarks"]);
            }
        }

        void loadProducts()
        {
            var i = clsParts.GetAllParts();
            ddlPN.DisplayMember = "PartName";
            ddlPN.ValueMember = "ID";
            ddlPN.DataSource = i.ToList();
        }

        void ResetTextFields()
        {
            Action<Control.ControlCollection> func = null;
            func = (x) =>
            {
                foreach (Control c in x)
                    if (c is TextBox)
                        (c as TextBox).Text = "";
                    else
                        func(c.Controls);
            };
            func(Controls);
        }

        private bool Exist()
        {
            var i = clsParts.Exists(Convert.ToInt32(txtID.Text));
            if (i == true)
                return true;
            else
                return false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                loadData();
                ResetTextFields();
                loadProducts();
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
                            clsDebtors x = new clsDebtors();
                            x.ID = Convert.ToInt32(txtID.Text.Trim());
                            x.DebtorNO = Convert.ToString(txtDN.Text.Trim());
                            x.DebtorDate = Convert.ToDateTime(txtDD.Text.Trim());
                            x.PID = Convert.ToInt32(ddlPN.SelectedValue);
                            x.FName = Convert.ToString(txtFN.Text.Trim());
                            x.SName = Convert.ToString(txtLN.Text.Trim());
                            x.Tel = Convert.ToString(txtTel.Text.Trim());
                            x.Email = Convert.ToString(txtEmail.Text.Trim());
                            x.CAddress = Convert.ToString(txtCA.Text.Trim());
                            x.Qty = Convert.ToInt32(txtQ.Text.Trim());
                            Boolean j = false;
                            if (ddlIsP.SelectedIndex == 1)
                            {
                                j = true;
                            }
                            else
                            {
                                j = false;
                            }
                            x.IsPaid = j;
                            x.DRemarks = Convert.ToString(txtR.Text.Trim());
                            x.Flag = "Unknown";
                            int r = clsDebtors.update(x);
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
                        clsDebtors x = new clsDebtors();
                        x.DebtorNO = Convert.ToString(txtDN.Text.Trim());
                        x.DebtorDate = Convert.ToDateTime(txtDD.Text.Trim());
                        x.PID = Convert.ToInt32(ddlPN.SelectedValue);
                        x.FName = Convert.ToString(txtFN.Text.Trim());
                        x.SName = Convert.ToString(txtLN.Text.Trim());
                        x.Tel = Convert.ToString(txtTel.Text.Trim());
                        x.Email = Convert.ToString(txtEmail.Text.Trim());
                        x.CAddress = Convert.ToString(txtCA.Text.Trim());
                        x.Qty = Convert.ToInt32(txtQ.Text.Trim());
                        Boolean j = false;
                        if (ddlIsP.SelectedIndex == 1)
                        {
                            j = true;
                        }
                        else
                        {
                            j = false;
                        }
                        x.IsPaid = j;
                        x.DRemarks = Convert.ToString(txtR.Text.Trim());
                        x.Flag = "Unknown";
                        int r = clsDebtors.insert(x);
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
                        int i = clsDebtors.delete(Convert.ToInt32(txtID.Text));
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                
                txtID.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtDN .Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                txtDD.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                ddlPN.SelectedText = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                txtFN.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtLN.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                txtTel.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                txtEmail.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                txtQ.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                ddlIsP.SelectedText = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());              
                txtCA.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
                txtR.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchPartName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)13)
                {
                    if (string.IsNullOrEmpty(txtSearchPartName.Text.Trim()))
                    {
                        loadProducts();
                    }
                    else
                    {
                        var i = clsParts.search(txtSearchPartName.Text.Trim());
                        ddlPN.DisplayMember = "PartName";
                        ddlPN.ValueMember = "ID";
                        ddlPN.DataSource = i.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar == (Char)13)
                {
                    if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
                    {
                        loadData();
                    }
                    else
                    {
                        DataTable dt = (DataTable)new clsDebtors().Search_DataTable(txtSearch.Text.Trim());
                        dataGridView1.Rows.Clear();
                        foreach (DataRow dr in dt.Rows)
                        {
                            int n = dataGridView1.Rows.Add();
                            dataGridView1.Rows[n].Cells[0].Value = Convert.ToInt32(dr["ID"]);
                            dataGridView1.Rows[n].Cells[1].Value = Convert.ToString(dr["DebtorNo"]);
                            dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(dr["DebtorDate"]);
                            dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(dr["PartName"]);
                            dataGridView1.Rows[n].Cells[4].Value = Convert.ToString(dr["FName"]);
                            dataGridView1.Rows[n].Cells[5].Value = Convert.ToString(dr["LName"]);
                            dataGridView1.Rows[n].Cells[6].Value = Convert.ToString(dr["Tel"]);
                            dataGridView1.Rows[n].Cells[7].Value = Convert.ToString(dr["Email"]);
                            dataGridView1.Rows[n].Cells[8].Value = Convert.ToInt32(dr["Qty"]);
                            int i = Convert.ToInt32(dr["IsPaid"]);
                            if (i == 0)
                            {
                                dataGridView1.Rows[n].Cells[9].Value = "No";
                            }
                            else
                            {
                                dataGridView1.Rows[n].Cells[9].Value = "Yes";
                            }
                            dataGridView1.Rows[n].Cells[10].Value = Convert.ToString(dr["CAddress"]);
                            dataGridView1.Rows[n].Cells[11].Value = Convert.ToString(dr["DRemarks"]);
                        }
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
