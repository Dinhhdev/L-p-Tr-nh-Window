using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai53.model
{
    [Serializable]
    public class SinhVien
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public DateTime NamSinh { get; set; }
        public bool GioiTinh { get; set; }
        public LopHop LopChuQuan { get; set; }
        public override string ToString()
        {
            return Ten;
        }
    }
}
