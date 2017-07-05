using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iShopClass;

namespace iShop.Controls
{
    public partial class ucSuppliers : MetroFramework.Controls.MetroUserControl
    {
        public ucSuppliers()
        {
            InitializeComponent();
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
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
                            //byte[] i = null;
                            //FileStream fs = new FileStream(this.txtImagePath.Text, FileMode.Open, FileAccess.Read);
                            //BinaryReader rdr = new BinaryReader(fs);
                            //i = rdr.ReadBytes((int)fs.Length);
                            clsSuppliers x = new clsSuppliers();
                            x.ID = Convert.ToInt32(txtID.Text.Trim());
                            x.Name = Convert.ToString(txtFullName.Text.Trim());
                            x.Email = Convert.ToString(txtEmail.Text.Trim());
                            x.Tel = Convert.ToString(txtTel.Text.Trim());
                            x.City = Convert.ToString(txtCity.Text.Trim());
                            x.CAddress = Convert.ToString(txtContactAddress.Text.Trim());
                            x.Remarks = Convert.ToString(txtRemarks.Text.Trim());
                            //x.Flagg = i;
                            int r = clsSuppliers.update(x);
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
                        //byte[] i = null;
                        //FileStream fs = new FileStream(this.txtImagePath.Text,FileMode.Open,FileAccess.Read);
                        //BinaryReader rdr = new BinaryReader(fs);
                        //i = rdr.ReadBytes((int)fs.Length);
                        clsSuppliers x = new clsSuppliers();
                        x.Name = Convert.ToString(txtFullName.Text.Trim());
                        x.Email = Convert.ToString(txtEmail.Text.Trim());
                        x.Tel = Convert.ToString(txtTel.Text.Trim());
                        x.City = Convert.ToString(txtCity.Text.Trim());
                        x.CAddress = Convert.ToString(txtContactAddress.Text.Trim());
                        x.Remarks = Convert.ToString(txtRemarks.Text.Trim());
                       // x.Flagg = i;
                        int r = clsSuppliers.insert(x);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtFullName.Focus();
            ResetTextFields();
        }

        private void ResetTextFields()
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

        private void loadData()
        {
            txtFullName.Focus();
            DataTable dt = (DataTable)new clsSuppliers().GetAllSuppliers_DataTable();
            dataGridView1.Rows.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = Convert.ToInt32(dr["ID"]);
                dataGridView1.Rows[n].Cells[1].Value = Convert.ToString(dr["Name"]);
                dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(dr["Email"]);
                dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(dr["Tel"]);
                dataGridView1.Rows[n].Cells[4].Value = Convert.ToString(dr["City"]);
                dataGridView1.Rows[n].Cells[5].Value = Convert.ToString(dr["CAddress"]);
                dataGridView1.Rows[n].Cells[6].Value = Convert.ToString(dr["Remarks"]);
                dataGridView1.Rows[n].Cells[7].Value = Convert.ToString(dr["Flag"]);
            }
        }

        private bool Exist()
        {
            var i = clsSuppliers.Exists(Convert.ToInt32(txtID.Text));
            if (i == true)
                return true;
            else
                return false;
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
                        int i = clsSuppliers.delete(Convert.ToInt32(txtID.Text));
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "JPG Files(*.jpg)|*.jpg | PNG Files(*.png)|*.png | All Files(*.*) | *.* ";
                    ofd.ValidateNames = true;
                    ofd.Multiselect = false;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string picPath = ofd.FileName.ToString();
                        txtImagePath.Text = picPath;
                        pictureBox1.ImageLocation = picPath;
                        //string fileName = ofd.FileName;
                        //txtImagePath.Text = fileName;
                        //pictureBox1.Image = Image.FromFile(fileName);
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    DataTable dt = (DataTable)new clsSuppliers().Search_DataTable(txtSearch.Text.Trim());
                    dataGridView1.Rows.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = Convert.ToInt32(dr["ID"]);
                        dataGridView1.Rows[n].Cells[1].Value = Convert.ToString(dr["Name"]);
                        dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(dr["Email"]);
                        dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(dr["Tel"]);
                        dataGridView1.Rows[n].Cells[4].Value = Convert.ToString(dr["City"]);
                        dataGridView1.Rows[n].Cells[5].Value = Convert.ToString(dr["CAddress"]);
                        dataGridView1.Rows[n].Cells[6].Value = Convert.ToString(dr["Remarks"]);
                        dataGridView1.Rows[n].Cells[7].Value = Convert.ToString(dr["Flag"]);
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
                txtFullName.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                txtEmail.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtTel.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                txtCity.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtContactAddress.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                txtRemarks.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
