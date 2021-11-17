using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DTO
{
    public class Bill
    {
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private DateTime? dateCheckIn;
        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        private DateTime? dateCheckOut;
        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }
        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public Bill(int id, DateTime checkin, DateTime checkout , int status)
        {
            this.ID = id;
            this.DateCheckIn = checkin;
            this.DateCheckOut = checkout;
            this.Status = status;
        }

       public Bill(DataRow row)
        {
            this.ID =(int) row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];
            var dateCheckOut = row["dateCheckOut"];
            if (dateCheckOut.ToString() != "")
            {
                this.DateCheckOut = (DateTime?)dateCheckOut;
            }
          
            this.Status = (int)row["status"];
        }
    }
}
