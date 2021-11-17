using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SanPhamAccess:DatabaseAccess
    {
        public List<SanPham>LayToanBoSanPham()
        {
            List<SanPham> dsSP = new List<SanPham>();
            OpenConnection();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from SanPham";
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                int ma = reader.GetInt32(0);
                string ten = reader.GetString(1);
                int gia = reader.GetInt32(2);
                int madm = reader.GetInt32(3);

                SanPham sp = new SanPham();
                sp.MaSp = ma;
                sp.TenSp = ten;
                sp.DonGia = gia;
                sp.MaDM = madm;
                dsSP.Add(sp);
            }
            reader.Close();
            return dsSP;
        }
        public bool XoaSanPham(int ma)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from Sanpham where masp=@ma";
            command.Connection = conn;
            command.Parameters.Add("@ma", SqlDbType.Int).Value = ma;

            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }
        public bool ThemSanPham(SanPham sp)
        {
            //ta gọi các lệnh để thêm mới 1 sản phẩm ở đây
            //Tự xử nha các em.....
            return true;
        }
    }
}
