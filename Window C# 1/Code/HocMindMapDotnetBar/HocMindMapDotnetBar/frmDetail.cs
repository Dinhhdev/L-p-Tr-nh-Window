using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HocMindMapDotnetBar
{
    public partial class frmDetail : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDetail()
        {
            InitializeComponent();
        }

        private void frmDetail_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;     
        }
    }
}
