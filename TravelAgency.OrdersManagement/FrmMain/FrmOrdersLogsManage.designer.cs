namespace TravelAgency.OrdersManagement
{
    partial class FrmOrdersLogsManage
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new DevComponents.DotNetBar.PanelEx();
            this.panelDgv = new DevComponents.DotNetBar.PanelEx();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.lbGuestInfoTypedInCount = new DevComponents.DotNetBar.LabelItem();
            this.lbReplyResultCount = new DevComponents.DotNetBar.LabelItem();
            this.panelBars = new DevComponents.DotNetBar.PanelEx();
            this.panelSerachBar = new DevComponents.DotNetBar.PanelEx();
            this.cbActType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtWorkId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnTimeSpanChoose = new DevComponents.DotNetBar.ButtonX();
            this.txtSchEntryTimeTo = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtSchEntryTimeFrom = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.txtSchName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbSchName = new DevComponents.DotNetBar.LabelX();
            this.progressLoading = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.btnClearSchConditions = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
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
            this.btnGeneratePersonalReport = new DevComponents.DotNetBar.ButtonItem();
            this.cmsDgvRb = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsItemRefreshState = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人申请表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.机票报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外领担保函ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.韩国担保函ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.韩国加急申请书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgWorkerLoadData = new System.ComponentModel.BackgroundWorker();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.txtOrderNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.panelMain.SuspendLayout();
            this.panelDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.panelBars.SuspendLayout();
            this.panelSerachBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.cmsDgvRb.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelMain.Controls.Add(this.panelDgv);
            this.panelMain.Controls.Add(this.panelBars);
            this.panelMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1271, 623);
            this.panelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMain.Style.GradientAngle = 90;
            this.panelMain.TabIndex = 23;
            // 
            // panelDgv
            // 
            this.panelDgv.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelDgv.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDgv.Controls.Add(this.dataGridView1);
            this.panelDgv.Controls.Add(this.bar2);
            this.panelDgv.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDgv.Location = new System.Drawing.Point(0, 97);
            this.panelDgv.Name = "panelDgv";
            this.panelDgv.Size = new System.Drawing.Size(1271, 526);
            this.panelDgv.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDgv.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelDgv.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelDgv.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelDgv.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelDgv.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelDgv.Style.GradientAngle = 90;
            this.panelDgv.TabIndex = 38;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNo,
            this.ActType,
            this.WorkId,
            this.UserName,
            this.EntryTime,
            this.Id});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1271, 502);
            this.dataGridView1.TabIndex = 30;
            // 
            // OrderNo
            // 
            this.OrderNo.DataPropertyName = "OrderNo";
            this.OrderNo.HeaderText = "订单号";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            // 
            // ActType
            // 
            this.ActType.HeaderText = "操作类型";
            this.ActType.Name = "ActType";
            this.ActType.ReadOnly = true;
            // 
            // WorkId
            // 
            this.WorkId.DataPropertyName = "WorkId";
            this.WorkId.HeaderText = "工号";
            this.WorkId.Name = "WorkId";
            this.WorkId.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "操作员";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // EntryTime
            // 
            this.EntryTime.DataPropertyName = "EntryTime";
            this.EntryTime.HeaderText = "时间";
            this.EntryTime.Name = "EntryTime";
            this.EntryTime.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar2.DockTabStripHeight = 30;
            this.bar2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lbGuestInfoTypedInCount,
            this.lbReplyResultCount});
            this.bar2.ItemSpacing = 5;
            this.bar2.Location = new System.Drawing.Point(0, 502);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(1271, 24);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 29;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // lbGuestInfoTypedInCount
            // 
            this.lbGuestInfoTypedInCount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbGuestInfoTypedInCount.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbGuestInfoTypedInCount.Name = "lbGuestInfoTypedInCount";
            this.lbGuestInfoTypedInCount.Text = "--";
            // 
            // lbReplyResultCount
            // 
            this.lbReplyResultCount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbReplyResultCount.ForeColor = System.Drawing.Color.Tomato;
            this.lbReplyResultCount.Name = "lbReplyResultCount";
            this.lbReplyResultCount.Text = "--";
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
            this.panelBars.Size = new System.Drawing.Size(1271, 97);
            this.panelBars.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelBars.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelBars.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelBars.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelBars.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelBars.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelBars.Style.GradientAngle = 90;
            this.panelBars.TabIndex = 34;
            // 
            // panelSerachBar
            // 
            this.panelSerachBar.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelSerachBar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelSerachBar.Controls.Add(this.txtOrderNo);
            this.panelSerachBar.Controls.Add(this.labelX4);
            this.panelSerachBar.Controls.Add(this.cbActType);
            this.panelSerachBar.Controls.Add(this.labelX2);
            this.panelSerachBar.Controls.Add(this.txtWorkId);
            this.panelSerachBar.Controls.Add(this.labelX1);
            this.panelSerachBar.Controls.Add(this.btnTimeSpanChoose);
            this.panelSerachBar.Controls.Add(this.txtSchEntryTimeTo);
            this.panelSerachBar.Controls.Add(this.txtSchEntryTimeFrom);
            this.panelSerachBar.Controls.Add(this.labelX14);
            this.panelSerachBar.Controls.Add(this.labelX12);
            this.panelSerachBar.Controls.Add(this.txtSchName);
            this.panelSerachBar.Controls.Add(this.lbSchName);
            this.panelSerachBar.Controls.Add(this.progressLoading);
            this.panelSerachBar.Controls.Add(this.btnClearSchConditions);
            this.panelSerachBar.Controls.Add(this.btnSearch);
            this.panelSerachBar.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelSerachBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSerachBar.Location = new System.Drawing.Point(0, 28);
            this.panelSerachBar.Name = "panelSerachBar";
            this.panelSerachBar.Size = new System.Drawing.Size(1271, 69);
            this.panelSerachBar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelSerachBar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelSerachBar.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelSerachBar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelSerachBar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelSerachBar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelSerachBar.Style.GradientAngle = 90;
            this.panelSerachBar.TabIndex = 24;
            // 
            // cbActType
            // 
            this.cbActType.DisplayMember = "Text";
            this.cbActType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbActType.FormattingEnabled = true;
            this.cbActType.ItemHeight = 15;
            this.cbActType.Location = new System.Drawing.Point(570, 37);
            this.cbActType.Name = "cbActType";
            this.cbActType.Size = new System.Drawing.Size(197, 21);
            this.cbActType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbActType.TabIndex = 66;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(505, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(79, 23);
            this.labelX2.TabIndex = 67;
            this.labelX2.Text = "操作类型:";
            // 
            // txtWorkId
            // 
            // 
            // 
            // 
            this.txtWorkId.Border.Class = "TextBoxBorder";
            this.txtWorkId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWorkId.Location = new System.Drawing.Point(696, 7);
            this.txtWorkId.Name = "txtWorkId";
            this.txtWorkId.Size = new System.Drawing.Size(71, 21);
            this.txtWorkId.TabIndex = 65;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(656, 7);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(63, 21);
            this.labelX1.TabIndex = 64;
            this.labelX1.Text = "工号:";
            // 
            // btnTimeSpanChoose
            // 
            this.btnTimeSpanChoose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTimeSpanChoose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTimeSpanChoose.Location = new System.Drawing.Point(417, 9);
            this.btnTimeSpanChoose.Name = "btnTimeSpanChoose";
            this.btnTimeSpanChoose.Size = new System.Drawing.Size(91, 21);
            this.btnTimeSpanChoose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTimeSpanChoose.TabIndex = 63;
            this.btnTimeSpanChoose.Text = "时间区间选择";
            // 
            // txtSchEntryTimeTo
            // 
            // 
            // 
            // 
            this.txtSchEntryTimeTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSchEntryTimeTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtSchEntryTimeTo.ButtonDropDown.Visible = true;
            this.txtSchEntryTimeTo.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtSchEntryTimeTo.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtSchEntryTimeTo.IsPopupCalendarOpen = false;
            this.txtSchEntryTimeTo.Location = new System.Drawing.Point(251, 9);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtSchEntryTimeTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeTo.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtSchEntryTimeTo.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeTo.MonthCalendar.DisplayMonth = new System.DateTime(2017, 11, 1, 0, 0, 0, 0);
            this.txtSchEntryTimeTo.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtSchEntryTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtSchEntryTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchEntryTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtSchEntryTimeTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeTo.MonthCalendar.TodayButtonVisible = true;
            this.txtSchEntryTimeTo.Name = "txtSchEntryTimeTo";
            this.txtSchEntryTimeTo.Size = new System.Drawing.Size(160, 21);
            this.txtSchEntryTimeTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtSchEntryTimeTo.TabIndex = 62;
            // 
            // txtSchEntryTimeFrom
            // 
            // 
            // 
            // 
            this.txtSchEntryTimeFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSchEntryTimeFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtSchEntryTimeFrom.ButtonDropDown.Visible = true;
            this.txtSchEntryTimeFrom.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtSchEntryTimeFrom.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtSchEntryTimeFrom.IsPopupCalendarOpen = false;
            this.txtSchEntryTimeFrom.Location = new System.Drawing.Point(66, 9);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtSchEntryTimeFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeFrom.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtSchEntryTimeFrom.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeFrom.MonthCalendar.DisplayMonth = new System.DateTime(2017, 11, 1, 0, 0, 0, 0);
            this.txtSchEntryTimeFrom.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtSchEntryTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtSchEntryTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchEntryTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtSchEntryTimeFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeFrom.MonthCalendar.TodayButtonVisible = true;
            this.txtSchEntryTimeFrom.Name = "txtSchEntryTimeFrom";
            this.txtSchEntryTimeFrom.Size = new System.Drawing.Size(160, 21);
            this.txtSchEntryTimeFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtSchEntryTimeFrom.TabIndex = 61;
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(232, 9);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(13, 21);
            this.labelX14.TabIndex = 60;
            this.labelX14.Text = "-";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(8, 10);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(63, 21);
            this.labelX12.TabIndex = 59;
            this.labelX12.Text = "录入时间:";
            // 
            // txtSchName
            // 
            // 
            // 
            // 
            this.txtSchName.Border.Class = "TextBoxBorder";
            this.txtSchName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchName.Location = new System.Drawing.Point(570, 8);
            this.txtSchName.Name = "txtSchName";
            this.txtSchName.Size = new System.Drawing.Size(80, 21);
            this.txtSchName.TabIndex = 58;
            // 
            // lbSchName
            // 
            // 
            // 
            // 
            this.lbSchName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbSchName.Location = new System.Drawing.Point(530, 8);
            this.lbSchName.Name = "lbSchName";
            this.lbSchName.Size = new System.Drawing.Size(63, 21);
            this.lbSchName.TabIndex = 57;
            this.lbSchName.Text = "姓名:";
            // 
            // progressLoading
            // 
            // 
            // 
            // 
            this.progressLoading.BackgroundStyle.BackgroundImageAlpha = ((byte)(64));
            this.progressLoading.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressLoading.FocusCuesEnabled = false;
            this.progressLoading.Location = new System.Drawing.Point(1152, 6);
            this.progressLoading.Name = "progressLoading";
            this.progressLoading.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.progressLoading.ProgressColor = System.Drawing.Color.YellowGreen;
            this.progressLoading.Size = new System.Drawing.Size(55, 52);
            this.progressLoading.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.progressLoading.TabIndex = 27;
            this.progressLoading.Value = 100;
            // 
            // btnClearSchConditions
            // 
            this.btnClearSchConditions.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearSchConditions.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClearSchConditions.Location = new System.Drawing.Point(881, 7);
            this.btnClearSchConditions.Name = "btnClearSchConditions";
            this.btnClearSchConditions.Size = new System.Drawing.Size(92, 23);
            this.btnClearSchConditions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClearSchConditions.TabIndex = 26;
            this.btnClearSchConditions.Text = "清空搜索条件";
            this.btnClearSchConditions.Click += new System.EventHandler(this.btnClearSchConditions_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(783, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnGeneratePersonalReport});
            this.bar1.ItemSpacing = 5;
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1271, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 23;
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
            // btnGeneratePersonalReport
            // 
            this.btnGeneratePersonalReport.Name = "btnGeneratePersonalReport";
            // 
            // cmsDgvRb
            // 
            this.cmsDgvRb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItemRefreshState,
            this.删除ToolStripMenuItem});
            this.cmsDgvRb.Name = "cmsDgvRb";
            this.cmsDgvRb.Size = new System.Drawing.Size(161, 48);
            // 
            // cmsItemRefreshState
            // 
            this.cmsItemRefreshState.Name = "cmsItemRefreshState";
            this.cmsItemRefreshState.Size = new System.Drawing.Size(160, 22);
            this.cmsItemRefreshState.Text = "刷新数据库状态";
            this.cmsItemRefreshState.Click += new System.EventHandler(this.cmsItemRefreshState_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 人申请表ToolStripMenuItem
            // 
            this.人申请表ToolStripMenuItem.Name = "人申请表ToolStripMenuItem";
            this.人申请表ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 机票报表ToolStripMenuItem
            // 
            this.机票报表ToolStripMenuItem.Name = "机票报表ToolStripMenuItem";
            this.机票报表ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 外领担保函ToolStripMenuItem
            // 
            this.外领担保函ToolStripMenuItem.Name = "外领担保函ToolStripMenuItem";
            this.外领担保函ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 韩国担保函ToolStripMenuItem
            // 
            this.韩国担保函ToolStripMenuItem.Name = "韩国担保函ToolStripMenuItem";
            this.韩国担保函ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 韩国加急申请书ToolStripMenuItem
            // 
            this.韩国加急申请书ToolStripMenuItem.Name = "韩国加急申请书ToolStripMenuItem";
            this.韩国加急申请书ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // bgWorkerLoadData
            // 
            this.bgWorkerLoadData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoadData_DoWork);
            this.bgWorkerLoadData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerLoadData_ProgressChanged);
            this.bgWorkerLoadData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoadData_RunWorkerCompleted);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // txtOrderNo
            // 
            // 
            // 
            // 
            this.txtOrderNo.Border.Class = "TextBoxBorder";
            this.txtOrderNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderNo.DisabledBackColor = System.Drawing.Color.White;
            this.txtOrderNo.Location = new System.Drawing.Point(66, 37);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(345, 21);
            this.txtOrderNo.TabIndex = 115;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(4, 37);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(81, 23);
            this.labelX4.TabIndex = 114;
            this.labelX4.Text = "订单号:";
            // 
            // FrmOrdersLogsManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 623);
            this.Controls.Add(this.panelMain);
            this.Name = "FrmOrdersLogsManage";
            this.Text = "日志管理:";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMain.ResumeLayout(false);
            this.panelDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.panelBars.ResumeLayout(false);
            this.panelSerachBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.cmsDgvRb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.PanelEx panelMain;
        private System.Windows.Forms.ContextMenuStrip cmsDgvRb;
        private System.Windows.Forms.ToolStripMenuItem cmsItemRefreshState;
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
        private DevComponents.DotNetBar.PanelEx panelDgv;
        private DevComponents.DotNetBar.PanelEx panelBars;
        private DevComponents.DotNetBar.PanelEx panelSerachBar;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.ButtonX btnClearSchConditions;
        private DevComponents.DotNetBar.Controls.CircularProgress progressLoading;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadData;
        private System.Windows.Forms.ToolStripMenuItem 人申请表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 机票报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 外领担保函ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 韩国担保函ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 韩国加急申请书ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonItem btnGeneratePersonalReport;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.LabelItem lbGuestInfoTypedInCount;
        private DevComponents.DotNetBar.LabelItem lbReplyResultCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbActType;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtWorkId;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnTimeSpanChoose;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtSchEntryTimeTo;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtSchEntryTimeFrom;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSchName;
        private DevComponents.DotNetBar.LabelX lbSchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActType;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderNo;
        private DevComponents.DotNetBar.LabelX labelX4;
    }
}

