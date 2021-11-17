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

namespace QuanLyTrungTam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string strConn = "Server=ThanhTran;Database=CSDL_QLTrungTam;User id=sa;pwd=@Hunggia113";
        SqlConnection conn = null;
        void OpenConnection()
        {
            if(conn==null)
                 conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TaiTrungTamLenCayCoi();
        }
        SqlCommand TaoCommand(string sql)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            return command;
        }
        void TaiTrungTamLenCayCoi()
        {
           
            SqlCommand commandTT = TaoCommand("Select * from CacTrungTam");
            SqlDataReader readerTT = commandTT.ExecuteReader();
            tvTrungTam.Nodes.Clear();
            while(readerTT.Read())
            {
                string matt = readerTT.GetString(0);
                string tentt = readerTT.GetString(1);
                TreeNode nodeTT = new TreeNode(tentt);
                nodeTT.Tag = matt;
                nodeTT.ImageIndex = 0;

                tvTrungTam.Nodes.Add(nodeTT);

                SqlCommand commandLop = TaoCommand("Select * from Lop where MaTT='"+matt+"'");
                SqlDataReader readerLop = commandLop.ExecuteReader();
                while(readerLop.Read())
                {
                    string maLop = readerLop.GetString(0);
                    string tenLop = readerLop.GetString(1);
                    TreeNode nodeLop = new TreeNode(tenLop);
                    nodeLop.Tag = maLop;
                    nodeTT.Nodes.Add(nodeLop);
                    nodeLop.ImageIndex = 1;

                    SqlCommand commandSV = TaoCommand("Select * from SinhVien where malop='" + maLop + "'");
                    SqlDataReader readerSV = commandSV.ExecuteReader();
                    while(readerSV.Read())
                    {
                        string masv = readerSV.GetString(0);
                        string tensv = readerSV.GetString(1);
                        string sdt = readerSV.GetString(2);
                        TreeNode nodeSV = new TreeNode(tensv);
                        nodeSV.Tag = masv;

                        nodeLop.Nodes.Add(nodeSV);

                        nodeSV.ImageIndex = 2;
                    }
                    readerSV.Close();
                }
                readerLop.Close();
            }
            readerTT.Close();

        }

        private void tvTrungTam_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node!=null)
            {
                if(e.Node.Level==0)//nhấn vào nút trung tâm
                {
                    string matt = e.Node.Tag.ToString();
                    HienThiLopLenListView(matt);
                }
                else if(e.Node.Level==1)
                {
                    string malop = e.Node.Tag.ToString();
                    HienThiSinhVienLenListView(malop);
                }
            }
        }

        private void HienThiSinhVienLenListView(string malop)
        {
            lvData.Items.Clear();
            lvData.Columns.Clear();
            lvData.Columns.Add("Mã SV", 100);
            lvData.Columns.Add("Tên SV", 300);
            lvData.Columns.Add("Phone", 150);

            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select* from SinhVien where malop = '" + malop + "'";
            command.Connection = conn;
            SqlDataReader readerSV = command.ExecuteReader();
            while (readerSV.Read())
            {
                string maSV = readerSV.GetString(0);
                string tenSV = readerSV.GetString(1);
                string phone = readerSV.GetString(2);
                ListViewItem lvi = new ListViewItem(maSV);
                lvi.SubItems.Add(tenSV);
                lvi.SubItems.Add(phone);
                lvData.Items.Add(lvi);
            }
            readerSV.Close();
        }

        private void HienThiLopLenListView(string matt)
        {
            lvData.Items.Clear();
            lvData.Columns.Clear();
            lvData.Columns.Add("Mã Lớp",100);
            lvData.Columns.Add("Tên Lớp",300);

            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Lop where MaTT='" + matt + "'";
            command.Connection = conn;
            SqlDataReader readerLop = command.ExecuteReader();
            while(readerLop.Read())
            {
                string maLop = readerLop.GetString(0);
                string tenLop = readerLop.GetString(1);
                ListViewItem lvi = new ListViewItem(maLop);
                lvi.SubItems.Add(tenLop);
                lvData.Items.Add(lvi);
            }
            readerLop.Close();

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            lvData.Items.Clear();
            lvData.Columns.Clear();
            lvData.Columns.Add("Mã SV", 100);
            lvData.Columns.Add("Tên SV", 300);
            lvData.Columns.Add("Phone", 150);

            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from SinhVien where TenSV like @ten";
            command.Parameters.Add("@ten",SqlDbType.NVarChar).Value="%"+txtTen.Text+"%";
            command.Connection = conn;
            SqlDataReader readerSV = command.ExecuteReader();
            while (readerSV.Read())
            {
                string maSV = readerSV.GetString(0);
                string tenSV = readerSV.GetString(1);
                string phone = readerSV.GetString(2);
                ListViewItem lvi = new ListViewItem(maSV);
                lvi.SubItems.Add(tenSV);
                lvi.SubItems.Add(phone);
                lvData.Items.Add(lvi);
            }
            readerSV.Close();
        }
    }
}
