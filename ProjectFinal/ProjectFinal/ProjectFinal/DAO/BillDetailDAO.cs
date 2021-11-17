using ProjectFinal.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DAO
{
    public class BillDetailDAO
    {
        private static BillDetailDAO instance;

        public static BillDetailDAO Instance
        {
            get { if (instance == null) instance = new BillDetailDAO(); return BillDetailDAO.instance; }
            private set { BillDetailDAO.instance = value; }

        }

        private BillDetailDAO() { }

        public List<BillDetail> GetListBillDetail(int id)
        {
            List < BillDetail > listBillDetail = new List<BillDetail>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from BillDetail where idBill = " + id);
            foreach (DataRow item in data.Rows)
            {
                BillDetail detail = new BillDetail(item);
                listBillDetail.Add(detail);
            }
            return listBillDetail;
        }
        public void InsertBillDetail( int idBill , int idFood , string username,int quantum)
        {
            string query = "exec InsertBillDetail @idBill , @idFood , @username , @quantum";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBill , idFood , quantum , username });
        }

        public List<BillDetail> getIdBillDetailByIdFood(int idFood)
        {
            string query = "Select * from billDetail where idFood = " + idFood;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<BillDetail> list = new List<BillDetail>();
            foreach (DataRow item in data.Rows)
            {
                BillDetail billDetail = new BillDetail(item);
                list.Add(billDetail);
            }
            return list;
        }

        public void deleteBillDetailByIdFood(int idfood)
        {
            DataProvider.Instance.ExecuteQuery("delete billdetail where idfood = " + idfood);
        }
    }
}
