namespace TravelAgency.CSUI.FrmMain
{
    partial class FrmGaoPaiManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGaoPaiManage));
            this.panelMain = new DevComponents.DotNetBar.PanelEx();
            this.lvPics = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.panelRightTop = new DevComponents.DotNetBar.PanelEx();
            this.sliderPicSize = new DevComponents.DotNetBar.Controls.Slider();
            this.lbCount = new DevComponents.DotNetBar.LabelX();
            this.panelLeft = new DevComponents.DotNetBar.PanelEx();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.cmsAdvTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存选中组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain.SuspendLayout();
            this.panelRightTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.cmsAdvTree.SuspendLayout();
            this.cmsListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelMain.Controls.Add(this.lvPics);
            this.panelMain.Controls.Add(this.panelRightTop);
            this.panelMain.Controls.Add(this.panelLeft);
            this.panelMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1207, 657);
            this.panelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMain.Style.GradientAngle = 90;
            this.panelMain.TabIndex = 0;
            // 
            // lvPics
            // 
            // 
            // 
            // 
            this.lvPics.Border.Class = "ListViewBorder";
            this.lvPics.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvPics.DisabledBackColor = System.Drawing.Color.Empty;
            this.lvPics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPics.Location = new System.Drawing.Point(305, 50);
            this.lvPics.Name = "lvPics";
            this.lvPics.Size = new System.Drawing.Size(902, 607);
            this.lvPics.TabIndex = 4;
            this.lvPics.UseCompatibleStateImageBehavior = false;
            this.lvPics.DoubleClick += new System.EventHandler(this.lvPics_DoubleClick);
            this.lvPics.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvPics_MouseUp);
            // 
            // panelRightTop
            // 
            this.panelRightTop.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelRightTop.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelRightTop.Controls.Add(this.sliderPicSize);
            this.panelRightTop.Controls.Add(this.lbCount);
            this.panelRightTop.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightTop.Location = new System.Drawing.Point(305, 0);
            this.panelRightTop.Name = "panelRightTop";
            this.panelRightTop.Size = new System.Drawing.Size(902, 50);
            this.panelRightTop.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelRightTop.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelRightTop.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelRightTop.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelRightTop.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelRightTop.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelRightTop.Style.GradientAngle = 90;
            this.panelRightTop.TabIndex = 8;
            // 
            // sliderPicSize
            // 
            // 
            // 
            // 
            this.sliderPicSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderPicSize.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Top;
            this.sliderPicSize.Location = new System.Drawing.Point(725, 7);
            this.sliderPicSize.Name = "sliderPicSize";
            this.sliderPicSize.Size = new System.Drawing.Size(174, 38);
            this.sliderPicSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sliderPicSize.TabIndex = 1;
            this.sliderPicSize.Text = "图标大小:";
            this.sliderPicSize.Value = 0;
            this.sliderPicSize.ValueChanged += new System.EventHandler(this.sliderPicSize_ValueChanged);
            // 
            // lbCount
            // 
            // 
            // 
            // 
            this.lbCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbCount.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCount.Location = new System.Drawing.Point(6, 7);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(256, 37);
            this.lbCount.TabIndex = 0;
            this.lbCount.Text = "共有图像:28张";
            // 
            // panelLeft
            // 
            this.panelLeft.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelLeft.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelLeft.Controls.Add(this.advTree1);
            this.panelLeft.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(305, 657);
            this.panelLeft.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelLeft.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelLeft.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelLeft.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelLeft.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelLeft.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelLeft.Style.GradientAngle = 90;
            this.panelLeft.TabIndex = 0;
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = true;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.Location = new System.Drawing.Point(0, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(305, 657);
            this.advTree1.TabIndex = 1;
            this.advTree1.Click += new System.EventHandler(this.advTree1_Click);
            // 
            // cmsAdvTree
            // 
            this.cmsAdvTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存选中组ToolStripMenuItem});
            this.cmsAdvTree.Name = "cmsAdvTree";
            this.cmsAdvTree.Size = new System.Drawing.Size(137, 26);
            // 
            // 保存选中组ToolStripMenuItem
            // 
            this.保存选中组ToolStripMenuItem.Name = "保存选中组ToolStripMenuItem";
            this.保存选中组ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.保存选中组ToolStripMenuItem.Text = "保存选中组";
            // 
            // cmsListView
            // 
            this.cmsListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存图像ToolStripMenuItem});
            this.cmsListView.Name = "cmsAdvTree";
            this.cmsListView.Size = new System.Drawing.Size(125, 26);
            // 
            // 保存图像ToolStripMenuItem
            // 
            this.保存图像ToolStripMenuItem.Name = "保存图像ToolStripMenuItem";
            this.保存图像ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存图像ToolStripMenuItem.Text = "保存图像";
            this.保存图像ToolStripMenuItem.Click += new System.EventHandler(this.保存图像ToolStripMenuItem_Click);
            // 
            // FrmGaoPaiManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 657);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGaoPaiManage";
            this.Text = "高拍图像管理";
            this.Load += new System.EventHandler(this.FrmGaoPaiManage_Load);
            this.panelMain.ResumeLayout(false);
            this.panelRightTop.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.cmsAdvTree.ResumeLayout(false);
            this.cmsListView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelMain;
        private DevComponents.DotNetBar.PanelEx panelLeft;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.DotNetBar.Controls.ListViewEx lvPics;
        private System.Windows.Forms.ContextMenuStrip cmsAdvTree;
        private System.Windows.Forms.ContextMenuStrip cmsListView;
        private System.Windows.Forms.ToolStripMenuItem 保存图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存选中组ToolStripMenuItem;
        private DevComponents.DotNetBar.PanelEx panelRightTop;
        private DevComponents.DotNetBar.LabelX lbCount;
        private DevComponents.DotNetBar.Controls.Slider sliderPicSize;
    }
}