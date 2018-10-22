namespace TravelAgency.UpdateTools
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnAddFiles = new DevComponents.DotNetBar.ButtonX();
            this.txtUpdateSql = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtUpdateFilesSaveDir = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCopyUpdateFiles = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtUpdateDetails = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtVersion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnGenerate = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtRootDir = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddFiles.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddFiles.Location = new System.Drawing.Point(5, 311);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(75, 23);
            this.btnAddFiles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddFiles.TabIndex = 0;
            this.btnAddFiles.Text = "添加文件";
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // txtUpdateSql
            // 
            // 
            // 
            // 
            this.txtUpdateSql.Border.Class = "TextBoxBorder";
            this.txtUpdateSql.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUpdateSql.Location = new System.Drawing.Point(466, 156);
            this.txtUpdateSql.Multiline = true;
            this.txtUpdateSql.Name = "txtUpdateSql";
            this.txtUpdateSql.PreventEnterBeep = true;
            this.txtUpdateSql.Size = new System.Drawing.Size(237, 149);
            this.txtUpdateSql.TabIndex = 1;
            // 
            // listViewEx1
            // 
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.Path});
            this.listViewEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx1.Location = new System.Drawing.Point(5, 37);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(457, 268);
            this.listViewEx1.TabIndex = 2;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            // 
            // No
            // 
            this.No.Text = "编号";
            this.No.Width = 87;
            // 
            // Path
            // 
            this.Path.Text = "路径";
            this.Path.Width = 358;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.txtUpdateFilesSaveDir);
            this.panelEx1.Controls.Add(this.btnCopyUpdateFiles);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.txtUpdateDetails);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.txtVersion);
            this.panelEx1.Controls.Add(this.btnGenerate);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.txtRootDir);
            this.panelEx1.Controls.Add(this.listViewEx1);
            this.panelEx1.Controls.Add(this.btnAddFiles);
            this.panelEx1.Controls.Add(this.txtUpdateSql);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(706, 339);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 3;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(155, 311);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(115, 23);
            this.labelX4.TabIndex = 12;
            this.labelX4.Text = "更新文件存放目录:";
            // 
            // txtUpdateFilesSaveDir
            // 
            // 
            // 
            // 
            this.txtUpdateFilesSaveDir.Border.Class = "TextBoxBorder";
            this.txtUpdateFilesSaveDir.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUpdateFilesSaveDir.Location = new System.Drawing.Point(276, 311);
            this.txtUpdateFilesSaveDir.Name = "txtUpdateFilesSaveDir";
            this.txtUpdateFilesSaveDir.PreventEnterBeep = true;
            this.txtUpdateFilesSaveDir.Size = new System.Drawing.Size(336, 21);
            this.txtUpdateFilesSaveDir.TabIndex = 11;
            this.txtUpdateFilesSaveDir.Text = "E:\\东瀛假日签证识别管理系统更新目录";
            // 
            // btnCopyUpdateFiles
            // 
            this.btnCopyUpdateFiles.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCopyUpdateFiles.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCopyUpdateFiles.Location = new System.Drawing.Point(618, 311);
            this.btnCopyUpdateFiles.Name = "btnCopyUpdateFiles";
            this.btnCopyUpdateFiles.Size = new System.Drawing.Size(85, 23);
            this.btnCopyUpdateFiles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCopyUpdateFiles.TabIndex = 10;
            this.btnCopyUpdateFiles.Text = "拷贝更新文件";
            this.btnCopyUpdateFiles.Click += new System.EventHandler(this.btnCopyUpdateFiles_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(468, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(64, 23);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "更新详情:";
            // 
            // txtUpdateDetails
            // 
            // 
            // 
            // 
            this.txtUpdateDetails.Border.Class = "TextBoxBorder";
            this.txtUpdateDetails.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUpdateDetails.Location = new System.Drawing.Point(468, 35);
            this.txtUpdateDetails.Multiline = true;
            this.txtUpdateDetails.Name = "txtUpdateDetails";
            this.txtUpdateDetails.PreventEnterBeep = true;
            this.txtUpdateDetails.Size = new System.Drawing.Size(230, 86);
            this.txtUpdateDetails.TabIndex = 8;
            this.txtUpdateDetails.Text = "修复一些bug";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(576, 126);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(53, 23);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "版本:";
            // 
            // txtVersion
            // 
            // 
            // 
            // 
            this.txtVersion.Border.Class = "TextBoxBorder";
            this.txtVersion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtVersion.Location = new System.Drawing.Point(635, 127);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.PreventEnterBeep = true;
            this.txtVersion.Size = new System.Drawing.Size(63, 21);
            this.txtVersion.TabIndex = 6;
            this.txtVersion.Text = "5.1";
            // 
            // btnGenerate
            // 
            this.btnGenerate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerate.Location = new System.Drawing.Point(468, 127);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "生成更新SQL";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(5, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(53, 23);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "根目录:";
            // 
            // txtRootDir
            // 
            // 
            // 
            // 
            this.txtRootDir.Border.Class = "TextBoxBorder";
            this.txtRootDir.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRootDir.Location = new System.Drawing.Point(64, 6);
            this.txtRootDir.Name = "txtRootDir";
            this.txtRootDir.PreventEnterBeep = true;
            this.txtRootDir.Size = new System.Drawing.Size(398, 21);
            this.txtRootDir.TabIndex = 3;
            this.txtRootDir.Text = "E:\\东瀛假日签证识别管理系统";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 339);
            this.Controls.Add(this.panelEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "东瀛假日签证识别管理系统更新工具";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnAddFiles;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUpdateSql;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRootDir;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader Path;
        private DevComponents.DotNetBar.ButtonX btnGenerate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtVersion;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUpdateDetails;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnCopyUpdateFiles;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUpdateFilesSaveDir;
    }
}

