using ProjectFinal.DAO;
using ProjectFinal.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFinal.GUI
{
    public partial class frmAccount : Form
    {
        private Account accountLogin;
        public Account AccountLogin
        {
            get { return accountLogin; }
            set { accountLogin = value; changeAccount(accountLogin); }
        }

        private void changeAccount(Account acc)
        {
            txtTenDangNhap.Text = acc.UserName;
            txtTenHienThi.Text = acc.DisplayName;

           
        }

        public void getInfoEmployee(string username)
        {
           
            DataTable data = AccountDAO.Instance.GetEmployeeByusername(username);

            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                txtHoTen.Text = employee.FullName;
                txtMaNhanVien.Text = employee.ID.ToString();
                txtSDT.Text = employee.PhoneNumber;
                break;
            }

        }

        public frmAccount(Account acc)
        {
            InitializeComponent();
          
            this.AccountLogin = acc;
            getInfoEmployee(AccountLogin.UserName);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            updateThongTinNhanVien();
        }

        private void updateThongTinNhanVien()
        {
            string displayName = txtTenHienThi.Text;
            string userName = txtTenDangNhap.Text;
            string passWord = txtMatKhau.Text;
            string newPassWord = txtMatKhauMoi.Text;
            string reNewPassWord = txtXacNhanMatKhau.Text;
          
            
            if (!newPassWord.Equals(reNewPassWord))
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng");
            }
            else
            {
                if(AccountDAO.Instance.updateAccount(userName , displayName , passWord , newPassWord ))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if(updateAccount != null)
                    {
                        updateAccount(this, new AccountEventHandler(AccountDAO.Instance.GetAccountByUserName(userName)));
                    }
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại mật khẩu");
                }
            }
        }

        private event EventHandler<AccountEventHandler> updateAccount;
        public event EventHandler<AccountEventHandler> UpDateAccount 
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            string userName = txtTenDangNhap.Text;
            string fullName = txtHoTen.Text;
            string SDT = txtSDT.Text;
            if (AccountDAO.Instance.updateEmployee(userName, fullName, SDT))
            {
                MessageBox.Show("Thay đổi thông tin cá nhân thành công");
            }
            else
            {
                MessageBox.Show("Thay đổi thông tin cá nhân thất bại");
            }
        }
    }
    public class AccountEventHandler : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value ; }
        }
        public AccountEventHandler(Account Ac)
        {
            this.Acc = Ac;
        }
    }

}
