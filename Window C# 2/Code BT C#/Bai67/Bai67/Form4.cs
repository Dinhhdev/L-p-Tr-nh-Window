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

namespace Bai67
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        DataSet ds;
        SqlDataAdapter adapter;
        BindingSource bs;

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection
                ("Server=ThanhTran;Database=CSDLTest;User Id=sa;pwd=@Hunggia113");
            adapter = new SqlDataAdapter("select * from SanPham", conn);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            ds = new DataSet();
            adapter.Fill(ds, "SanPham");

            bs = new BindingSource(ds, "SanPham");
            txtMa.DataBindings.Add("Text", bs, "Ma");
            txtTen.DataBindings.Add("Text",bs, "Ten");
            txtDonGia.DataBindings.Add("Text",bs, "DonGia");
            txtMaDanhMuc.DataBindings.Add("Text",bs, "MaDanhMuc");

            lblPosition.Text = "1/" + bs.Count;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            lblPosition.Text = (bs.Position+1)+"/" + bs.Count;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (bs.Position > 0)
                bs.Position--;
            lblPosition.Text = (bs.Position + 1) + "/" + bs.Count;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (bs.Position < bs.Count-1)
                bs.Position++;
            lblPosition.Text = (bs.Position + 1) + "/" + bs.Count;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
            lblPosition.Text = (bs.Position + 1) + "/" + bs.Count;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bs.AddNew();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            int kq = adapter.Update(ds.Tables["SanPham"]);
            if(kq>0)
            {
                MessageBox.Show("Đã lưu thành công");
            }
            else
            {
                MessageBox.Show("Đã lưu thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bs.RemoveCurrent();
            int kq = adapter.Update(ds.Tables[0]);
            if (kq > 0)
                MessageBox.Show("Xóa thành công");
            else
                MessageBox.Show("xóa thất bại");
        }
    }
}
