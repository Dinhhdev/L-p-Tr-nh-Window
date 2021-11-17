using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace maytinhmini
{
    public partial class Form1 : Form
    {
        float so1,so2;
        //int an;
        Boolean kiemtra =false, kiemtrabang = false;
        String s = "";
        public Form1()
        {
            InitializeComponent();
        }

        //số 0
        private void btn_0_Click(object sender, EventArgs e)
        {
            number(btn_0.Text);
        }
        //số 1
        private void btn_1_Click(object sender, EventArgs e)
        {
            number(btn_1.Text);
        }

        //số 2
        private void btn_2_Click(object sender, EventArgs e)
        {
            number(btn_2.Text);
        }

        //số 3
        private void btn_3_Click(object sender, EventArgs e)
        {
            number(btn_3.Text);
        }

        //số 4
        private void btn_4_Click(object sender, EventArgs e)
        {
            number(btn_4.Text);
        }

        //số 5
        private void btn_5_Click(object sender, EventArgs e)
        {
            number(btn_5.Text);
        }

        //số 6
        private void btn_6_Click(object sender, EventArgs e)
        {
            number(btn_6.Text);
        }

        //số 7
        private void btn_7_Click(object sender, EventArgs e)
        {
            number(btn_7.Text);
        }

        //số 8
        private void btn_8_Click(object sender, EventArgs e)
        {
            number(btn_8.Text);
        }

        //số 9
        private void btn_9_Click(object sender, EventArgs e)
        {
            number(btn_9.Text);
        }


        //dấu +
        private void btn_cong_Click(object sender, EventArgs e)
        {
            sign_dau(btn_cong.Text);
        }

        //dấu -
        private void btn_tru_Click(object sender, EventArgs e)
        {
            sign_dau(btn_tru.Text);
        }

        //dấu *
        private void btn_nhan_Click(object sender, EventArgs e)
        {
            sign_dau(btn_nhan.Text);
        }

        //dấu /
        private void btn_chia_Click(object sender, EventArgs e)
        {
            sign_dau(btn_chia.Text);
        }

        //dấu (=)
        private void btn_bang_Click(object sender, EventArgs e)
        {
            switch (s)
            {
                case "+":   
                    so2 = float.Parse(txt_kq.Lines[1]);
                    //MessageBox.Show((so1+so2).ToString());
                    txt_kq.Text = so1 + s + so2 + "\r\n" + (so1  so2).ToString();
                    kiemtrabang = true;
                    break;
                case "-":
                    so2 = float.Parse(txt_kq.Lines[1]);
                    txt_kq.Text = so1 + s + so2 + "\r\n" + (so1 - so2).ToString();
                    kiemtrabang = true;
                    break;
                case "*":
                    so2 = float.Parse(txt_kq.Lines[1]);
                    txt_kq.Text = so1 + s + so2 + "\r\n" + (so1 * so2).ToString();
                    kiemtrabang = true;
                    break;
                case "/":
                    so2 = float.Parse(txt_kq.Lines[1]);
                    txt_kq.Text = so1 + s + so2 + "\r\n" + (so1 / so2).ToString();
                    kiemtrabang = true;
                    break;
            }      
        }
        //Download source code free tại sharecode.vn
        //dấu chấm (.)
        private void btn_cham_Click(object sender, EventArgs e)
        {
            if(!txt_kq.ReadOnly)
            {
                txt_kq.Text += btn_cham.Text;
                txt_kq.ReadOnly = true;
            }
            
        }

        //tạo nút reset
        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_kq.Text = "0";
            so1 = 0;
            so2 = 0;
            s = "";
            txt_kq.ReadOnly = false;

        }
        //Download source code free tại sharecode.vn
        //Tạo Phương Thức nút số
        private void number(String num)
        {
            if (!txt_kq.Text.Equals(""))//textbox đã có số
            {
                if (txt_kq.Text.Equals("0"))//kiểm tra số đầu tiên là số 0
                {
                    txt_kq.Text = num;//=0 thì không cho phép nhập số 0 nào nữa
                }
                else
                {
                    if (kiemtra.Equals(true))//kiểm tra đã nhấn dấu + - * /
                    {
                        
                        txt_kq.Text += "\r\n" + num;
                        kiemtra = false;
                        kiemtrabang = false;
                        //MessageBox.Show(txt_kq.Text);
                    }
                    else//chưa nhấn dấu + - * /
                    {
                        if (kiemtrabang)//kiểm tra đã nhấn dấu =
                        {
                            txt_kq.Clear();
                            txt_kq.Text = num;
                            kiemtrabang = false;
                        }
                        else//chưa nhấn dấu =
                        {
                            txt_kq.Text += num;
                            //MessageBox.Show(txt_kq.Text);
                        }
                    }
                    
                }
            }
            else//textbox chưa có số
            {
                txt_kq.Text = num;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Tạo Phương Thức nút dấu
        private void sign_dau(String sign)
        {
            if (!s.Equals("")) //dấu đã có
            {
                if (kiemtrabang.Equals(true)) //đã nhấn =
                {
                    so1 = float.Parse(txt_kq.Lines[1]);
                    txt_kq.Text =so1 + sign;
                    kiemtra = true;
                    s = sign;
                    txt_kq.ReadOnly = false;
                }
                else
                {
                    so1 = float.Parse(txt_kq.Text);
                    txt_kq.Text = so1 + sign;
                    kiemtra = true;
                    s = sign;
                    txt_kq.ReadOnly = false;
                }
                //MessageBox.Show(so1 + "dau co" +so2);
            }
            else // dấu chưa có
            {
                if(txt_kq.Text.Equals("0") && sign.Equals(btn_tru.Text))
                {

                    txt_kq.Clear();
                    txt_kq.Text = sign;
                }
                else
                {
                    so1 = float.Parse(txt_kq.Text);
                    txt_kq.Text = so1 + sign;
                    kiemtra = true;
                    s = sign;
                    txt_kq.ReadOnly = false;
                    //MessageBox.Show(so1 +"dau ko"+ so2);
                }
                
            }
            
        }
        //Download source code free tại sharecode.vn
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            txt_kq.Text = txt_kq.Text.Remove(txt_kq.Text.Length - 1, 1);
        }
    }
}
