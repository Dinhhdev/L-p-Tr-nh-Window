namespace Bai61
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
            this.btnDemSoSanPham = new System.Windows.Forms.Button();
            this.lblSoSanPham = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaMuonTim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lvSanPham = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnDemSoSanPham
            // 
            this.btnDemSoSanPham.Location = new System.Drawing.Point(13, 13);
            this.btnDemSoSanPham.Name = "btnDemSoSanPham";
            this.btnDemSoSanPham.Size = new System.Drawing.Size(219, 49);
            this.btnDemSoSanPham.TabIndex = 0;
            this.btnDemSoSanPham.Text = "Đếm số Sản Phẩm";
            this.btnDemSoSanPham.UseVisualStyleBackColor = true;
            this.btnDemSoSanPham.Click += new System.EventHandler(this.btnDemSoSanPham_Click);
            // 
            // lblSoSanPham
            // 
            this.lblSoSanPham.AutoSize = true;
            this.lblSoSanPham.Location = new System.Drawing.Point(238, 25);
            this.lblSoSanPham.Name = "lblSoSanPham";
            this.lblSoSanPham.Size = new System.Drawing.Size(64, 25);
            this.lblSoSanPham.TabIndex = 1;
            this.lblSoSanPham.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "Xem chi tiết sản phẩm:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập mã sp:";
            // 
            // txtMaMuonTim
            // 
            this.txtMaMuonTim.Location = new System.Drawing.Point(141, 102);
            this.txtMaMuonTim.Name = "txtMaMuonTim";
            this.txtMaMuonTim.Size = new System.Drawing.Size(100, 30);
            this.txtMaMuonTim.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Giá:";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(98, 204);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(380, 30);
            this.txtMa.TabIndex = 8;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(98, 242);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(380, 30);
            this.txtTen.TabIndex = 8;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(98, 278);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(380, 30);
            this.txtGia.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(251, 48);
            this.button2.TabIndex = 9;
            this.button2.Text = "Xem chi tiết sản phẩm c2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(532, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(444, 49);
            this.button3.TabIndex = 10;
            this.button3.Text = "Hiển thị danh sách Sản phẩm";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lvSanPham
            // 
            this.lvSanPham.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvSanPham.FullRowSelect = true;
            this.lvSanPham.GridLines = true;
            this.lvSanPham.HideSelection = false;
            this.lvSanPham.Location = new System.Drawing.Point(532, 83);
            this.lvSanPham.Name = "lvSanPham";
            this.lvSanPham.Size = new System.Drawing.Size(444, 225);
            this.lvSanPham.TabIndex = 11;
            this.lvSanPham.UseCompatibleStateImageBehavior = false;
            this.lvSanPham.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá";
            this.columnHeader3.Width = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 425);
            this.Controls.Add(this.lvSanPham);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaMuonTim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblSoSanPham);
            this.Controls.Add(this.btnDemSoSanPham);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDemSoSanPham;
        private System.Windows.Forms.Label lblSoSanPham;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaMuonTim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView lvSanPham;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

