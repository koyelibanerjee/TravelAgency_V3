﻿namespace TravelAgency.OrdersManagement
{
    partial class FrmAddOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelMain = new DevComponents.DotNetBar.PanelEx();
            this.txtComboName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtWaitorConfirmTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnOperInfo = new DevComponents.DotNetBar.ButtonX();
            this.btnGuestInfo = new DevComponents.DotNetBar.ButtonX();
            this.txtPlatformActivity = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.txtReallyPay = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.txtOrderAmount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.txtPurchaseNum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txtProductType = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtProductId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtGroupNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtPaymentPlatform = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtProductName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtReplyResult = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.txtOrderNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnAddFromExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.progressLoading = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.txtGuestOrderTime = new System.Windows.Forms.DateTimePicker();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdersId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestNamePinYin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestWeChat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestEMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestPassportNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestLastNightHotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddGuest = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWaitorConfirmTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX20
            // 
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Location = new System.Drawing.Point(262, 48);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(50, 22);
            this.labelX20.TabIndex = 98;
            this.labelX20.Text = "团号:";
            this.labelX20.WordWrap = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(544, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(449, 276);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
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
            this.panelEx1.Size = new System.Drawing.Size(738, 561);
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
            this.panelMain.Controls.Add(this.btnAddGuest);
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Controls.Add(this.txtComboName);
            this.panelMain.Controls.Add(this.labelX1);
            this.panelMain.Controls.Add(this.txtWaitorConfirmTime);
            this.panelMain.Controls.Add(this.btnOperInfo);
            this.panelMain.Controls.Add(this.btnGuestInfo);
            this.panelMain.Controls.Add(this.txtPlatformActivity);
            this.panelMain.Controls.Add(this.labelX15);
            this.panelMain.Controls.Add(this.txtReallyPay);
            this.panelMain.Controls.Add(this.labelX14);
            this.panelMain.Controls.Add(this.labelX13);
            this.panelMain.Controls.Add(this.txtOrderAmount);
            this.panelMain.Controls.Add(this.labelX9);
            this.panelMain.Controls.Add(this.txtPurchaseNum);
            this.panelMain.Controls.Add(this.labelX8);
            this.panelMain.Controls.Add(this.txtProductType);
            this.panelMain.Controls.Add(this.labelX7);
            this.panelMain.Controls.Add(this.txtProductId);
            this.panelMain.Controls.Add(this.labelX6);
            this.panelMain.Controls.Add(this.txtGroupNo);
            this.panelMain.Controls.Add(this.txtPaymentPlatform);
            this.panelMain.Controls.Add(this.labelX5);
            this.panelMain.Controls.Add(this.txtProductName);
            this.panelMain.Controls.Add(this.labelX2);
            this.panelMain.Controls.Add(this.txtReplyResult);
            this.panelMain.Controls.Add(this.labelX11);
            this.panelMain.Controls.Add(this.txtOrderNo);
            this.panelMain.Controls.Add(this.labelX4);
            this.panelMain.Controls.Add(this.btnAddFromExcel);
            this.panelMain.Controls.Add(this.btnAdd);
            this.panelMain.Controls.Add(this.progressLoading);
            this.panelMain.Controls.Add(this.txtGuestOrderTime);
            this.panelMain.Controls.Add(this.btnOK);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.labelX20);
            this.panelMain.Controls.Add(this.labelX10);
            this.panelMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(738, 561);
            this.panelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMain.Style.GradientAngle = 90;
            this.panelMain.TabIndex = 106;
            // 
            // txtComboName
            // 
            // 
            // 
            // 
            this.txtComboName.Border.Class = "TextBoxBorder";
            this.txtComboName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtComboName.Location = new System.Drawing.Point(126, 113);
            this.txtComboName.Multiline = true;
            this.txtComboName.Name = "txtComboName";
            this.txtComboName.Size = new System.Drawing.Size(189, 91);
            this.txtComboName.TabIndex = 165;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(26, 113);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(73, 27);
            this.labelX1.TabIndex = 164;
            this.labelX1.Text = "套餐名:";
            // 
            // txtWaitorConfirmTime
            // 
            // 
            // 
            // 
            this.txtWaitorConfirmTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWaitorConfirmTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWaitorConfirmTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtWaitorConfirmTime.ButtonDropDown.Visible = true;
            this.txtWaitorConfirmTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtWaitorConfirmTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtWaitorConfirmTime.IsPopupCalendarOpen = false;
            this.txtWaitorConfirmTime.Location = new System.Drawing.Point(126, 277);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtWaitorConfirmTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWaitorConfirmTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtWaitorConfirmTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtWaitorConfirmTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtWaitorConfirmTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtWaitorConfirmTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtWaitorConfirmTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtWaitorConfirmTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtWaitorConfirmTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtWaitorConfirmTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWaitorConfirmTime.MonthCalendar.DisplayMonth = new System.DateTime(2018, 3, 1, 0, 0, 0, 0);
            this.txtWaitorConfirmTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtWaitorConfirmTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtWaitorConfirmTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtWaitorConfirmTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtWaitorConfirmTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWaitorConfirmTime.MonthCalendar.TodayButtonVisible = true;
            this.txtWaitorConfirmTime.Name = "txtWaitorConfirmTime";
            this.txtWaitorConfirmTime.Size = new System.Drawing.Size(187, 23);
            this.txtWaitorConfirmTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtWaitorConfirmTime.TabIndex = 163;
            // 
            // btnOperInfo
            // 
            this.btnOperInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOperInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOperInfo.Location = new System.Drawing.Point(544, 147);
            this.btnOperInfo.Name = "btnOperInfo";
            this.btnOperInfo.Size = new System.Drawing.Size(128, 57);
            this.btnOperInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOperInfo.TabIndex = 141;
            this.btnOperInfo.Text = "设置(查看)操作信息";
            this.btnOperInfo.Click += new System.EventHandler(this.btnOperInfo_Click);
            // 
            // btnGuestInfo
            // 
            this.btnGuestInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGuestInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGuestInfo.Location = new System.Drawing.Point(544, 213);
            this.btnGuestInfo.Name = "btnGuestInfo";
            this.btnGuestInfo.Size = new System.Drawing.Size(128, 57);
            this.btnGuestInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGuestInfo.TabIndex = 140;
            this.btnGuestInfo.Text = "设置(查看)客户信息";
            this.btnGuestInfo.Click += new System.EventHandler(this.btnGuestInfo_Click);
            // 
            // txtPlatformActivity
            // 
            // 
            // 
            // 
            this.txtPlatformActivity.Border.Class = "TextBoxBorder";
            this.txtPlatformActivity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPlatformActivity.Location = new System.Drawing.Point(126, 374);
            this.txtPlatformActivity.Multiline = true;
            this.txtPlatformActivity.Name = "txtPlatformActivity";
            this.txtPlatformActivity.Size = new System.Drawing.Size(186, 27);
            this.txtPlatformActivity.TabIndex = 139;
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(26, 374);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(115, 27);
            this.labelX15.TabIndex = 138;
            this.labelX15.Text = "平台活动:";
            // 
            // txtReallyPay
            // 
            // 
            // 
            // 
            this.txtReallyPay.Border.Class = "TextBoxBorder";
            this.txtReallyPay.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReallyPay.Location = new System.Drawing.Point(126, 309);
            this.txtReallyPay.Multiline = true;
            this.txtReallyPay.Name = "txtReallyPay";
            this.txtReallyPay.Size = new System.Drawing.Size(189, 27);
            this.txtReallyPay.TabIndex = 137;
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(26, 309);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(115, 27);
            this.labelX14.TabIndex = 136;
            this.labelX14.Text = "实际支付金额:";
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(26, 277);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(121, 27);
            this.labelX13.TabIndex = 134;
            this.labelX13.Text = "客服确认时间:";
            // 
            // txtOrderAmount
            // 
            // 
            // 
            // 
            this.txtOrderAmount.Border.Class = "TextBoxBorder";
            this.txtOrderAmount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderAmount.Location = new System.Drawing.Point(402, 111);
            this.txtOrderAmount.Multiline = true;
            this.txtOrderAmount.Name = "txtOrderAmount";
            this.txtOrderAmount.Size = new System.Drawing.Size(91, 27);
            this.txtOrderAmount.TabIndex = 131;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(322, 111);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(73, 27);
            this.labelX9.TabIndex = 130;
            this.labelX9.Text = "订单金额:";
            // 
            // txtPurchaseNum
            // 
            // 
            // 
            // 
            this.txtPurchaseNum.Border.Class = "TextBoxBorder";
            this.txtPurchaseNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPurchaseNum.Location = new System.Drawing.Point(126, 213);
            this.txtPurchaseNum.Multiline = true;
            this.txtPurchaseNum.Name = "txtPurchaseNum";
            this.txtPurchaseNum.Size = new System.Drawing.Size(189, 27);
            this.txtPurchaseNum.TabIndex = 129;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(26, 213);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(73, 27);
            this.labelX8.TabIndex = 128;
            this.labelX8.Text = "购买数量:";
            // 
            // txtProductType
            // 
            // 
            // 
            // 
            this.txtProductType.Border.Class = "TextBoxBorder";
            this.txtProductType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProductType.Location = new System.Drawing.Point(588, 77);
            this.txtProductType.Multiline = true;
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(141, 27);
            this.txtProductType.TabIndex = 127;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(507, 77);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(73, 27);
            this.labelX7.TabIndex = 126;
            this.labelX7.Text = "商品类型:";
            // 
            // txtProductId
            // 
            // 
            // 
            // 
            this.txtProductId.Border.Class = "TextBoxBorder";
            this.txtProductId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProductId.Location = new System.Drawing.Point(402, 77);
            this.txtProductId.Multiline = true;
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(91, 27);
            this.txtProductId.TabIndex = 125;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(324, 77);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(73, 27);
            this.labelX6.TabIndex = 124;
            this.labelX6.Text = "商品ID:";
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.DisplayMember = "Text";
            this.txtGroupNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtGroupNo.FormattingEnabled = true;
            this.txtGroupNo.ItemHeight = 17;
            this.txtGroupNo.Location = new System.Drawing.Point(320, 45);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(409, 23);
            this.txtGroupNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtGroupNo.TabIndex = 123;
            // 
            // txtPaymentPlatform
            // 
            this.txtPaymentPlatform.DisplayMember = "Text";
            this.txtPaymentPlatform.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtPaymentPlatform.FormattingEnabled = true;
            this.txtPaymentPlatform.ItemHeight = 17;
            this.txtPaymentPlatform.Location = new System.Drawing.Point(126, 45);
            this.txtPaymentPlatform.Name = "txtPaymentPlatform";
            this.txtPaymentPlatform.Size = new System.Drawing.Size(124, 23);
            this.txtPaymentPlatform.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtPaymentPlatform.TabIndex = 122;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(26, 45);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(73, 27);
            this.labelX5.TabIndex = 121;
            this.labelX5.Text = "交易平台:";
            // 
            // txtProductName
            // 
            // 
            // 
            // 
            this.txtProductName.Border.Class = "TextBoxBorder";
            this.txtProductName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProductName.Location = new System.Drawing.Point(126, 77);
            this.txtProductName.Multiline = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(189, 27);
            this.txtProductName.TabIndex = 117;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(26, 77);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(73, 27);
            this.labelX2.TabIndex = 116;
            this.labelX2.Text = "商品名:";
            // 
            // txtReplyResult
            // 
            this.txtReplyResult.DisplayMember = "Text";
            this.txtReplyResult.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtReplyResult.FormattingEnabled = true;
            this.txtReplyResult.ItemHeight = 17;
            this.txtReplyResult.Location = new System.Drawing.Point(126, 342);
            this.txtReplyResult.Name = "txtReplyResult";
            this.txtReplyResult.Size = new System.Drawing.Size(186, 23);
            this.txtReplyResult.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtReplyResult.TabIndex = 113;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(26, 342);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(73, 27);
            this.labelX11.TabIndex = 112;
            this.labelX11.Text = "回复结果:";
            // 
            // txtOrderNo
            // 
            // 
            // 
            // 
            this.txtOrderNo.Border.Class = "TextBoxBorder";
            this.txtOrderNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderNo.Location = new System.Drawing.Point(126, 14);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(603, 23);
            this.txtOrderNo.TabIndex = 111;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(26, 14);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(94, 27);
            this.labelX4.TabIndex = 110;
            this.labelX4.Text = "订单号:";
            // 
            // btnAddFromExcel
            // 
            this.btnAddFromExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddFromExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddFromExcel.Location = new System.Drawing.Point(1162, 7);
            this.btnAddFromExcel.Name = "btnAddFromExcel";
            this.btnAddFromExcel.Size = new System.Drawing.Size(107, 27);
            this.btnAddFromExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddFromExcel.TabIndex = 56;
            this.btnAddFromExcel.Text = "从excel导入";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(1031, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(107, 27);
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
            this.progressLoading.Location = new System.Drawing.Point(972, 0);
            this.progressLoading.Name = "progressLoading";
            this.progressLoading.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.progressLoading.ProgressColor = System.Drawing.Color.YellowGreen;
            this.progressLoading.Size = new System.Drawing.Size(52, 33);
            this.progressLoading.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.progressLoading.TabIndex = 27;
            this.progressLoading.Value = 100;
            // 
            // txtGuestOrderTime
            // 
            this.txtGuestOrderTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.txtGuestOrderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtGuestOrderTime.Location = new System.Drawing.Point(126, 246);
            this.txtGuestOrderTime.Name = "txtGuestOrderTime";
            this.txtGuestOrderTime.Size = new System.Drawing.Size(186, 23);
            this.txtGuestOrderTime.TabIndex = 81;
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(26, 246);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(121, 27);
            this.labelX10.TabIndex = 80;
            this.labelX10.Text = "客人下单时间:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.OrdersId,
            this.GuestId,
            this.GuestType,
            this.GuestName,
            this.GuestNamePinYin,
            this.GuestPhone,
            this.GuestWeChat,
            this.GuestEMail,
            this.GuestSex,
            this.GuestBirthday,
            this.GuestPassportNo,
            this.GuestLastNightHotel,
            this.GuestCountry});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 419);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 30;
            //this.dataGridView1.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.Default;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(738, 142);
            this.dataGridView1.TabIndex = 166;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // OrdersId
            // 
            this.OrdersId.DataPropertyName = "OrdersId";
            this.OrdersId.HeaderText = "订单号";
            this.OrdersId.Name = "OrdersId";
            this.OrdersId.Visible = false;
            // 
            // GuestId
            // 
            this.GuestId.DataPropertyName = "GuestId";
            this.GuestId.HeaderText = "客人Id";
            this.GuestId.Name = "GuestId";
            // 
            // GuestType
            // 
            this.GuestType.DataPropertyName = "GuestType";
            this.GuestType.HeaderText = "客人类型";
            this.GuestType.Name = "GuestType";
            // 
            // GuestName
            // 
            this.GuestName.DataPropertyName = "GuestName";
            this.GuestName.HeaderText = "客人姓名";
            this.GuestName.Name = "GuestName";
            // 
            // GuestNamePinYin
            // 
            this.GuestNamePinYin.DataPropertyName = "GuestNamePinYin";
            this.GuestNamePinYin.HeaderText = "姓名拼音";
            this.GuestNamePinYin.Name = "GuestNamePinYin";
            // 
            // GuestPhone
            // 
            this.GuestPhone.DataPropertyName = "GuestPhone";
            this.GuestPhone.HeaderText = "电话";
            this.GuestPhone.Name = "GuestPhone";
            // 
            // GuestWeChat
            // 
            this.GuestWeChat.DataPropertyName = "GuestWeChat";
            this.GuestWeChat.HeaderText = "微信";
            this.GuestWeChat.Name = "GuestWeChat";
            // 
            // GuestEMail
            // 
            this.GuestEMail.DataPropertyName = "GuestEMail";
            this.GuestEMail.HeaderText = "邮箱";
            this.GuestEMail.Name = "GuestEMail";
            // 
            // GuestSex
            // 
            this.GuestSex.DataPropertyName = "GuestSex";
            this.GuestSex.HeaderText = "性别";
            this.GuestSex.Name = "GuestSex";
            // 
            // GuestBirthday
            // 
            this.GuestBirthday.DataPropertyName = "GuestBirthday";
            this.GuestBirthday.HeaderText = "出生日期";
            this.GuestBirthday.Name = "GuestBirthday";
            // 
            // GuestPassportNo
            // 
            this.GuestPassportNo.DataPropertyName = "GuestPassportNo";
            this.GuestPassportNo.HeaderText = "护照号";
            this.GuestPassportNo.Name = "GuestPassportNo";
            // 
            // GuestLastNightHotel
            // 
            this.GuestLastNightHotel.DataPropertyName = "GuestLastNightHotel";
            this.GuestLastNightHotel.HeaderText = "昨晚酒店名";
            this.GuestLastNightHotel.Name = "GuestLastNightHotel";
            // 
            // GuestCountry
            // 
            this.GuestCountry.DataPropertyName = "GuestCountry";
            this.GuestCountry.HeaderText = "国家";
            this.GuestCountry.Name = "GuestCountry";
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddGuest.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddGuest.Location = new System.Drawing.Point(341, 386);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(87, 27);
            this.btnAddGuest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddGuest.TabIndex = 167;
            this.btnAddGuest.Text = "添加客人";
            this.btnAddGuest.Click += new System.EventHandler(this.btnAddGuest_Click);
            // 
            // FrmAddOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 561);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmAddOrders";
            this.Text = "新增订单信息:";
            this.Load += new System.EventHandler(this.FrmAddOrders_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWaitorConfirmTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX20;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelMain;
        private DevComponents.DotNetBar.ButtonX btnAddFromExcel;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.Controls.CircularProgress progressLoading;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderNo;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx txtReplyResult;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProductName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx txtPaymentPlatform;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx txtGroupNo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProductId;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProductType;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPurchaseNum;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderAmount;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.Controls.TextBoxX txtReallyPay;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPlatformActivity;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.ButtonX btnGuestInfo;
        private DevComponents.DotNetBar.ButtonX btnOperInfo;
        private System.Windows.Forms.DateTimePicker txtGuestOrderTime;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtWaitorConfirmTime;
        private DevComponents.DotNetBar.Controls.TextBoxX txtComboName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdersId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestType;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestNamePinYin;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestWeChat;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestEMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestPassportNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestLastNightHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestCountry;
        private DevComponents.DotNetBar.ButtonX btnAddGuest;
    }
}