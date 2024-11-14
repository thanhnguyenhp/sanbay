using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLySanBay
{
    public class databaseConnecting
    {
        private string connectionString = "Data Source=NguyenXuanThanh\\SQLEXPRESS;Database=quanlysanbay;Trusted_Connection=True;";

        public void insertmaybay(string tenmb, int namsx, int sogiobay)
        {
            string query = "INSERT INTO maybay(Tenmb, Namsx,Sogiobay) VALUES(@Tenmb,@Namsx,@Sogiobay)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Tenmb",tenmb);
                cmd.Parameters.AddWithValue("@Namsx", namsx);
                cmd.Parameters.AddWithValue("@Sogiobay", sogiobay);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
