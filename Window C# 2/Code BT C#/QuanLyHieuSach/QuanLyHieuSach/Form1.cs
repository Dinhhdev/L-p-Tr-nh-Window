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

namespace QuanLyHieuSach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string strConn = "Server=ThanhTran;Database=CSDL_QLHieuSach;User id=sa;pwd=@Hunggia113";
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
            HienThiSach();
        }
        void HienThiSach()
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Sach";
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            pnSach.Controls.Clear();
            while(reader.Read())
            {
                string sdkcb = reader.GetString(0);
                string ten = reader.GetString(1);
                string tacgia = reader.GetString(2);
                int gia = reader.GetInt32(3);
                Button btn = new Button();
                btn.Text = ten;
                btn.Tag = sdkcb;
                btn.Width = pnSach.Width -20;
                btn.Height = 50;

                pnSach.Controls.Add(btn);
                btn.Click += Btn_Click;
            }
            reader.Close();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string sodkcb = btn.Tag.ToString();
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Sach where SDKCB=@sdk";
            command.Connection = conn;
            command.Parameters.Add("@sdk",SqlDbType.VarChar).Value=sodkcb;
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                string ten = reader.GetString(1);
                string tacgia = reader.GetString(2);
                int gia = reader.GetInt32(3);
                txtSDKCB.Text = sodkcb;
                txtTenSach.Text = ten;
                txtTacGia.Text = tacgia;
                txtDonGia.Text = gia + "";
            }
            reader.Close();
        }
    }
}
