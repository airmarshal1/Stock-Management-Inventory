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
    public class clsDebtors
    {
        public int ID { get; set; }
        public string DebtorNO { get; set; }
        public DateTime DebtorDate { get; set; }
        public int PID { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string CAddress { get; set; }
        public int Qty { get; set; }
        public Boolean IsPaid { get; set; }
        public string Flag { get; set; }
        public string PRemarks { get; set; }
        public string DRemarks { get; set; }
        public string Product { get; set; }

        public static int insert(clsDebtors x)
        {
            using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("shop.spInsertDebtors", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@dn", x.DebtorNO);
                cmd.Parameters.AddWithValue("@dd", x.DebtorDate);
                cmd.Parameters.AddWithValue("@p", x.PID);
                cmd.Parameters.AddWithValue("@fn", x.FName);
                cmd.Parameters.AddWithValue("@ln", x.SName);
                cmd.Parameters.AddWithValue("@e", x.Email);
                cmd.Parameters.AddWithValue("@t", x.Tel);
                cmd.Parameters.AddWithValue("@c", x.CAddress);
                cmd.Parameters.AddWithValue("@q", x.Qty);
                cmd.Parameters.AddWithValue("@i", x.IsPaid);
                cmd.Parameters.AddWithValue("@r", x.DRemarks);
                cmd.Parameters.AddWithValue("@f", x.Flag);
                int r = cmd.ExecuteNonQuery();
                return r;
            }
        }

        public static int update(clsDebtors x)
        {
            using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("shop.spUpdateDebtors", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", x.ID);
                //cmd.Parameters.AddWithValue("@dn", x.DebtorNO);
                cmd.Parameters.AddWithValue("@dd", x.DebtorDate);
                cmd.Parameters.AddWithValue("@p", x.PID);
                cmd.Parameters.AddWithValue("@fn", x.FName);
                cmd.Parameters.AddWithValue("@ln", x.SName);
                cmd.Parameters.AddWithValue("@e", x.Email);
                cmd.Parameters.AddWithValue("@t", x.Tel);
                cmd.Parameters.AddWithValue("@c", x.CAddress);
                cmd.Parameters.AddWithValue("@q", x.Qty);
                cmd.Parameters.AddWithValue("@i", x.IsPaid);
                cmd.Parameters.AddWithValue("@r", x.DRemarks);
                cmd.Parameters.AddWithValue("@f", x.Flag);
                int r = cmd.ExecuteNonQuery();
                return r;
            }
        }

        public static int delete(int ID)
        {
            using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("shop.spDeleteDebtors", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                int r = cmd.ExecuteNonQuery();
                return r;
            }
        }

        public static List<clsDebtors> select(int ID)
        {
            List<clsDebtors> x = new List<clsDebtors>();
            using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("shop.spSelectDebtors", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clsDebtors y = new clsDebtors();
                    y.ID = Convert.ToInt32(rdr["ID"]);
                    y.DebtorNO = Convert.ToString(rdr["DebtorNO"]);
                    y.DebtorDate = Convert.ToDateTime(rdr["DebtorDate"]);
                    y.Product = Convert.ToString(rdr["PartName"]);
                    y.FName = Convert.ToString(rdr["FName"]);
                    y.SName = Convert.ToString(rdr["SName"]);
                    y.Email = Convert.ToString(rdr["Email"]);
                    y.Tel = Convert.ToString(rdr["Tel"]);
                    y.CAddress = Convert.ToString(rdr["CAddress"]);
                    y.Qty = Convert.ToInt32(rdr["Qty"]);
                    y.IsPaid = Convert.ToBoolean(rdr["IsPaid"]);
                    y.PRemarks = Convert.ToString(rdr["PRemarks"]);
                    y.DRemarks = Convert.ToString(rdr["DRemarks"]);
                    y.Flag = Convert.ToString(rdr["Flag"]);

                    x.Add(y);
                }
            }
            return x;
        }

        public static List<clsDebtors> GetAllDebtors()
        {
            List<clsDebtors> x = new List<clsDebtors>();
            using (SqlConnection conn = new SqlConnection(clsMain.sqlconnstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("shop.spSelectAllDebtors", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clsDebtors y = new clsDebtors();
                    y.ID = Convert.ToInt32(rdr["ID"]);
                    y.DebtorNO = Convert.ToString(rdr["DebtorNO"]);
                    y.DebtorDate = Convert.ToDateTime(rdr["DebtorDate"]);
                    y.Product = Convert.ToString(rdr["PartName"]);
                    y.FName = Convert.ToString(rdr["FName"]);
                    y.SName = Convert.ToString(rdr["SName"]);
                    y.Email = Convert.ToString(rdr["Email"]);
                    y.Tel = Convert.ToString(rdr["Tel"]);
                    y.CAddress = Convert.ToString(rdr["CAddress"]);
                    y.Qty = Convert.ToInt32(rdr["Qty"]);
                    y.IsPaid = Convert.ToBoolean(rdr["IsPaid"]);
                    y.PRemarks = Convert.ToString(rdr["PRemarks"]);
                    y.DRemarks = Convert.ToString(rdr["DRemarks"]);
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
                SqlDataAdapter adap = new SqlDataAdapter("shop.spSelectAllDebtors", conn);
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
                SqlDataAdapter adap = new SqlDataAdapter("shop.spSearchDebtors", conn);
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

                SqlDataAdapter adap = new SqlDataAdapter("shop.spExistsDebtors", conn);
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
