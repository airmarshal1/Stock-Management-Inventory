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
using System.Drawing.Imaging;

namespace iShop.Controls
{
    public partial class ucCompanyInfo : MetroFramework.Controls.MetroUserControl
    {
        //List<tblCompanyInfo> list;

        string fileName;

        public ucCompanyInfo()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            txtCN.Focus();
            listView1.Items.Clear();
            //using (PicEntities db = new PicEntities())
            //{
            //    list = db.tblCompanyInfoes.ToList();
            //    foreach (tblCompanyInfo x in list)
            //    {
            //        ListViewItem a = new ListViewItem(x.ID.ToString());
            //        a.SubItems.Add(x.CName.ToString());
            //        a.SubItems.Add(x.Tel.ToString());
            //        a.SubItems.Add(x.Email.ToString());
            //        a.SubItems.Add(x.Tin.ToString());
            //        a.SubItems.Add(x.STNO.ToString());
            //        a.SubItems.Add(x.CIN.ToString());
            //        a.SubItems.Add(x.CAddress.ToString());
            //        a.SubItems.Add(x.FileNamee.ToString());
            //        listView1.Items.Add(a);
            //    }
            //}
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

        private bool Exist()
        {
            var i = iShopClass.clsCompanyInfo.Exists(Convert.ToInt32(txtID.Text));
            if (i == true)
                return true;
            else
                return false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTextFields();
            txtCN.Focus();
        }

        byte[] ConvertImageToBinary(Image img)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                img.Save(ms,ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        Image ConvertBinaryToImage(byte[] data)
        {
            using(MemoryStream ms = new MemoryStream(data)){
                return Image.FromStream(ms);
            }
        }

        private  void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCN.Text.Trim()))
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
                            //using (PicEntities db = new PicEntities())
                            //{
                            //    tblCompanyInfo a = new tblCompanyInfo() { ID = Convert.ToInt32(txtID.Text), CName = txtCN.Text.Trim(), CAddress = txtCA.Text.Trim(), Tel = txtTel.Text.Trim(), Email = txtEmail.Text.Trim(), Tin = txtTin.Text.Trim(), STNO = txtStno.Text.Trim(), CIN = txtCin.Text.Trim(), Flag = ConvertImageToBinary(pictureBox1.Image), FileNamee = fileName };
                            //    db.tblCompanyInfoes.Add(a);
                            //    db.SaveChanges();
                            //    MetroFramework.MetroMessageBox.Show(this, "Hurray Record Successfully Updated.....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    loadData();
                            //    ResetTextFields();
                            //}
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "This record does not Exist in the Database......", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //insert   
                        //using (PicEntities db = new PicEntities())
                        //{
                        //    tblCompanyInfo a = new tblCompanyInfo() { CName = txtCN.Text.Trim(), CAddress = txtCA.Text.Trim(), Tel = txtTel.Text.Trim(), Email = txtEmail.Text.Trim(), Tin = txtTin.Text.Trim(), STNO = txtStno.Text.Trim(), CIN = txtCin.Text.Trim(), Flag = ConvertImageToBinary(pictureBox1.Image), FileNamee = fileName };
                        //    db.tblCompanyInfoes.Add(a);
                        //    db.SaveChanges();
                        //    MetroFramework.MetroMessageBox.Show(this, "Hurray Record Successfully Inserted.....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    loadData();
                        //    ResetTextFields();
                        //}
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
                        int i = iShopClass.clsCompanyInfo.delete(Convert.ToInt32(txtID.Text));
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
                using(OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "JPEG|*.jpg";
                    ofd.ValidateNames = true;
                    ofd.Multiselect = false;
                    if(ofd.ShowDialog() == DialogResult.OK)
                    {
                        string picPath = ofd.FileName.ToString();
                        fileName = ofd.FileName;
                        txtImagePath.Text = picPath;
                        pictureBox1.Image = Image.FromFile(fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (listView1.FocusedItem != null)
                {
                    //pictureBox2.Image = ConvertBinaryToImage(list[listView1.FocusedItem.Index].Flag);
                    //pictureBox1.Image = ConvertBinaryToImage(list[listView1.FocusedItem.Index].Flag);
                    string a = listView1.FocusedItem.SubItems[0].Text;
                    string b = listView1.FocusedItem.SubItems[1].Text;
                    string c = listView1.FocusedItem.SubItems[2].Text;
                    string d = listView1.FocusedItem.SubItems[3].Text;
                    string ee = listView1.FocusedItem.SubItems[4].Text;
                    string f = listView1.FocusedItem.SubItems[5].Text;
                    string g = listView1.FocusedItem.SubItems[6].Text;
                    string h = listView1.FocusedItem.SubItems[7].Text;
                    string ii = listView1.FocusedItem.SubItems[8].Text;

                    lblID.Text = string.Format("SNO: {0}", Convert.ToString(a));
                    lblCN.Text = string.Format("Name: {0}", b);
                    lblTel.Text = string.Format("Phone: {0}", c);
                    lblEmail.Text = string.Format("Phone: {0}", d);
                    lblTin.Text = string.Format("TIN: {0}", ee);
                    lblStno.Text = string.Format("STNO: {0}", f);
                    lblCin.Text = string.Format("CIN: {0}", g);
                    lblCA.Text = string.Format("Address: {0}", h);
                    lblFN.Text = string.Format("File Name: {0}", ii);

                    txtID.Text = Convert.ToString(a);
                    txtCN.Text = b;
                    txtTel.Text = c;
                    txtEmail.Text = d;
                    txtTin.Text = ee;
                    txtStno.Text = f;
                    txtCin.Text = g;
                    txtCA.Text = h;
                    txtImagePath.Text = ii;
                    //string j = listView1.FocusedItem.SubItems[9].Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
