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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection
            ("Server=ThanhTran;Database=CSDLTest;User id=sa;pwd=@Hunggia113");
        bool finished = false;
        private void Form3_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapterDanhMuc =
                new SqlDataAdapter("Select * from DanhMuc",conn);
            DataSet dsDm = new DataSet();
            adapterDanhMuc.Fill(dsDm);

            finished = false;
            cboDanhMuc.DataSource = dsDm.Tables[0];
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";

            finished = true;

        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDanhMuc.SelectedIndex == -1) return;
            if (finished == false) return;

            int madm = (int)cboDanhMuc.SelectedValue;

            SqlDataAdapter adapterSanPham = 
                new SqlDataAdapter("Select * from SanPham where MaDanhMuc="+madm,conn);
            DataSet dsSp = new DataSet();
            adapterSanPham.Fill(dsSp);

            dataGridView1.DataSource = dsSp.Tables[0];
        }
    }
}
