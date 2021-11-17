namespace Bai50
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Khoa CNTT");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Khoa May Thời Trang");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Đại Học Cộng Đồng", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Lớp ĐH ĐT 1", 2, 3);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Khoa Cơ điện tử", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Đại Học XYZ", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tvDuLieu = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuThemNut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSuaNut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMoRong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThuGom = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblValue = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvDuLieu
            // 
            this.tvDuLieu.ContextMenuStrip = this.contextMenuStrip1;
            this.tvDuLieu.ImageIndex = 0;
            this.tvDuLieu.ImageList = this.imageList1;
            this.tvDuLieu.Location = new System.Drawing.Point(12, 50);
            this.tvDuLieu.Name = "tvDuLieu";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Khoa CNTT";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Khoa May Thời Trang";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Đại Học Cộng Đồng";
            treeNode4.ImageIndex = 2;
            treeNode4.Name = "Node5";
            treeNode4.SelectedImageIndex = 3;
            treeNode4.Text = "Lớp ĐH ĐT 1";
            treeNode5.Name = "Node4";
            treeNode5.Text = "Khoa Cơ điện tử";
            treeNode6.Name = "Node3";
            treeNode6.Text = "Đại Học XYZ";
            this.tvDuLieu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.tvDuLieu.SelectedImageIndex = 1;
            this.tvDuLieu.Size = new System.Drawing.Size(295, 279);
            this.tvDuLieu.TabIndex = 0;
            this.tvDuLieu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDuLieu_AfterSelect);
            this.tvDuLieu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvDuLieu_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThemNut,
            this.mnuSuaNut,
            this.mnuuXoa,
            this.toolStripMenuItem1,
            this.mnuMoRong,
            this.mnuThuGom});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 120);
            // 
            // mnuThemNut
            // 
            this.mnuThemNut.Name = "mnuThemNut";
            this.mnuThemNut.Size = new System.Drawing.Size(127, 22);
            this.mnuThemNut.Text = "Thêm Nút";
            this.mnuThemNut.Click += new System.EventHandler(this.mnuThemNut_Click);
            // 
            // mnuSuaNut
            // 
            this.mnuSuaNut.Name = "mnuSuaNut";
            this.mnuSuaNut.Size = new System.Drawing.Size(127, 22);
            this.mnuSuaNut.Text = "Sửa Nút";
            this.mnuSuaNut.Click += new System.EventHandler(this.mnuSuaNut_Click);
            // 
            // mnuuXoa
            // 
            this.mnuuXoa.Name = "mnuuXoa";
            this.mnuuXoa.Size = new System.Drawing.Size(127, 22);
            this.mnuuXoa.Text = "Xóa Nút";
            this.mnuuXoa.Click += new System.EventHandler(this.mnuuXoa_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 6);
            // 
            // mnuMoRong
            // 
            this.mnuMoRong.Name = "mnuMoRong";
            this.mnuMoRong.Size = new System.Drawing.Size(127, 22);
            this.mnuMoRong.Text = "Mở rộng";
            this.mnuMoRong.Click += new System.EventHandler(this.mnuMoRong_Click);
            // 
            // mnuThuGom
            // 
            this.mnuThuGom.Name = "mnuThuGom";
            this.mnuThuGom.Size = new System.Drawing.Size(127, 22);
            this.mnuThuGom.Text = "Thu gom";
            this.mnuThuGom.Click += new System.EventHandler(this.mnuThuGom_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "folder_open.png");
            this.imageList1.Images.SetKeyName(2, "file.png");
            this.imageList1.Images.SetKeyName(3, "file_open.png");
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(331, 22);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(64, 25);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "label1";
            this.lblValue.Click += new System.EventHandler(this.lblValue_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 405);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.tvDuLieu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDuLieu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuThemNut;
        private System.Windows.Forms.ToolStripMenuItem mnuSuaNut;
        private System.Windows.Forms.ToolStripMenuItem mnuuXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuMoRong;
        private System.Windows.Forms.ToolStripMenuItem mnuThuGom;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.ImageList imageList1;
    }
}

