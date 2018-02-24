using TravelAgency.CSUI.CustomCtrls;

namespace TravelAgency.CSUI.FrmSub
{
    partial class FrmShowPicture
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
            this.panelPicBox = new DevComponents.DotNetBar.PanelEx();
            this.panelTools = new DevComponents.DotNetBar.PanelEx();
            this.btnNext = new DevComponents.DotNetBar.ButtonX();
            this.lbPageIdx = new DevComponents.DotNetBar.LabelX();
            this.btnPre = new DevComponents.DotNetBar.ButtonX();
            this.btnFlipHorizontal = new DevComponents.DotNetBar.ButtonX();
            this.btnFlipVertical = new DevComponents.DotNetBar.ButtonX();
            this.btnRight90 = new DevComponents.DotNetBar.ButtonX();
            this.btnLeft90 = new DevComponents.DotNetBar.ButtonX();
            this.cmsPicBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.旋转图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.左旋90度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.右旋90度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.垂直翻转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.水平翻转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picBox1 = new ProPictureBox();
            this.panelPicBox.SuspendLayout();
            this.panelTools.SuspendLayout();
            this.cmsPicBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPicBox
            // 
            this.panelPicBox.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelPicBox.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelPicBox.Controls.Add(this.picBox1);
            this.panelPicBox.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicBox.Location = new System.Drawing.Point(0, 0);
            this.panelPicBox.Name = "panelPicBox";
            this.panelPicBox.Size = new System.Drawing.Size(532, 706);
            this.panelPicBox.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelPicBox.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelPicBox.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelPicBox.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelPicBox.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelPicBox.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelPicBox.Style.GradientAngle = 90;
            this.panelPicBox.TabIndex = 1;
            // 
            // panelTools
            // 
            this.panelTools.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelTools.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelTools.Controls.Add(this.btnNext);
            this.panelTools.Controls.Add(this.lbPageIdx);
            this.panelTools.Controls.Add(this.btnPre);
            this.panelTools.Controls.Add(this.btnFlipHorizontal);
            this.panelTools.Controls.Add(this.btnFlipVertical);
            this.panelTools.Controls.Add(this.btnRight90);
            this.panelTools.Controls.Add(this.btnLeft90);
            this.panelTools.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTools.Location = new System.Drawing.Point(0, 706);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(532, 31);
            this.panelTools.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelTools.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelTools.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelTools.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelTools.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelTools.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelTools.Style.GradientAngle = 90;
            this.panelTools.TabIndex = 5;
            // 
            // btnNext
            // 
            this.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNext.Location = new System.Drawing.Point(217, 6);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "下一张";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbPageIdx
            // 
            // 
            // 
            // 
            this.lbPageIdx.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbPageIdx.Location = new System.Drawing.Point(167, 5);
            this.lbPageIdx.Name = "lbPageIdx";
            this.lbPageIdx.Size = new System.Drawing.Size(53, 23);
            this.lbPageIdx.TabIndex = 3;
            this.lbPageIdx.Text = "100/520";
            // 
            // btnPre
            // 
            this.btnPre.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPre.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPre.Location = new System.Drawing.Point(77, 5);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPre.TabIndex = 2;
            this.btnPre.Text = "上一张";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnFlipHorizontal
            // 
            this.btnFlipHorizontal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFlipHorizontal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFlipHorizontal.Location = new System.Drawing.Point(285, 6);
            this.btnFlipHorizontal.Name = "btnFlipHorizontal";
            this.btnFlipHorizontal.Size = new System.Drawing.Size(75, 23);
            this.btnFlipHorizontal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFlipHorizontal.TabIndex = 1;
            this.btnFlipHorizontal.Text = "水平翻转";
            this.btnFlipHorizontal.Visible = false;
            this.btnFlipHorizontal.Click += new System.EventHandler(this.btnFlipHorizontal_Click);
            // 
            // btnFlipVertical
            // 
            this.btnFlipVertical.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFlipVertical.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFlipVertical.Location = new System.Drawing.Point(267, 6);
            this.btnFlipVertical.Name = "btnFlipVertical";
            this.btnFlipVertical.Size = new System.Drawing.Size(75, 23);
            this.btnFlipVertical.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFlipVertical.TabIndex = 1;
            this.btnFlipVertical.Text = "垂直翻转";
            this.btnFlipVertical.Visible = false;
            this.btnFlipVertical.Click += new System.EventHandler(this.btnFlipVertical_Click);
            // 
            // btnRight90
            // 
            this.btnRight90.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRight90.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRight90.Location = new System.Drawing.Point(251, 6);
            this.btnRight90.Name = "btnRight90";
            this.btnRight90.Size = new System.Drawing.Size(75, 23);
            this.btnRight90.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRight90.TabIndex = 0;
            this.btnRight90.Text = "右旋90度";
            this.btnRight90.Visible = false;
            this.btnRight90.Click += new System.EventHandler(this.btnRight90_Click);
            // 
            // btnLeft90
            // 
            this.btnLeft90.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLeft90.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLeft90.Location = new System.Drawing.Point(238, 5);
            this.btnLeft90.Name = "btnLeft90";
            this.btnLeft90.Size = new System.Drawing.Size(75, 23);
            this.btnLeft90.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLeft90.TabIndex = 0;
            this.btnLeft90.Text = "左旋90度";
            this.btnLeft90.Visible = false;
            this.btnLeft90.Click += new System.EventHandler(this.btnLeft90_Click);
            // 
            // cmsPicBox
            // 
            this.cmsPicBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存图像ToolStripMenuItem,
            this.旋转图像ToolStripMenuItem});
            this.cmsPicBox.Name = "cmsPicBox";
            this.cmsPicBox.Size = new System.Drawing.Size(125, 48);
            // 
            // 保存图像ToolStripMenuItem
            // 
            this.保存图像ToolStripMenuItem.Name = "保存图像ToolStripMenuItem";
            this.保存图像ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存图像ToolStripMenuItem.Text = "保存图像";
            this.保存图像ToolStripMenuItem.Click += new System.EventHandler(this.保存图像ToolStripMenuItem_Click);
            // 
            // 旋转图像ToolStripMenuItem
            // 
            this.旋转图像ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.左旋90度ToolStripMenuItem,
            this.右旋90度ToolStripMenuItem,
            this.垂直翻转ToolStripMenuItem,
            this.水平翻转ToolStripMenuItem});
            this.旋转图像ToolStripMenuItem.Name = "旋转图像ToolStripMenuItem";
            this.旋转图像ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.旋转图像ToolStripMenuItem.Text = "旋转图像";
            // 
            // 左旋90度ToolStripMenuItem
            // 
            this.左旋90度ToolStripMenuItem.Name = "左旋90度ToolStripMenuItem";
            this.左旋90度ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.左旋90度ToolStripMenuItem.Text = "左旋90度";
            this.左旋90度ToolStripMenuItem.Click += new System.EventHandler(this.左旋90度ToolStripMenuItem_Click);
            // 
            // 右旋90度ToolStripMenuItem
            // 
            this.右旋90度ToolStripMenuItem.Name = "右旋90度ToolStripMenuItem";
            this.右旋90度ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.右旋90度ToolStripMenuItem.Text = "右旋90度";
            this.右旋90度ToolStripMenuItem.Click += new System.EventHandler(this.右旋90度ToolStripMenuItem_Click);
            // 
            // 垂直翻转ToolStripMenuItem
            // 
            this.垂直翻转ToolStripMenuItem.Name = "垂直翻转ToolStripMenuItem";
            this.垂直翻转ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.垂直翻转ToolStripMenuItem.Text = "垂直翻转";
            this.垂直翻转ToolStripMenuItem.Click += new System.EventHandler(this.垂直翻转ToolStripMenuItem_Click);
            // 
            // 水平翻转ToolStripMenuItem
            // 
            this.水平翻转ToolStripMenuItem.Name = "水平翻转ToolStripMenuItem";
            this.水平翻转ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.水平翻转ToolStripMenuItem.Text = "水平翻转";
            this.水平翻转ToolStripMenuItem.Click += new System.EventHandler(this.水平翻转ToolStripMenuItem_Click);
            // 
            // picBox1
            // 
            this.picBox1.DefaultSaveFileName = null;
            this.picBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox1.Location = new System.Drawing.Point(0, 0);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(532, 706);
            this.picBox1.TabIndex = 0;
            this.picBox1.TabStop = false;
            this.picBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBox1_MouseUp);
            // 
            // FrmShowPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 737);
            this.Controls.Add(this.panelPicBox);
            this.Controls.Add(this.panelTools);
            this.Name = "FrmShowPicture";
            this.Text = "图像查看";
            this.Load += new System.EventHandler(this.FrmShowPicture_Load);
            this.panelPicBox.ResumeLayout(false);
            this.panelTools.ResumeLayout(false);
            this.cmsPicBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ProPictureBox picBox1;
        private DevComponents.DotNetBar.PanelEx panelPicBox;
        private DevComponents.DotNetBar.PanelEx panelTools;
        private DevComponents.DotNetBar.ButtonX btnLeft90;
        private DevComponents.DotNetBar.ButtonX btnRight90;
        private DevComponents.DotNetBar.ButtonX btnFlipHorizontal;
        private DevComponents.DotNetBar.ButtonX btnFlipVertical;
        private System.Windows.Forms.ContextMenuStrip cmsPicBox;
        private System.Windows.Forms.ToolStripMenuItem 保存图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 旋转图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 左旋90度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 右旋90度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 垂直翻转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 水平翻转ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX btnPre;
        private DevComponents.DotNetBar.ButtonX btnNext;
        private DevComponents.DotNetBar.LabelX lbPageIdx;
    }
}