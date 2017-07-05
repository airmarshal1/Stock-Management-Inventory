using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace iShopClass
{
   public class clsPractice : clsMain
    {
       public int ID { get; set; }
       public string FullName { get; set; }
       public byte[] Flag { get; set; }
       public string FlagName { get; set; }

       public static int insert(clsPractice x)
       {
           using(SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.pInsert", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@n", x.FullName);
               cmd.Parameters.AddWithValue("@f", x.Flag);
               cmd.Parameters.AddWithValue("@fn", x.FlagName);
                int r= cmd.ExecuteNonQuery();
                return r;
           }
       }

       public static int update(clsPractice x)
       {
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.pUpdate", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id", x.ID);
               cmd.Parameters.AddWithValue("@n", x.FullName);
               cmd.Parameters.AddWithValue("@f", x.Flag);
               cmd.Parameters.AddWithValue("@fn", x.FlagName);
               int r = cmd.ExecuteNonQuery();
               return r;
           }
       }

       public static List<clsPractice> Select(int ID)
       {
           List<clsPractice> x = new List<clsPractice>();
           using(SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.pSelect",conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@id",ID);
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsPractice y = new clsPractice();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.FullName = Convert.ToString(rdr["FullName"]);
                   y.Flag =  (byte[])(rdr["Flag"]);
                   y.FlagName = Convert.ToString(rdr["FlagName"]);
                   x.Add(y);
               }
           }
           return x;
       }

       public static List<clsPractice> GetAll()
       {
           List<clsPractice> x = new List<clsPractice>();
           using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
           {
               conn.Open();
               SqlCommand cmd = new SqlCommand("shop.pSelectAll",conn);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader rdr = cmd.ExecuteReader();
               while (rdr.Read())
               {
                   clsPractice y = new clsPractice();
                   y.ID = Convert.ToInt32(rdr["ID"]);
                   y.FullName = Convert.ToString(rdr["FullName"]);
                   y.Flag = (byte[])(rdr["Flag"]);
                   y.FlagName = Convert.ToString(rdr["FlagName"]);
                   x.Add(y);
               }
           }
           return x;
       }
    }
}
