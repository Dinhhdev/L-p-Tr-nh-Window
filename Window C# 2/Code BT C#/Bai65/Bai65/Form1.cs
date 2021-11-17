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
namespace Bai65
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
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "LayToanBoSanPham";
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            lvSanPham.Items.Clear();
            while(reader.Read())
            {
                int ma = reader.GetInt32(0);
                string ten = reader.GetString(1);
                int gia = reader.GetInt32(2);
                ListViewItem lvi = new ListViewItem(ma + "");
                lvi.SubItems.Add(ten);
                lvi.SubItems.Add(gia + "");
                lvSanPham.Items.Add(lvi);
            }
            reader.Close();
        }

        private void lvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSanPham.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvSanPham.SelectedItems[0];
            int ma =int.Parse( lvi.SubItems[0].Text);
            HienThiChiTietSanPham(ma);
        }
        private void HienThiChiTietSanPham(int ma)
        {
            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ChiTietSanPham";
            command.Connection = conn;

            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.Int);
            parMa.Value = ma;
            command.Parameters.Add(parMa);

            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                txtMa.Text = reader.GetInt32(0) + "";
                txtTen.Text = reader.GetString(1);
                txtGia.Text = reader.GetInt32(2)+"";
                txtMaDM.Text = reader.GetInt32(3) + "";
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
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ThemSanPham";
            command.Connection = conn;

            command.Parameters.Add("@ma", SqlDbType.Int).Value = txtMa.Text;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtTen.Text;
            command.Parameters.Add("@gia", SqlDbType.Int).Value = txtGia.Text;
            command.Parameters.Add("@madm", SqlDbType.Int).Value = txtMaDM.Text;

            int ret = command.ExecuteNonQuery();
            if(ret>0)
            {
                HienThiToanBoSanPham();
                MessageBox.Show("Đã thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "CapNhatGia";
            command.Connection = conn;
            command.Parameters.Add("@ma",SqlDbType.Int).Value=txtMa.Text;
            command.Parameters.Add("@dongia",SqlDbType.Int).Value=txtGia.Text;

            int ret = command.ExecuteNonQuery();
            if(ret>0)
            {
                HienThiToanBoSanPham();
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "XoaSanPham";
            command.Connection = conn;

            command.Parameters.Add("@ma",SqlDbType.Int).Value=txtMa.Text;

            int ret = command.ExecuteNonQuery();
            if(ret>0)
            {
                HienThiToanBoSanPham();
                MessageBox.Show("Đã xóa thành công");
            }
            else { MessageBox.Show("Xóa thất bại"); }
        }
    }
}
