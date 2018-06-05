namespace TravelAgency.CSUI.Financial.FrmMain
{
    partial class FrmVisaClaimManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lbInfoManifest = new DevComponents.DotNetBar.LabelItem();
            this.dataGridView1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cmsDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemRefreshDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsItemShowGroupNo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.生成账单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.签证认账ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBars = new DevComponents.DotNetBar.PanelEx();
            this.panelSerachBar = new DevComponents.DotNetBar.PanelEx();
            this.cbClaimedFlag = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtSchFinishTimeTo = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtSchFinishTimeFrom = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.progressLoading = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.lbMonneyCount = new DevComponents.DotNetBar.LabelX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.txtSalesPerson = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtClient = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbDepatureType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cbCountry = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnShowToday = new DevComponents.DotNetBar.ButtonX();
            this.cbDisplayType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnClearSchConditions = new DevComponents.DotNetBar.ButtonX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.txtSchGroupNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lb1 = new DevComponents.DotNetBar.LabelX();
            this.txtSchRealTimeTo = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtSchRealTimeFrom = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.btnShowAll = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.bgWorkerLoadData = new System.ComponentModel.BackgroundWorker();
            this.labelItem8 = new DevComponents.DotNetBar.LabelItem();
            this.panelDgv = new DevComponents.DotNetBar.PanelEx();
            this.GroupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.RealTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Person = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tips = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tips2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Types = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUrgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeInPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActuallyAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaimedFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quidco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsulateCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisaPersonCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvitationCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubmitFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visa_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmsDgv.SuspendLayout();
            this.panelBars.SuspendLayout();
            this.panelSerachBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchFinishTimeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchFinishTimeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchRealTimeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchRealTimeFrom)).BeginInit();
            this.panelDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.lbInfoManifest});
            this.bar1.ItemSpacing = 5;
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1381, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 25;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnPageFirst
            // 
            this.btnPageFirst.Name = "btnPageFirst";
            this.btnPageFirst.Text = "首页";
            this.btnPageFirst.Click += new System.EventHandler(this.btnPageFirst_Click);
            // 
            // btnPagePre
            // 
            this.btnPagePre.Name = "btnPagePre";
            this.btnPagePre.Text = "上一页";
            this.btnPagePre.Click += new System.EventHandler(this.btnPagePre_Click);
            // 
            // btnPageNext
            // 
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.Text = "下一页";
            this.btnPageNext.Click += new System.EventHandler(this.btnPageNext_Click);
            // 
            // btnPageLast
            // 
            this.btnPageLast.Name = "btnPageLast";
            this.btnPageLast.Text = "尾页";
            this.btnPageLast.Click += new System.EventHandler(this.btnPageLast_Click);
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
            this.cbPageSize.TextChanged += new System.EventHandler(this.cbPageSize_TextChanged);
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
            // lbInfoManifest
            // 
            this.lbInfoManifest.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbInfoManifest.ForeColor = System.Drawing.Color.Red;
            this.lbInfoManifest.Name = "lbInfoManifest";
            this.lbInfoManifest.Text = "总价单价规则说明";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupNo,
            this.Country,
            this.CountryImage,
            this.RealTime,
            this.FinishTime,
            this.Person,
            this.Number,
            this.Tips,
            this.Tips2,
            this.EntryTime,
            this.Types,
            this.IsUrgent,
            this.Status,
            this.DepartureType,
            this.Client,
            this.SalesPerson,
            this.TypeInPerson,
            this.Price,
            this.ActuallyAmount,
            this.ClaimedFlag,
            this.Quidco,
            this.ConsulateCost,
            this.VisaPersonCost,
            this.InvitationCost,
            this.Picture,
            this.MailCost,
            this.OtherCost,
            this.Cost,
            this.SubmitFlag,
            this.Visa_id});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1381, 480);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // cmsDgv
            // 
            this.cmsDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem,
            this.cmsItemRefreshDatabase,
            this.toolStripSeparator3,
            this.cmsItemShowGroupNo,
            this.toolStripSeparator2,
            this.生成账单ToolStripMenuItem,
            this.签证认账ToolStripMenuItem});
            this.cmsDgv.Name = "cmsDgv";
            this.cmsDgv.Size = new System.Drawing.Size(185, 148);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.复制ToolStripMenuItem.Text = "复制单元格所选内容";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // cmsItemRefreshDatabase
            // 
            this.cmsItemRefreshDatabase.Name = "cmsItemRefreshDatabase";
            this.cmsItemRefreshDatabase.Size = new System.Drawing.Size(184, 22);
            this.cmsItemRefreshDatabase.Text = "刷新数据库状态";
            this.cmsItemRefreshDatabase.Click += new System.EventHandler(this.cmsItemRefreshDatabase_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // cmsItemShowGroupNo
            // 
            this.cmsItemShowGroupNo.Name = "cmsItemShowGroupNo";
            this.cmsItemShowGroupNo.Size = new System.Drawing.Size(184, 22);
            this.cmsItemShowGroupNo.Text = "查看选中团号";
            this.cmsItemShowGroupNo.Visible = false;
            this.cmsItemShowGroupNo.Click += new System.EventHandler(this.cmsItemShowGroupNo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // 生成账单ToolStripMenuItem
            // 
            this.生成账单ToolStripMenuItem.Name = "生成账单ToolStripMenuItem";
            this.生成账单ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.生成账单ToolStripMenuItem.Text = "生成账单";
            this.生成账单ToolStripMenuItem.Visible = false;
            this.生成账单ToolStripMenuItem.Click += new System.EventHandler(this.生成账单ToolStripMenuItem_Click);
            // 
            // 签证认账ToolStripMenuItem
            // 
            this.签证认账ToolStripMenuItem.Name = "签证认账ToolStripMenuItem";
            this.签证认账ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.签证认账ToolStripMenuItem.Text = "签证认账";
            this.签证认账ToolStripMenuItem.Click += new System.EventHandler(this.签证认账ToolStripMenuItem_Click);
            // 
            // panelBars
            // 
            this.panelBars.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelBars.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelBars.Controls.Add(this.panelSerachBar);
            this.panelBars.Controls.Add(this.bar1);
            this.panelBars.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelBars.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBars.Location = new System.Drawing.Point(0, 0);
            this.panelBars.Name = "panelBars";
            this.panelBars.Size = new System.Drawing.Size(1381, 94);
            this.panelBars.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelBars.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelBars.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelBars.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelBars.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelBars.Style.GradientAngle = 90;
            this.panelBars.TabIndex = 30;
            // 
            // panelSerachBar
            // 
            this.panelSerachBar.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelSerachBar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelSerachBar.Controls.Add(this.cbClaimedFlag);
            this.panelSerachBar.Controls.Add(this.labelX2);
            this.panelSerachBar.Controls.Add(this.txtSchFinishTimeTo);
            this.panelSerachBar.Controls.Add(this.txtSchFinishTimeFrom);
            this.panelSerachBar.Controls.Add(this.labelX1);
            this.panelSerachBar.Controls.Add(this.labelX8);
            this.panelSerachBar.Controls.Add(this.progressLoading);
            this.panelSerachBar.Controls.Add(this.lbMonneyCount);
            this.panelSerachBar.Controls.Add(this.btnUpdate);
            this.panelSerachBar.Controls.Add(this.txtSalesPerson);
            this.panelSerachBar.Controls.Add(this.txtClient);
            this.panelSerachBar.Controls.Add(this.cbDepatureType);
            this.panelSerachBar.Controls.Add(this.labelX7);
            this.panelSerachBar.Controls.Add(this.labelX5);
            this.panelSerachBar.Controls.Add(this.labelX6);
            this.panelSerachBar.Controls.Add(this.cbCountry);
            this.panelSerachBar.Controls.Add(this.labelX3);
            this.panelSerachBar.Controls.Add(this.btnShowToday);
            this.panelSerachBar.Controls.Add(this.cbDisplayType);
            this.panelSerachBar.Controls.Add(this.btnClearSchConditions);
            this.panelSerachBar.Controls.Add(this.labelX15);
            this.panelSerachBar.Controls.Add(this.txtSchGroupNo);
            this.panelSerachBar.Controls.Add(this.lb1);
            this.panelSerachBar.Controls.Add(this.txtSchRealTimeTo);
            this.panelSerachBar.Controls.Add(this.txtSchRealTimeFrom);
            this.panelSerachBar.Controls.Add(this.labelX14);
            this.panelSerachBar.Controls.Add(this.labelX12);
            this.panelSerachBar.Controls.Add(this.btnShowAll);
            this.panelSerachBar.Controls.Add(this.btnSearch);
            this.panelSerachBar.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelSerachBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSerachBar.Location = new System.Drawing.Point(0, 28);
            this.panelSerachBar.Name = "panelSerachBar";
            this.panelSerachBar.Size = new System.Drawing.Size(1381, 66);
            this.panelSerachBar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelSerachBar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelSerachBar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelSerachBar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelSerachBar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelSerachBar.Style.GradientAngle = 90;
            this.panelSerachBar.TabIndex = 29;
            // 
            // cbClaimedFlag
            // 
            this.cbClaimedFlag.DisplayMember = "Text";
            this.cbClaimedFlag.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbClaimedFlag.ForeColor = System.Drawing.Color.Black;
            this.cbClaimedFlag.FormattingEnabled = true;
            this.cbClaimedFlag.ItemHeight = 15;
            this.cbClaimedFlag.Location = new System.Drawing.Point(432, 35);
            this.cbClaimedFlag.Name = "cbClaimedFlag";
            this.cbClaimedFlag.Size = new System.Drawing.Size(82, 21);
            this.cbClaimedFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbClaimedFlag.TabIndex = 56;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(360, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(66, 21);
            this.labelX2.TabIndex = 55;
            this.labelX2.Text = "认账状态:";
            // 
            // txtSchFinishTimeTo
            // 
            // 
            // 
            // 
            this.txtSchFinishTimeTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSchFinishTimeTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchFinishTimeTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtSchFinishTimeTo.ButtonDropDown.Visible = true;
            this.txtSchFinishTimeTo.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtSchFinishTimeTo.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtSchFinishTimeTo.IsPopupCalendarOpen = false;
            this.txtSchFinishTimeTo.Location = new System.Drawing.Point(1299, 3);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtSchFinishTimeTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchFinishTimeTo.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtSchFinishTimeTo.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtSchFinishTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtSchFinishTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchFinishTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtSchFinishTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSchFinishTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtSchFinishTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtSchFinishTimeTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchFinishTimeTo.MonthCalendar.DisplayMonth = new System.DateTime(2017, 11, 1, 0, 0, 0, 0);
            this.txtSchFinishTimeTo.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtSchFinishTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtSchFinishTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchFinishTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtSchFinishTimeTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchFinishTimeTo.MonthCalendar.TodayButtonVisible = true;
            this.txtSchFinishTimeTo.Name = "txtSchFinishTimeTo";
            this.txtSchFinishTimeTo.Size = new System.Drawing.Size(132, 21);
            this.txtSchFinishTimeTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtSchFinishTimeTo.TabIndex = 52;
            this.txtSchFinishTimeTo.Visible = false;
            // 
            // txtSchFinishTimeFrom
            // 
            // 
            // 
            // 
            this.txtSchFinishTimeFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSchFinishTimeFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchFinishTimeFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtSchFinishTimeFrom.ButtonDropDown.Visible = true;
            this.txtSchFinishTimeFrom.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtSchFinishTimeFrom.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtSchFinishTimeFrom.IsPopupCalendarOpen = false;
            this.txtSchFinishTimeFrom.Location = new System.Drawing.Point(1149, 2);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtSchFinishTimeFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchFinishTimeFrom.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtSchFinishTimeFrom.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtSchFinishTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtSchFinishTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchFinishTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtSchFinishTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSchFinishTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtSchFinishTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtSchFinishTimeFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchFinishTimeFrom.MonthCalendar.DisplayMonth = new System.DateTime(2017, 11, 1, 0, 0, 0, 0);
            this.txtSchFinishTimeFrom.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtSchFinishTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtSchFinishTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchFinishTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtSchFinishTimeFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchFinishTimeFrom.MonthCalendar.TodayButtonVisible = true;
            this.txtSchFinishTimeFrom.Name = "txtSchFinishTimeFrom";
            this.txtSchFinishTimeFrom.Size = new System.Drawing.Size(132, 21);
            this.txtSchFinishTimeFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtSchFinishTimeFrom.TabIndex = 51;
            this.txtSchFinishTimeFrom.Visible = false;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(1283, 2);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(13, 21);
            this.labelX1.TabIndex = 50;
            this.labelX1.Text = "-";
            this.labelX1.Visible = false;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(1094, 2);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(63, 21);
            this.labelX8.TabIndex = 49;
            this.labelX8.Text = "出签时间:";
            this.labelX8.Visible = false;
            // 
            // progressLoading
            // 
            // 
            // 
            // 
            this.progressLoading.BackgroundStyle.BackgroundImageAlpha = ((byte)(64));
            this.progressLoading.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressLoading.FocusCuesEnabled = false;
            this.progressLoading.Location = new System.Drawing.Point(1220, 5);
            this.progressLoading.Name = "progressLoading";
            this.progressLoading.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.progressLoading.ProgressColor = System.Drawing.Color.YellowGreen;
            this.progressLoading.Size = new System.Drawing.Size(73, 55);
            this.progressLoading.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.progressLoading.TabIndex = 27;
            this.progressLoading.Value = 100;
            // 
            // lbMonneyCount
            // 
            // 
            // 
            // 
            this.lbMonneyCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbMonneyCount.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMonneyCount.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbMonneyCount.Location = new System.Drawing.Point(1093, 5);
            this.lbMonneyCount.Name = "lbMonneyCount";
            this.lbMonneyCount.Size = new System.Drawing.Size(166, 51);
            this.lbMonneyCount.TabIndex = 54;
            this.lbMonneyCount.Text = "共12000元";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(999, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 52);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 53;
            this.btnUpdate.Text = "提交修改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtSalesPerson
            // 
            this.txtSalesPerson.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSalesPerson.Border.Class = "TextBoxBorder";
            this.txtSalesPerson.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSalesPerson.DisabledBackColor = System.Drawing.Color.White;
            this.txtSalesPerson.ForeColor = System.Drawing.Color.Black;
            this.txtSalesPerson.Location = new System.Drawing.Point(738, 36);
            this.txtSalesPerson.Name = "txtSalesPerson";
            this.txtSalesPerson.Size = new System.Drawing.Size(60, 21);
            this.txtSalesPerson.TabIndex = 42;
            // 
            // txtClient
            // 
            this.txtClient.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtClient.Border.Class = "TextBoxBorder";
            this.txtClient.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClient.DisabledBackColor = System.Drawing.Color.White;
            this.txtClient.ForeColor = System.Drawing.Color.Black;
            this.txtClient.Location = new System.Drawing.Point(738, 6);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(60, 21);
            this.txtClient.TabIndex = 43;
            // 
            // cbDepatureType
            // 
            this.cbDepatureType.DisplayMember = "Text";
            this.cbDepatureType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDepatureType.ForeColor = System.Drawing.Color.Black;
            this.cbDepatureType.FormattingEnabled = true;
            this.cbDepatureType.ItemHeight = 15;
            this.cbDepatureType.Location = new System.Drawing.Point(614, 5);
            this.cbDepatureType.Name = "cbDepatureType";
            this.cbDepatureType.Size = new System.Drawing.Size(82, 21);
            this.cbDepatureType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDepatureType.TabIndex = 47;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(555, 7);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(66, 21);
            this.labelX7.TabIndex = 46;
            this.labelX7.Text = "出境类型:";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(704, 38);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(37, 21);
            this.labelX5.TabIndex = 44;
            this.labelX5.Text = "销售:";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(704, 6);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(37, 21);
            this.labelX6.TabIndex = 45;
            this.labelX6.Text = "客户:";
            // 
            // cbCountry
            // 
            this.cbCountry.DisplayMember = "Text";
            this.cbCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCountry.ForeColor = System.Drawing.Color.Black;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.ItemHeight = 15;
            this.cbCountry.Location = new System.Drawing.Point(471, 5);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(79, 21);
            this.cbCountry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbCountry.TabIndex = 36;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(419, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(46, 21);
            this.labelX3.TabIndex = 35;
            this.labelX3.Text = "国家:";
            // 
            // btnShowToday
            // 
            this.btnShowToday.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowToday.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowToday.Location = new System.Drawing.Point(902, 34);
            this.btnShowToday.Name = "btnShowToday";
            this.btnShowToday.Size = new System.Drawing.Size(92, 23);
            this.btnShowToday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowToday.TabIndex = 31;
            this.btnShowToday.Text = "显示今日";
            this.btnShowToday.Click += new System.EventHandler(this.btnShowToday_Click);
            // 
            // cbDisplayType
            // 
            this.cbDisplayType.DisplayMember = "Text";
            this.cbDisplayType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDisplayType.ForeColor = System.Drawing.Color.Black;
            this.cbDisplayType.FormattingEnabled = true;
            this.cbDisplayType.ItemHeight = 15;
            this.cbDisplayType.Location = new System.Drawing.Point(333, 6);
            this.cbDisplayType.Name = "cbDisplayType";
            this.cbDisplayType.Size = new System.Drawing.Size(79, 21);
            this.cbDisplayType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDisplayType.TabIndex = 30;
            // 
            // btnClearSchConditions
            // 
            this.btnClearSchConditions.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearSchConditions.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClearSchConditions.Location = new System.Drawing.Point(804, 34);
            this.btnClearSchConditions.Name = "btnClearSchConditions";
            this.btnClearSchConditions.Size = new System.Drawing.Size(92, 23);
            this.btnClearSchConditions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClearSchConditions.TabIndex = 26;
            this.btnClearSchConditions.Text = "清空搜索条件";
            this.btnClearSchConditions.Click += new System.EventHandler(this.btnClearSchConditions_Click);
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(298, 7);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(46, 21);
            this.labelX15.TabIndex = 24;
            this.labelX15.Text = "类型:";
            // 
            // txtSchGroupNo
            // 
            this.txtSchGroupNo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSchGroupNo.Border.Class = "TextBoxBorder";
            this.txtSchGroupNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchGroupNo.DisabledBackColor = System.Drawing.Color.White;
            this.txtSchGroupNo.ForeColor = System.Drawing.Color.Black;
            this.txtSchGroupNo.Location = new System.Drawing.Point(62, 7);
            this.txtSchGroupNo.Name = "txtSchGroupNo";
            this.txtSchGroupNo.Size = new System.Drawing.Size(230, 21);
            this.txtSchGroupNo.TabIndex = 23;
            // 
            // lb1
            // 
            // 
            // 
            // 
            this.lb1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb1.Location = new System.Drawing.Point(7, 8);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(49, 21);
            this.lb1.TabIndex = 22;
            this.lb1.Text = "团号:";
            // 
            // txtSchRealTimeTo
            // 
            // 
            // 
            // 
            this.txtSchRealTimeTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSchRealTimeTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchRealTimeTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtSchRealTimeTo.ButtonDropDown.Visible = true;
            this.txtSchRealTimeTo.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtSchRealTimeTo.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtSchRealTimeTo.IsPopupCalendarOpen = false;
            this.txtSchRealTimeTo.Location = new System.Drawing.Point(212, 36);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtSchRealTimeTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchRealTimeTo.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtSchRealTimeTo.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtSchRealTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtSchRealTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchRealTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtSchRealTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSchRealTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtSchRealTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtSchRealTimeTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchRealTimeTo.MonthCalendar.DisplayMonth = new System.DateTime(2017, 11, 1, 0, 0, 0, 0);
            this.txtSchRealTimeTo.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtSchRealTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtSchRealTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchRealTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtSchRealTimeTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchRealTimeTo.MonthCalendar.TodayButtonVisible = true;
            this.txtSchRealTimeTo.Name = "txtSchRealTimeTo";
            this.txtSchRealTimeTo.Size = new System.Drawing.Size(132, 21);
            this.txtSchRealTimeTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtSchRealTimeTo.TabIndex = 21;
            // 
            // txtSchRealTimeFrom
            // 
            // 
            // 
            // 
            this.txtSchRealTimeFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSchRealTimeFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchRealTimeFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtSchRealTimeFrom.ButtonDropDown.Visible = true;
            this.txtSchRealTimeFrom.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtSchRealTimeFrom.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtSchRealTimeFrom.IsPopupCalendarOpen = false;
            this.txtSchRealTimeFrom.Location = new System.Drawing.Point(62, 35);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtSchRealTimeFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchRealTimeFrom.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtSchRealTimeFrom.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtSchRealTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtSchRealTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchRealTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtSchRealTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSchRealTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtSchRealTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtSchRealTimeFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchRealTimeFrom.MonthCalendar.DisplayMonth = new System.DateTime(2017, 11, 1, 0, 0, 0, 0);
            this.txtSchRealTimeFrom.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtSchRealTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtSchRealTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchRealTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtSchRealTimeFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchRealTimeFrom.MonthCalendar.TodayButtonVisible = true;
            this.txtSchRealTimeFrom.Name = "txtSchRealTimeFrom";
            this.txtSchRealTimeFrom.Size = new System.Drawing.Size(132, 21);
            this.txtSchRealTimeFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtSchRealTimeFrom.TabIndex = 20;
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(196, 35);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(13, 21);
            this.labelX14.TabIndex = 19;
            this.labelX14.Text = "-";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(7, 35);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(63, 21);
            this.labelX12.TabIndex = 17;
            this.labelX12.Text = "进签时间:";
            // 
            // btnShowAll
            // 
            this.btnShowAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowAll.Location = new System.Drawing.Point(902, 5);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(91, 23);
            this.btnShowAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowAll.TabIndex = 14;
            this.btnShowAll.Text = "显示全部";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(804, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // bgWorkerLoadData
            // 
            this.bgWorkerLoadData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoadData_DoWork);
            this.bgWorkerLoadData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerLoadData_ProgressChanged);
            this.bgWorkerLoadData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoadData_RunWorkerCompleted);
            // 
            // labelItem8
            // 
            this.labelItem8.Name = "labelItem8";
            this.labelItem8.Text = "显示类型:";
            // 
            // panelDgv
            // 
            this.panelDgv.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelDgv.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDgv.Controls.Add(this.dataGridView1);
            this.panelDgv.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDgv.Location = new System.Drawing.Point(0, 94);
            this.panelDgv.Name = "panelDgv";
            this.panelDgv.Size = new System.Drawing.Size(1381, 480);
            this.panelDgv.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDgv.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelDgv.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelDgv.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelDgv.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelDgv.Style.GradientAngle = 90;
            this.panelDgv.TabIndex = 37;
            this.panelDgv.Text = "panelEx1";
            // 
            // GroupNo
            // 
            this.GroupNo.DataPropertyName = "GroupNo";
            this.GroupNo.HeaderText = "团号";
            this.GroupNo.Name = "GroupNo";
            this.GroupNo.ReadOnly = true;
            this.GroupNo.Width = 300;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "国家";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // CountryImage
            // 
            this.CountryImage.HeaderText = "国家图标";
            this.CountryImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.CountryImage.Name = "CountryImage";
            this.CountryImage.ReadOnly = true;
            this.CountryImage.Width = 200;
            // 
            // RealTime
            // 
            this.RealTime.DataPropertyName = "RealTime";
            this.RealTime.HeaderText = "送签日期";
            this.RealTime.Name = "RealTime";
            this.RealTime.ReadOnly = true;
            // 
            // FinishTime
            // 
            this.FinishTime.DataPropertyName = "FinishTime";
            this.FinishTime.HeaderText = "出签日期";
            this.FinishTime.Name = "FinishTime";
            this.FinishTime.ReadOnly = true;
            // 
            // Person
            // 
            this.Person.DataPropertyName = "Person";
            this.Person.HeaderText = "送签社担当";
            this.Person.Name = "Person";
            this.Person.ReadOnly = true;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "人数";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // Tips
            // 
            this.Tips.DataPropertyName = "Tips";
            this.Tips.HeaderText = "备注1";
            this.Tips.Name = "Tips";
            this.Tips.ReadOnly = true;
            // 
            // Tips2
            // 
            this.Tips2.DataPropertyName = "Tips2";
            this.Tips2.HeaderText = "备注2";
            this.Tips2.Name = "Tips2";
            this.Tips2.ReadOnly = true;
            // 
            // EntryTime
            // 
            this.EntryTime.DataPropertyName = "EntryTime";
            this.EntryTime.HeaderText = "办理时间";
            this.EntryTime.Name = "EntryTime";
            this.EntryTime.ReadOnly = true;
            this.EntryTime.Visible = false;
            // 
            // Types
            // 
            this.Types.DataPropertyName = "Types";
            this.Types.HeaderText = "类型";
            this.Types.Name = "Types";
            this.Types.ReadOnly = true;
            // 
            // IsUrgent
            // 
            this.IsUrgent.DataPropertyName = "IsUrgent";
            this.IsUrgent.HeaderText = "是否急件";
            this.IsUrgent.Name = "IsUrgent";
            this.IsUrgent.ReadOnly = true;
            this.IsUrgent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsUrgent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IsUrgent.Visible = false;
            // 
            // Status
            // 
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            // 
            // DepartureType
            // 
            this.DepartureType.DataPropertyName = "DepartureType";
            this.DepartureType.HeaderText = "出境类型";
            this.DepartureType.Name = "DepartureType";
            this.DepartureType.ReadOnly = true;
            // 
            // Client
            // 
            this.Client.DataPropertyName = "Client";
            this.Client.HeaderText = "客户";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            // 
            // SalesPerson
            // 
            this.SalesPerson.DataPropertyName = "SalesPerson";
            this.SalesPerson.HeaderText = "销售";
            this.SalesPerson.Name = "SalesPerson";
            this.SalesPerson.ReadOnly = true;
            // 
            // TypeInPerson
            // 
            this.TypeInPerson.DataPropertyName = "TypeInPerson";
            this.TypeInPerson.HeaderText = "做资料员";
            this.TypeInPerson.Name = "TypeInPerson";
            this.TypeInPerson.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // ActuallyAmount
            // 
            this.ActuallyAmount.DataPropertyName = "ActuallyAmount";
            this.ActuallyAmount.HeaderText = "实收";
            this.ActuallyAmount.Name = "ActuallyAmount";
            this.ActuallyAmount.ReadOnly = true;
            // 
            // ClaimedFlag
            // 
            this.ClaimedFlag.DataPropertyName = "ClaimedFlag";
            this.ClaimedFlag.HeaderText = "已认账";
            this.ClaimedFlag.Name = "ClaimedFlag";
            this.ClaimedFlag.ReadOnly = true;
            // 
            // Quidco
            // 
            this.Quidco.DataPropertyName = "Quidco";
            this.Quidco.HeaderText = "返款";
            this.Quidco.Name = "Quidco";
            this.Quidco.ReadOnly = true;
            this.Quidco.Visible = false;
            // 
            // ConsulateCost
            // 
            this.ConsulateCost.DataPropertyName = "ConsulateCost";
            this.ConsulateCost.HeaderText = "领馆收费";
            this.ConsulateCost.Name = "ConsulateCost";
            this.ConsulateCost.ReadOnly = true;
            this.ConsulateCost.Visible = false;
            // 
            // VisaPersonCost
            // 
            this.VisaPersonCost.DataPropertyName = "VisaPersonCost";
            this.VisaPersonCost.HeaderText = "送签员费用";
            this.VisaPersonCost.Name = "VisaPersonCost";
            this.VisaPersonCost.ReadOnly = true;
            this.VisaPersonCost.Visible = false;
            // 
            // InvitationCost
            // 
            this.InvitationCost.DataPropertyName = "InvitationCost";
            this.InvitationCost.HeaderText = "邀请函费用";
            this.InvitationCost.Name = "InvitationCost";
            this.InvitationCost.ReadOnly = true;
            this.InvitationCost.Visible = false;
            // 
            // Picture
            // 
            this.Picture.DataPropertyName = "Picture";
            this.Picture.HeaderText = "洗照片";
            this.Picture.Name = "Picture";
            this.Picture.ReadOnly = true;
            this.Picture.Visible = false;
            // 
            // MailCost
            // 
            this.MailCost.DataPropertyName = "MailCost";
            this.MailCost.HeaderText = "寄资料费";
            this.MailCost.Name = "MailCost";
            this.MailCost.ReadOnly = true;
            this.MailCost.Visible = false;
            // 
            // OtherCost
            // 
            this.OtherCost.DataPropertyName = "OtherCost";
            this.OtherCost.HeaderText = "杂费";
            this.OtherCost.Name = "OtherCost";
            this.OtherCost.ReadOnly = true;
            this.OtherCost.Visible = false;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "总价";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Visible = false;
            // 
            // SubmitFlag
            // 
            this.SubmitFlag.HeaderText = "提交状态";
            this.SubmitFlag.Name = "SubmitFlag";
            this.SubmitFlag.ReadOnly = true;
            this.SubmitFlag.Visible = false;
            // 
            // Visa_id
            // 
            this.Visa_id.DataPropertyName = "Visa_id";
            this.Visa_id.HeaderText = "Visa_id";
            this.Visa_id.Name = "Visa_id";
            this.Visa_id.ReadOnly = true;
            this.Visa_id.Visible = false;
            // 
            // FrmVisaClaimManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 574);
            this.Controls.Add(this.panelDgv);
            this.Controls.Add(this.panelBars);
            this.Name = "FrmVisaClaimManage";
            this.Text = "签证认账";
            this.Load += new System.EventHandler(this.FrmVisaManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmsDgv.ResumeLayout(false);
            this.panelBars.ResumeLayout(false);
            this.panelSerachBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSchFinishTimeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchFinishTimeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchRealTimeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchRealTimeFrom)).EndInit();
            this.panelDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cmsDgv;
        private System.Windows.Forms.ToolStripMenuItem cmsItemShowGroupNo;
        private System.Windows.Forms.ToolStripMenuItem cmsItemRefreshDatabase;
        private DevComponents.DotNetBar.PanelEx panelBars;
        private DevComponents.DotNetBar.PanelEx panelSerachBar;
        private DevComponents.DotNetBar.Controls.CircularProgress progressLoading;
        private DevComponents.DotNetBar.ButtonX btnClearSchConditions;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSchGroupNo;
        private DevComponents.DotNetBar.LabelX lb1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtSchRealTimeTo;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtSchRealTimeFrom;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.ButtonX btnShowAll;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadData;
        private DevComponents.DotNetBar.LabelItem labelItem8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbDisplayType;
        private DevComponents.DotNetBar.PanelEx panelDgv;
        private DevComponents.DotNetBar.ButtonX btnShowToday;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbCountry;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSalesPerson;
        private DevComponents.DotNetBar.Controls.TextBoxX txtClient;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbDepatureType;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtSchFinishTimeTo;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtSchFinishTimeFrom;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.LabelX lbMonneyCount;
        private DevComponents.DotNetBar.LabelItem lbInfoManifest;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbClaimedFlag;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.ToolStripMenuItem 签证认账ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成账单ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewImageColumn CountryImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Person;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tips;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tips2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Types;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsUrgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartureType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeInPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActuallyAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaimedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quidco;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsulateCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisaPersonCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvitationCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubmitFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visa_id;
    }
}