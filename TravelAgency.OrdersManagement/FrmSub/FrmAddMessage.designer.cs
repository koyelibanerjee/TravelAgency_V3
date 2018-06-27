namespace TravelAgency.OrdersManagement
{
    partial class FrmAddMessage
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
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelMain = new DevComponents.DotNetBar.PanelEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGuestRefundApplyTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtRefundAmout = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtRefundReason = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.txtMsgType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtMsgState = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtMsgContent = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtToUser = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.txtOrderNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnAddFromExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.progressLoading = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.txtRefundState = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuestRefundApplyTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(325, 262);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(244, 262);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 29;
            this.btnOK.Text = "确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.panelMain);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(669, 297);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Controls.Add(this.txtMsgType);
            this.panelMain.Controls.Add(this.labelX5);
            this.panelMain.Controls.Add(this.txtMsgState);
            this.panelMain.Controls.Add(this.labelX3);
            this.panelMain.Controls.Add(this.txtMsgContent);
            this.panelMain.Controls.Add(this.labelX1);
            this.panelMain.Controls.Add(this.txtToUser);
            this.panelMain.Controls.Add(this.labelX11);
            this.panelMain.Controls.Add(this.txtOrderNo);
            this.panelMain.Controls.Add(this.labelX4);
            this.panelMain.Controls.Add(this.btnAddFromExcel);
            this.panelMain.Controls.Add(this.btnAdd);
            this.panelMain.Controls.Add(this.progressLoading);
            this.panelMain.Controls.Add(this.btnOK);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(669, 297);
            this.panelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMain.Style.GradientAngle = 90;
            this.panelMain.TabIndex = 106;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelX7);
            this.groupBox1.Controls.Add(this.txtRefundState);
            this.groupBox1.Controls.Add(this.txtGuestRefundApplyTime);
            this.groupBox1.Controls.Add(this.labelX6);
            this.groupBox1.Controls.Add(this.txtRefundAmout);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.txtRefundReason);
            this.groupBox1.Controls.Add(this.labelX12);
            this.groupBox1.Location = new System.Drawing.Point(325, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 234);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "退款信息";
            // 
            // txtGuestRefundApplyTime
            // 
            // 
            // 
            // 
            this.txtGuestRefundApplyTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtGuestRefundApplyTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGuestRefundApplyTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtGuestRefundApplyTime.ButtonDropDown.Visible = true;
            this.txtGuestRefundApplyTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtGuestRefundApplyTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtGuestRefundApplyTime.IsPopupCalendarOpen = false;
            this.txtGuestRefundApplyTime.Location = new System.Drawing.Point(150, 62);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtGuestRefundApplyTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGuestRefundApplyTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtGuestRefundApplyTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtGuestRefundApplyTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtGuestRefundApplyTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtGuestRefundApplyTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtGuestRefundApplyTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtGuestRefundApplyTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtGuestRefundApplyTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtGuestRefundApplyTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGuestRefundApplyTime.MonthCalendar.DisplayMonth = new System.DateTime(2018, 3, 1, 0, 0, 0, 0);
            this.txtGuestRefundApplyTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtGuestRefundApplyTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtGuestRefundApplyTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtGuestRefundApplyTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtGuestRefundApplyTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGuestRefundApplyTime.MonthCalendar.TodayButtonVisible = true;
            this.txtGuestRefundApplyTime.Name = "txtGuestRefundApplyTime";
            this.txtGuestRefundApplyTime.Size = new System.Drawing.Size(185, 23);
            this.txtGuestRefundApplyTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtGuestRefundApplyTime.TabIndex = 173;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(6, 62);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(140, 27);
            this.labelX6.TabIndex = 172;
            this.labelX6.Text = "客人申请退款时间:";
            // 
            // txtRefundAmout
            // 
            // 
            // 
            // 
            this.txtRefundAmout.Border.Class = "TextBoxBorder";
            this.txtRefundAmout.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRefundAmout.Location = new System.Drawing.Point(150, 28);
            this.txtRefundAmout.Multiline = true;
            this.txtRefundAmout.Name = "txtRefundAmout";
            this.txtRefundAmout.Size = new System.Drawing.Size(185, 27);
            this.txtRefundAmout.TabIndex = 171;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(6, 29);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(110, 27);
            this.labelX2.TabIndex = 170;
            this.labelX2.Text = "退款金额:";
            // 
            // txtRefundReason
            // 
            // 
            // 
            // 
            this.txtRefundReason.Border.Class = "TextBoxBorder";
            this.txtRefundReason.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRefundReason.Location = new System.Drawing.Point(150, 93);
            this.txtRefundReason.Multiline = true;
            this.txtRefundReason.Name = "txtRefundReason";
            this.txtRefundReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRefundReason.Size = new System.Drawing.Size(185, 83);
            this.txtRefundReason.TabIndex = 169;
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(6, 93);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(110, 27);
            this.labelX12.TabIndex = 168;
            this.labelX12.Text = "退款理由:";
            // 
            // txtMsgType
            // 
            this.txtMsgType.DisplayMember = "Text";
            this.txtMsgType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtMsgType.FormattingEnabled = true;
            this.txtMsgType.ItemHeight = 17;
            this.txtMsgType.Location = new System.Drawing.Point(107, 40);
            this.txtMsgType.Name = "txtMsgType";
            this.txtMsgType.Size = new System.Drawing.Size(107, 23);
            this.txtMsgType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtMsgType.TabIndex = 122;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(19, 38);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(82, 23);
            this.labelX5.TabIndex = 121;
            this.labelX5.Text = "消息类型:";
            // 
            // txtMsgState
            // 
            this.txtMsgState.DisplayMember = "Text";
            this.txtMsgState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtMsgState.FormattingEnabled = true;
            this.txtMsgState.ItemHeight = 17;
            this.txtMsgState.Location = new System.Drawing.Point(220, 40);
            this.txtMsgState.Name = "txtMsgState";
            this.txtMsgState.Size = new System.Drawing.Size(90, 23);
            this.txtMsgState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtMsgState.TabIndex = 120;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(220, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 119;
            this.labelX3.Text = "消息状态:";
            // 
            // txtMsgContent
            // 
            // 
            // 
            // 
            this.txtMsgContent.Border.Class = "TextBoxBorder";
            this.txtMsgContent.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMsgContent.Location = new System.Drawing.Point(107, 71);
            this.txtMsgContent.Multiline = true;
            this.txtMsgContent.Name = "txtMsgContent";
            this.txtMsgContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgContent.Size = new System.Drawing.Size(203, 148);
            this.txtMsgContent.TabIndex = 115;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(20, 67);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(81, 23);
            this.labelX1.TabIndex = 114;
            this.labelX1.Text = "消息内容:";
            // 
            // txtToUser
            // 
            this.txtToUser.DisplayMember = "Text";
            this.txtToUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtToUser.FormattingEnabled = true;
            this.txtToUser.ItemHeight = 17;
            this.txtToUser.Location = new System.Drawing.Point(107, 11);
            this.txtToUser.Name = "txtToUser";
            this.txtToUser.Size = new System.Drawing.Size(107, 23);
            this.txtToUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtToUser.TabIndex = 113;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(19, 11);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(82, 23);
            this.labelX11.TabIndex = 112;
            this.labelX11.Text = "收件人:";
            // 
            // txtOrderNo
            // 
            // 
            // 
            // 
            this.txtOrderNo.Border.Class = "TextBoxBorder";
            this.txtOrderNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderNo.Location = new System.Drawing.Point(107, 225);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(203, 23);
            this.txtOrderNo.TabIndex = 111;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(20, 225);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(81, 23);
            this.labelX4.TabIndex = 110;
            this.labelX4.Text = "订单号:";
            // 
            // btnAddFromExcel
            // 
            this.btnAddFromExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddFromExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddFromExcel.Location = new System.Drawing.Point(996, 6);
            this.btnAddFromExcel.Name = "btnAddFromExcel";
            this.btnAddFromExcel.Size = new System.Drawing.Size(92, 23);
            this.btnAddFromExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddFromExcel.TabIndex = 56;
            this.btnAddFromExcel.Text = "从excel导入";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(884, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "新增";
            // 
            // progressLoading
            // 
            // 
            // 
            // 
            this.progressLoading.BackgroundStyle.BackgroundImageAlpha = ((byte)(64));
            this.progressLoading.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressLoading.FocusCuesEnabled = false;
            this.progressLoading.Location = new System.Drawing.Point(833, 0);
            this.progressLoading.Name = "progressLoading";
            this.progressLoading.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.progressLoading.ProgressColor = System.Drawing.Color.YellowGreen;
            this.progressLoading.Size = new System.Drawing.Size(45, 28);
            this.progressLoading.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.progressLoading.TabIndex = 27;
            this.progressLoading.Value = 100;
            // 
            // txtRefundState
            // 
            this.txtRefundState.DisplayMember = "Text";
            this.txtRefundState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtRefundState.FormattingEnabled = true;
            this.txtRefundState.ItemHeight = 17;
            this.txtRefundState.Location = new System.Drawing.Point(150, 196);
            this.txtRefundState.Name = "txtRefundState";
            this.txtRefundState.Size = new System.Drawing.Size(182, 23);
            this.txtRefundState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtRefundState.TabIndex = 174;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(6, 192);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(110, 27);
            this.labelX7.TabIndex = 179;
            this.labelX7.Text = "退款状态:";
            // 
            // FrmAddMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 297);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmAddMessage";
            this.Text = "发送信息:";
            this.Load += new System.EventHandler(this.FrmAddMessage_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGuestRefundApplyTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelMain;
        private DevComponents.DotNetBar.ButtonX btnAddFromExcel;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.Controls.CircularProgress progressLoading;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderNo;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx txtToUser;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMsgContent;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx txtMsgState;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx txtMsgType;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtGuestRefundApplyTime;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRefundAmout;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRefundReason;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx txtRefundState;
    }
}