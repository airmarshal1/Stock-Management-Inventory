using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace iShopClass
{
   public class clsCompanyInfo
    {

       public int ID { get; set; }
       public string CName { get; set; }
       public string CAddress { get; set; }
       public string Tel { get; set; }
       public string Email { get; set; }
       public string Tin { get; set; }
       public string STNO { get; set; }
       public string CIN { get; set; }
       public string Flag { get; set; }
       public string FileName { get; set; }

       public byte[] Image { get; set; }

       public static int insert(clsCompanyInfo x)
       {
           using (SqlConnection conn = new SqlConnection(iShopClass.clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spInsertCompanyInfo", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@cn", x.CName);
               cmd.Parameters.AddWithValue("@ca", x.CAddress);
               cmd.Parameters.AddWithValue("@tel",x.Tel);
               cmd.Parameters.AddWithValue("@em", x.Email);
               cmd.Parameters.AddWithValue("@tin",x.Tin);
               cmd.Parameters.AddWithValue("@stno",x.STNO);
               cmd.Parameters.AddWithValue("@cin",x.CIN);
               cmd.Parameters.AddWithValue("@flag",x.Image);
               cmd.Parameters.AddWithValue("@fn",x.FileName);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int update(clsCompanyInfo x)
       {
           using (SqlConnection conn = new SqlConnection(iShopClass.clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spUpdateCompanyInfo", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", x.ID);
               cmd.Parameters.AddWithValue("@cn", x.CName);
               cmd.Parameters.AddWithValue("@ca", x.CAddress);
               cmd.Parameters.AddWithValue("@tel", x.Tel);
               cmd.Parameters.AddWithValue("@em", x.Email);
               cmd.Parameters.AddWithValue("@tin", x.Tin);
               cmd.Parameters.AddWithValue("@stno", x.STNO);
               cmd.Parameters.AddWithValue("@cin", x.CIN);
               cmd.Parameters.AddWithValue("@flag", x.Image);
               cmd.Parameters.AddWithValue("@fn", x.FileName);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int delete(int ID)
       {
           using (SqlConnection conn = new SqlConnection(iShopClass.clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spDeleteCompanyInfo", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id",ID);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static List<clsCompanyInfo> select(int ID)
       {
           List<clsCompanyInfo> x = new List<clsCompanyInfo>();
           using (SqlConnection conn = new SqlConnection(iShopClass.clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectCompanyInfo", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsCompanyInfo y = new clsCompanyInfo();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.CName = Convert.ToString(rdr["CName"]);
                   y.Email = Convert.ToString(rdr["Email"]);
                   y.Tel = Convert.ToString(rdr["Tel"]);
                   y.Tin = Convert.ToString(rdr["Tin"]);
                   y.STNO = Convert.ToString(rdr["STNO"]);
                   y.CIN = Convert.ToString(rdr["CIN"]);
                   y.CAddress = Convert.ToString(rdr["CAddress"]);
                   //y.Flag = Convert.ToString(rdr["Flag"]);
                   y.FileName = Convert.ToString(rdr["FileNamee"]);

                   x.Add(y);
               }
           }
           return x;
       }

       public static List<clsCompanyInfo> seearch(string ID)
       {
           List<clsCompanyInfo> x = new List<clsCompanyInfo>();
           using (SqlConnection conn = new SqlConnection(iShopClass.clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSearchCompanyInfo", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsCompanyInfo y = new clsCompanyInfo();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.CName = Convert.ToString(rdr["CName"]);
                   y.Email = Convert.ToString(rdr["Email"]);
                   y.Tel = Convert.ToString(rdr["Tel"]);
                   y.Tin = Convert.ToString(rdr["Tin"]);
                   y.STNO = Convert.ToString(rdr["STNO"]);
                   y.CIN = Convert.ToString(rdr["CIN"]);
                   y.CAddress = Convert.ToString(rdr["CAddress"]);
                   y.FileName = Convert.ToString(rdr["FileNamee"]);

                   x.Add(y);
               }
           }
           return x;
       }

       public static List<clsCompanyInfo> GetAllCompanyInfo()
       {
           List<clsCompanyInfo> x = new List<clsCompanyInfo>();
           using (SqlConnection conn = new SqlConnection(iShopClass.clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectAllCompanyInfo", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsCompanyInfo y = new clsCompanyInfo();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.CName = Convert.ToString(rdr["CName"]);
                   y.Email = Convert.ToString(rdr["Email"]);
                   y.Tel = Convert.ToString(rdr["Tel"]);
                   y.Tin = Convert.ToString(rdr["Tin"]);
                   y.STNO = Convert.ToString(rdr["STNO"]);
                   y.CIN = Convert.ToString(rdr["CIN"]);
                   y.CAddress = Convert.ToString(rdr["CAddress"]);
                   //y.Flag = Convert.ToString(rdr["Flag"]);
                   y.FileName = Convert.ToString(rdr["FileNamee"]);

                   x.Add(y);
               }
           }
           return x;
       }

       public DataTable GetAll_DataTable()
       {
           using (SqlConnection conn = new SqlConnection(iShopClass.clsMain.sqlconnstring))
           {
               conn.Open();
               SqlDataAdapter adap = new SqlDataAdapter("shop.spSelectAllCompanyInfo", conn);
               adap.SelectCommand.CommandType = CommandType.StoredProcedure;
               DataTable dt = new DataTable();
               adap.Fill(dt);
               return dt;
           }
       }       

       public static bool Exists(int ID)
       {
           using (SqlConnection conn = new SqlConnection(iShopClass.clsMain.sqlconnstring))
           {
               conn.Open();

               SqlDataAdapter adap = new SqlDataAdapter("shop.spExistsCompanyInfo", conn);
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
