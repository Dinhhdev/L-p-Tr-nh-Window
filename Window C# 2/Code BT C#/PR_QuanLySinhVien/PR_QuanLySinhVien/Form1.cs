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
namespace PR_QuanLySinhVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string strConn = "Server=ThanhTran;Database=CSDL_QLSinhVien;user id=sa;pwd=@Hunggia113";
        SqlConnection conn = null;
        void OpenConnection()
        {
            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            NapLopLenMenu();
        }

        private void NapLopLenMenu()
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Lop";
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            mnuDanhSachLop.DropDownItems.Clear();
            ToolStripMenuItem mnuItem = new ToolStripMenuItem("Tất cả các lớp");
            
            mnuItem.Tag = "all";
            mnuItem.Click += MnuItem_Click;
            
            mnuDanhSachLop.DropDownItems.Add(mnuItem);
            while (reader.Read())
            {
                string ma = reader.GetString(0);
                string ten = reader.GetString(1);
                mnuItem = new ToolStripMenuItem(ten);
                mnuItem.Tag = ma;
                mnuDanhSachLop.DropDownItems.Add(mnuItem);
                mnuItem.Click += MnuItem_Click;
            }
            reader.Close();
        }
        ToolStripMenuItem mnuItemPrevious = null;
        private void MnuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnuItem = sender as ToolStripMenuItem;
            if (mnuItemPrevious != null)
                mnuItemPrevious.Checked = false;
            mnuItem.Checked = !mnuItem.Checked;
            mnuItemPrevious = mnuItem;
            string ma = mnuItem.Tag.ToString();
            if (ma == "all")
            {
                HienThiToanBoLop();
            }
            else
            {
                HienThiSinhVienTheoLop(ma);
            }
        }

        private void HienThiSinhVienTheoLop(string maLop)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from SinhVien where MaLop='" + maLop + "'";
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            listView1.Items.Clear();
            listView1.Groups.Clear();
           
            int stt = 1;
            while (reader.Read())
            {
                string ma = reader.GetString(0);
                string ten = reader.GetString(1);
                ListViewItem lvi = new ListViewItem(stt + "");
                lvi.SubItems.Add(ma);
                lvi.SubItems.Add(ten);
                listView1.Items.Add(lvi);                
                stt++;
            }
            reader.Close();
        }

        private void HienThiToanBoLop()
        {
            OpenConnection();

            SqlCommand commandLop = new SqlCommand();
            commandLop.CommandType = CommandType.Text;
            commandLop.CommandText = "select * from Lop";
            commandLop.Connection = conn;
            listView1.Groups.Clear();
            listView1.Items.Clear();
            SqlDataReader readerLop = commandLop.ExecuteReader();
            while (readerLop.Read())
            {
                ListViewGroup lvg = new ListViewGroup(readerLop.GetString(1));
                lvg.Tag = readerLop.GetString(0);
                listView1.Groups.Add(lvg);
            }
            readerLop.Close();
            foreach(ListViewGroup lvg in listView1.Groups)
            {
                string maLop = lvg.Tag.ToString();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from SinhVien where MaLop='"+ maLop+"'";
                command.Connection = conn;
                SqlDataReader reader = command.ExecuteReader();


                int stt = 1;
                while (reader.Read())
                {
                    string ma = reader.GetString(0);
                    string ten = reader.GetString(1);
                    ListViewItem lvi = new ListViewItem(stt + "");
                    lvi.SubItems.Add(ma);
                    lvi.SubItems.Add(ten);
                    listView1.Items.Add(lvi);
                    lvi.Group = lvg;
                    stt++;
                }
                reader.Close();
            }            
        }

       
    }
}
