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
    public partial class ucProducts : MetroFramework.Controls.MetroUserControl
    {
        public ucProducts()
        {
            InitializeComponent();
            loadData();
            loadComboxes();
        }

        private void loadData()
        {
            txtPN.Focus();
            DataTable dt = (DataTable)new clsParts().GetAll_DataTable();
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = Convert.ToInt32(dr["ID"]);
                dataGridView1.Rows[n].Cells[1].Value = Convert.ToString(dr["PartName"]);
                dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(dr["PartType"]);
                dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(dr["SupplierName"]);
                dataGridView1.Rows[n].Cells[4].Value = Convert.ToString(dr["StockLevel"]);
                dataGridView1.Rows[n].Cells[5].Value = Convert.ToString(dr["MinStockLevel"]);
                dataGridView1.Rows[n].Cells[6].Value = Convert.ToString(dr["CostPrice"]);
                dataGridView1.Rows[n].Cells[7].Value = Convert.ToString(dr["SellingPrice"]);
                dataGridView1.Rows[n].Cells[8].Value = Convert.ToString(dr["Discount"]);
                dataGridView1.Rows[n].Cells[9].Value = Convert.ToString(dr["Location"]);
                dataGridView1.Rows[n].Cells[10].Value = Convert.ToString(dr["Remarks"]);
            }
        }

        private void ResetTextFields()
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

        private void ResetCheckboxes()
        {
            Action<Control.ControlCollection> func = null;
            func = (x) =>
            {
                foreach (Control c in x)
                    if (c is ComboBox)
                        (c as ComboBox).SelectedIndex = 0;
                    else
                        func(c.Controls);
            };
            func(Controls);
        }

        private void loadComboxes()
        {
            var i = clsPartTypes.GetAllPartTypes();
            ddlPT.DisplayMember = "Tag";
            ddlPT.ValueMember = "ID";
            ddlPT.DataSource = i.ToList();

            var j = clsSuppliers.GetAllSuppliers();
            ddlSN.DisplayMember = "Name";
            ddlSN.ValueMember = "ID";
            ddlSN.DataSource = j.ToList();
        }

        private bool Exist()
        {
            var i = clsParts.Exists(Convert.ToInt32(txtID.Text));
            if (i == true)
                return true;
            else
                return false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    loadData();
                }
                else
                {
                    DataTable dt = (DataTable)new clsParts().Search_DataTable(txtSearch.Text.Trim());
                    dataGridView1.Rows.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = Convert.ToInt32(dr["ID"]);
                        dataGridView1.Rows[n].Cells[1].Value = Convert.ToString(dr["PartName"]);
                        dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(dr["PartType"]);
                        dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(dr["SupplierName"]);
                        dataGridView1.Rows[n].Cells[4].Value = Convert.ToString(dr["StockLevel"]);
                        dataGridView1.Rows[n].Cells[5].Value = Convert.ToString(dr["MinStockLevel"]);
                        dataGridView1.Rows[n].Cells[6].Value = Convert.ToString(dr["CostPrice"]);
                        dataGridView1.Rows[n].Cells[7].Value = Convert.ToString(dr["SellingPrice"]);
                        dataGridView1.Rows[n].Cells[8].Value = Convert.ToString(dr["Discount"]);
                        dataGridView1.Rows[n].Cells[9].Value = Convert.ToString(dr["Location"]);
                        dataGridView1.Rows[n].Cells[10].Value = Convert.ToString(dr["Remarks"]);
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
            ResetCheckboxes();
            ResetTextFields();
            txtPN.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPN.Text.Trim()))
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
                            clsParts x = new clsParts();
                            x.ID = Convert.ToInt32(txtID.Text.Trim());
                            x.PartName = Convert.ToString(txtPN.Text.Trim());
                            x.PartType = Convert.ToInt32(ddlPT.SelectedValue);
                            x.SUID = Convert.ToInt32(ddlSN.SelectedValue);
                            x.StockLevel = Convert.ToInt32(txtSL.Text.Trim());
                            x.MinStockLevel = Convert.ToInt32(txtMSL.Text.Trim());
                            x.CostPrice = Convert.ToDouble(txtCP.Text.Trim());
                            x.SellingPrice = Convert.ToDouble(txtSP.Text.Trim());
                            x.Discount = Convert.ToDouble(txtD.Text.Trim());
                            x.Location = Convert.ToString(txtL.Text.Trim());
                            x.Remarks = Convert.ToString(txtR.Text.Trim());
                            int r = clsParts.update(x);
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
                        clsParts x = new clsParts();
                        x.PartName = Convert.ToString(txtPN.Text.Trim());
                        x.PartType = Convert.ToInt32(ddlPT.SelectedValue);
                        x.SUID = Convert.ToInt32(ddlSN.SelectedValue);
                        x.StockLevel = Convert.ToInt32(txtSL.Text.Trim());
                        x.MinStockLevel = Convert.ToInt32(txtMSL.Text.Trim());
                        x.CostPrice = Convert.ToDouble(txtCP.Text.Trim());
                        x.SellingPrice = Convert.ToDouble(txtSP.Text.Trim());
                        x.Discount = Convert.ToDouble(txtD.Text.Trim());
                        x.Location = Convert.ToString(txtL.Text.Trim());
                        x.Remarks = Convert.ToString(txtR.Text.Trim());
                        int r = clsParts.insert(x);
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
                        int i = clsParts.delete(Convert.ToInt32(txtID.Text));
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

        private void btnSearchPT_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtPTSearch.Text.Trim()))
                {
                    var i = clsPartTypes.GetAllPartTypes();
                    ddlPT.DisplayMember = "Tag";
                    ddlPT.ValueMember = "ID";
                    ddlPT.DataSource = i.ToList();
                }
                else
                {
                    var i = clsPartTypes.selectPartTypes(txtPTSearch.Text.Trim());
                    ddlPT.DisplayMember = "Tag";
                    ddlPT.ValueMember = "ID";
                    ddlPT.DataSource = i.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSUPSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSUPSearch.Text.Trim()))
                {
                    var j = clsSuppliers.GetAllSuppliers();
                    ddlSN.DisplayMember = "Name";
                    ddlSN.ValueMember = "ID";
                    ddlSN.DataSource = j.ToList();
                }
                else
                {
                    var j = clsSuppliers.selectSupplier(txtSUPSearch.Text.Trim());
                    ddlSN.DisplayMember = "Name";
                    ddlSN.ValueMember = "ID";
                    ddlSN.DataSource = j.ToList();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtID.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtPN.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                ddlPT.SelectedText = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                ddlSN.SelectedText = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                txtSL.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtMSL.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                txtCP.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                txtSP.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                txtD.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                txtL.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                txtR.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetOutOfStockProducts_Click(object sender, EventArgs e)
        {
            try
            {
                int i=0;
                DataTable dt = (DataTable)new clsParts().GetAll_DataTable3();
                dataGridView2.Rows.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = (i += 1);
                    dataGridView2.Rows[n].Cells[1].Value = Convert.ToString(dr["PartName"]);
                    dataGridView2.Rows[n].Cells[2].Value = Convert.ToString(dr["PartType"]);
                    dataGridView2.Rows[n].Cells[3].Value = Convert.ToString(dr["SupplierName"]);
                    dataGridView2.Rows[n].Cells[4].Value = Convert.ToString(dr["StockLevel"]);
                    dataGridView2.Rows[n].Cells[5].Value = Convert.ToString(dr["MinStockLevel"]);
                    dataGridView2.Rows[n].Cells[6].Value = Convert.ToString(dr["CostPrice"]);
                    dataGridView2.Rows[n].Cells[7].Value = Convert.ToString(dr["SellingPrice"]);
                    dataGridView2.Rows[n].Cells[8].Value = Convert.ToString(dr["Discount"]);
                    dataGridView2.Rows[n].Cells[9].Value = Convert.ToString(dr["Location"]);
                    dataGridView2.Rows[n].Cells[10].Value = Convert.ToString(dr["Remarks"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
