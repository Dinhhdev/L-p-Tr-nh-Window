using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai54
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<SinhVien> dsSV = new List<SinhVien>();
        private void btnThem_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.Ma = int.Parse(txtMa.Text);
            sv.Ten = txtTen.Text;
            sv.NamSinh = dtpNamSinh.Value;
            dsSV.Add(sv);

            HienThiDSSV();
        }

        private void HienThiDSSV()
        {
            lsbDSSV.Items.Clear();
            foreach (SinhVien sv in dsSV)
                lsbDSSV.Items.Add(sv);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath + "\\csdl.txt";
                bool kt=FileFactory.LuuFile(dsSV, path);
                if (kt)
                    MessageBox.Show("Lưu thành công");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\csdl.txt";
            if (System.IO.File.Exists(path))
            {
                dsSV = FileFactory.DocFile(path);

                HienThiDSSV();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDoc.PerformClick();
        }
    }
}
