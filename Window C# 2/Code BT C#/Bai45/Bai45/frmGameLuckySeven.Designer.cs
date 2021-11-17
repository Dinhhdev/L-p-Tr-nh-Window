namespace Bai45
{
    partial class frmGameLuckySeven
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTienMay = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTienNguoiChoi = new System.Windows.Forms.Label();
            this.btnQuaySo = new System.Windows.Forms.Button();
            this.btnGameMoi = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl3);
            this.groupBox1.Controls.Add(this.lbl2);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lbl1
            // 
            this.lbl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(20, 16);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(67, 85);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "7";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl2
            // 
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(102, 16);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(67, 85);
            this.lbl2.TabIndex = 1;
            this.lbl2.Text = "7";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl3
            // 
            this.lbl3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(179, 15);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(67, 85);
            this.lbl3.TabIndex = 2;
            this.lbl3.Text = "7";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tiền máy:";
            // 
            // lblTienMay
            // 
            this.lblTienMay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTienMay.Location = new System.Drawing.Point(125, 123);
            this.lblTienMay.Name = "lblTienMay";
            this.lblTienMay.Size = new System.Drawing.Size(147, 23);
            this.lblTienMay.TabIndex = 2;
            this.lblTienMay.Text = "100";
            this.lblTienMay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tiền người chơi:";
            // 
            // lblTienNguoiChoi
            // 
            this.lblTienNguoiChoi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTienNguoiChoi.Location = new System.Drawing.Point(125, 150);
            this.lblTienNguoiChoi.Name = "lblTienNguoiChoi";
            this.lblTienNguoiChoi.Size = new System.Drawing.Size(147, 23);
            this.lblTienNguoiChoi.TabIndex = 4;
            this.lblTienNguoiChoi.Text = "100";
            this.lblTienNguoiChoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnQuaySo
            // 
            this.btnQuaySo.Location = new System.Drawing.Point(32, 180);
            this.btnQuaySo.Name = "btnQuaySo";
            this.btnQuaySo.Size = new System.Drawing.Size(75, 32);
            this.btnQuaySo.TabIndex = 5;
            this.btnQuaySo.Text = "Quay số";
            this.btnQuaySo.UseVisualStyleBackColor = true;
            this.btnQuaySo.Click += new System.EventHandler(this.btnQuaySo_Click);
            // 
            // btnGameMoi
            // 
            this.btnGameMoi.Location = new System.Drawing.Point(114, 180);
            this.btnGameMoi.Name = "btnGameMoi";
            this.btnGameMoi.Size = new System.Drawing.Size(75, 32);
            this.btnGameMoi.TabIndex = 6;
            this.btnGameMoi.Text = "Game mới";
            this.btnGameMoi.UseVisualStyleBackColor = true;
            this.btnGameMoi.Click += new System.EventHandler(this.btnGameMoi_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Location = new System.Drawing.Point(205, 179);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(75, 32);
            this.btnKetThuc.TabIndex = 7;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.UseVisualStyleBackColor = true;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmGameLuckySeven
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 218);
            this.Controls.Add(this.btnKetThuc);
            this.Controls.Add(this.btnGameMoi);
            this.Controls.Add(this.btnQuaySo);
            this.Controls.Add(this.lblTienNguoiChoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTienMay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGameLuckySeven";
            this.Text = "Lucky Seven";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTienMay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTienNguoiChoi;
        private System.Windows.Forms.Button btnQuaySo;
        private System.Windows.Forms.Button btnGameMoi;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.Timer timer1;
    }
}