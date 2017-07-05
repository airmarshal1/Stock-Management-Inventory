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
   public class clsDevelopers
    {
       
       public struct Developers
       {
           public int ID { get; set; }
           public string FName { get; set; }
           public string LName { get; set; }
           public string Gender { get; set; }
           public string Email { get; set; }
           public string Tel { get; set; }
           public string City { get; set; }
           public string CAddress { get; set; }
           public string CState { get; set; }
           public string Hobbies { get; set; }
           public string Speciality { get; set; }
           public string Remarks { get; set; }
           public string Flag { get; set; }
       }

       public Developers[] GetAllDevelopers()
       {
           try
           {
               using( SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
               {
                   conn.Open();
                   SqlDataAdapter adap = new SqlDataAdapter("shop.spSelectAllDevelopers", conn);
                   adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                   DataSet ds = new DataSet();
                   adap.Fill(ds);
                   Developers[] x = new Developers[ds.Tables[0].Rows.Count];
                   for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                   {
                       x[i].ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                       x[i].FName = Convert.ToString(ds.Tables[0].Rows[i]["FName"].ToString());
                       x[i].LName = Convert.ToString(ds.Tables[0].Rows[i]["LName"].ToString());
                       x[i].Gender = Convert.ToString(ds.Tables[0].Rows[i]["Gender"].ToString());
                       x[i].Tel = Convert.ToString(ds.Tables[0].Rows[i]["Tel"].ToString());
                       x[i].Email = Convert.ToString(ds.Tables[0].Rows[i]["Email"].ToString());
                       x[i].CAddress = Convert.ToString(ds.Tables[0].Rows[i]["CAddress"].ToString());
                       x[i].CState = Convert.ToString(ds.Tables[0].Rows[i]["CState"].ToString());
                       x[i].Speciality = Convert.ToString(ds.Tables[0].Rows[i]["Speciality"].ToString());
                       x[i].Hobbies = Convert.ToString(ds.Tables[0].Rows[i]["Hobbies"].ToString());
                       x[i].Flag = Convert.ToString(ds.Tables[0].Rows[i]["Flag"].ToString());
                       x[i].Remarks = Convert.ToString(ds.Tables[0].Rows[i]["Review"].ToString());
                   }
                   return x;
               }
           }
           catch (Exception)
           {
               
               throw;
           }
       }

    }
}
