namespace Bai60
{
    partial class Form1
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
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.btnDongKetNoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Location = new System.Drawing.Point(33, 32);
            this.btnKetNoi.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(324, 44);
            this.btnKetNoi.TabIndex = 0;
            this.btnKetNoi.Text = "Kết nối CSDL";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // btnDongKetNoi
            // 
            this.btnDongKetNoi.Location = new System.Drawing.Point(33, 105);
            this.btnDongKetNoi.Name = "btnDongKetNoi";
            this.btnDongKetNoi.Size = new System.Drawing.Size(324, 48);
            this.btnDongKetNoi.TabIndex = 1;
            this.btnDongKetNoi.Text = "Đóng Kết Nối";
            this.btnDongKetNoi.UseVisualStyleBackColor = true;
            this.btnDongKetNoi.Click += new System.EventHandler(this.btnDongKetNoi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 502);
            this.Controls.Add(this.btnDongKetNoi);
            this.Controls.Add(this.btnKetNoi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.Button btnDongKetNoi;
    }
}

