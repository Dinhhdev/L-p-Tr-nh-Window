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

namespace Pr_TongHop_QLKH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string strConn = "Server=ThanhTran;Database=CSDL_QLKH;user id=sa;pwd=@Hunggia113";
        SqlConnection conn = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiToanBoKhachHang();
        }
        private void OpenConnection()
        {
            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        private void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
        private void HienThiToanBoKhachHang()
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * from KhachHang";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();
                lvKhachHang.Items.Clear();
                lvKhachHang.Groups.Clear();
                ListViewGroup lvgVip = new ListViewGroup("Khách hàng VIP");
                lvKhachHang.Groups.Add(lvgVip);
                ListViewGroup lvgThuong = new ListViewGroup("Khách hàng Thường");
                lvKhachHang.Groups.Add(lvgThuong);
                while(reader.Read())
                {
                    int ma = reader.GetInt32(0);
                    string ten = reader.GetString(1);
                    int gioiTinh = reader.GetInt32(2);
                    string phone = reader.GetString(3);
                    string loaiKh = reader.GetString(4);
                    ListViewItem lvi = new ListViewItem((lvKhachHang.Items.Count+1)+"");
                    lvi.SubItems.Add(ma+"");
                    lvi.SubItems.Add(ten);
                    lvi.SubItems.Add(gioiTinh == 0 ? "Nam" : "Nữ");
                    lvi.SubItems.Add(phone);

                    lvKhachHang.Items.Add(lvi);

                    if (string.Compare(loaiKh, "vip", true) == 0)
                        lvi.Group = lvgVip;
                    else
                        lvi.Group = lvgThuong;
                    if (gioiTinh == 0)
                        lvi.ImageIndex = 0;
                    else if (gioiTinh == 1)
                        lvi.ImageIndex = 1;
                    lvi.Tag = ma;
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKhachHang.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvKhachHang.SelectedItems[0];
            int ma = (int)lvi.Tag;
            HienThiChiTiet(ma);
        }
        private void HienThiChiTiet(int ma)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * from KhachHang where Ma=@ma";
                command.Connection = conn;
                SqlParameter parMa = new SqlParameter("@ma", SqlDbType.Int);
                parMa.Value = ma;
                command.Parameters.Add(parMa);

                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    string ten = reader.GetString(1);
                    int gioiTinh = reader.GetInt32(2);
                    string phone = reader.GetString(3);
                    string loaiKh = reader.GetString(4);

                    txtMa.Text = ma + "";
                    txtTen.Text = ten;
                    if (gioiTinh == 0)
                        radNam.Checked = true;
                    else
                        radNu.Checked = true;
                    txtPhone.Text = phone;
                    if (string.Compare(loaiKh, "vip", true) == 0)
                        cboLoaiKH.SelectedIndex = 0;
                    else
                        cboLoaiKH.SelectedIndex = 1;
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtPhone.Text = "";
            cboLoaiKH.SelectedIndex = -1;
            txtMa.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int ma = int.Parse(txtMa.Text); 
            if(KiemTraTonTai(ma)==true)
            {
                //tiến hành cập nhật
                CapNhapKhachHang(ma);
            }
            else
            {
                //tiến hành thêm mới
                ThemMoiKhachHang();
            }
        }

        private void CapNhapKhachHang(int ma)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "update Khachhang set Ten=@ten, gioitinh=@gt, phone=@phone, loaikh=@loai where ma=@ma";
                command.CommandText = sql;
                command.Connection = conn;

                command.Parameters.Add("@ten",SqlDbType.NVarChar).Value=txtTen.Text;
                command.Parameters.Add("@gt",SqlDbType.Int).Value=radNam.Checked?0:1;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = txtPhone.Text;
                command.Parameters.Add("@loai", SqlDbType.NVarChar).Value = cboLoaiKH.Text;
                command.Parameters.Add("@ma",SqlDbType.Int).Value=ma;

                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiToanBoKhachHang();
                    MessageBox.Show("Lưu thông tin thành công");
                    btnTaoMoi.PerformClick();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin thất bại");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThemMoiKhachHang()
        {
            try
            {
                OpenConnection();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                string sql = "insert into KhachHang values(@ma,@ten,@gt,@phone,@loai)";
                command.CommandText = sql;
                command.Connection = conn;

                command.Parameters.Add("@ma", SqlDbType.Int).Value = txtMa.Text;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtTen.Text;
                if(radNam.Checked==true)
                    command.Parameters.Add("@gt", SqlDbType.Int).Value = 0;
                else
                    command.Parameters.Add("@gt", SqlDbType.Int).Value = 1;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = txtPhone.Text;
                command.Parameters.Add("@loai", SqlDbType.NVarChar).Value = cboLoaiKH.Text;

                int kq = command.ExecuteNonQuery();
                if(kq>0)
                {
                    HienThiToanBoKhachHang();
                    MessageBox.Show("Lưu thông tin thành công");
                    btnTaoMoi.PerformClick();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin thất bại");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool KiemTraTonTai(int ma)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * from KhachHang where Ma=@ma";
                command.Connection = conn;
                SqlParameter parMa = new SqlParameter("@ma", SqlDbType.Int);
                parMa.Value = ma;
                command.Parameters.Add(parMa);

                SqlDataReader reader = command.ExecuteReader();
                bool kq = reader.Read();
                reader.Close();
                return kq;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lvKhachHang.SelectedItems.Count==0)
            {
                MessageBox.Show("Chưa chọn khách hàng làm sao xóa hả Thím?");
                return;
            }
            ListViewItem lvi = lvKhachHang.SelectedItems[0];
            int ma =(int) lvi.Tag;
            DialogResult ret = MessageBox.Show("Thím có chắc chắn muốn xóa mã [" + ma + "]?",
                "xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ret==DialogResult.Yes)
            {
                ThucHienXoa(ma);
            }
        }

        private void ThucHienXoa(int ma)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from khachhang where ma=@ma";
                command.Connection = conn;
                command.Parameters.Add("@ma", SqlDbType.Int).Value = ma;

                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiToanBoKhachHang();
                    MessageBox.Show("Xóa thông tin thành công");
                    btnTaoMoi.PerformClick();
                }
                else
                {
                    MessageBox.Show("Xóa thông tin thất bại");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInAn frm = new frmInAn();
            frm.Show();
        }
    }
}
