namespace TravelAgency.CSUI.FrmMain
{
    partial class FrmVisaInfoSubmitDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.panelDgv = new DevComponents.DotNetBar.PanelEx();
            this.dataGridView1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this._Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnglishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QRCodeImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LicenseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthplace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssuePlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outState = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.HasTypeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Types = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisaInfo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnPageFirst = new DevComponents.DotNetBar.ButtonItem();
            this.btnPagePre = new DevComponents.DotNetBar.ButtonItem();
            this.btnPageNext = new DevComponents.DotNetBar.ButtonItem();
            this.btnPageLast = new DevComponents.DotNetBar.ButtonItem();
            this.cbCurPage = new DevComponents.DotNetBar.ComboBoxItem();
            this.btnGoto = new DevComponents.DotNetBar.ButtonItem();
            this.lbRecordCount = new DevComponents.DotNetBar.LabelItem();
            this.lbl = new DevComponents.DotNetBar.LabelItem();
            this.cbPageSize = new DevComponents.DotNetBar.ComboBoxItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.lbCurPage = new DevComponents.DotNetBar.LabelItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem6 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem7 = new DevComponents.DotNetBar.LabelItem();
            this.cmsDgvRb = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsItemQRCodeShow = new System.Windows.Forms.ToolStripMenuItem();
            this.复制二维码信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemQRCodeBatchGenerate = new System.Windows.Forms.ToolStripMenuItem();
            this.更改送签状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改签证状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.panelDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.cmsDgvRb.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1271, 625);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.panelEx4);
            this.panelEx2.Controls.Add(this.panelEx3);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1271, 625);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 29;
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.panelDgv);
            this.panelEx4.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx4.Location = new System.Drawing.Point(0, 31);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(1271, 594);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 29;
            this.panelEx4.Text = "panelEx4";
            // 
            // panelDgv
            // 
            this.panelDgv.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelDgv.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDgv.Controls.Add(this.dataGridView1);
            this.panelDgv.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDgv.Location = new System.Drawing.Point(0, 0);
            this.panelDgv.Name = "panelDgv";
            this.panelDgv.Size = new System.Drawing.Size(1271, 594);
            this.panelDgv.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDgv.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelDgv.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelDgv.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelDgv.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelDgv.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelDgv.Style.GradientAngle = 90;
            this.panelDgv.TabIndex = 29;
            this.panelDgv.Text = "panelEx5";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Name,
            this.EnglishName,
            this.QRCodeImage,
            this.Sex,
            this.BirthDay,
            this.PassportNo,
            this.LicenseTime,
            this.ExpiryDate,
            this.Birthplace,
            this.IssuePlace,
            this.outState,
            this.HasTypeIn,
            this.GroupNo,
            this.Types,
            this.VisaInfo_id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1271, 594);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // _Name
            // 
            this._Name.DataPropertyName = "Name";
            this._Name.HeaderText = "本国姓名";
            this._Name.Name = "_Name";
            this._Name.ReadOnly = true;
            // 
            // EnglishName
            // 
            this.EnglishName.DataPropertyName = "EnglishName";
            this.EnglishName.HeaderText = "英语姓名";
            this.EnglishName.Name = "EnglishName";
            this.EnglishName.ReadOnly = true;
            // 
            // QRCodeImage
            // 
            this.QRCodeImage.HeaderText = "二维码";
            this.QRCodeImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.QRCodeImage.Name = "QRCodeImage";
            this.QRCodeImage.ReadOnly = true;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "Sex";
            this.Sex.HeaderText = "性别";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            // 
            // BirthDay
            // 
            this.BirthDay.DataPropertyName = "Birthday";
            this.BirthDay.HeaderText = "生日";
            this.BirthDay.Name = "BirthDay";
            this.BirthDay.ReadOnly = true;
            // 
            // PassportNo
            // 
            this.PassportNo.DataPropertyName = "PassportNo";
            this.PassportNo.HeaderText = "护照号";
            this.PassportNo.Name = "PassportNo";
            this.PassportNo.ReadOnly = true;
            // 
            // LicenseTime
            // 
            this.LicenseTime.DataPropertyName = "LicenseTime";
            this.LicenseTime.HeaderText = "发证日期";
            this.LicenseTime.Name = "LicenseTime";
            this.LicenseTime.ReadOnly = true;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.DataPropertyName = "ExpiryDate";
            this.ExpiryDate.HeaderText = "有效期";
            this.ExpiryDate.Name = "ExpiryDate";
            this.ExpiryDate.ReadOnly = true;
            // 
            // Birthplace
            // 
            this.Birthplace.DataPropertyName = "Birthplace";
            this.Birthplace.HeaderText = "出生地";
            this.Birthplace.Name = "Birthplace";
            this.Birthplace.ReadOnly = true;
            // 
            // IssuePlace
            // 
            this.IssuePlace.DataPropertyName = "IssuePlace";
            this.IssuePlace.HeaderText = "签发地";
            this.IssuePlace.Name = "IssuePlace";
            this.IssuePlace.ReadOnly = true;
            // 
            // outState
            // 
            this.outState.DataPropertyName = "outState";
            this.outState.HeaderText = "送签状态";
            this.outState.Name = "outState";
            this.outState.ReadOnly = true;
            this.outState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.outState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // HasTypeIn
            // 
            this.HasTypeIn.DataPropertyName = "HasTypeIn";
            this.HasTypeIn.HeaderText = "资料录入";
            this.HasTypeIn.Name = "HasTypeIn";
            this.HasTypeIn.ReadOnly = true;
            // 
            // GroupNo
            // 
            this.GroupNo.DataPropertyName = "GroupNo";
            this.GroupNo.HeaderText = "团号";
            this.GroupNo.Name = "GroupNo";
            this.GroupNo.ReadOnly = true;
            // 
            // Types
            // 
            this.Types.DataPropertyName = "Types";
            this.Types.HeaderText = "类型";
            this.Types.Name = "Types";
            this.Types.ReadOnly = true;
            // 
            // VisaInfo_id
            // 
            this.VisaInfo_id.DataPropertyName = "VisaInfo_id";
            this.VisaInfo_id.HeaderText = "VisaInfo_id";
            this.VisaInfo_id.Name = "VisaInfo_id";
            this.VisaInfo_id.ReadOnly = true;
            this.VisaInfo_id.Visible = false;
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.bar1);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(1271, 31);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 25;
            this.panelEx3.Text = "panelEx3";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.bar1.DockTabStripHeight = 30;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPageFirst,
            this.btnPagePre,
            this.btnPageNext,
            this.btnPageLast,
            this.cbCurPage,
            this.btnGoto,
            this.lbRecordCount,
            this.lbl,
            this.cbPageSize,
            this.labelItem2,
            this.lbCurPage,
            this.labelItem1,
            this.labelItem3,
            this.labelItem4,
            this.labelItem5,
            this.labelItem6,
            this.labelItem7});
            this.bar1.ItemSpacing = 5;
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1271, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 24;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnPageFirst
            // 
            this.btnPageFirst.Name = "btnPageFirst";
            this.btnPageFirst.Text = "首页";
            // 
            // btnPagePre
            // 
            this.btnPagePre.Name = "btnPagePre";
            this.btnPagePre.Text = "上一页";
            // 
            // btnPageNext
            // 
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.Text = "下一页";
            // 
            // btnPageLast
            // 
            this.btnPageLast.Name = "btnPageLast";
            this.btnPageLast.Text = "尾页";
            // 
            // cbCurPage
            // 
            this.cbCurPage.DropDownHeight = 106;
            this.cbCurPage.ItemHeight = 17;
            this.cbCurPage.Name = "cbCurPage";
            // 
            // btnGoto
            // 
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Text = "Go";
            // 
            // lbRecordCount
            // 
            this.lbRecordCount.Name = "lbRecordCount";
            this.lbRecordCount.Text = "共有记录";
            // 
            // lbl
            // 
            this.lbl.Name = "lbl";
            this.lbl.Text = "每页显示";
            // 
            // cbPageSize
            // 
            this.cbPageSize.DropDownHeight = 106;
            this.cbPageSize.ItemHeight = 17;
            this.cbPageSize.Name = "cbPageSize";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "条";
            // 
            // lbCurPage
            // 
            this.lbCurPage.Name = "lbCurPage";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "进签:";
            // 
            // labelItem3
            // 
            this.labelItem3.BackColor = System.Drawing.Color.Yellow;
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "          ";
            // 
            // labelItem4
            // 
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = "出签:";
            // 
            // labelItem5
            // 
            this.labelItem5.BackColor = System.Drawing.Color.Green;
            this.labelItem5.Name = "labelItem5";
            this.labelItem5.Text = "          ";
            // 
            // labelItem6
            // 
            this.labelItem6.Name = "labelItem6";
            this.labelItem6.Text = "未正常出签:";
            // 
            // labelItem7
            // 
            this.labelItem7.BackColor = System.Drawing.Color.Red;
            this.labelItem7.Name = "labelItem7";
            this.labelItem7.Text = "          ";
            // 
            // cmsDgvRb
            // 
            this.cmsDgvRb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItemQRCodeShow,
            this.复制二维码信息ToolStripMenuItem,
            this.cmsItemQRCodeBatchGenerate,
            this.更改送签状态ToolStripMenuItem});
            this.cmsDgvRb.Name = "cmsDgvRb";
            this.cmsDgvRb.Size = new System.Drawing.Size(161, 114);
            // 
            // cmsItemQRCodeShow
            // 
            this.cmsItemQRCodeShow.Name = "cmsItemQRCodeShow";
            this.cmsItemQRCodeShow.Size = new System.Drawing.Size(160, 22);
            this.cmsItemQRCodeShow.Text = "显示二维码";
            this.cmsItemQRCodeShow.Click += new System.EventHandler(this.showQRCode_Click);
            // 
            // 复制二维码信息ToolStripMenuItem
            // 
            this.复制二维码信息ToolStripMenuItem.Name = "复制二维码信息ToolStripMenuItem";
            this.复制二维码信息ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.复制二维码信息ToolStripMenuItem.Text = "复制二维码信息";
            this.复制二维码信息ToolStripMenuItem.Click += new System.EventHandler(this.复制二维码信息ToolStripMenuItem_Click);
            // 
            // cmsItemQRCodeBatchGenerate
            // 
            this.cmsItemQRCodeBatchGenerate.Name = "cmsItemQRCodeBatchGenerate";
            this.cmsItemQRCodeBatchGenerate.Size = new System.Drawing.Size(160, 22);
            this.cmsItemQRCodeBatchGenerate.Text = "批量生成二维码";
            this.cmsItemQRCodeBatchGenerate.Click += new System.EventHandler(this.cmsItemQRCodeBatchGenerate_Click);
            // 
            // 更改送签状态ToolStripMenuItem
            // 
            this.更改送签状态ToolStripMenuItem.Name = "更改送签状态ToolStripMenuItem";
            this.更改送签状态ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.更改送签状态ToolStripMenuItem.Text = "更改送签状态";
            this.更改送签状态ToolStripMenuItem.Click += new System.EventHandler(this.更改送签状态ToolStripMenuItem_Click);
            // 
            // 修改签证状态ToolStripMenuItem
            // 
            this.修改签证状态ToolStripMenuItem.Name = "修改签证状态ToolStripMenuItem";
            this.修改签证状态ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.修改签证状态ToolStripMenuItem.Text = "修改送签状态";
            // 
            // FrmVisaInfoSubmitDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 625);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmVisaInfoSubmitDetails";
            this.Text = "团号送签情况明细查看";
            this.Load += new System.EventHandler(this.FrmVisaSubmit_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
            this.panelDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelEx3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.cmsDgvRb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnPageFirst;
        private DevComponents.DotNetBar.ButtonItem btnPagePre;
        private DevComponents.DotNetBar.ButtonItem btnPageNext;
        private DevComponents.DotNetBar.ButtonItem btnPageLast;
        private DevComponents.DotNetBar.ComboBoxItem cbCurPage;
        private DevComponents.DotNetBar.ButtonItem btnGoto;
        private DevComponents.DotNetBar.LabelItem lbRecordCount;
        private DevComponents.DotNetBar.LabelItem lbl;
        private DevComponents.DotNetBar.ComboBoxItem cbPageSize;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.LabelItem lbCurPage;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.ContextMenuStrip cmsDgvRb;
        private System.Windows.Forms.ToolStripMenuItem cmsItemQRCodeShow;
        private System.Windows.Forms.ToolStripMenuItem cmsItemQRCodeBatchGenerate;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.DotNetBar.LabelItem labelItem5;
        private DevComponents.DotNetBar.LabelItem labelItem6;
        private DevComponents.DotNetBar.LabelItem labelItem7;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnglishName;
        private System.Windows.Forms.DataGridViewImageColumn QRCodeImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassportNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LicenseTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthplace;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssuePlace;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn outState;
        private System.Windows.Forms.DataGridViewTextBoxColumn HasTypeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Types;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisaInfo_id;
        private DevComponents.DotNetBar.PanelEx panelDgv;
        private System.Windows.Forms.ToolStripMenuItem 更改送签状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改签证状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制二维码信息ToolStripMenuItem;
    }
}