namespace TravelAgency.CSUI.FrmSub
{
    partial class FrmTodaySubmit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTodaySubmit));
            this.panelUp = new DevComponents.DotNetBar.PanelEx();
            this.panelUpRight = new DevComponents.DotNetBar.PanelEx();
            this.dgvHasExported = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgvHasExported_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassportNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTimeSpan = new DevComponents.DotNetBar.PanelEx();
            this.btnAddVisaInfo = new DevComponents.DotNetBar.ButtonX();
            this.lbCount = new DevComponents.DotNetBar.LabelX();
            this.lbTo = new DevComponents.DotNetBar.LabelX();
            this.lbFrom = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.label = new DevComponents.DotNetBar.LabelX();
            this.txtFrom = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtTo = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnPreAMonth = new DevComponents.DotNetBar.ButtonX();
            this.btnToday = new DevComponents.DotNetBar.ButtonX();
            this.btnPre2Week = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.btnPre7Days = new DevComponents.DotNetBar.ButtonX();
            this.btnYestoday = new DevComponents.DotNetBar.ButtonX();
            this.btnPre2Day = new DevComponents.DotNetBar.ButtonX();
            this.panelBottom = new DevComponents.DotNetBar.PanelEx();
            this.panelNoUseContainer = new DevComponents.DotNetBar.PanelEx();
            this.btnGetJinGunMingDan = new DevComponents.DotNetBar.ButtonX();
            this.btnGetTodaySubmitExcel = new DevComponents.DotNetBar.ButtonX();
            this.cmsDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导出报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个签意见书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.金桥大名单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人申请表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移到已导出不进行统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDgvHasExported = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.移入每日送签统计表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rowMergeView1 = new RowMergeView();
            this.outState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssuePlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Residence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubmitCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisaInfo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visa_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelUp.SuspendLayout();
            this.panelUpRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHasExported)).BeginInit();
            this.panelTimeSpan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelNoUseContainer.SuspendLayout();
            this.cmsDgv.SuspendLayout();
            this.cmsDgvHasExported.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rowMergeView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUp
            // 
            this.panelUp.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelUp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelUp.Controls.Add(this.rowMergeView1);
            this.panelUp.Controls.Add(this.panelUpRight);
            this.panelUp.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(1203, 516);
            this.panelUp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelUp.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelUp.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelUp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelUp.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelUp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelUp.Style.GradientAngle = 90;
            this.panelUp.TabIndex = 1;
            // 
            // panelUpRight
            // 
            this.panelUpRight.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelUpRight.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelUpRight.Controls.Add(this.dgvHasExported);
            this.panelUpRight.Controls.Add(this.panelTimeSpan);
            this.panelUpRight.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelUpRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelUpRight.Location = new System.Drawing.Point(865, 0);
            this.panelUpRight.Name = "panelUpRight";
            this.panelUpRight.Size = new System.Drawing.Size(338, 516);
            this.panelUpRight.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelUpRight.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelUpRight.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelUpRight.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelUpRight.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelUpRight.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelUpRight.Style.GradientAngle = 90;
            this.panelUpRight.TabIndex = 2;
            // 
            // dgvHasExported
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHasExported.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHasExported.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHasExported.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvHasExported_Name,
            this.PassportNo,
            this.Country});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHasExported.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHasExported.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHasExported.EnableHeadersVisualStyles = false;
            this.dgvHasExported.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvHasExported.Location = new System.Drawing.Point(0, 143);
            this.dgvHasExported.Name = "dgvHasExported";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHasExported.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHasExported.RowHeadersWidth = 60;
            this.dgvHasExported.RowTemplate.Height = 23;
            this.dgvHasExported.Size = new System.Drawing.Size(338, 373);
            this.dgvHasExported.TabIndex = 1;
            // 
            // dgvHasExported_Name
            // 
            this.dgvHasExported_Name.DataPropertyName = "Name";
            this.dgvHasExported_Name.HeaderText = "姓名";
            this.dgvHasExported_Name.Name = "dgvHasExported_Name";
            // 
            // PassportNo
            // 
            this.PassportNo.DataPropertyName = "PassportNo";
            this.PassportNo.HeaderText = "护照号";
            this.PassportNo.Name = "PassportNo";
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "国家";
            this.Country.Name = "Country";
            // 
            // panelTimeSpan
            // 
            this.panelTimeSpan.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelTimeSpan.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelTimeSpan.Controls.Add(this.btnAddVisaInfo);
            this.panelTimeSpan.Controls.Add(this.lbCount);
            this.panelTimeSpan.Controls.Add(this.lbTo);
            this.panelTimeSpan.Controls.Add(this.lbFrom);
            this.panelTimeSpan.Controls.Add(this.labelX3);
            this.panelTimeSpan.Controls.Add(this.label);
            this.panelTimeSpan.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelTimeSpan.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTimeSpan.Location = new System.Drawing.Point(0, 0);
            this.panelTimeSpan.Name = "panelTimeSpan";
            this.panelTimeSpan.Size = new System.Drawing.Size(338, 143);
            this.panelTimeSpan.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelTimeSpan.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelTimeSpan.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelTimeSpan.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelTimeSpan.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelTimeSpan.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelTimeSpan.Style.GradientAngle = 90;
            this.panelTimeSpan.TabIndex = 32;
            // 
            // btnAddVisaInfo
            // 
            this.btnAddVisaInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddVisaInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddVisaInfo.Location = new System.Drawing.Point(254, 109);
            this.btnAddVisaInfo.Name = "btnAddVisaInfo";
            this.btnAddVisaInfo.Size = new System.Drawing.Size(72, 28);
            this.btnAddVisaInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddVisaInfo.TabIndex = 35;
            this.btnAddVisaInfo.Text = "添加签证";
            this.btnAddVisaInfo.Click += new System.EventHandler(this.btnAddVisaInfo_Click);
            // 
            // lbCount
            // 
            // 
            // 
            // 
            this.lbCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbCount.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCount.ForeColor = System.Drawing.Color.Green;
            this.lbCount.Location = new System.Drawing.Point(9, 94);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(224, 23);
            this.lbCount.TabIndex = 34;
            this.lbCount.Text = "共:";
            // 
            // lbTo
            // 
            // 
            // 
            // 
            this.lbTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTo.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTo.Location = new System.Drawing.Point(8, 65);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(224, 23);
            this.lbTo.TabIndex = 34;
            this.lbTo.Text = "2017/12/29 00:00:00";
            // 
            // lbFrom
            // 
            // 
            // 
            // 
            this.lbFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbFrom.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFrom.Location = new System.Drawing.Point(8, 36);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(225, 23);
            this.lbFrom.TabIndex = 34;
            this.lbFrom.Text = "2017/12/29 00:00:00";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(8, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(134, 23);
            this.labelX3.TabIndex = 34;
            this.labelX3.Text = "当前时间段:";
            // 
            // label
            // 
            // 
            // 
            // 
            this.label.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label.Font = new System.Drawing.Font("华文新魏", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label.Location = new System.Drawing.Point(6, 114);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(180, 23);
            this.label.TabIndex = 20;
            this.label.Text = "已延后签证信息:";
            // 
            // txtFrom
            // 
            // 
            // 
            // 
            this.txtFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFrom.ButtonDropDown.Visible = true;
            this.txtFrom.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.txtFrom.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtFrom.IsPopupCalendarOpen = false;
            this.txtFrom.Location = new System.Drawing.Point(26, 18);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFrom.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFrom.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFrom.MonthCalendar.DisplayMonth = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.txtFrom.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFrom.MonthCalendar.TodayButtonVisible = true;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(273, 21);
            this.txtFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFrom.TabIndex = 32;
            // 
            // txtTo
            // 
            // 
            // 
            // 
            this.txtTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtTo.ButtonDropDown.Visible = true;
            this.txtTo.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.txtTo.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtTo.IsPopupCalendarOpen = false;
            this.txtTo.Location = new System.Drawing.Point(26, 45);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTo.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtTo.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTo.MonthCalendar.DisplayMonth = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.txtTo.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTo.MonthCalendar.TodayButtonVisible = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(273, 21);
            this.txtTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtTo.TabIndex = 33;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(2, 18);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(30, 23);
            this.labelX1.TabIndex = 24;
            this.labelX1.Text = "从:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(2, 45);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(30, 23);
            this.labelX2.TabIndex = 23;
            this.labelX2.Text = "到:";
            // 
            // btnPreAMonth
            // 
            this.btnPreAMonth.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPreAMonth.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPreAMonth.Location = new System.Drawing.Point(227, 96);
            this.btnPreAMonth.Name = "btnPreAMonth";
            this.btnPreAMonth.Size = new System.Drawing.Size(71, 23);
            this.btnPreAMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPreAMonth.TabIndex = 29;
            this.btnPreAMonth.Text = "最近一个月";
            // 
            // btnToday
            // 
            this.btnToday.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnToday.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnToday.Location = new System.Drawing.Point(24, 70);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(71, 23);
            this.btnToday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnToday.TabIndex = 28;
            this.btnToday.Text = "今天";
            // 
            // btnPre2Week
            // 
            this.btnPre2Week.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPre2Week.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPre2Week.Location = new System.Drawing.Point(126, 96);
            this.btnPre2Week.Name = "btnPre2Week";
            this.btnPre2Week.Size = new System.Drawing.Size(71, 23);
            this.btnPre2Week.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPre2Week.TabIndex = 30;
            this.btnPre2Week.Text = "最近两周";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(227, 122);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPre7Days
            // 
            this.btnPre7Days.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPre7Days.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPre7Days.Location = new System.Drawing.Point(24, 96);
            this.btnPre7Days.Name = "btnPre7Days";
            this.btnPre7Days.Size = new System.Drawing.Size(71, 23);
            this.btnPre7Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPre7Days.TabIndex = 31;
            this.btnPre7Days.Text = "最近一周";
            // 
            // btnYestoday
            // 
            this.btnYestoday.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnYestoday.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnYestoday.Location = new System.Drawing.Point(126, 70);
            this.btnYestoday.Name = "btnYestoday";
            this.btnYestoday.Size = new System.Drawing.Size(71, 23);
            this.btnYestoday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnYestoday.TabIndex = 26;
            this.btnYestoday.Text = "最近两天";
            // 
            // btnPre2Day
            // 
            this.btnPre2Day.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPre2Day.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPre2Day.Location = new System.Drawing.Point(228, 70);
            this.btnPre2Day.Name = "btnPre2Day";
            this.btnPre2Day.Size = new System.Drawing.Size(71, 23);
            this.btnPre2Day.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPre2Day.TabIndex = 25;
            this.btnPre2Day.Text = "最近三天";
            // 
            // panelBottom
            // 
            this.panelBottom.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelBottom.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelBottom.Controls.Add(this.panelNoUseContainer);
            this.panelBottom.Controls.Add(this.btnGetJinGunMingDan);
            this.panelBottom.Controls.Add(this.btnGetTodaySubmitExcel);
            this.panelBottom.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 516);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1203, 39);
            this.panelBottom.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelBottom.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelBottom.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelBottom.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelBottom.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelBottom.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelBottom.Style.GradientAngle = 90;
            this.panelBottom.TabIndex = 5;
            // 
            // panelNoUseContainer
            // 
            this.panelNoUseContainer.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelNoUseContainer.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelNoUseContainer.Controls.Add(this.txtFrom);
            this.panelNoUseContainer.Controls.Add(this.btnPre2Day);
            this.panelNoUseContainer.Controls.Add(this.btnYestoday);
            this.panelNoUseContainer.Controls.Add(this.btnPre7Days);
            this.panelNoUseContainer.Controls.Add(this.btnSearch);
            this.panelNoUseContainer.Controls.Add(this.btnPre2Week);
            this.panelNoUseContainer.Controls.Add(this.txtTo);
            this.panelNoUseContainer.Controls.Add(this.btnToday);
            this.panelNoUseContainer.Controls.Add(this.btnPreAMonth);
            this.panelNoUseContainer.Controls.Add(this.labelX1);
            this.panelNoUseContainer.Controls.Add(this.labelX2);
            this.panelNoUseContainer.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelNoUseContainer.Location = new System.Drawing.Point(765, 7);
            this.panelNoUseContainer.Name = "panelNoUseContainer";
            this.panelNoUseContainer.Size = new System.Drawing.Size(150, 29);
            this.panelNoUseContainer.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelNoUseContainer.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelNoUseContainer.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelNoUseContainer.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelNoUseContainer.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelNoUseContainer.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelNoUseContainer.Style.GradientAngle = 90;
            this.panelNoUseContainer.TabIndex = 35;
            this.panelNoUseContainer.Visible = false;
            // 
            // btnGetJinGunMingDan
            // 
            this.btnGetJinGunMingDan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetJinGunMingDan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetJinGunMingDan.Location = new System.Drawing.Point(527, 7);
            this.btnGetJinGunMingDan.Name = "btnGetJinGunMingDan";
            this.btnGetJinGunMingDan.Size = new System.Drawing.Size(137, 23);
            this.btnGetJinGunMingDan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGetJinGunMingDan.TabIndex = 1;
            this.btnGetJinGunMingDan.Text = "生成国旅进馆名单";
            this.btnGetJinGunMingDan.Click += new System.EventHandler(this.btnGetJinGunMingDan_Click);
            // 
            // btnGetTodaySubmitExcel
            // 
            this.btnGetTodaySubmitExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetTodaySubmitExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetTodaySubmitExcel.Location = new System.Drawing.Point(373, 7);
            this.btnGetTodaySubmitExcel.Name = "btnGetTodaySubmitExcel";
            this.btnGetTodaySubmitExcel.Size = new System.Drawing.Size(137, 23);
            this.btnGetTodaySubmitExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGetTodaySubmitExcel.TabIndex = 0;
            this.btnGetTodaySubmitExcel.Text = "生成今日送签情况报表";
            this.btnGetTodaySubmitExcel.Click += new System.EventHandler(this.buttonGetTodaySubmitExcel_Click);
            // 
            // cmsDgv
            // 
            this.cmsDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出报表ToolStripMenuItem,
            this.移到已导出不进行统计ToolStripMenuItem});
            this.cmsDgv.Name = "cmsDgv";
            this.cmsDgv.Size = new System.Drawing.Size(125, 48);
            // 
            // 导出报表ToolStripMenuItem
            // 
            this.导出报表ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个签意见书ToolStripMenuItem,
            this.金桥大名单ToolStripMenuItem,
            this.人申请表ToolStripMenuItem});
            this.导出报表ToolStripMenuItem.Name = "导出报表ToolStripMenuItem";
            this.导出报表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.导出报表ToolStripMenuItem.Text = "导出报表";
            // 
            // 个签意见书ToolStripMenuItem
            // 
            this.个签意见书ToolStripMenuItem.Name = "个签意见书ToolStripMenuItem";
            this.个签意见书ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.个签意见书ToolStripMenuItem.Text = "个签意见书";
            this.个签意见书ToolStripMenuItem.Click += new System.EventHandler(this.个签意见书ToolStripMenuItem_Click);
            // 
            // 金桥大名单ToolStripMenuItem
            // 
            this.金桥大名单ToolStripMenuItem.Name = "金桥大名单ToolStripMenuItem";
            this.金桥大名单ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.金桥大名单ToolStripMenuItem.Text = "金桥大名单";
            this.金桥大名单ToolStripMenuItem.Click += new System.EventHandler(this.金桥大名单ToolStripMenuItem_Click);
            // 
            // 人申请表ToolStripMenuItem
            // 
            this.人申请表ToolStripMenuItem.Name = "人申请表ToolStripMenuItem";
            this.人申请表ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.人申请表ToolStripMenuItem.Text = "8人申请表";
            this.人申请表ToolStripMenuItem.Click += new System.EventHandler(this.人申请表ToolStripMenuItem_Click);
            // 
            // 移到已导出不进行统计ToolStripMenuItem
            // 
            this.移到已导出不进行统计ToolStripMenuItem.Name = "移到已导出不进行统计ToolStripMenuItem";
            this.移到已导出不进行统计ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.移到已导出不进行统计ToolStripMenuItem.Text = "移出";
            this.移到已导出不进行统计ToolStripMenuItem.Click += new System.EventHandler(this.移到已导出不进行统计ToolStripMenuItem_Click);
            // 
            // cmsDgvHasExported
            // 
            this.cmsDgvHasExported.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.移入每日送签统计表ToolStripMenuItem});
            this.cmsDgvHasExported.Name = "cmsDgv";
            this.cmsDgvHasExported.Size = new System.Drawing.Size(185, 26);
            // 
            // 移入每日送签统计表ToolStripMenuItem
            // 
            this.移入每日送签统计表ToolStripMenuItem.Name = "移入每日送签统计表ToolStripMenuItem";
            this.移入每日送签统计表ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.移入每日送签统计表ToolStripMenuItem.Text = "移入每日送签统计表";
            this.移入每日送签统计表ToolStripMenuItem.Click += new System.EventHandler(this.移入每日送签统计表ToolStripMenuItem_Click);
            // 
            // rowMergeView1
            // 
            this.rowMergeView1.AllowUserToAddRows = false;
            this.rowMergeView1.AllowUserToDeleteRows = false;
            this.rowMergeView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rowMergeView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.outState,
            this._Name,
            this.IssuePlace,
            this.Residence,
            this.DepartureType,
            this.ReturnTime,
            this.Remark,
            this.GroupNo,
            this.SubmitCondition,
            this.VisaInfo_id,
            this.Visa_Id});
            this.rowMergeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowMergeView1.Location = new System.Drawing.Point(0, 0);
            this.rowMergeView1.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.rowMergeView1.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("rowMergeView1.MergeColumnNames")));
            this.rowMergeView1.Name = "rowMergeView1";
            this.rowMergeView1.ReadOnly = true;
            this.rowMergeView1.RowHeadersWidth = 60;
            this.rowMergeView1.RowTemplate.Height = 23;
            this.rowMergeView1.Size = new System.Drawing.Size(865, 516);
            this.rowMergeView1.TabIndex = 0;
            this.rowMergeView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.rowMergeView1_CellMouseClick);
            this.rowMergeView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.rowMergeView1_RowsAdded);
            // 
            // outState
            // 
            this.outState.DataPropertyName = "outState";
            this.outState.HeaderText = "导出状态";
            this.outState.Name = "outState";
            this.outState.ReadOnly = true;
            // 
            // _Name
            // 
            this._Name.DataPropertyName = "Name";
            this._Name.HeaderText = "姓名";
            this._Name.Name = "_Name";
            this._Name.ReadOnly = true;
            // 
            // IssuePlace
            // 
            this.IssuePlace.DataPropertyName = "IssuePlace";
            this.IssuePlace.HeaderText = "签发地";
            this.IssuePlace.Name = "IssuePlace";
            this.IssuePlace.ReadOnly = true;
            // 
            // Residence
            // 
            this.Residence.DataPropertyName = "Residence";
            this.Residence.HeaderText = "居住地";
            this.Residence.Name = "Residence";
            this.Residence.ReadOnly = true;
            // 
            // DepartureType
            // 
            this.DepartureType.DataPropertyName = "DepartureType";
            this.DepartureType.HeaderText = "签证类型";
            this.DepartureType.Name = "DepartureType";
            this.DepartureType.ReadOnly = true;
            // 
            // ReturnTime
            // 
            this.ReturnTime.DataPropertyName = "ReturnTime";
            this.ReturnTime.HeaderText = "归国时间";
            this.ReturnTime.Name = "ReturnTime";
            this.ReturnTime.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "关系";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // GroupNo
            // 
            this.GroupNo.DataPropertyName = "GroupNo";
            this.GroupNo.HeaderText = "团号";
            this.GroupNo.Name = "GroupNo";
            this.GroupNo.ReadOnly = true;
            // 
            // SubmitCondition
            // 
            this.SubmitCondition.HeaderText = "外领送签条件";
            this.SubmitCondition.Name = "SubmitCondition";
            this.SubmitCondition.ReadOnly = true;
            // 
            // VisaInfo_id
            // 
            this.VisaInfo_id.DataPropertyName = "VisaInfo_id";
            this.VisaInfo_id.HeaderText = "VisaInfo_id";
            this.VisaInfo_id.Name = "VisaInfo_id";
            this.VisaInfo_id.ReadOnly = true;
            this.VisaInfo_id.Visible = false;
            // 
            // Visa_Id
            // 
            this.Visa_Id.DataPropertyName = "Visa_Id";
            this.Visa_Id.HeaderText = "Visa_Id";
            this.Visa_Id.Name = "Visa_Id";
            this.Visa_Id.ReadOnly = true;
            this.Visa_Id.Visible = false;
            // 
            // FrmTodaySubmit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 555);
            this.Controls.Add(this.panelUp);
            this.Controls.Add(this.panelBottom);
            this.Name = "FrmTodaySubmit";
            this.Text = "今日送签情况";
            this.Load += new System.EventHandler(this.FrmTodaySubmit_Load);
            this.panelUp.ResumeLayout(false);
            this.panelUpRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHasExported)).EndInit();
            this.panelTimeSpan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelNoUseContainer.ResumeLayout(false);
            this.cmsDgv.ResumeLayout(false);
            this.cmsDgvHasExported.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rowMergeView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RowMergeView rowMergeView1;
        private DevComponents.DotNetBar.PanelEx panelUp;
        private DevComponents.DotNetBar.PanelEx panelBottom;
        private DevComponents.DotNetBar.ButtonX btnGetTodaySubmitExcel;
        private System.Windows.Forms.ContextMenuStrip cmsDgv;
        private System.Windows.Forms.ToolStripMenuItem 导出报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个签意见书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 金桥大名单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人申请表ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvHasExported;
        private DevComponents.DotNetBar.PanelEx panelUpRight;
        private DevComponents.DotNetBar.LabelX label;
        private DevComponents.DotNetBar.PanelEx panelTimeSpan;
        private DevComponents.DotNetBar.ButtonX btnPreAMonth;
        private DevComponents.DotNetBar.ButtonX btnPre2Week;
        private DevComponents.DotNetBar.ButtonX btnPre7Days;
        private DevComponents.DotNetBar.ButtonX btnPre2Day;
        private DevComponents.DotNetBar.ButtonX btnYestoday;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.ButtonX btnToday;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHasExported_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassportNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.ContextMenuStrip cmsDgvHasExported;
        private System.Windows.Forms.ToolStripMenuItem 移入每日送签统计表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移到已导出不进行统计ToolStripMenuItem;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFrom;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtTo;
        private DevComponents.DotNetBar.ButtonX btnGetJinGunMingDan;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX lbFrom;
        private DevComponents.DotNetBar.LabelX lbTo;
        private DevComponents.DotNetBar.LabelX lbCount;
        private DevComponents.DotNetBar.PanelEx panelNoUseContainer;
        private DevComponents.DotNetBar.ButtonX btnAddVisaInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn outState;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssuePlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn Residence;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartureType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubmitCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisaInfo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visa_Id;
    }
}