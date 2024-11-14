using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySanBay
{
    public partial class SuaMayBay : Form
    {
        private string connectionString = "sever=NguyenXuanThanh\\SQLEXPRESS;Database=quanlysanbay;Trusted_Connection=True;";
        private int mamb;
        public SuaMayBay()
        {
            InitializeComponent();
            this.mamb = mamb;
            LoadMayBaydata();
        }

        private void LoadMayBaydata()
        {
            string query = "SELECT* FROM maybay WHERE Mamb =@Mamb";
             
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Mamb", mamb);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    txt_name.Text = reader["Tenmb"].ToString();
                    txt_year.Text = reader["year"].ToString();
                    txt_hour.Text = reader["hour"].ToString();
                }
            }
        }

        private void btn_fix_Click(object sender, EventArgs e)
        {
            string tenmb = txt_name.Text;
            int namsx = int.Parse(txt_year.Text);
            int sogiobay = int.Parse(txt_hour.Text);

            string query = "UPDATE maybay SET Tenmb = @Tenmb, Namsx = @Namsx, Sogiobay = @Sogiobay";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Tenmb", tenmb);
                cmd.Parameters.AddWithValue("@Namsx", namsx);
                cmd.Parameters.AddWithValue("@Sogiobay", sogiobay);
                cmd.Parameters.AddWithValue("@Mamb",mamb);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sua thanh cong!", "Thong bao");
            }
        }
    }
}
