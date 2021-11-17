using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai48
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        List<DanhMuc> khoHang = new List<DanhMuc>();
        private void Form2_Load(object sender, EventArgs e)
        {
            DanhMuc bia = new DanhMuc();
            bia.Ma = "dm1";
            bia.Ten = "Nhóm Bia";
            khoHang.Add(bia);

            SanPham biaken = new SanPham();
            biaken.Ma = "sp1";
            biaken.Ten = "Heneiken";
            biaken.Gia = 150;
            bia.ThemSanPham(biaken);
            SanPham bia33 = new SanPham();
            bia33.Ma = "sp2";
            bia33.Ten = "Bia Bố Bố";
            bia33.Gia = 100;
            bia.ThemSanPham(bia33);

            DanhMuc ruou = new DanhMuc();
            ruou.Ma = "dm2";
            ruou.Ten = "Nhóm Rượu";
            khoHang.Add(ruou);

            SanPham vodka = new SanPham();
            vodka.Ma = "sp3";
            vodka.Ten = "Rượu Vodka Lào";
            vodka.Gia = 50;
            ruou.ThemSanPham(vodka);

            foreach(DanhMuc dm in khoHang)
            {
                //Tạo nhóm cho ListView:
                ListViewGroup lvg = new ListViewGroup(dm.Ten);
                listView1.Groups.Add(lvg);
                foreach(SanPham sp in dm.SanPhams)
                {
                    //tạo 1 dòng listview item:
                    ListViewItem lvi = new ListViewItem(sp.Ma);
                    lvi.SubItems.Add(sp.Ten);
                    lvi.SubItems.Add(sp.Gia + "");
                    lvi.Group = lvg;
                    listView1.Items.Add(lvi);
                    if (dm == ruou)
                        lvi.ForeColor = Color.Red;
                }
            }
        }
    }
}
