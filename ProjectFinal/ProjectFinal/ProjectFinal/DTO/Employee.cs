using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DTO
{
    public class Employee
    {
        public Employee(int id , string fullname, string phoneNumber , string username )
        {
            this.ID = id;
            this.FullName = fullname;
            this.PhoneNumber = phoneNumber;
            this.UserName = username;
        }
        public Employee(DataRow row)
        {
            this.ID = (int)row["id"];
            this.FullName = row["fullname"].ToString();
            this.PhoneNumber = row["NumberPhone"].ToString();
            this.UserName = row["username"].ToString();
        }
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
