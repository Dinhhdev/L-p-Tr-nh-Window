using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bai53.model;
using Bai53.io;

namespace Bai53
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        Dictionary<string, Khoa> CSDL = new Dictionary<string, Khoa>();
        SinhVien SelectedSinhVien = null;
        private void frmMain_Load(object sender, EventArgs e)
        {
            LamGiaDuLieu();
            HienThiLenTreeView();
            HienThiKhoaLenCombobox();
        }
        private void HienThiKhoaLenCombobox()
        {
            cboKhoa.Items.Clear();
            foreach(KeyValuePair<string,Khoa> itemKhoa in CSDL)
            {
                Khoa kh = itemKhoa.Value;
                cboKhoa.Items.Add(kh);
            }
        }
        private void HienThiLenTreeView()
        {
            tvKhoa.Nodes.Clear();
            foreach(KeyValuePair<string,Khoa> itemKhoa in CSDL)
            {
                Khoa kh = itemKhoa.Value;
                TreeNode nodeKhoa = new TreeNode(kh.TenKhoa);
                nodeKhoa.Tag = kh;
                tvKhoa.Nodes.Add(nodeKhoa);

                foreach(KeyValuePair<string,LopHop> itemLop in kh.Lops)
                {
                    LopHop lp = itemLop.Value;
                    TreeNode nodeLop = new TreeNode(lp.TenLop);
                    nodeLop.Tag = lp;
                    nodeKhoa.Nodes.Add(nodeLop);
                }
            }
            tvKhoa.ExpandAll();
        }
        private void LamGiaDuLieu()
        {
            Khoa cntt = new Khoa()
            { MaKhoa = "CNTT", TenKhoa = "Khoa Công Nghệ Thông Tin" };
            Khoa dt = new Khoa()
            { MaKhoa = "dt", TenKhoa = "Khoa Điện Tử" };
            Khoa kinhte = new Khoa()
            { MaKhoa = "kt", TenKhoa = "Khoa Kinh Tế" };
            Khoa luat = new Khoa()
            { MaKhoa = "kl", TenKhoa = "Khoa Luật" };

            CSDL.Add(cntt.MaKhoa, cntt);
            CSDL.Add(dt.MaKhoa, dt);
            CSDL.Add(kinhte.MaKhoa, kinhte);
            CSDL.Add(luat.MaKhoa, luat);

            LopHop lopcntt1 = new LopHop()
            { MaLop = "cntt1", TenLop = "Đại Học Tin Học 1" };
            cntt.Lops.Add(lopcntt1.MaLop, lopcntt1);
            lopcntt1.KhoaChuQuan = cntt;
            LopHop lopcntt2 = new LopHop()
            { MaLop = "cntt2", TenLop = "Đại Học Tin Học 2" };
            cntt.Lops.Add(lopcntt2.MaLop, lopcntt2);
            lopcntt2.KhoaChuQuan = cntt;

            LopHop lopluat1 = new LopHop()
            { MaLop = "luat1", TenLop = "Đại Học Luật 1" };
            luat.Lops.Add(lopluat1.MaLop, lopluat1);
            lopluat1.KhoaChuQuan = luat;

            LopHop lopluat2 = new LopHop()
            { MaLop = "luat2", TenLop = "Đại Học Luật 2" };
            luat.Lops.Add(lopluat2.MaLop, lopluat2);
            lopluat2.KhoaChuQuan = luat;

            LopHop lopluat3 = new LopHop()
            { MaLop = "luat3", TenLop = "Đại Học Luật 3" };
            luat.Lops.Add(lopluat3.MaLop, lopluat3);
            lopluat3.KhoaChuQuan = luat;

            LopHop lopkt1 = new LopHop()
            { MaLop = "kt1", TenLop = "Đại Học Kinh Tế 1" };
            kinhte.Lops.Add(lopkt1.MaLop, lopkt1);
            lopkt1.KhoaChuQuan = kinhte;

            SinhVien teo = new SinhVien() {
                Ma = "sv1",
                Ten = "Nguyễn văn Tèo",
                GioiTinh = false,
                NamSinh = new DateTime(1990, 1, 1) };
            lopcntt1.SinhViens.Add(teo.Ma, teo);
            teo.LopChuQuan = lopcntt1;

            SinhVien ty = new SinhVien()
            {
                Ma = "sv2",
                Ten = "Trần Thị Tý",
                GioiTinh = true,
                NamSinh = new DateTime(1992, 2, 1)
            };
            lopcntt1.SinhViens.Add(ty.Ma, ty);
            ty.LopChuQuan = lopcntt1;
        }

        private void tvKhoa_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node!=null)//có chọn nút gì đó trên giao diện
            {
                if(e.Node.Level==1)//đúnglà NSD chọn nút Lớp học=>hiển thị DS sinh viên
                {
                    LopHop lp = e.Node.Tag as LopHop;
                    HienThiDanhSachSinhVienTheoLop(lp);
                }
                else
                {
                    lvSinhVien.Items.Clear();//xóa đi vì ko xem danh sách Sinh viên
                }
            }
        }

        private void HienThiDanhSachSinhVienTheoLop(LopHop lp)
        {
            lvSinhVien.Items.Clear();
            foreach(KeyValuePair<string,SinhVien> itemSinhVien in lp.SinhViens)
            {
                SinhVien sv = itemSinhVien.Value;
                ListViewItem lvi = new ListViewItem(sv.Ma);
                lvi.SubItems.Add(sv.Ten);
                lvi.SubItems.Add(sv.GioiTinh == false ? "Nam" : "Nữ");
                if(sv.NamSinh!=null)
                    lvi.SubItems.Add(sv.NamSinh.ToString("dd/MM/yyyy"));
                else
                    lvi.SubItems.Add(sv.NamSinh.ToString("<....>"));
                lvSinhVien.Items.Add(lvi);
                lvi.Tag = sv;
            }
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedIndex == -1) return;
            Khoa kh = cboKhoa.SelectedItem as Khoa;
            HienThiLopLenCombobox(kh);
        }
        private void HienThiLopLenCombobox(Khoa kh)
        {
            cboLop.Items.Clear();
            foreach (KeyValuePair<string, LopHop> itemLop in kh.Lops)
            {
                LopHop lp = itemLop.Value;
                cboLop.Items.Add(lp);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Khoa");
                return;
            }
            if (cboLop.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Lớp");
                return;
            }
            SinhVien sv = new SinhVien();
            sv.Ma = txtMa.Text;
            sv.Ten = txtTen.Text;
            sv.GioiTinh = radNu.Checked;
            LopHop lp = cboLop.SelectedItem as LopHop;
            sv.LopChuQuan = lp;
            lp.SinhViens.Add(sv.Ma, sv);
            MessageBox.Show("Đã lưu thành công");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //xử lý xóa:
            if (SelectedSinhVien != null)
            {
                LopHop lp = SelectedSinhVien.LopChuQuan;
                lp.SinhViens.Remove(SelectedSinhVien.Ma);
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sinh viên để xóa");
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0) return;

            ListViewItem lvi = lvSinhVien.SelectedItems[0];
            SinhVien sv = lvi.Tag as SinhVien;
            txtMa.Text = sv.Ma;
            txtTen.Text = sv.Ten;
            if (sv.GioiTinh)
                radNu.Checked = true;
            else
                radNam.Checked = true;
            SelectedSinhVien = sv;
        }

        private void mnuHeThongThoat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show(
                "Thím muốn thoát hả thím?",
                "Hỏi thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                Close();//Application.Exit();
        }

        private void mnuHeThongLuuDuLieu_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bool kt= FileFactory.SaveFile(CSDL,saveFileDialog1.FileName);
                if (kt)
                    MessageBox.Show("Lưu tập tin thành công");
             }
        }

        private void mnuHeThongDocDuLieu_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                CSDL = FileFactory.ReadFile(openFileDialog1.FileName);
                HienThiLenTreeView();
            }
        }
    }
}
