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
   public class clsParts
    {

       public int ID { get; set; }
       public string PartName { get; set; }
       public int PartType { get; set; }
       public string PartTypee { get; set; }
       public int SUID { get; set; }
       public string SupplierName { get; set; }
       public int StockLevel { get; set; }
       public int MinStockLevel { get; set; }
       public double CostPrice { get; set; }
       public double SellingPrice { get; set; }
       public double Discount { get; set; }
       public string Location { get; set; }
       public string Flag { get; set; }
       public string Remarks { get; set; }

       public static int insert(clsParts x)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spInsertPart", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               string f = "Unknown";
               cmd.Parameters.AddWithValue("@pn", x.PartName);
               cmd.Parameters.AddWithValue("@pt",x.PartType);
               cmd.Parameters.AddWithValue("@suid",x.SUID);
               cmd.Parameters.AddWithValue("@sl", x.StockLevel);
               cmd.Parameters.AddWithValue("@msl",x.MinStockLevel);
               cmd.Parameters.AddWithValue("@cp", x.CostPrice);
               cmd.Parameters.AddWithValue("@sp",x.SellingPrice);
               cmd.Parameters.AddWithValue("@d",x.Discount);
               cmd.Parameters.AddWithValue("@l", x.Location);
               cmd.Parameters.AddWithValue("@f",f);
               cmd.Parameters.AddWithValue("@r",x.Remarks);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int update(clsParts x)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spUpdatePart", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               string f = "Unknown";
               cmd.Parameters.AddWithValue("@id", x.ID);
               cmd.Parameters.AddWithValue("@pn", x.PartName);
               cmd.Parameters.AddWithValue("@pt", x.PartType);
               cmd.Parameters.AddWithValue("@suid", x.SUID);
               cmd.Parameters.AddWithValue("@sl", x.StockLevel);
               cmd.Parameters.AddWithValue("@msl", x.MinStockLevel);
               cmd.Parameters.AddWithValue("@cp", x.CostPrice);
               cmd.Parameters.AddWithValue("@sp", x.SellingPrice);
               cmd.Parameters.AddWithValue("@d", x.Discount);
               cmd.Parameters.AddWithValue("@l", x.Location);
               cmd.Parameters.AddWithValue("@f", f);
               cmd.Parameters.AddWithValue("@r", x.Remarks);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int delete(int ID)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spDeletePart", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id",ID);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static List<clsParts> select(int ID)
       {
           List<clsParts> x = new List<clsParts>();
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectPart", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsParts y = new clsParts();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.PartName = Convert.ToString(rdr["PartName"]);
                   y.PartTypee = Convert.ToString(rdr["PartType"]);
                   y.SupplierName = Convert.ToString(rdr["SupplierName"]);
                   y.StockLevel = Convert.ToInt32(rdr["StockLevel"]);
                   y.MinStockLevel = Convert.ToInt32(rdr["MinStockLevel"]);
                   y.CostPrice = Convert.ToDouble(rdr["CostPrice"]);
                   y.SellingPrice = Convert.ToDouble(rdr["SellingPrice"]);
                   y.Discount = Convert.ToDouble(rdr["Discount"]);
                   y.Location = Convert.ToString(rdr["Location"]);
                   y.Remarks = Convert.ToString(rdr["Remarks"]);
                   y.Flag = Convert.ToString(rdr["Flag"]);

                   x.Add(y);
               }
           }
           return x;
       }

       public static List<clsParts> search(string ID)
       {
           List<clsParts> x = new List<clsParts>();
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSearchPart", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsParts y = new clsParts();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.PartName = Convert.ToString(rdr["PartName"]);
                   y.PartTypee = Convert.ToString(rdr["PartType"]);
                   y.SupplierName = Convert.ToString(rdr["SupplierName"]);
                   y.StockLevel = Convert.ToInt32(rdr["StockLevel"]);
                   y.MinStockLevel = Convert.ToInt32(rdr["MinStockLevel"]);
                   y.CostPrice = Convert.ToDouble(rdr["CostPrice"]);
                   y.SellingPrice = Convert.ToDouble(rdr["SellingPrice"]);
                   y.Discount = Convert.ToDouble(rdr["Discount"]);
                   y.Location = Convert.ToString(rdr["Location"]);
                   y.Remarks = Convert.ToString(rdr["Remarks"]);
                   y.Flag = Convert.ToString(rdr["Flag"]);

                   x.Add(y);
               }
           }
           return x;
       }

       public static List<clsParts> search2(string ID)
       {
           List<clsParts> x = new List<clsParts>();
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSearchPart2", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsParts y = new clsParts();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.PartName = Convert.ToString(rdr["PartName"]);
                   y.PartTypee = Convert.ToString(rdr["PartType"]);
                   y.SupplierName = Convert.ToString(rdr["SupplierName"]);
                   y.StockLevel = Convert.ToInt32(rdr["StockLevel"]);
                   y.MinStockLevel = Convert.ToInt32(rdr["MinStockLevel"]);
                   y.CostPrice = Convert.ToDouble(rdr["CostPrice"]);
                   y.SellingPrice = Convert.ToDouble(rdr["SellingPrice"]);
                   y.Discount = Convert.ToDouble(rdr["Discount"]);
                   y.Location = Convert.ToString(rdr["Location"]);
                   y.Remarks = Convert.ToString(rdr["Remarks"]);
                   y.Flag = Convert.ToString(rdr["Flag"]);

                   x.Add(y);
               }
           }
           return x;
       }


       public static List<clsParts> GetAllParts()
       {
           List<clsParts> x = new List<clsParts>();
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectAllPart", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsParts y = new clsParts();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.PartName = Convert.ToString(rdr["PartName"]);
                   y.PartTypee = Convert.ToString(rdr["PartType"]);
                   y.SupplierName = Convert.ToString(rdr["SupplierName"]);
                   y.StockLevel = Convert.ToInt32(rdr["StockLevel"]);
                   y.MinStockLevel = Convert.ToInt32(rdr["MinStockLevel"]);
                   y.CostPrice = Convert.ToDouble(rdr["CostPrice"]);
                   y.SellingPrice = Convert.ToDouble(rdr["SellingPrice"]);
                   y.Discount = Convert.ToDouble(rdr["Discount"]);
                   y.Location = Convert.ToString(rdr["Location"]);
                   y.Remarks = Convert.ToString(rdr["Remarks"]);
                   y.Flag = Convert.ToString(rdr["Flag"]);

                   x.Add(y);
               }
           }
           return x;
       }

       public static List<clsParts> GetAllParts2()
       {
           List<clsParts> x = new List<clsParts>();
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectAllPart2", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsParts y = new clsParts();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.PartName = Convert.ToString(rdr["PartName"]);
                   y.PartTypee = Convert.ToString(rdr["PartType"]);
                   y.SupplierName = Convert.ToString(rdr["SupplierName"]);
                   y.StockLevel = Convert.ToInt32(rdr["StockLevel"]);
                   y.MinStockLevel = Convert.ToInt32(rdr["MinStockLevel"]);
                   y.CostPrice = Convert.ToDouble(rdr["CostPrice"]);
                   y.SellingPrice = Convert.ToDouble(rdr["SellingPrice"]);
                   y.Discount = Convert.ToDouble(rdr["Discount"]);
                   y.Location = Convert.ToString(rdr["Location"]);
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
               SqlDataAdapter adap = new SqlDataAdapter("shop.spSelectAllPart", conn);
               adap.SelectCommand.CommandType = CommandType.StoredProcedure;
               DataTable dt = new DataTable();
               adap.Fill(dt);
               return dt;
           }
       }

       public DataTable GetAll_DataTable2()
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlDataAdapter adap = new SqlDataAdapter("shop.spSelectAllPart2", conn);
               adap.SelectCommand.CommandType = CommandType.StoredProcedure;
               DataTable dt = new DataTable();
               adap.Fill(dt);
               return dt;
           }
       }

       public DataTable GetAll_DataTable3()
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlDataAdapter adap = new SqlDataAdapter("shop.spSelectAllPart3", conn);
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
               SqlDataAdapter adap = new SqlDataAdapter("shop.spSearchPart", conn);
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

               SqlDataAdapter adap = new SqlDataAdapter("shop.spExistsParts", conn);
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
