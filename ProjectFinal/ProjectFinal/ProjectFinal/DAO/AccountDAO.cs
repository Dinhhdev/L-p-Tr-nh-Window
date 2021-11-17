using ProjectFinal.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DAO
{
    class AccountDAO
    {

        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }

        }
        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = "Login @username , @password";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            //frmLogin.role = int.Parse( data.Rows[0][4].ToString());
            return data.Rows.Count > 0;
        }

        public Account GetAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from account where username = '" + username + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool updateAccount(string username, string displayname, string password, string newPassword)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec updateAccount @usernam , @displayName , @password , @newpassword", new object[] { username, displayname, password, newPassword });
            return result > 0;
        }
        public bool updateEmployee(string username , string fullname, string sdt)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec updateEmployee @usernam , @fullname , @phoneNumber", new object[] {username , fullname , sdt});
            return result > 0;
        }
        public DataTable getAllInfoEmployee()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("exec getAllInfoEmployee");
            return data;
        }
        public DataTable getAllAccount()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from account");
            return data;
        }
        public DataTable getAllType()
        {
           DataTable data = DataProvider.Instance.ExecuteQuery("select * from TypeAccount");
            return data;
        }
        public int getIdType(string nameType)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery(string.Format("select * from TypeAccount where nameType = N'{0}'",nameType));
            foreach (DataRow item in data.Rows)
            {
                TypeAccount typeAccount = new TypeAccount(item);
                return typeAccount.ID;
            }
            return -1;
        }

        public bool insertAccount(string username, string displayname, int type)
        {
            string query = "exec insertAccount  @username , @displayname , @type";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, displayname, type });
            return result > 0;
        }

        public bool updateAccountFrmAdmin(string username, string displayname, int type)
        {
            string query = "exec updateAccountFrmAdmin  @username , @displayname , @type";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, displayname, type });
            return result > 0;
        }

        public bool resetPWFood(string username)
        {
            string query = string.Format("update account set password = 1 where Username = N'{0}'", username);

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool deleteAccount(string username)
        {
            string query = string.Format("exec deleteAccount @username");

            int result = DataProvider.Instance.ExecuteNonQuery(query , new object[] { username});
            return result > 0;
        }
        public string getNameTypeByUserName(string username)
        {
            TypeAccount typeAccount = null;
            string query = ("exec getNameTypeByUserName @username");
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            foreach (DataRow item in data.Rows)
            {
                typeAccount = new TypeAccount(item);
            }
            return typeAccount.NameType;
        }
        public DataTable GetAccountByUsernameFrmAdmin(string name)
        {
            // List<Food> list = new List<Food>();
            string query = "exec GetAccountByUsername @name";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { name });
            return data;
        }
        public DataTable GetEmployeeByusername(string name)
        {
            // List<Food> list = new List<Food>();
            string query = string.Format("select * from Employee where username = N'{0}'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
         
        }

    }
}
