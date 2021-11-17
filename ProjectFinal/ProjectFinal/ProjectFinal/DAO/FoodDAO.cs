using ProjectFinal.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }

        }

        private FoodDAO() { }

        public List<Food> GetFoodbyID(int id)
        {
            List<Food> list = new List<Food>();
            string query = "select * from Food where idCategory = " + id ;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food fo = new Food(item);
                list.Add(fo);
            }
            return list;
        }

        public DataTable GetFoodbyName(string name)
        {
           // List<Food> list = new List<Food>();
            string query = "exec GetFoodbyName @name";
            DataTable data = DataProvider.Instance.ExecuteQuery(query , new object[] { name });
            return data;
        }

        public List<Food> loadListFood()
        {
            List<Food> list = new List<Food>();
            string query = "select * from food";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food fo = new Food(item);
                list.Add(fo);
            }
            return list;
        }
        public DataTable loadListFoodByDataTable()
        {
            string query = " exec loadListFoodByDataTable";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public bool insertFood(string name, int idCategory, float Price)
        {
            string query = string.Format("insert dbo.Food (name , idCategory ,price) values (  N'{0}' , {1} , {2} )" , name , idCategory , Price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool updateFood(int id,string name, int idCategory, float Price )
        {
            string query = string.Format(" Update dbo.Food set name = N'{0}' , idCategory = {1}, price = {2} where id = {3}", name, idCategory, Price , id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool deleteFood(int id)
        {
            BillDetailDAO.Instance.deleteBillDetailByIdFood(id);
            string query = string.Format("delete dbo.Food where id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        
        public string getNameCategory(string nameFood)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery(string.Format("select f.* from Food t, FoodCategory f where t.name = N'{0}' and t.idCategory = f.id ", nameFood));
            foreach (DataRow item in data.Rows)
            {
                Category ca = new Category(item);
                return ca.Name;
            }
            return "-1";
        }
    }
}
