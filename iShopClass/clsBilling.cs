using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace iShopClass
{
   public class clsBilling
    {
       private static string sqlconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

       public int ID { get; set; }
       public string InvoiceNo { get; set; }
       public DateTime InvoiceDate { get; set; }
       public int PID { get; set; }
       public int CID { get; set; }
       public string FullName{ get; set; }
       public string Product { get; set; }
       public int Amount { get; set; }
       public string PaymentMethod { get; set; }
       public Boolean IsInCart { get; set; }
       public string Remarks { get; set; }

       public static int insert(clsBilling x)
       {
           using (SqlConnection conn = new SqlConnection(sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spInsertBilling", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@ivno", x.InvoiceNo);
               cmd.Parameters.AddWithValue("@ivdate",x.InvoiceDate);
               cmd.Parameters.AddWithValue("@pid",x.PID);
               cmd.Parameters.AddWithValue("@cid",x.CID);
               cmd.Parameters.AddWithValue("@qty",x.Amount);
               cmd.Parameters.AddWithValue("@pm", x.PaymentMethod);
               cmd.Parameters.AddWithValue("@is",x.IsInCart);
               cmd.Parameters.AddWithValue("@rem",x.Remarks);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int update(clsBilling x)
       {
           using (SqlConnection conn = new SqlConnection(sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spUpdateBilling", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", x.ID);
               cmd.Parameters.AddWithValue("@ivno", x.InvoiceNo);
               cmd.Parameters.AddWithValue("@ivdate", x.InvoiceDate);
               cmd.Parameters.AddWithValue("@pid", x.PID);
               cmd.Parameters.AddWithValue("@cid", x.CID);
               cmd.Parameters.AddWithValue("@qty", x.Amount);
               cmd.Parameters.AddWithValue("@pm", x.PaymentMethod);
               cmd.Parameters.AddWithValue("@is", x.IsInCart);
               cmd.Parameters.AddWithValue("@rem", x.Remarks);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int delete(int ID)
       {
           using (SqlConnection conn = new SqlConnection(sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spDeleteBilling", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id",ID);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static List<clsBilling> select(int ID)
       {
           List<clsBilling> x = new List<clsBilling>();
           using (SqlConnection conn = new SqlConnection(sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectBilling", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsBilling y = new clsBilling();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.InvoiceNo = Convert.ToString(rdr["InvoiceNo"]);
                   y.InvoiceDate = Convert.ToDateTime(rdr["InvoiceDate"]);
                   y.Product = Convert.ToString(rdr["PartName"]);
                   y.FullName = Convert.ToString(rdr["FullName"]);
                   y.Amount = Convert.ToInt32(rdr[@"Amount\Qty"]);
                   y.PaymentMethod = Convert.ToString(rdr["PaymentMethod"]);
                   y.IsInCart = Convert.ToBoolean(rdr["IsInCart"]);
                   y.Remarks = Convert.ToString(rdr["Remarks"]);

                   x.Add(y);
               }
           }
           return x;
       }


       public static List<clsBilling> selectAll()
       {
           List<clsBilling> x = new List<clsBilling>();
           using (SqlConnection conn = new SqlConnection(sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectAllBilling", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsBilling y = new clsBilling();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.InvoiceNo = Convert.ToString(rdr["InvoiceNo"]);
                   y.InvoiceDate = Convert.ToDateTime(rdr["InvoiceDate"]);
                   y.Product = Convert.ToString(rdr["PartName"]);
                   y.FullName = Convert.ToString(rdr["FullName"]);
                   y.Amount = Convert.ToInt32(rdr[@"Amount\Qty"]);
                   y.PaymentMethod = Convert.ToString(rdr["PaymentMethod"]);
                   y.IsInCart = Convert.ToBoolean(rdr["IsInCart"]);
                   y.Remarks = Convert.ToString(rdr["Remarks"]);

                   x.Add(y);
               }
           }
           return x;
       }
    }
}
