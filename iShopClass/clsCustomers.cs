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
   public class clsCustomers
    {

       public int ID { get; set; }
       public string FName { get; set; }
       public string SName { get; set; }
       public string Gender { get; set; }
       public string Email { get; set; }
       public string Tel { get; set; }
       public string City { get; set; }
       public string CAddress { get; set; }
       public string PinCode { get; set; }
       public string Remarks { get; set; }
       public string Flag { get; set; }

       public static int insert(clsCustomers x)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spInsertCustomers", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@fn", x.FName);
               cmd.Parameters.AddWithValue("@sn", x.SName);
               cmd.Parameters.AddWithValue("@g", x.Gender);
               cmd.Parameters.AddWithValue("@em", x.Email);
               cmd.Parameters.AddWithValue("@tel", x.Tel);
               cmd.Parameters.AddWithValue("@city", x.City);
               cmd.Parameters.AddWithValue("@ca", x.CAddress);
               cmd.Parameters.AddWithValue("@pin", x.PinCode);
               cmd.Parameters.AddWithValue("@remarks", x.Remarks);
               cmd.Parameters.AddWithValue("@flag", x.Flag);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int update(clsCustomers x)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spUpdateCustomers", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", x.ID);
               cmd.Parameters.AddWithValue("@fn", x.FName);
               cmd.Parameters.AddWithValue("@sn", x.SName);
               cmd.Parameters.AddWithValue("@g", x.Gender);
               cmd.Parameters.AddWithValue("@em", x.Email);
               cmd.Parameters.AddWithValue("@tel", x.Tel);
               cmd.Parameters.AddWithValue("@city", x.City);
               cmd.Parameters.AddWithValue("@ca", x.CAddress);
               cmd.Parameters.AddWithValue("@pin", x.PinCode);
               cmd.Parameters.AddWithValue("@remarks", x.Remarks);
               cmd.Parameters.AddWithValue("@flag", x.Flag);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int delete(int ID)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spDeleteCustomers", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id",ID);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static List<clsCustomers> select(int ID)
       {
           List<clsCustomers> x = new List<clsCustomers>();
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectCustomers", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsCustomers y = new clsCustomers();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.FName = Convert.ToString(rdr["FName"]);
                   y.SName = Convert.ToString(rdr["SName"]);
                   y.Gender = Convert.ToString(rdr["Gender"]);
                   y.Email = Convert.ToString(rdr["Email"]);
                   y.Tel = Convert.ToString(rdr["Tel"]);
                   y.City = Convert.ToString(rdr["City"]);
                   y.CAddress = Convert.ToString(rdr["CAddress"]);
                   y.PinCode = Convert.ToString(rdr["PinCode"]);
                   y.Remarks = Convert.ToString(rdr["Remarks"]);
                   y.Flag = Convert.ToString(rdr["Flag"]);

                   x.Add(y);
               }
           }
           return x;
       }

       public static List<clsCustomers> GetAllCustomers()
       {
           List<clsCustomers> x = new List<clsCustomers>();
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectAllCustomers", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsCustomers y = new clsCustomers();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.FName = Convert.ToString(rdr["FName"]);
                   y.SName = Convert.ToString(rdr["SName"]);
                   y.Gender = Convert.ToString(rdr["Gender"]);
                   y.Email = Convert.ToString(rdr["Email"]);
                   y.Tel = Convert.ToString(rdr["Tel"]);
                   y.City = Convert.ToString(rdr["City"]);
                   y.CAddress = Convert.ToString(rdr["CAddress"]);
                   y.PinCode = Convert.ToString(rdr["PinCode"]);
                   y.Remarks = Convert.ToString(rdr["Remarks"]);
                   y.Flag = Convert.ToString(rdr["Flag"]);

                   x.Add(y);
               }
           }
           return x;
       }

       public DataTable GetAll_DataTable()
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlDataAdapter adap = new SqlDataAdapter("shop.spSelectAllCustomers", conn);
               adap.SelectCommand.CommandType = CommandType.StoredProcedure;
               DataTable dt = new DataTable();
               adap.Fill(dt);
               return dt;
           }
       }

       public DataTable Search_DataTable(string param)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlDataAdapter adap = new SqlDataAdapter("shop.spSearchCustomers", conn);
               adap.SelectCommand.CommandType = CommandType.StoredProcedure;
               adap.SelectCommand.Parameters.AddWithValue("@id", param);
               DataTable dt = new DataTable();
               adap.Fill(dt);
               return dt;
           }
       }

       public static bool Exists(int ID)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();

               SqlDataAdapter adap = new SqlDataAdapter("shop.spExistsCustomers", conn);
               adap.SelectCommand.CommandType = CommandType.StoredProcedure;
               adap.SelectCommand.Parameters.AddWithValue("@id", ID);
               DataTable dt = new DataTable();
               adap.Fill(dt);
               if (dt.Rows.Count > 0)
                   return true;
               else
                   return false;
           }
       }

    }
}
