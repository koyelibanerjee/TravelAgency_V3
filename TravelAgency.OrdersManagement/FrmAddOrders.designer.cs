namespace TravelAgency.OrdersManagement
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
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtGuestOrderTime = new System.Windows.Forms.DateTimePicker();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelMain = new DevComponents.DotNetBar.PanelEx();
            this.btnOperInfo = new DevComponents.DotNetBar.ButtonX();
            this.btnGuestInfo = new DevComponents.DotNetBar.ButtonX();
            this.txtPlatformActivity = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.txtReallyPay = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.txtWaitorConfirmTime = new System.Windows.Forms.DateTimePicker();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.txtWaitorOrderTime = new System.Windows.Forms.DateTimePicker();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
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
            this.panelEx1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX20
            // 
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Location = new System.Drawing.Point(225, 41);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(43, 19);
            this.labelX20.TabIndex = 98;
            this.labelX20.Text = "团号:";
            this.labelX20.WordWrap = true;
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(17, 132);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(104, 23);
            this.labelX10.TabIndex = 80;
            this.labelX10.Text = "客人下单时间:";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(466, 246);
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
            this.btnOK.Location = new System.Drawing.Point(385, 246);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 29;
            this.btnOK.Text = "确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtGuestOrderTime
            // 
            this.txtGuestOrderTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.txtGuestOrderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtGuestOrderTime.Location = new System.Drawing.Point(108, 132);
            this.txtGuestOrderTime.Name = "txtGuestOrderTime";
            this.txtGuestOrderTime.Size = new System.Drawing.Size(160, 21);
            this.txtGuestOrderTime.TabIndex = 81;
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
            this.panelEx1.Size = new System.Drawing.Size(633, 307);
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
            this.panelMain.Controls.Add(this.btnOperInfo);
            this.panelMain.Controls.Add(this.btnGuestInfo);
            this.panelMain.Controls.Add(this.txtPlatformActivity);
            this.panelMain.Controls.Add(this.labelX15);
            this.panelMain.Controls.Add(this.txtReallyPay);
            this.panelMain.Controls.Add(this.labelX14);
            this.panelMain.Controls.Add(this.txtWaitorConfirmTime);
            this.panelMain.Controls.Add(this.labelX13);
            this.panelMain.Controls.Add(this.txtWaitorOrderTime);
            this.panelMain.Controls.Add(this.labelX12);
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
            this.panelMain.Size = new System.Drawing.Size(633, 307);
            this.panelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMain.Style.GradientAngle = 90;
            this.panelMain.TabIndex = 106;
            // 
            // btnOperInfo
            // 
            this.btnOperInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOperInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOperInfo.Location = new System.Drawing.Point(466, 135);
            this.btnOperInfo.Name = "btnOperInfo";
            this.btnOperInfo.Size = new System.Drawing.Size(110, 49);
            this.btnOperInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOperInfo.TabIndex = 141;
            this.btnOperInfo.Text = "设置(查看)操作信息";
            this.btnOperInfo.Click += new System.EventHandler(this.btnOperInfo_Click);
            // 
            // btnGuestInfo
            // 
            this.btnGuestInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGuestInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGuestInfo.Location = new System.Drawing.Point(350, 135);
            this.btnGuestInfo.Name = "btnGuestInfo";
            this.btnGuestInfo.Size = new System.Drawing.Size(110, 49);
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
            this.txtPlatformActivity.Location = new System.Drawing.Point(108, 273);
            this.txtPlatformActivity.Multiline = true;
            this.txtPlatformActivity.Name = "txtPlatformActivity";
            this.txtPlatformActivity.Size = new System.Drawing.Size(162, 23);
            this.txtPlatformActivity.TabIndex = 139;
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(22, 273);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(99, 23);
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
            this.txtReallyPay.Location = new System.Drawing.Point(108, 217);
            this.txtReallyPay.Multiline = true;
            this.txtReallyPay.Name = "txtReallyPay";
            this.txtReallyPay.Size = new System.Drawing.Size(162, 23);
            this.txtReallyPay.TabIndex = 137;
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(20, 217);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(99, 23);
            this.labelX14.TabIndex = 136;
            this.labelX14.Text = "实际支付金额:";
            // 
            // txtWaitorConfirmTime
            // 
            this.txtWaitorConfirmTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.txtWaitorConfirmTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtWaitorConfirmTime.Location = new System.Drawing.Point(108, 190);
            this.txtWaitorConfirmTime.Name = "txtWaitorConfirmTime";
            this.txtWaitorConfirmTime.Size = new System.Drawing.Size(160, 21);
            this.txtWaitorConfirmTime.TabIndex = 135;
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(17, 190);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(104, 23);
            this.labelX13.TabIndex = 134;
            this.labelX13.Text = "客服确认时间:";
            // 
            // txtWaitorOrderTime
            // 
            this.txtWaitorOrderTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.txtWaitorOrderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtWaitorOrderTime.Location = new System.Drawing.Point(108, 161);
            this.txtWaitorOrderTime.Name = "txtWaitorOrderTime";
            this.txtWaitorOrderTime.Size = new System.Drawing.Size(160, 21);
            this.txtWaitorOrderTime.TabIndex = 133;
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(17, 161);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(104, 23);
            this.labelX12.TabIndex = 132;
            this.labelX12.Text = "客服下单时间:";
            // 
            // txtOrderAmount
            // 
            // 
            // 
            // 
            this.txtOrderAmount.Border.Class = "TextBoxBorder";
            this.txtOrderAmount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderAmount.Location = new System.Drawing.Point(345, 104);
            this.txtOrderAmount.Multiline = true;
            this.txtOrderAmount.Name = "txtOrderAmount";
            this.txtOrderAmount.Size = new System.Drawing.Size(78, 23);
            this.txtOrderAmount.TabIndex = 131;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(276, 104);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(63, 23);
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
            this.txtPurchaseNum.Location = new System.Drawing.Point(108, 104);
            this.txtPurchaseNum.Multiline = true;
            this.txtPurchaseNum.Name = "txtPurchaseNum";
            this.txtPurchaseNum.Size = new System.Drawing.Size(162, 23);
            this.txtPurchaseNum.TabIndex = 129;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(19, 104);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(63, 23);
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
            this.txtProductType.Location = new System.Drawing.Point(504, 75);
            this.txtProductType.Multiline = true;
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(121, 23);
            this.txtProductType.TabIndex = 127;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(435, 75);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(63, 23);
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
            this.txtProductId.Location = new System.Drawing.Point(345, 75);
            this.txtProductId.Multiline = true;
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(78, 23);
            this.txtProductId.TabIndex = 125;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(278, 75);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(63, 23);
            this.labelX6.TabIndex = 124;
            this.labelX6.Text = "商品ID:";
            // 
            // txtGroupNo
            // 
            this.txtGroupNo.DisplayMember = "Text";
            this.txtGroupNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtGroupNo.FormattingEnabled = true;
            this.txtGroupNo.ItemHeight = 15;
            this.txtGroupNo.Location = new System.Drawing.Point(274, 39);
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.Size = new System.Drawing.Size(351, 21);
            this.txtGroupNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtGroupNo.TabIndex = 123;
            // 
            // txtPaymentPlatform
            // 
            this.txtPaymentPlatform.DisplayMember = "Text";
            this.txtPaymentPlatform.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtPaymentPlatform.FormattingEnabled = true;
            this.txtPaymentPlatform.ItemHeight = 15;
            this.txtPaymentPlatform.Location = new System.Drawing.Point(108, 39);
            this.txtPaymentPlatform.Name = "txtPaymentPlatform";
            this.txtPaymentPlatform.Size = new System.Drawing.Size(107, 21);
            this.txtPaymentPlatform.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtPaymentPlatform.TabIndex = 122;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(18, 39);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(63, 23);
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
            this.txtProductName.Location = new System.Drawing.Point(108, 75);
            this.txtProductName.Multiline = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(162, 23);
            this.txtProductName.TabIndex = 117;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(19, 75);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(63, 23);
            this.labelX2.TabIndex = 116;
            this.labelX2.Text = "商品名:";
            // 
            // txtReplyResult
            // 
            this.txtReplyResult.DisplayMember = "Text";
            this.txtReplyResult.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtReplyResult.FormattingEnabled = true;
            this.txtReplyResult.ItemHeight = 15;
            this.txtReplyResult.Location = new System.Drawing.Point(108, 246);
            this.txtReplyResult.Name = "txtReplyResult";
            this.txtReplyResult.Size = new System.Drawing.Size(160, 21);
            this.txtReplyResult.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtReplyResult.TabIndex = 113;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(20, 246);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(63, 23);
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
            this.txtOrderNo.Location = new System.Drawing.Point(108, 12);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(517, 21);
            this.txtOrderNo.TabIndex = 111;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(18, 12);
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
            // FrmAddOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 307);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmAddOrders";
            this.Text = "新增订单信息:";
            this.Load += new System.EventHandler(this.FrmAddOrders_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX20;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.DateTimePicker txtGuestOrderTime;
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
        private System.Windows.Forms.DateTimePicker txtWaitorConfirmTime;
        private DevComponents.DotNetBar.LabelX labelX13;
        private System.Windows.Forms.DateTimePicker txtWaitorOrderTime;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtReallyPay;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPlatformActivity;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.ButtonX btnGuestInfo;
        private DevComponents.DotNetBar.ButtonX btnOperInfo;
    }
}