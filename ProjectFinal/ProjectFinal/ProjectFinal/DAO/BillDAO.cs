using ProjectFinal.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }

        }
       
        private BillDAO() { }

        public int getUnBillID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Bill where idTable = "+id.ToString()+" and status = 0");
           if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public void CheckOut(int id , float sumPrice)
        {
            string query = "Update dbo.bill set dateCheckOut = getdate(), Status = 1 , sumPrice = " + sumPrice + " where id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable getBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec getListBillByDate @datecheckIn , @dateCheckOut", new object[] { checkIn, checkOut });
        }
        public DataTable getBillListByDateForReport(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec getListBillByDateForReport @datecheckIn , @dateCheckOut", new object[] { checkIn, checkOut });
        }
        public void InsertBill(int id)
        {
            string query = "exec InsertBill @idTable";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
        }

        public int getMaxIdBill()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select max(id) from bill");
        }
        
        public List<Bill> getIDBillByIdFood(int idFood)
        {
            //lấy bill theo id
            List<BillDetail> listBillDetail = BillDetailDAO.Instance.getIdBillDetailByIdFood(idFood);
            List<Bill> listBill = new List<Bill>();

            foreach (BillDetail item in listBillDetail)
            {
                string query = "select * from bill where id = " + item.BillID;
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow itemBill in data.Rows)
                {
                    Bill bill = new Bill(itemBill);
                    listBill.Add(bill);
                }
            }
            return listBill;
        }
        public int tongDoanhThu()
        {
            string query = "select sum(sumPrice) from bill";
            int data = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return data;
        }
        public int checkBillStatus(int idFood)
        {
            List<Bill> list = getIDBillByIdFood(idFood);
          //  int i = list.Count;
            foreach (Bill item in list)
            {
                if(item.Status.Equals("Có Người"))
                {
                    return item.ID;
                }
            }
            return -1;
        }
    }
}
