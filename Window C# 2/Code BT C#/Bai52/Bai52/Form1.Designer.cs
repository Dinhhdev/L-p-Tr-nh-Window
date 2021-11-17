namespace Bai52
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnChon1Hinh = new System.Windows.Forms.Button();
            this.picOpenFile = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbSave = new System.Windows.Forms.RichTextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnDoiMau = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblFont = new System.Windows.Forms.Label();
            this.btnDoiFont = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnChonThuMuc = new System.Windows.Forms.Button();
            this.btnLuuThongTin = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenFile)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(527, 413);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.picOpenFile);
            this.tabPage1.Controls.Add(this.btnChon1Hinh);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(519, 387);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "OpenFile Dialog";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnLuu);
            this.tabPage2.Controls.Add(this.rtbSave);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(519, 387);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Save File Dialog";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnDoiMau);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(519, 387);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Color Dialog";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnDoiFont);
            this.tabPage4.Controls.Add(this.lblFont);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(519, 387);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Font Dialog";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnLuuThongTin);
            this.tabPage5.Controls.Add(this.btnChonThuMuc);
            this.tabPage5.Controls.Add(this.txtPath);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.richTextBox1);
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(519, 387);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "FolderBrowser Dialog";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnChon1Hinh
            // 
            this.btnChon1Hinh.Location = new System.Drawing.Point(21, 16);
            this.btnChon1Hinh.Name = "btnChon1Hinh";
            this.btnChon1Hinh.Size = new System.Drawing.Size(115, 25);
            this.btnChon1Hinh.TabIndex = 0;
            this.btnChon1Hinh.Text = "Chọn 1 hình";
            this.btnChon1Hinh.UseVisualStyleBackColor = true;
            this.btnChon1Hinh.Click += new System.EventHandler(this.btnChon1Hinh_Click);
            // 
            // picOpenFile
            // 
            this.picOpenFile.Location = new System.Drawing.Point(81, 63);
            this.picOpenFile.Name = "picOpenFile";
            this.picOpenFile.Size = new System.Drawing.Size(331, 297);
            this.picOpenFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOpenFile.TabIndex = 1;
            this.picOpenFile.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập nội dung:";
            // 
            // rtbSave
            // 
            this.rtbSave.Location = new System.Drawing.Point(22, 45);
            this.rtbSave.Name = "rtbSave";
            this.rtbSave.Size = new System.Drawing.Size(336, 122);
            this.rtbSave.TabIndex = 1;
            this.rtbSave.Text = "";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(22, 188);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDoiMau
            // 
            this.btnDoiMau.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMau.Location = new System.Drawing.Point(138, 74);
            this.btnDoiMau.Name = "btnDoiMau";
            this.btnDoiMau.Size = new System.Drawing.Size(218, 120);
            this.btnDoiMau.TabIndex = 0;
            this.btnDoiMau.Text = "Đổi màu em đi Thím";
            this.btnDoiMau.UseVisualStyleBackColor = true;
            this.btnDoiMau.Click += new System.EventHandler(this.btnDoiMau_Click);
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFont.Location = new System.Drawing.Point(133, 19);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(146, 31);
            this.lblFont.TabIndex = 0;
            this.lblFont.Text = "Vô Thường";
            // 
            // btnDoiFont
            // 
            this.btnDoiFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiFont.Location = new System.Drawing.Point(126, 76);
            this.btnDoiFont.Name = "btnDoiFont";
            this.btnDoiFont.Size = new System.Drawing.Size(170, 35);
            this.btnDoiFont.TabIndex = 1;
            this.btnDoiFont.Text = "Đổi Font thím ơi";
            this.btnDoiFont.UseVisualStyleBackColor = true;
            this.btnDoiFont.Click += new System.EventHandler(this.btnDoiFont_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhập nội dung:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(477, 121);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Chọn nơi lưu trữ thông tin:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(15, 201);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(392, 20);
            this.txtPath.TabIndex = 3;
            // 
            // btnChonThuMuc
            // 
            this.btnChonThuMuc.Location = new System.Drawing.Point(414, 201);
            this.btnChonThuMuc.Name = "btnChonThuMuc";
            this.btnChonThuMuc.Size = new System.Drawing.Size(75, 23);
            this.btnChonThuMuc.TabIndex = 4;
            this.btnChonThuMuc.Text = "...";
            this.btnChonThuMuc.UseVisualStyleBackColor = true;
            this.btnChonThuMuc.Click += new System.EventHandler(this.btnChonThuMuc_Click);
            // 
            // btnLuuThongTin
            // 
            this.btnLuuThongTin.Location = new System.Drawing.Point(15, 250);
            this.btnLuuThongTin.Name = "btnLuuThongTin";
            this.btnLuuThongTin.Size = new System.Drawing.Size(115, 29);
            this.btnLuuThongTin.TabIndex = 5;
            this.btnLuuThongTin.Text = "Lưu thông tin";
            this.btnLuuThongTin.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 413);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox picOpenFile;
        private System.Windows.Forms.Button btnChon1Hinh;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.RichTextBox rtbSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnDoiMau;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnDoiFont;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnLuuThongTin;
        private System.Windows.Forms.Button btnChonThuMuc;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

