using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DTO
{
    public class Food
    {

        public Food(int id, string name, int idCategory , float price)
        {
            this.ID = id;
            this.IDCategory = idCategory;
            this.Name = name;
            this.Price = price;
        }
        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDCategory = (int)row["idCategory"];
            this.Name = row["name"].ToString();
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
       
        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private int iDCategory;
        public int IDCategory
        {
            get { return iDCategory; }
            set { iDCategory = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
