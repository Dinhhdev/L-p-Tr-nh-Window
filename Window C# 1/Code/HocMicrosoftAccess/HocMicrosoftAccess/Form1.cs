using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HocMicrosoftAccess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string strConn = "";
        OleDbConnection conn = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            string pathCsdl = Application.StartupPath + "\\dbNhanVien.accdb";
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathCsdl;
            conn = new OleDbConnection(strConn);
            conn.Open();
            HienThiNhanVien();
        }
        void HienThiNhanVien()
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from NhanVien";
            command.Connection = conn;
            OleDbDataReader reader = command.ExecuteReader();
            lvNhanVien.Items.Clear();
            while(reader.Read())
            {
                string ma = reader.GetString(0);
                string ten = reader.GetString(1);
                string mapb = reader.GetString(2);

                ListViewItem lvi = new ListViewItem(ma);
                lvi.SubItems.Add(ten);
                lvi.SubItems.Add(mapb);
                lvNhanVien.Items.Add(lvi); 
            }
            reader.Close();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into NhanVien values(@ma,@ten,@pb)";
            command.Connection = conn;
            command.Parameters.Add("@ma",OleDbType.BSTR).Value=txtMa.Text;
            command.Parameters.Add("@ten", OleDbType.BSTR).Value = txtTen.Text;
            command.Parameters.Add("@pb", OleDbType.BSTR).Value = txtMaPB.Text;
            int kq = command.ExecuteNonQuery();
            if (kq > 0)
                HienThiNhanVien();
        }

        private void lvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvNhanVien.SelectedItems[0];
            txtMa.Text = lvi.SubItems[0].Text;
            txtTen.Text = lvi.SubItems[1].Text;
            txtMaPB.Text = lvi.SubItems[2].Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "update NhanVien set Ten=@ten, MaPhongBan=@pb where Ma=@ma";
            command.Connection = conn;
            command.Parameters.Add("@ten",OleDbType.BSTR).Value=txtTen.Text;
            command.Parameters.Add("@pb", OleDbType.BSTR).Value = txtMaPB.Text;
            command.Parameters.Add("@ma", OleDbType.BSTR).Value = txtMa.Text;

            int kq = command.ExecuteNonQuery();
            if (kq > 0)
                HienThiNhanVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from NhanVien where Ma=@ma";
            command.Connection = conn;
            command.Parameters.Add("@ma",OleDbType.BSTR).Value=txtMa.Text;
            int kq = command.ExecuteNonQuery();
            if (kq > 0)
                HienThiNhanVien();
        }
    }
}
