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

namespace Bai62
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        string strConn = "Server=ThanhTran;Database=CSDLTest;User Id=sa;pwd=@Hunggia113";
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiToanBoSanPham();
        }
        private void HienThiToanBoSanPham()
        {
            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from SanPham";
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            lvSanPham.Items.Clear();
            while(reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader.GetInt32(0) + "");
                lvi.SubItems.Add(reader.GetString(1));
                lvi.SubItems.Add(reader.GetInt32(2)+"");

                lvSanPham.Items.Add(lvi);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;

            string sql = "Insert into SanPham(Ma,Ten,DonGia,MaDanhMuc) "+ 
                " values ("+txtMa.Text+",N'"+txtTen.Text+"',"+txtGia.Text+","+txtMaDanhMuc.Text+")";

            command.CommandText = sql;
            command.Connection = conn;

            int ret= command.ExecuteNonQuery();
            if(ret>0)
            {
                HienThiToanBoSanPham();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(strConn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "Insert into Sanpham(Ma,Ten,DonGia,MaDanhMuc) " +
                      " values(@ma,@ten,@gia,@madm)";
                command.CommandText = sql;
                command.Connection = conn;

                command.Parameters.Add("@ma", SqlDbType.Int).Value = txtMa.Text;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtTen.Text;
                command.Parameters.Add("@gia", SqlDbType.Int).Value = txtGia.Text;
                command.Parameters.Add("@madm", SqlDbType.Int).Value = txtMaDanhMuc.Text;

                int ret = command.ExecuteNonQuery();
                if (ret > 0)
                    HienThiToanBoSanPham();
                else
                    MessageBox.Show("Thêm Thất bại");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi rồi thím:\n"+ex.Message);
            }
        }
    }
}
