using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            SanPhamBLL spbll = new SanPhamBLL();
            List<SanPham> dsSP = spbll.LayToanBoSanPham();
            lvSanPham.Items.Clear();
            foreach(SanPham sp in dsSP)
            {
                ListViewItem lvi = new ListViewItem(sp.MaSp + "");
                lvi.SubItems.Add(sp.TenSp);
                lvi.SubItems.Add(sp.DonGia+"");
                lvi.SubItems.Add(sp.MaDM+"");

                lvSanPham.Items.Add(lvi);
                lvi.Tag = sp;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lvSanPham.SelectedItems.Count>0)
            {
                ListViewItem lvi = lvSanPham.SelectedItems[0];
                SanPham sp = lvi.Tag as SanPham;
                SanPhamBLL spbll = new SanPhamBLL();
                bool kq = spbll.XoaSanPham(sp.MaSp);
                if (kq)
                    btnHienThi.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            sp.MaSp = int.Parse(txtMa.Text);
            sp.TenSp = txtTen.Text;
            sp.DonGia = int.Parse(txtGia.Text);
            sp.MaDM = int.Parse(txtMaDM.Text);

            SanPhamBLL spbll = new SanPhamBLL();
            bool kq = spbll.ThemSanPham(sp);
            if (kq)
                btnHienThi.PerformClick();
        }
    }
}
