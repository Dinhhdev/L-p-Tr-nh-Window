using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DTO
{
    public class Account
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string passWord;
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        private string displayName;
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        private int type;
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public Account(string username , string displayName, int type, string passWord) 
        {
            this.UserName = username;
            this.DisplayName = displayName;
            this.Type = type;
            this.PassWord = passWord;
        }
        public Account(DataRow row)
        {
            this.UserName = row["username"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.Type = (int)row["type"];
            this.PassWord = row["passWord"].ToString();
        }
       
    }
}
