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
using Microsoft.Reporting.WinForms;

namespace Pr_TongHop_QLKH
{
    public partial class frmInAn : Form
    {
        public frmInAn()
        {
            InitializeComponent();
        }

        private void frmInAn_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection
                ("Server=ThanhTran;Database=CSDL_QLKH;user id=sa;pwd=@Hunggia113");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from KhachHang", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "KhachHang");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables[0];
            this.reportViewer1.LocalReport.ReportEmbeddedResource =
                "Pr_TongHop_QLKH.ReportKhachHang.rdlc";

            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
