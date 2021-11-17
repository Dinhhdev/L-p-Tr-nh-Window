using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Bai67
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn =
                new SqlConnection("Server=ThanhTran;Database=CSDLTest;User Id=sa;pwd=@Hunggia113");
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from SanPham", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            lsbSanPham.DataSource = ds.Tables[0];
            lsbSanPham.ValueMember = "Ma";
            lsbSanPham.DisplayMember = "Ten";
        }
    }
}
