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
    public partial class ThemMayBay : Form
    {
        private string connectionString = "sever=NguyenXuanThanh\\SQLEXPRESS;Database=quanlysanbay;Trusted_Connection=True;";
        public ThemMayBay()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string tenmb=txt_name.Text;
            int namsx=int.Parse(txt_year.Text);
            int sogiobay=int.Parse(txt_hour.Text);

            string query = "INSERT INTO maybay(Tenmb,Namsx,Sogiobay) VALUES(@Tenmb, @Namsx,@Sogiobay";
            
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Tenmb",tenmb);
                cmd.Parameters.AddWithValue("@Namsx",namsx);
                cmd.Parameters.AddWithValue("@Sogiobay",sogiobay);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Them thanh cong!", "Thong bao");
            }
        }
    }
}
