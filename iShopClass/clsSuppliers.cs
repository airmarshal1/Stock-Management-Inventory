using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;

namespace iShopClass
{
  public  class clsSuppliers
    {

      public int ID { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }
      public string Tel { get; set; }
      public string City { get; set; }
      public string CAddress { get; set; }
      public string Remarks { get; set; }
      public string Flag { get; set; }

      public byte[] Flagg { get; set; }

      //[NotMapped]
      //public Image Picture
      //{
      //    get
      //    {
      //        if (!String.IsNullOrEmpty(Flag))
      //        {
      //            if(File.Exists(Flag))
      //            {
      //                return Image.FromFile(Flag);
      //            }                  
      //        }
      //        return null;
      //    }
      //}

      public static int insert(clsSuppliers x)
      {
          using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
          {
              conn.Open();
              SqlCommand cmd = new SqlCommand("shop.spInsertSuppliers", conn);
              cmd.CommandType = CommandType.StoredProcedure;
              string f= "Unknown";
              cmd.Parameters.AddWithValue("@fn", x.Name);
              cmd.Parameters.AddWithValue("@em",x.Email);
              cmd.Parameters.AddWithValue("@tel", x.Tel);
              cmd.Parameters.AddWithValue("@city",x.City);
              cmd.Parameters.AddWithValue("@ca", x.CAddress);
              cmd.Parameters.AddWithValue("@remarks",x.Remarks);
              cmd.Parameters.AddWithValue("@flag",f);
              int r = cmd.ExecuteNonQuery();
              return r;
          }
      }

      public static int update(clsSuppliers x)
      {
          using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
          {
              conn.Open();
              SqlCommand cmd = new SqlCommand("shop.spUpdateSuppliers", conn);
              cmd.CommandType = CommandType.StoredProcedure;
              string f = "Unknown";
              cmd.Parameters.AddWithValue("@id", x.ID);
              cmd.Parameters.AddWithValue("@fn", x.Name);
              cmd.Parameters.AddWithValue("@em", x.Email);
              cmd.Parameters.AddWithValue("@tel", x.Tel);
              cmd.Parameters.AddWithValue("@city", x.City);
              cmd.Parameters.AddWithValue("@ca", x.CAddress);
              cmd.Parameters.AddWithValue("@remarks", x.Remarks);
              cmd.Parameters.AddWithValue("@flag", f);
              int r = cmd.ExecuteNonQuery();
              return r;
          }
      }

      public static int delete(int ID)
      {
          using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
          {
              conn.Open();
              SqlCommand cmd = new SqlCommand("shop.spDeleteSuppliers", conn);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@id",ID);
              int r = cmd.ExecuteNonQuery();
              return r;
          }
      }

      public static List<clsSuppliers> select(int ID)
      {
          List<clsSuppliers> x = new List<clsSuppliers>();
          using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
          {
              conn.Open();
              SqlCommand cmd = new SqlCommand("shop.spSelectSuppliers", conn);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@id", ID);
              SqlDataReader rdr = cmd.ExecuteReader();
              while (rdr.Read())
              {
                  clsSuppliers y = new clsSuppliers();
                  y.ID = Convert.ToInt32(rdr["ID"]);
                  y.Name = Convert.ToString(rdr["Name"]);
                  y.Email = Convert.ToString(rdr["Email"]);
                  y.Tel = Convert.ToString(rdr["Tel"]);
                  y.City = Convert.ToString(rdr["City"]);
                  y.CAddress = Convert.ToString(rdr["CAddress"]);
                  y.Remarks = Convert.ToString(rdr["Remarks"]);
                  y.Flag = Convert.ToString(rdr["Flag"]);

                  x.Add(y);
              }
          }
          return x;
      }

      public static List<clsSuppliers> selectSupplier(string ID)
      {
          List<clsSuppliers> x = new List<clsSuppliers>();
          using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
          {
              conn.Open();
              SqlCommand cmd = new SqlCommand("shop.spSearchSuppliers", conn);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@id", ID);
              SqlDataReader rdr = cmd.ExecuteReader();
              while (rdr.Read())
              {
                  clsSuppliers y = new clsSuppliers();
                  y.ID = Convert.ToInt32(rdr["ID"]);
                  y.Name = Convert.ToString(rdr["Name"]);
                  y.Email = Convert.ToString(rdr["Email"]);
                  y.Tel = Convert.ToString(rdr["Tel"]);
                  y.City = Convert.ToString(rdr["City"]);
                  y.CAddress = Convert.ToString(rdr["CAddress"]);
                  y.Remarks = Convert.ToString(rdr["Remarks"]);
                  y.Flag = Convert.ToString(rdr["Flag"]);

                  x.Add(y);
              }
          }
          return x;
      }

      public static List<clsSuppliers> GetAllSuppliers()
      {
          List<clsSuppliers> x = new List<clsSuppliers>();
          using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
          {
              conn.Open();
              SqlCommand cmd = new SqlCommand("shop.spSelectAllSuppliers", conn);
              cmd.CommandType = CommandType.StoredProcedure;
              SqlDataReader rdr = cmd.ExecuteReader();
              while (rdr.Read())
              {
                  clsSuppliers y = new clsSuppliers();
                  y.ID = Convert.ToInt32(rdr["ID"]);
                  y.Name = Convert.ToString(rdr["Name"]);
                  y.Email = Convert.ToString(rdr["Email"]);
                  y.Tel = Convert.ToString(rdr["Tel"]);
                  y.City = Convert.ToString(rdr["City"]);
                  y.CAddress = Convert.ToString(rdr["CAddress"]);
                  y.Remarks = Convert.ToString(rdr["Remarks"]);
                  y.Flag = Convert.ToString(rdr["Flag"]);

                  x.Add(y);
              }
          }
          return x;
      }

      public  DataTable GetAllSuppliers_DataTable()
      {
          using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
          {
              conn.Open();
              SqlDataAdapter adap = new SqlDataAdapter("shop.spSelectAllSuppliers", conn);
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
              SqlDataAdapter adap = new SqlDataAdapter("shop.spSearchSuppliers", conn);
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

              SqlDataAdapter adap = new SqlDataAdapter("shop.spExistsSuppliers", conn);
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
