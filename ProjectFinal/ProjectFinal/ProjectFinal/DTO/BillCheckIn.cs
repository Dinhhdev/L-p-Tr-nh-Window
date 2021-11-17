using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DTO
{
    public class BillCheckIn
    {
        private string foodName;
        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }

        private float sumPrice;
        public float SumPrice
        {
            get { return sumPrice; }
            set { sumPrice = value; }
        }
        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private int quanTum;
        public int QuanTum
        {
            get { return quanTum; }
            set { quanTum = value; }
        }

        public BillCheckIn(string foodName, int quanTum, float price, float sumPrice = 0)
        {
            this.FoodName = foodName;
            this.QuanTum = quanTum;
            this.Price = price;
            this.SumPrice = sumPrice;
        }
        public BillCheckIn(DataRow row)
        {
            this.FoodName =row["Name"].ToString();
            this.QuanTum = (int) row["quanTum"];
            this.Price = (float) Convert.ToDouble(row["price"]);
            this.SumPrice = (float)Convert.ToDouble(row["sumPrice"]);
        }
    }
}
