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
using System.Globalization;
namespace ProjectFinal.GUI
{
    public partial class frmMain : Form
    {
        float sumTemp = 0;
        private Account accountLogin;
        public Account AccountLogin
        {
            get { return accountLogin; }
            set { accountLogin = value;}
        }
        public frmMain(Account acc)
        {
            this.AccountLogin = acc;
            
            InitializeComponent();
            LoadTable();
            loadCategory();
        }

        #region method
       
        void LoadTable()
        {
            flTable.Controls.Clear();

            List<Table> listTable = TableDAO.Instance.LoadtableList();
            foreach (Table item in listTable)
            {
                Button btn = new Button()
                {
                    Width = TableDAO.tableWidth,
                    Height = TableDAO.tableHeight,
                    Cursor = default,
                };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Lime;
                        break;

                    default:
                        btn.BackColor = Color.Orange;
                        break;
                }
                flTable.Controls.Add(btn);
            }

        }

        void loadBill(int id)
        {
            lvBill.Items.Clear();
            List<BillCheckIn> list = MenuDAO.Instance.GetListMenu(id);//Lấy ra các bill chưa checkin theo idTable

            float tong = 0;
            foreach (BillCheckIn item in list)
            {
                ListViewItem lv = new ListViewItem(item.FoodName.ToString());
                lv.SubItems.Add(item.QuanTum.ToString());
                lv.SubItems.Add(item.Price.ToString());
                lv.SubItems.Add(item.SumPrice.ToString());
                tong += item.SumPrice;
                lvBill.Items.Add(lv);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            sumTemp = tong;
            txtTongTien.Text = tong.ToString("c", culture);
           
        }

        void loadCategory()
        {
            List<Category> list = CategoryDAO.Instance.GetListMenu();
            cbLoai.DataSource = list;
            cbLoai.DisplayMember = "Name";
        }
        void loadFoodByCategoryId(int id)
        {
            List<Food> list = FoodDAO.Instance.GetFoodbyID(id);
            cbTen.DataSource = list;
            cbTen.DisplayMember = "Name";
        }
        #endregion

        #region event
        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            loadFoodByCategoryId(id);
        }
        void Btn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as Table).ID;
            lvBill.Tag = (sender as Button).Tag;
            loadBill(idTable);
        }
        private void xemThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccount frm = new frmAccount(AccountLogin);
            frm.UpDateAccount += frm_updateAccount;
            frm.ShowDialog();
        }

        private void frm_updateAccount(object sender, AccountEventHandler e)
        {
            xemThôngTinCáNhânToolStripMenuItem.Text = "Xem Thông Tin Cá Nhân [" + e.Acc.DisplayName + "]"; 
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin admin = new frmAdmin(accountLogin);
            admin.InsertFood += admin_InsertFood;
            admin.DeleteFood += admin_DeleteFood;
            admin.UpdateFood += admin_UpdateFood;
            admin.Inserttable += admin_InsertTable;
            admin.UpdateTable += admin_UpdateTable;
            admin.DeleteTable += admin_DeleteTable;
            this.Hide();
            admin.ShowDialog();
            this.Show();
        }
        private void admin_DeleteTable(object sender, EventArgs e)
        {
            LoadTable();
        }
        private void admin_UpdateTable(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void admin_InsertTable(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void admin_UpdateFood(object sender, EventArgs e)
        {
            loadFoodByCategoryId((cbLoai.SelectedItem as Category).ID);
            if(lvBill.Tag != null)
                loadBill((lvBill.Tag as Table).ID);
        }

        private void admin_DeleteFood(object sender, EventArgs e)
        {
            int id = (cbLoai.SelectedItem as Category).ID;
            loadFoodByCategoryId(id);
            if (lvBill.Tag != null)
                loadBill((lvBill.Tag as Table).ID);
            LoadTable();
        }

        private void admin_InsertFood(object sender, EventArgs e)
        {
            loadFoodByCategoryId((cbLoai.SelectedItem as Category).ID);
            if (lvBill.Tag != null)
                loadBill((lvBill.Tag as Table).ID);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;
            if(table == null)
            {
                MessageBox.Show("bạn chưa chọn bàn!!"); return;
            }
            int idBill = BillDAO.Instance.getUnBillID(table.ID);
            int foodID = (cbTen.SelectedItem as Food).ID;
            int quantum = (int)numTangGiam.Value;


            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillDetailDAO.Instance.InsertBillDetail(BillDAO.Instance.getMaxIdBill(), foodID, AccountLogin.UserName,quantum);
            }
            else
            {
                BillDetailDAO.Instance.InsertBillDetail(idBill, foodID, AccountLogin.UserName, quantum);
            }
            loadBill(table.ID);
            numTangGiam.Value = 1;
            LoadTable();
        }

        #endregion

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;
            int idBill = BillDAO.Instance.getUnBillID(table.ID);
          
            if (idBill != -1)
            {
                if (MessageBox.Show("Thanh toán bàn " + table.ID, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, sumTemp);
                    MessageBox.Show("Thanh toán thành công." , "Thông báo" , MessageBoxButtons.OK, MessageBoxIcon.None);
                    loadBill(table.ID);
                }
            }else if(idBill == -1)
            {
                MessageBox.Show("Bàn đang không có người.");
            }
            LoadTable();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cbTen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLoai.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void lvBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem lv = lvBill.SelectedItems[0];
           
            cbTen.Text = lv.SubItems[0].Text;
            cbLoai.Text = FoodDAO.Instance.getNameCategory(lv.SubItems[0].Text);
            numTangGiam.Value = Convert.ToInt32(lv.SubItems[1].Text);
        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thanhToánCtrTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThanhToan.PerformClick();
        }

        private void mởFormAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminToolStripMenuItem_Click(sender , e);
        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThemMon.PerformClick();
        }

        private void flTable_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
