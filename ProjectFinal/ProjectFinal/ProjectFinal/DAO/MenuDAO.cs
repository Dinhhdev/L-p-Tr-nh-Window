using ProjectFinal.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFinal.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
            
        }

        private MenuDAO() { }

        public List<BillCheckIn> GetListMenu(int id)
        {
            List<BillCheckIn> list = new List<BillCheckIn>();
            string query = "select f.name , bi.quantum , f.price , f.price*bi.quantum as sumPrice from food f , bill b, BillDetail bi where bi.idBill = b.id and bi.idFood = f.id and b.status = 0 and b.idTable = " + id;
          
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillCheckIn menu = new BillCheckIn(item);
                list.Add(menu);
            }
            return list;
        }
     }
}
