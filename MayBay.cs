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
    public partial class MayBay : Form
    {
        private string connectionString = "Data Source=NguyenXuanThanh\\SQLEXPRESS;Database=quanlysanbay;Trusted_Connection=True;";
        public MayBay()
        {
            InitializeComponent();
        }

        private void LoadMayBay()
        {
            string query = "SELEC* FROM maybay ORDER BY Tenmb ASC";

        using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }

        }
        private void MayBay_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ThemMayBay themmaybayform = new ThemMayBay())
            {
                themmaybayform.ShowDialog();
                LoadMayBay();
            }

        }
    }
}
