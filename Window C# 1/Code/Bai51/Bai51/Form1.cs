using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai51
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, 
            EventArgs e)
        {
            if(tabControl1.SelectedIndex==0)
            {
                button1.BackColor = Color.Red;
            }
            else if(tabControl1.SelectedIndex==1)
            {
                richTextBox1.BackColor = Color.Yellow;
            }
        }
    }
}
