using ProjectFinal.DAO;
using ProjectFinal.DTO;
using ProjectFinal.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFinal
{
    public partial class frmLogin : Form
    {
        public static int role = -1;

        public frmLogin()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Diền dầy đủ thông tin đăng nhập.");
            }
            else
            {
                if (login(username, password))
                {
                    Account accountLogin = AccountDAO.Instance.GetAccountByUserName(username);
                    frmMain frmDanhSach = new frmMain(accountLogin);
                    if (accountLogin.Type != 1) frmDanhSach.adminToolStripMenuItem.Visible = false;
                    frmDanhSach.xemThôngTinCáNhânToolStripMenuItem.Text += " [" + accountLogin.DisplayName + "]";
                    this.Hide();
                    frmDanhSach.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khấu!!");
                }
            }

        }


        public bool login(string username, string password)
        {

            return AccountDAO.Instance.Login(username, password);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát??", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
