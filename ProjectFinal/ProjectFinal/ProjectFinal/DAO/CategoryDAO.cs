using ProjectFinal.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }

        }

        private CategoryDAO() { }

        public List<Category> GetListMenu()
        {
            List<Category> list = new List<Category>();
            string query = "select * from Foodcategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category ca = new Category(item);
                list.Add(ca);
            }

            return list;
        }

        public DataTable GetListMenuByDatatable()
        {
            string query = "select id as [Mã] , nameCategory as [Tên Loại] from Foodcategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public Category GetCategoryById(int id)
        {
            Category category = null;
            string query = "select * from Foodcategory where id = "+id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
            }
            return category;
        }
        public string GetNameCategoryById(int id)
        {
            Category category = null;
            string query = "exec getNameCategoryByID @id";

            DataTable data = DataProvider.Instance.ExecuteQuery(query , new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
            }
            return category.Name;
        }


        public bool insertCategory(string nameCategory)
        {
            string query = string.Format("insert into FoodCategory(nameCategory) values (N'{0}')" , nameCategory);

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool updateCategory(int id ,string nameCategory)
        {
            string query = string.Format("update FoodCategory set nameCategory = N'{0}' where id = {1}", nameCategory,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool deleteCategory(int id)
        {
            string query = string.Format("delete FoodCategory where id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable GetCategorybyIdDataTable(string nameCategofy)
        {
            
            string query = "exec GetCategorybyName @nameCategofy";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { nameCategofy });
            return data;
        }
    }
}
