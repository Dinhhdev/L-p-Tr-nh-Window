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
namespace Bai64
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
            HienThiSanPham();
        }

        private void HienThiSanPham()
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

            lsbSanPham.Items.Clear();
            while(reader.Read())
            {
                int ma = reader.GetInt32(0);
                string ten = reader.GetString(1);
                lsbSanPham.Items.Add(ma+"-"+ten);
            }
            reader.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lsbSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Thím chưa chọn làm sao mà xóa...");
                return;
            }
            string line = lsbSanPham.SelectedItem + "";
            string[] arr = line.Split('-');
            int ma =int.Parse( arr[0]);

            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from SanPham where ma="+ma;
            command.Connection = conn;
            int ret = command.ExecuteNonQuery();
            if(ret>0)
            {
                HienThiSanPham();
                MessageBox.Show("Đã xóa thành công");
            }
            else
            {
                MessageBox.Show("Đã xóa thất bại");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lsbSanPham.SelectedIndex ==-1) return;
            string line = lsbSanPham.SelectedItem.ToString();
            string[] arr = line.Split('-');
            int ma = int.Parse(arr[0]);
            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from SanPham where Ma=@ma";
            command.Connection = conn;
            command.Parameters.Add("@ma",SqlDbType.Int).Value=ma;
            int ret = command.ExecuteNonQuery();
            if(ret>0)
            {
                HienThiSanPham();
                MessageBox.Show("Xóa thành công rồi thím ơi");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
    }
}
