using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai47
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn tạo mới File");
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn mở file");
        }

        private void btnMoFile_Click(object sender, EventArgs e)
        {
            mnuFileOpen.PerformClick();
        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            mnuFileNew.PerformClick();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string s = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblDate.Text = s;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                int percent = i * 100 / 100;
                backgroundWorker1.ReportProgress(percent, i);
                System.Threading.Thread.Sleep(200);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, 
            ProgressChangedEventArgs e)
        {
            progressBarPercent.Value = e.ProgressPercentage;
            lblValue.Text = e.UserState + "";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
