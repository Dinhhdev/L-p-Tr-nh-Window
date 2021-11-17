using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DTO
{
    public class BillDetail
    {
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }


        private int billID;
        public int BillID
        {
            get { return billID; }
            set { billID = value; }
        }

        private int foodID;
        public int FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }

        private int quanTum;
        public int QuanTum
        {
            get { return quanTum; }
            set { quanTum = value; }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public BillDetail(int id, int billid, int foodid, string username,int quantum)
        {
            this.ID = id;
            this.BillID = billid;
            this.FoodID = foodid;
            this.Username = username;
            this.QuanTum = quantum;
        }
        public BillDetail(DataRow row)
        {
            this.ID =(int) row["id"];
            this.BillID = (int)row["idbill"];
            this.FoodID = (int)row["idfood"];
            this.Username = row["username"].ToString();
            this.QuanTum = (int)row["quanTum"];
        }
    }
}
