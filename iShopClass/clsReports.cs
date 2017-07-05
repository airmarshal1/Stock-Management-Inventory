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
   public class clsReports : clsMain
    {
       public int ID { get; set; }
       public string Product { get; set; }
       public double Price { get; set; }
       public int Qty { get; set; }
       public string DateCreated { get; set; }
       public string PaymentMethod { get; set; }

       public static int insert(clsReports x)
       {
           using (SqlConnection conn = new SqlConnection())
           {
               conn.ConnectionString = clsMain.sqlconnstring;
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spInsertReports", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@pt", x.Product);
               cmd.Parameters.AddWithValue("@pr", x.Price);
               cmd.Parameters.AddWithValue("@q", x.Qty);
               cmd.Parameters.AddWithValue("@d",DateTime.Now.ToShortDateString().ToString());
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int update(clsReports x)
       {
           using (SqlConnection conn = new SqlConnection())
           {
               conn.ConnectionString = clsMain.sqlconnstring;
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spUpdateReports", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", x.ID);
               cmd.Parameters.AddWithValue("@pt", x.Product);
               cmd.Parameters.AddWithValue("@pr", x.Price);
               cmd.Parameters.AddWithValue("@q", x.Qty);
               cmd.Parameters.AddWithValue("@d", x.DateCreated);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int delete(int id)
       {
           using (SqlConnection conn = new SqlConnection())
           {
               conn.ConnectionString = clsMain.sqlconnstring;
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spDeleteReports", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id",id);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static List<clsReports> select(int ID)
       {
           List<clsReports> x = new List<clsReports>();
           int i = 0;
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectReports", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsReports y = new clsReports();
                   y.ID = Convert.ToInt32((i += 1));
                   y.Product = Convert.ToString(rdr["Product"]);
                   y.Price = Convert.ToDouble(rdr["Price"]);
                   y.Qty = Convert.ToInt32(rdr["Qty"]);
                   y.DateCreated = Convert.ToString(rdr["DateCreated"]);
                   y.PaymentMethod = Convert.ToString(rdr["PaymentMethod"]);
                   x.Add(y);
               }
           }
           return x;
       }

       public static List<clsReports> search(string ID)
       {
           List<clsReports> x = new List<clsReports>();
           int i = 0;
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSearchReports", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsReports y = new clsReports();
                   y.ID = Convert.ToInt32((i += 1));
                   y.Product = Convert.ToString(rdr["Product"]);
                   y.Price = Convert.ToDouble(rdr["Price"]);
                   y.Qty = Convert.ToInt32(rdr["Qty"]);
                   y.DateCreated = Convert.ToString(rdr["DateCreated"]);
                   y.PaymentMethod = Convert.ToString(rdr["PaymentMethod"]);
                   x.Add(y);
               }
           }
           return x;
       }

       public static List<clsReports> GetAllReports()
       {
           List<clsReports> x = new List<clsReports>();
           int i = 0;
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectAllReports", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsReports y = new clsReports();
                   y.ID = Convert.ToInt32((i+=1));
                   y.Product = Convert.ToString(rdr["Product"]);
                   y.Price = Convert.ToDouble(rdr["Price"]);
                   y.Qty = Convert.ToInt32(rdr["Qty"]);
                   y.DateCreated = Convert.ToString(rdr["DateCreated"]);
                   y.PaymentMethod = Convert.ToString(rdr["PaymentMethod"]);
                   x.Add(y);
               }
           }
           return x;
       }

    }
}
