using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai49
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<NhanVien> dsNv = new List<NhanVien>();
            dsNv.Add(new NhanVien()
            { Ma=1,Ten="Nguyễn Thị Hạnh",Phone="0981234567"});
            dsNv.Add(new NhanVien()
            { Ma = 2, Ten = "Trần Văn Phúc", Phone = "090242354" });
            dsNv.Add(new NhanVien()
            {Ma=3,Ten="Hồ Văn Giải",Phone="0942367423" });
            dsNv.Add(new NhanVien()
            {Ma=4,Ten="Trần Thị Thoát",Phone="097451234" });

            gvNhanVien.DataSource = dsNv;

        }

        private void gvNhanVien_CellContentClick(object sender,
            DataGridViewCellEventArgs e)
        {
            /*if (e.RowIndex == -1) return;
            DataGridViewRow row = gvNhanVien.Rows[e.RowIndex];
            string ten = row.Cells[1].Value + "";
            MessageBox.Show(ten);
           */
        }

        private void gvNhanVien_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = gvNhanVien.Rows[e.RowIndex];
            string ten = row.Cells[1].Value + "";
            MessageBox.Show(ten);
        }
    }
}
