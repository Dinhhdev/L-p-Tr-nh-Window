using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai53.model
{
    [Serializable]
    public class Khoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public Dictionary<string,LopHop> Lops
        {
            get;set;
        }
        public Khoa()
        {
            Lops = new Dictionary<string, LopHop>();
        }
        public override string ToString()
        {
            return TenKhoa;
        }
    }
}
