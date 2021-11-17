using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectFinal.DAO
{
    
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        
        }
        private DataProvider() { }

        private string strconnection = @"SERVER = VINHLE268\VINHLE2608 ; Database = QL_QuanAn ; User Id = sa ;pwd = 123456789";
        public DataTable ExecuteQuery (string query , object[] paramater = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(strconnection))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(query, conn);

                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            sqlCommand.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(data);
                conn.Close();

            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] paramater = null)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(strconnection))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(query, conn);

                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            sqlCommand.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                data = sqlCommand.ExecuteNonQuery();
               
                conn.Close();

            }
            return data;
        }

        public object ExecuteScalar(string query, object[] paramater = null)
        {
            object data = 0;
            using (SqlConnection conn = new SqlConnection(strconnection))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(query, conn);

                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            sqlCommand.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                data =(int) sqlCommand.ExecuteScalar();

                conn.Close();

            }
            return data;
        }
       
        
    }
}
