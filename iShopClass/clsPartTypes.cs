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
   public class clsPartTypes
    {
       public int ID { get; set; }
       public string Tag { get; set; }

      

       public static int insert(clsPartTypes x)
       {
           using(SqlConnection conn = new SqlConnection())
           {
               conn.ConnectionString = clsMain.sqlconnstring;
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spInsertPartTypes", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@tag",x.Tag);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int update(clsPartTypes x)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spUpdatePartTypes", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id",x.ID);
               cmd.Parameters.AddWithValue("@tag", x.Tag);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static int delete(int ID)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spDeletePartTypes", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id",ID);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static List<clsPartTypes> select(int ID)
       {
           List<clsPartTypes> x = new List<clsPartTypes>();
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectPartTypes", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id",ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsPartTypes y = new clsPartTypes();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.Tag = Convert.ToString(rdr["Tag"]);
                   x.Add(y);
               }
           }

           return x;
       }

       public static List<clsPartTypes> selectPartTypes(string ID)
       {
           List<clsPartTypes> x = new List<clsPartTypes>();
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSearchPartTypes", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsPartTypes y = new clsPartTypes();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.Tag = Convert.ToString(rdr["Tag"]);
                   x.Add(y);
               }
           }

           return x;
       }

       public static List<clsPartTypes> GetAllPartTypes()
       {          
           List<clsPartTypes> x = new List<clsPartTypes>();
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.spSelectAllPartTypes", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsPartTypes y = new clsPartTypes();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.Tag = Convert.ToString(rdr["Tag"]);

                   x.Add(y);
               }
           }
           return x;
       }

       public static bool Exists(int ID)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();

               SqlDataAdapter adap = new SqlDataAdapter("shop.spExistsPartTypes", conn);
               adap.SelectCommand.CommandType = CommandType.StoredProcedure;
               adap.SelectCommand.Parameters.AddWithValue("@id",ID);
               DataTable dt = new DataTable();
               adap.Fill(dt);
               if (dt.Rows.Count > 0)
                   return true;
               else
                   return false;
           }
       }

       public DataTable GetAllPartTypes_DataTable()
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();

               SqlDataAdapter adap = new SqlDataAdapter("shop.spSelectAllPartTypes", conn);
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

               SqlDataAdapter adap = new SqlDataAdapter("shop.spSearchPartTypes", conn);
               adap.SelectCommand.CommandType = CommandType.StoredProcedure;
               adap.SelectCommand.Parameters.AddWithValue("@id", param);
               DataTable dt = new DataTable();
               adap.Fill(dt);
               return dt;
           }
       }

    }
}
