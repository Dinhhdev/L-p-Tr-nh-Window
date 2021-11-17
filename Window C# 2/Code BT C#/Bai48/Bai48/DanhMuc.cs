using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai48
{
    public class DanhMuc
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public List<SanPham> SanPhams { get; set; }
        public DanhMuc()
        {
            SanPhams = new List<SanPham>();
        }
        public void ThemSanPham(SanPham sp)
        {
            SanPhams.Add(sp);
            sp.Nhom = this;
        }
    }
}
