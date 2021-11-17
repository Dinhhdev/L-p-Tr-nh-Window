using ProjectFinal.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }

        }
        public static int tableWidth = 100;
        public static int tableHeight = 100;
        private TableDAO() { }

        public List<Table> LoadtableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from tableFood");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Table> ListTableStatusNotNull()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("ListTableStatusNotNull");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;

        }
        

        public DataTable GetListTableByDataTable()
        {
            string query = "select id as [Mã Bàn] , name as [Tên Bàn] , status as [Tình Trạng] from tableFood";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
        public List<string> GetListStatusTableByDataTable()
        {
            List<string> loai = new List<string>();
            loai.Add("Trống");
            loai.Add("Có Người");
            return loai;
        }
        public string getStatustableByIdTable(int id)
        {
            Table table = null;
            string query = "select * from tableFood where id = " +id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                table = new Table(item);
            }
            return table.Status;
        }

        public bool insertTable( string nameTable , string status)
        {
            string query = string.Format("insert into tableFood( name , status) values (N'{0}' , N'{1}')", nameTable ,status);

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool updateTable(int id ,string nameTable, string status)
        {
          
            string query = string.Format("update tableFood set name  = N'{0}', status = N'{1}' where id = {2}", nameTable, status , id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool deleteTable(int id)
        {
            string query = string.Format("delete tableFood where id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
