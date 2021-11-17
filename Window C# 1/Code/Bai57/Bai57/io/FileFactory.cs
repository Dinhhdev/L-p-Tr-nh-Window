using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bai53.model;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
namespace Bai53.io
{
    public class FileFactory
    {
        public static bool SaveFile(Dictionary<string, Khoa> CSDL,string path)
        {
            try
            {
                FileStream fs = new FileStream(path,FileMode.Create);
                BinaryFormatter bft = new BinaryFormatter();
                bft.Serialize(fs, CSDL);
                fs.Close();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static Dictionary<string, Khoa> ReadFile(string path)
        {
            Dictionary<string, Khoa> CSDL = new Dictionary<string, Khoa>();
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bft = new BinaryFormatter();
                object data= bft.Deserialize(fs);
                CSDL = data as Dictionary<string, Khoa>;
                fs.Close();
                return CSDL;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
