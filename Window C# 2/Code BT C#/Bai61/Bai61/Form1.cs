using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bai61
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        string sqlConn = "Server=ThanhTran;database=CSDLTest;user id=sa;pwd=@Hunggia113";
        private void btnDemSoSanPham_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(sqlConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select count(*) from SanPham";
            command.Connection = conn;

            object data = command.ExecuteScalar();
            int n = (int)data;
            lblSoSanPham.Text = "Có " + n + " sản phẩm ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(sqlConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Sanpham where ma=" + txtMaMuonTim.Text;
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())//có dữ liệu
            {
                txtMa.Text = reader.GetInt32(0)+"";
                txtTen.Text = reader.GetString(1);
                txtGia.Text = reader.GetInt32(2) + "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(sqlConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from SanPham where ma=@ma";
            command.Connection = conn;

            SqlParameter parma = new SqlParameter("@ma", SqlDbType.Int);
            parma.Value = txtMaMuonTim.Text;
            command.Parameters.Add(parma);

            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                txtMa.Text = reader.GetInt32(0) + "";
                txtTen.Text = reader.GetString(1);
                txtGia.Text = reader.GetInt32(2) + "";
            }
            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(sqlConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from SanPham";
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            lvSanPham.Items.Clear();
            while(reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader.GetInt32(0) + "");
                lvi.SubItems.Add(reader.GetString(1));
                lvi.SubItems.Add(reader.GetInt32(2) + "");

                lvSanPham.Items.Add(lvi);
            }
            reader.Close();
        }
    }
}
