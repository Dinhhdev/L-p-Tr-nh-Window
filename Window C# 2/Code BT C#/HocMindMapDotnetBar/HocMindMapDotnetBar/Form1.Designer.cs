namespace HocMindMapDotnetBar
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
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.treeGX1 = new DevComponents.Tree.TreeGX();
            this.nodeConnector1 = new DevComponents.Tree.NodeConnector();
            this.nodeConnector2 = new DevComponents.Tree.NodeConnector();
            this.elementStyle1 = new DevComponents.Tree.ElementStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuTaoNut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSuaNut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXoaNut = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeGX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // treeGX1
            // 
            this.treeGX1.AllowDrop = true;
            this.treeGX1.CommandBackColorGradientAngle = 90;
            this.treeGX1.CommandMouseOverBackColor2SchemePart = DevComponents.Tree.eColorSchemePart.ItemHotBackground2;
            this.treeGX1.CommandMouseOverBackColorGradientAngle = 90;
            this.treeGX1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeGX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeGX1.ExpandLineColorSchemePart = DevComponents.Tree.eColorSchemePart.BarDockedBorder;
            this.treeGX1.Location = new System.Drawing.Point(0, 0);
            this.treeGX1.Name = "treeGX1";
            this.treeGX1.NodesConnector = this.nodeConnector2;
            this.treeGX1.NodeStyle = this.elementStyle1;
            this.treeGX1.PathSeparator = ";";
            this.treeGX1.RootConnector = this.nodeConnector1;
            this.treeGX1.Size = new System.Drawing.Size(650, 380);
            this.treeGX1.Styles.Add(this.elementStyle1);
            this.treeGX1.SuspendPaint = false;
            this.treeGX1.TabIndex = 0;
            this.treeGX1.Text = "treeGX1";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineWidth = 5;
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineWidth = 5;
            // 
            // elementStyle1
            // 
            this.elementStyle1.BackColor2SchemePart = DevComponents.Tree.eColorSchemePart.BarBackground2;
            this.elementStyle1.BackColorGradientAngle = 90;
            this.elementStyle1.BackColorSchemePart = DevComponents.Tree.eColorSchemePart.BarBackground;
            this.elementStyle1.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle1.BorderBottomWidth = 1;
            this.elementStyle1.BorderColorSchemePart = DevComponents.Tree.eColorSchemePart.BarDockedBorder;
            this.elementStyle1.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle1.BorderLeftWidth = 1;
            this.elementStyle1.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle1.BorderRightWidth = 1;
            this.elementStyle1.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            this.elementStyle1.BorderTopWidth = 1;
            this.elementStyle1.CornerDiameter = 4;
            this.elementStyle1.CornerType = DevComponents.Tree.eCornerType.Rounded;
            this.elementStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.PaddingBottom = 3;
            this.elementStyle1.PaddingLeft = 3;
            this.elementStyle1.PaddingRight = 3;
            this.elementStyle1.PaddingTop = 3;
            this.elementStyle1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTaoNut,
            this.mnuSuaNut,
            this.mnuXoaNut});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // mnuTaoNut
            // 
            this.mnuTaoNut.Name = "mnuTaoNut";
            this.mnuTaoNut.Size = new System.Drawing.Size(152, 22);
            this.mnuTaoNut.Text = "Tạo Nút";
            this.mnuTaoNut.Click += new System.EventHandler(this.mnuTaoNut_Click);
            // 
            // mnuSuaNut
            // 
            this.mnuSuaNut.Name = "mnuSuaNut";
            this.mnuSuaNut.Size = new System.Drawing.Size(152, 22);
            this.mnuSuaNut.Text = "Sửa Nút";
            // 
            // mnuXoaNut
            // 
            this.mnuXoaNut.Name = "mnuXoaNut";
            this.mnuXoaNut.Size = new System.Drawing.Size(152, 22);
            this.mnuXoaNut.Text = "Xóa Nút";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 380);
            this.Controls.Add(this.treeGX1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeGX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.Tree.TreeGX treeGX1;
        private DevComponents.Tree.NodeConnector nodeConnector2;
        private DevComponents.Tree.ElementStyle elementStyle1;
        private DevComponents.Tree.NodeConnector nodeConnector1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuTaoNut;
        private System.Windows.Forms.ToolStripMenuItem mnuSuaNut;
        private System.Windows.Forms.ToolStripMenuItem mnuXoaNut;
    }
}

