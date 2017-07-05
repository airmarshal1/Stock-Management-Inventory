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
using System.IO;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Diagnostics;

namespace iShop.Controls
{
    public partial class ucBilling : MetroFramework.Controls.MetroUserControl
    {
        public ucBilling()
        {
            InitializeComponent();
            loadProducts();
        }

        Task ProcessImport(List<string> data, IProgress<clsProgressReport> Progress) {
            int index = 1;
            int totalProgress = data.Count;
            var ProgressReport = new clsProgressReport();
            return Task.Run(()=>{
                for(int i =0;i<totalProgress;i++){
                    ProgressReport.percentComplete = index++ *100/totalProgress;
                    Progress.Report(ProgressReport);
                    System.Threading.Thread.Sleep(15);
                }
            });
        }

        private struct DataParameter
        {
            public int Process;
            public int Delay;
        }

        private DataParameter _inputparameter;

        void loadProducts()
        {
            txtQty.Focus();
            var i = clsParts.GetAllParts2();
            ddlProduct.DisplayMember = "PartName";
            ddlProduct.ValueMember = "PartName";
            ddlProduct.DataSource = i.ToList();
            ddlProduct.SelectedIndex = 0;            
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

        void ResetComboBox()
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            loadProducts();
            ResetTextFields();
            ResetComboBox();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtQty.Text.Trim()) || string.IsNullOrEmpty(txtDiscount.Text.Trim()) || string.IsNullOrEmpty(txtPrice.Text.Trim()))
                {
                    MetroFramework.MetroMessageBox.Show(this, "The Item Quantity or Item Price or Discount is required....Please Select a product again and Enter your Product Quantity to solve this Error.......", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ListViewItem x = new ListViewItem(Convert.ToString(ddlProduct.Text));
                    x.SubItems.Add(txtDiscount.Text.Trim());
                    x.SubItems.Add(txtPrice.Text.Trim());
                    x.SubItems.Add(txtQty.Text.Trim());
                    bool exists = false;
                    foreach(ListViewItem i in metroListView1.Items){
                        if (Convert.ToString(i.SubItems[0].Text) == Convert.ToString(x.SubItems[0].Text))
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        metroListView1.Items.Add(x);
                        ResetTextFields();
                        ResetComboBox();
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "The item you are trying to add already Exist in the Cart....", "Cart Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void txtSearchProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar == (Char)13)
                {
                    if (string.IsNullOrEmpty(txtSearchProduct.Text.Trim()))
                    {
                        loadProducts();
                    }
                    else
                    {
                        var i = clsParts.search2(txtSearchProduct.Text.Trim());
                        ddlProduct.DisplayMember = "PartName";
                        ddlProduct.ValueMember = "PartName";
                        ddlProduct.DataSource = i.ToList();
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var i = clsParts.search(Convert.ToString(ddlProduct.SelectedValue));
                foreach(var a in i.ToList())
                {
                    txtDiscount.Text = Convert.ToString(a.Discount);
                    txtPrice.Text = Convert.ToString(a.SellingPrice);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetTotal_Click(object sender, EventArgs e)
        {
            const double tax_rate = 0.21;
            double discount = 0.00;
            double isubtotal = 0.00;
            double iTax = 0.00;
            double iTotal = 0.00;
            //double iDiscount = 0.00;
            foreach (ListViewItem i in metroListView1.Items)
            {
                discount += double.Parse(i.SubItems[1].Text);
                isubtotal += Convert.ToDouble(double.Parse(i.SubItems[2].Text) * int.Parse(i.SubItems[3].Text));
                iTotal += Convert.ToDouble((double.Parse(i.SubItems[2].Text) * int.Parse(i.SubItems[3].Text)) * ((100 - double.Parse(i.SubItems[1].Text)) / 100));
                //iDiscount += Convert.ToDouble((double.Parse(i.SubItems[2].Text) * int.Parse(i.SubItems[3].Text)) * ((100 - double.Parse(i.SubItems[1].Text))/100) );
            }
            txtTotalDiscount.Text = Convert.ToString(discount);
            iTax = isubtotal * tax_rate;
            txtTax.Text = Convert.ToString(iTax);
            txtSubTotal.Text = Convert.ToString(isubtotal);
            txtTotal.Text = Convert.ToString(iTotal); 
            //iTotal = (isubtotal + iTax) + (discount = ((100 - discount)/100));
            //iTotal = (isubtotal + iTax + iDiscount);    
           //txtTotal.Text = Convert.ToString(iTotal); 

            txtSubTotal.Text = string.Format("{0:C}", isubtotal);
            txtTax.Text = string.Format("{0:C}", iTax);
            txtTotal.Text = string.Format("{0:C}", iTotal);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListViewItem x;
            x = metroListView1.SelectedItems[0];
            x.Remove();
            lblRemove.Text = "Hurray Successfully Removed";
            loadProducts();
        }

        private void metroListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (metroListView1.SelectedIndices.Count > 0)
                {
                    lblRemove.Text = string.Format("Item {0} Was Clicked", metroListView1.SelectedIndices[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                const double iTax_Rate = 0.21;
                double iChange = 0.00, iTotal = 0.00, iTax = 0.00, iSubTotal = 0.00, iCost = 0.00;
                if (ddlPaymentMethod.Text == "Cash")
                {                   
                    foreach (ListViewItem i in metroListView1.Items)
                    {
                        iSubTotal += Convert.ToDouble(double.Parse(i.SubItems[2].Text) * int.Parse(i.SubItems[3].Text));
                        iTotal += Convert.ToDouble((double.Parse(i.SubItems[2].Text) * int.Parse(i.SubItems[3].Text)) * ((100 - double.Parse(i.SubItems[1].Text)) / 100));
                    }
                    txtSubTotal.Text = Convert.ToString(iSubTotal);
                    iTax = (iSubTotal * iTax_Rate) / 100;
                    txtTax.Text = Convert.ToString(iTax);
                    //iTotal = iTotal + iTax;
                    iTotal = iTotal + iTax;
                    txtTotal.Text = Convert.ToString(iTotal);
                    iChange = Convert.ToDouble(txtCash.Text.Trim());
                    //iCost = iChange - (iTax + iTotal);
                    iCost = iChange - iTotal;
                    txtChange.Text = Convert.ToString(iCost);

                    txtSubTotal.Text = string.Format("{0:C}", iSubTotal);
                    txtChange.Text = string.Format("{0:C}",iCost);
                    txtTax.Text = string.Format("{0:C}",iTax);
                    txtTotal.Text = string.Format("{0:C}",iTotal);
                    loadReciept();
                }
                else
                {
                    foreach (ListViewItem i in metroListView1.Items)
                    {
                        iSubTotal += Convert.ToDouble(double.Parse(i.SubItems[2].Text) * int.Parse(i.SubItems[3].Text));
                        iTotal += Convert.ToDouble((double.Parse(i.SubItems[2].Text) * int.Parse(i.SubItems[3].Text)) * ((100 - double.Parse(i.SubItems[1].Text)) / 100));
                    }
                    txtSubTotal.Text = Convert.ToString(iSubTotal);
                    iTax = (iSubTotal * iTax_Rate) / 100;
                    txtTax.Text = Convert.ToString(iTax);
                    //iTotal = iTotal + iTax;
                    iTotal = iTotal + iTax;
                    txtTotal.Text = Convert.ToString(iTotal);

                    txtSubTotal.Text = string.Format("{0:C}", iSubTotal);
                    txtTax.Text = string.Format("{0:C}", iTax);
                    txtTotal.Text = string.Format("{0:C}", iTotal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void ddlPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPaymentMethod.Text == "Cash")
                {
                    txtCash.Enabled = true;
                    txtCash.Text = "";
                    txtCash.Focus();
                }
                else
                {
                    txtCash.Enabled = false;
                    txtCash.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private async void btnSaveToDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTotal.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Transaction Details is Empty...Pls Perform a Transaction....", "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    panel6.Visible = true;
                    foreach (ListViewItem i in metroListView1.Items)
                    {
                        if (i.SubItems[0].Text != null)
                        {
                            List<string> list = new List<string>();
                            clsReports x = new clsReports();
                            x.Product = Convert.ToString(i.SubItems[0].Text);
                            x.Price = Convert.ToDouble(i.SubItems[2].Text);
                            x.Qty = Convert.ToInt32(i.SubItems[3].Text);
                            clsReports.insert(x);
                            lblProgessing.Text = "Working....";
                            var ProgressReport = new Progress<clsProgressReport>();
                            ProgressReport.ProgressChanged +=(o,report)=>{
                                lblProgessing.Text = string.Format("Processing.....{0}%", report.percentComplete);
                                metroProgressBar1.Value = report.percentComplete;
                                metroProgressBar1.Update();
                            };
                            await ProcessImport(list, ProgressReport);
                            lblProgessing.Text = "Done!!!!";
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Transaction Details is Empty...Pls Perform a Transaction....", "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    MetroFramework.MetroMessageBox.Show(this, "Hurray Transaction Saved Successfully", "Transaction Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnPrintReciept.Visible = true;
                    //loadReciept();
                }                            
                //panel6.Visible = true;
                //if (backgroundWorker1.IsBusy)
                //    return;
                //foreach(ListViewItem i in metroListView1.Items)
                //{
                //    clsReports x = new clsReports();
                //    x.Product = Convert.ToString(i.SubItems[0].Text);
                //    x.Price = Convert.ToDouble(i.SubItems[2].Text);
                //    x.Qty = Convert.ToInt32(i.SubItems[3].Text);
                //    metroProgressBar1.Minimum = 0;
                //    metroProgressBar1.Value = 0;
                //    backgroundWorker1.RunWorkerAsync(clsReports.insert(x));
                //    //clsReports.insert(x);
                //}
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            metroProgressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = string.Format("Processing......{0}%",e.ProgressPercentage);
            metroProgressBar1.Update();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int process = ((DataParameter)e.Argument).Process;
            int delay = ((DataParameter)e.Argument).Delay;
            int index = 1;
            try
            {
                for (int i = 0; i < process;i++ )
                {
                    if (!backgroundWorker1.CancellationPending)
                    {
                        backgroundWorker1.ReportProgress(index * 100/process,string.Format("Process data {0}",i));
                        System.Threading.Thread.Sleep(delay);
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                      
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Threading.Thread.Sleep(10);
            if (e.Error == null)
                lblStatus.Text = "Your Transaction has ben successfully Saved...";
        }

        void loadReciept()
        {
            string a = null;
            var b = clsCompanyInfo.select(4);
            foreach(var i in b.ToList())
            {
                a = i.CName;
            }
            txtReciept.AppendText("\t\t\t"+ "Powered By "+ a +" Shopping System");
            txtReciept.AppendText("\t\t\t" + "==============================================================================" + Environment.NewLine);
            txtReciept.AppendText(" " + Environment.NewLine);
            txtReciept.AppendText(Environment.NewLine + "Ref No:" + LoadRefNo());
            txtReciept.AppendText(Environment.NewLine +"Order Date:"+ "\t" + LoadOrderDate() + "\t" + "Order Time:" + "\t" + LoadOrderTime());
            txtReciept.AppendText(Environment.NewLine + "Item Type:" + "\t\t" + "Qty:" + "\t" + "Unit Price:" + "\t" + Environment.NewLine);
            foreach (ListViewItem i in metroListView1.Items)
            {
                txtReciept.AppendText(Environment.NewLine + i.SubItems[0].Text + "\t" + i.SubItems[3].Text + "\t" + i.SubItems[2].Text + "\t"+Environment.NewLine );
            }
            txtReciept.AppendText(Environment.NewLine +"\t\t\t" + "Total:" + "\t" + txtTotal.Text+Environment.NewLine);
            txtReciept.AppendText("\t\t\t" + "==============================================================================" + Environment.NewLine);
            txtReciept.AppendText("\t\t\t" + "Powered By " + a + " Shopping System" + Environment.NewLine);
        }

        private string LoadOrderTime()
        {
            string i = Convert.ToString(DateTime.Now.ToShortTimeString().ToString());
            return i;
        }

        private string LoadOrderDate()
        {
            string i = Convert.ToString(DateTime.Now.ToShortDateString().ToString());
            return i;
        }

        private string LoadRefNo()
        {
            int i;
            Random rand = new Random();
            i = rand.Next(0, 32665);
            return (Convert.ToString(i));
        }

        private void btnPrintReciept_Click(object sender, EventArgs e)
        {
            try
            {
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                    printDocument1.Print();            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawString(txtReciept.Text,new System.Drawing.Font("Times New Romans",15,System.Drawing.FontStyle.Bold),Brushes.Black,new System.Drawing.PointF(100,100));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
