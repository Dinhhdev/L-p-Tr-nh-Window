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
namespace Bai66
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        string strConn = "Server=ThanhTran;database=CSDLTest;User Id=sa;pwd=@Hunggia113";
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        private void btnNap_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(strConn);

            adapter = new SqlDataAdapter("Select * from SanPham", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            ds = new DataSet();
            adapter.Fill(ds,"SanPham");

            gvSanPham.DataSource = ds.Tables["SanPham"];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["SanPham"].NewRow();
            row["Ma"] = txtMa.Text;
            row["Ten"] = txtTen.Text;
            row["DonGia"] = txtGia.Text;
            row["MaDanhMuc"] = txtMaDM.Text;

            ds.Tables["SanPham"].Rows.Add(row);

            int kq = adapter.Update(ds.Tables["SanPham"]);
            if(kq>0)
            {
                btnNap.PerformClick();
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại");
            }
        }

        private void gvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int vt = -1;
        private void gvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt == -1) return;
            DataRow row = ds.Tables["SanPham"].Rows[vt];
            txtMa.Text = row["Ma"]+"";
            txtTen.Text = row["Ten"]+"";
            txtGia.Text = row["dongia"]+"";
            txtMaDM.Text = row["Madanhmuc"]+"";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (vt == -1)
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để sửa");
                return;
            }
            DataRow row = ds.Tables["SanPham"].Rows[vt];
            row.BeginEdit();

            row["Ma"] = txtMa.Text;
            row["Ten"] = txtTen.Text;
            row["DonGia"] = txtGia.Text;
            row["MaDanhMuc"] = txtMaDM.Text;

            row.EndEdit();

            int kq = adapter.Update(ds.Tables["SanPham"]);
            if(kq>0)
            {
                btnNap.PerformClick();
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (vt == -1)
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xỏa");
                return;
            }
            DataRow row = ds.Tables["SanPham"].Rows[vt];
            row.Delete();

            int kq = adapter.Update(ds.Tables["SanPham"]);
            if(kq>0)
            {
                btnNap.PerformClick();
                MessageBox.Show("Đã xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
    }
}
