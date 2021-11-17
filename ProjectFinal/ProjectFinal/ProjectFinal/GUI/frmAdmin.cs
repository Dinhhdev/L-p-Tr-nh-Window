using Microsoft.Reporting.WinForms;
using ProjectFinal.DAO;
using ProjectFinal.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFinal.GUI
{
    public partial class frmAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource foodlistCategory = new BindingSource();
        BindingSource listTable = new BindingSource();
        private Account accountLogin;
       
        public Account AccountLogin
        {
            get { return accountLogin; }
            set { accountLogin = value; }
        }
        public frmAdmin(Account ac)
        {
            this.AccountLogin = ac;
           InitializeComponent();
           load();
        }
        void load()
        {
            //tab Bill
            loadDateFirstLast(dateTimePicker1,dateTimePicker2);
            LoadBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);

            //tab Food
            loadListFood();
            dtgvMenu.DataSource = foodList;
            loadCategory(cboCategoryMenu);
            bindingFood();
            //
            //Tab Account
            loadListAccount();
            dtgvAcounts.DataSource = accountList;
            bindingAccount();
            loadLoaiTaiKhoan(cbLoaiTaiKhoan);
            //
            //Tab CategoryFood
            loadListCategory();
            dtgvCategory.DataSource = foodlistCategory;
            bindingListCategory();
            //
            //Tab TableFood
            loadListTable();
            dtgvBanAn.DataSource = listTable;
            getStatusTable(cbTinhTrang);
            bindingListTable();

            //tab Báo Cáo
            loadDateFirstLast(dateTimePicker3, dateTimePicker4);
            loadReportView(dateTimePicker3 , dateTimePicker4);
        }

        private void loadReportView(DateTimePicker dateTimePicker3, DateTimePicker dateTimePicker4)
        {
            DataTable data = BillDAO.Instance.getBillListByDateForReport(dateTimePicker3.Value, dateTimePicker4.Value);
            ReportDataSource rds = new ReportDataSource("DataSetReport", data);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }



        //////Method///////
        #region method
        //Tab Table
        private void bindingListTable()
        {
            txtIDBan.DataBindings.Add(new Binding("Text", dtgvBanAn.DataSource, "Mã Bàn", true, DataSourceUpdateMode.Never));
            txtTenBan.DataBindings.Add(new Binding("Text", dtgvBanAn.DataSource, "Tên Bàn", true, DataSourceUpdateMode.Never));
        }

        private void loadListTable()
        {
           // MessageBox.Show("loadListTable");
            listTable.DataSource = TableDAO.Instance.GetListTableByDataTable();
        }
        void getStatusTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.GetListStatusTableByDataTable();
            cb.DisplayMember = "Tình Trạng";
        }
        //

        //Tab Category
        private void bindingListCategory()
        {
            txtIdCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Mã", true, DataSourceUpdateMode.Never));
            txtNameCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Tên Loại", true, DataSourceUpdateMode.Never));
        }
     
        private void loadListCategory()
        {
            foodlistCategory.DataSource = CategoryDAO.Instance.GetListMenuByDatatable();
        }
        //


        //Tab Account
        private void loadLoaiTaiKhoan(ComboBox cb)
        {
            cb.DataSource = AccountDAO.Instance.getAllType();
            cb.DisplayMember = "nameType";
        }
        private void bindingAccount()
        {
            txtTenDangNhap.DataBindings.Add(new Binding("Text", dtgvAcounts.DataSource, "Tên Đăng Nhập", true, DataSourceUpdateMode.Never));
            txtTenHienThi.DataBindings.Add(new Binding("Text", dtgvAcounts.DataSource, "Tên Hiển Thị", true, DataSourceUpdateMode.Never));
            txtMaNhanVien.DataBindings.Add(new Binding("Text", dtgvAcounts.DataSource, "Mã Nhân Viên", true, DataSourceUpdateMode.Never));
            txtHoTenNhanVien.DataBindings.Add(new Binding("Text", dtgvAcounts.DataSource, "Họ Và Tên", true, DataSourceUpdateMode.Never));
            txtSDTNhanVien.DataBindings.Add(new Binding("Text", dtgvAcounts.DataSource, "Số Điện Thoại", true, DataSourceUpdateMode.Never));
        }
        private void loadListAccount()
        {
            accountList.DataSource = AccountDAO.Instance.getAllInfoEmployee();
        }
        /////
        

        //Tab Doanh Thu
        public void LoadBillByDate(DateTime checkIn , DateTime checkOut)
        {
            dtgvDoanhThu.DataSource = BillDAO.Instance.getBillListByDate(checkIn, checkOut);
        }
        public void loadDateFirstLast(DateTimePicker d1 , DateTimePicker d2)
        {
            DateTime today = DateTime.Now;
            d1.Value = new DateTime(today.Year, today.Month, 1);
            d2.Value = dateTimePicker1.Value.AddMonths(1).AddDays(-1);
        }
        /////
       
        //Tab Food
        public void loadListFood()
        {
           foodList.DataSource = FoodDAO.Instance.loadListFoodByDataTable();
        }
        void bindingFood()
        {
            txtName.DataBindings.Add(new Binding("Text", dtgvMenu.DataSource, "name" , true , DataSourceUpdateMode.Never));
            txtIDMenu.DataBindings.Add(new Binding("Text", dtgvMenu.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtPrice.DataBindings.Add(new Binding("Text", dtgvMenu.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void loadCategory(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListMenu();
            cb.DisplayMember = "Name";
        }
        /////
        #endregion



        //////Event///////
        #region event

        //Tab Tablbe
        #region
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtTenBan.Text;
                string status = cbTinhTrang.Text;
              
                if (TableDAO.Instance.insertTable(name , status))
                {
                    MessageBox.Show("Thêm thành công!!");
                    loadListTable();

                    if (inserttable != null)
                    {
                        inserttable(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại!!");
            }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtIDBan.Text);
                if (TableDAO.Instance.deleteTable(id))
                {
                    MessageBox.Show("Xóa thành công!!");
                    loadListTable();
                    if (deleteTable != null)
                    {
                        deleteTable(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại!!");
            }
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtTenBan.Text;
                string status = cbTinhTrang.Text;
                int id = Convert.ToInt32(txtIDBan.Text);
                if (TableDAO.Instance.updateTable(id,name, status))
                {
                    MessageBox.Show("Cập nhật thành công!!");
                    loadListTable();
                    if (updateTable != null)
                    {
                        updateTable(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật thất bại!!");
            }
        }
        private void txtIDBan_TextChanged(object sender, EventArgs e)
        {
            int id =Convert.ToInt32(txtIDBan.Text);
            cbTinhTrang.Text = TableDAO.Instance.getStatustableByIdTable(id);
        }
        #endregion
        //

        //Tab Category
        #region TabCategory
        private void btnAddCa_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNameCategory.Text;
                if (CategoryDAO.Instance.insertCategory(name))
                {
                    MessageBox.Show("Thêm thành công!!");
                    loadListCategory();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại!!");
            }
        }

        private void btnDeleteCa_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtIdCategory.Text);

                if (CategoryDAO.Instance.deleteCategory(id))
                {
                    MessageBox.Show("Xóa thành công!!");
                    loadListCategory();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại!!");
            }
        }

        private void btnUpdateCa_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtIdCategory.Text);
                string name = txtNameCategory.Text;
                if (CategoryDAO.Instance.updateCategory(id, name))
                {
                    MessageBox.Show("Sửa thành công!!");
                    loadListCategory();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foodlistCategory.DataSource = CategoryDAO.Instance.GetCategorybyIdDataTable(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                loadListCategory();
            }
            else
            {
                button1.PerformClick();
            }
        }
        #endregion
        //

        ///Tab Account
        #region TabAcount
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                loadListAccount();
            }
            else
            {
                btnSearch.PerformClick();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            accountList.DataSource = AccountDAO.Instance.GetAccountByUsernameFrmAdmin(txtSearch.Text);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtTenDangNhap.Text;
                string displayname = txtTenHienThi.Text;
                string typeAccount = cbLoaiTaiKhoan.Text;
                int idtype = AccountDAO.Instance.getIdType(typeAccount);

                if (AccountDAO.Instance.insertAccount(username, displayname, idtype))
                {
                    MessageBox.Show("Thêm thành công!!");
                    loadListAccount();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tài khoản đã tồn tại!!");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            try
            {

                string username = txtTenDangNhap.Text;
                if (MessageBox.Show("Bạn chắc xóa tài khoản " + username, "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (!AccountLogin.UserName.Equals(username))
                    {
                        if (AccountDAO.Instance.deleteAccount(username))
                        {
                            MessageBox.Show("Xóa thành công!!");
                            loadListAccount();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản đang được sừ dụng!!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tài khoản đang được sừ dụng!!");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtTenDangNhap.Text;
                string displayname = txtTenHienThi.Text;
               
                int type = AccountDAO.Instance.getIdType(cbLoaiTaiKhoan.Text);
                if (AccountDAO.Instance.updateAccountFrmAdmin(username, displayname, type))
                {
                    MessageBox.Show("Sửa thành công!!");
                    loadListAccount();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không được sửa tên đăng nhập");
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;

            if (AccountDAO.Instance.resetPWFood(username))
            {
                MessageBox.Show("Đặt lại mật khẩu là 1 thành Công.");
                loadListAccount();
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu Thất Bại.");
            }
        }
        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string username = txtTenDangNhap.Text;
                cbLoaiTaiKhoan.Text = AccountDAO.Instance.getNameTypeByUserName(username);
            }
            catch
            {

            }
        }
        #endregion
        ///

        ///Tab Food
        #region TabFood

        private void tabDefault_Click(object sender, EventArgs e)
        {
            loadCategory(cboCategoryMenu);
        }
        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                int idCategory = (cboCategoryMenu.SelectedItem as Category).ID;
                float Price = (float)Convert.ToDouble(txtPrice.Text);

                if (FoodDAO.Instance.insertFood(name, idCategory, Price))
                {
                    MessageBox.Show("Thêm Thành Công.");
                
                    loadListFood();
                    if (insertFood != null)
                    {
                        insertFood(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại.");
                }
            }
            catch (Exception ex)
            {
               /// MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateMenu_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int idCategory = (cboCategoryMenu.SelectedItem as Category).ID;
            float Price = (float)Convert.ToDouble(txtPrice.Text);
            int id = Convert.ToInt32(txtIDMenu.Text);

            //   List<Table> listTable = TableDAO.Instance.ListTableStatusNotNull();
            if (BillDAO.Instance.checkBillStatus(id) != -1)
            {
                MessageBox.Show("Cần thanh toán bàn " + BillDAO.Instance.checkBillStatus(id).ToString());
                return;
            }

            if (FoodDAO.Instance.updateFood(id, name, idCategory, Price))
            {
                MessageBox.Show("Sửa Thành Công.");
                loadListFood();
                if (updateFood != null)
                {
                    updateFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Sửa TThất Bại.");
            }
          
        }

        private void btnDeleteMenu_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txtIDMenu.Text);

            if (FoodDAO.Instance.deleteFood(id))
            {
                MessageBox.Show("Xóa Thành Công.");
                loadListFood();
                if (deleteFood != null)
                {
                    deleteFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa TThất Bại.");
            }
            
        }
       
        private void btnSearchMenu_Click(object sender, EventArgs e)
        {
             foodList.DataSource = FoodDAO.Instance.GetFoodbyName(txtSearchMenu.Text);
         
        }
        
        private void txtIDMenu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtIDMenu.Text);
                cboCategoryMenu.Text = CategoryDAO.Instance.GetNameCategoryById(id);
            }
            catch
            {

            }
        }
        private void txtSearchMenu_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchMenu.Text == "")
            {
                loadListFood();
            }
            else
            {
                btnSearchMenu.PerformClick();
            }
        }
        #endregion
        ///
       
        //Tab Doanh Thu    
        #region TabAdmin1
        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value < dateTimePicker2.Value)
            {
                LoadBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else
            {
                MessageBox.Show("Ngày đầu phải nhỏ hơn ngày cuối!");
            }
           
        }
        #endregion
        ///
       
        
         #endregion

        //eventhandler Food
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add  { insertFood += value; }
            remove { insertFood -= value; }
        }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }
        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        //eventhandler Table
        private event EventHandler inserttable;
        public event EventHandler Inserttable
        {
            add { inserttable += value; }
            remove { inserttable -= value; }
        }
        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }
        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            int tong = 0;
            for (int i = 0; i < dtgvDoanhThu.Rows.Count; i++)
            {
                tong += Convert.ToInt32(dtgvDoanhThu.Rows[i].Cells[5].Value);
            }

            CultureInfo culture = new CultureInfo("vi-VN");

            txtDoanhThu.Text = tong.ToString("c", culture);
            cbTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLoaiTaiKhoan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoryMenu.DropDownStyle = ComboBoxStyle.DropDownList;
           
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            loadReportView(dateTimePicker3, dateTimePicker4);
        }

        private void bntXuatFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa làm được");

            /* LocalReport report = new LocalReport();
             report.ReportPath = "ProjectFinalreport.rdlc";
             ReportDataSource rds = new ReportDataSource();
             rds.Name = "DataSetReport";//This refers to the dataset name in the RDLC file
             rds.Value = BillDAO.Instance.getBillListByDateForReport(dateTimePicker3.Value, dateTimePicker4.Value);
             report.DataSources.Add(rds);

             Byte[] mybytes = report.Render("PDF");
             //Byte[] mybytes = report.Render("PDF"); for exporting to PDF
             using (FileStream fs = File.Create(@"D:\xx.ppt"))
             {
                 fs.Write(mybytes, 0, mybytes.Length);
             }*/
        }
    }
}
