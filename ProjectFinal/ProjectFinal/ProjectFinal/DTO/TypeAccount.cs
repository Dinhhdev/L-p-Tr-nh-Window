using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.DTO
{
     public class TypeAccount
    {
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string nameType;
        public string NameType
        {
            get { return nameType; }
            set { nameType = value; }
        }
        public TypeAccount(int id, string nametype)
        {
            this.ID = id;
            this.NameType = nametype;
        }
        public TypeAccount(DataRow row)
        {
            this.ID = (int)row["id"];
            this.NameType = row["nametype"].ToString();
        }
    }
}
