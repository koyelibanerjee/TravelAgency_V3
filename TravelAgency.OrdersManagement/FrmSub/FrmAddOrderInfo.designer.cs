﻿namespace TravelAgency.OrdersManagement
{
    partial class FrmAddOrderInfo
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
            this.txtAmount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtOrderTime = new System.Windows.Forms.DateTimePicker();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelMain = new DevComponents.DotNetBar.PanelEx();
            this.txtPaymentPlatform = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtOrderInfoState = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnShowExcel = new DevComponents.DotNetBar.ButtonX();
            this.txtProductName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtExtraData = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtOrderType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
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
            this.labelX20.Location = new System.Drawing.Point(317, 45);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(50, 22);
            this.labelX20.TabIndex = 98;
            this.labelX20.Text = "金额:";
            this.labelX20.WordWrap = true;
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(21, 45);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(93, 27);
            this.labelX10.TabIndex = 80;
            this.labelX10.Text = "结算时间:";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(273, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAmount
            // 
            // 
            // 
            // 
            this.txtAmount.Border.Class = "TextBoxBorder";
            this.txtAmount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAmount.Location = new System.Drawing.Point(370, 45);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(125, 23);
            this.txtAmount.TabIndex = 99;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(179, 401);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 29;
            this.btnOK.Text = "确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtOrderTime
            // 
            this.txtOrderTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.txtOrderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtOrderTime.Location = new System.Drawing.Point(124, 45);
            this.txtOrderTime.Name = "txtOrderTime";
            this.txtOrderTime.Size = new System.Drawing.Size(186, 23);
            this.txtOrderTime.TabIndex = 81;
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
            this.panelEx1.Size = new System.Drawing.Size(510, 440);
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
            this.panelMain.Controls.Add(this.txtPaymentPlatform);
            this.panelMain.Controls.Add(this.labelX5);
            this.panelMain.Controls.Add(this.txtOrderInfoState);
            this.panelMain.Controls.Add(this.labelX3);
            this.panelMain.Controls.Add(this.btnShowExcel);
            this.panelMain.Controls.Add(this.txtProductName);
            this.panelMain.Controls.Add(this.labelX2);
            this.panelMain.Controls.Add(this.txtExtraData);
            this.panelMain.Controls.Add(this.labelX1);
            this.panelMain.Controls.Add(this.txtOrderType);
            this.panelMain.Controls.Add(this.labelX11);
            this.panelMain.Controls.Add(this.txtOrderNo);
            this.panelMain.Controls.Add(this.labelX4);
            this.panelMain.Controls.Add(this.btnAddFromExcel);
            this.panelMain.Controls.Add(this.btnAdd);
            this.panelMain.Controls.Add(this.progressLoading);
            this.panelMain.Controls.Add(this.txtOrderTime);
            this.panelMain.Controls.Add(this.btnOK);
            this.panelMain.Controls.Add(this.txtAmount);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.labelX20);
            this.panelMain.Controls.Add(this.labelX10);
            this.panelMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(510, 440);
            this.panelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMain.Style.GradientAngle = 90;
            this.panelMain.TabIndex = 106;
            // 
            // txtPaymentPlatform
            // 
            this.txtPaymentPlatform.DisplayMember = "Text";
            this.txtPaymentPlatform.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtPaymentPlatform.FormattingEnabled = true;
            this.txtPaymentPlatform.ItemHeight = 17;
            this.txtPaymentPlatform.Location = new System.Drawing.Point(124, 108);
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
            this.labelX5.Location = new System.Drawing.Point(21, 108);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(73, 27);
            this.labelX5.TabIndex = 121;
            this.labelX5.Text = "交易平台:";
            // 
            // txtOrderInfoState
            // 
            this.txtOrderInfoState.DisplayMember = "Text";
            this.txtOrderInfoState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtOrderInfoState.FormattingEnabled = true;
            this.txtOrderInfoState.ItemHeight = 17;
            this.txtOrderInfoState.Location = new System.Drawing.Point(370, 77);
            this.txtOrderInfoState.Name = "txtOrderInfoState";
            this.txtOrderInfoState.Size = new System.Drawing.Size(124, 23);
            this.txtOrderInfoState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtOrderInfoState.TabIndex = 120;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(287, 77);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(73, 27);
            this.labelX3.TabIndex = 119;
            this.labelX3.Text = "订单状态:";
            // 
            // btnShowExcel
            // 
            this.btnShowExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowExcel.Location = new System.Drawing.Point(287, 108);
            this.btnShowExcel.Name = "btnShowExcel";
            this.btnShowExcel.Size = new System.Drawing.Size(208, 27);
            this.btnShowExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowExcel.TabIndex = 118;
            this.btnShowExcel.Text = "查看导入数据Excel";
            this.btnShowExcel.Click += new System.EventHandler(this.btnShowExcel_Click);
            // 
            // txtProductName
            // 
            // 
            // 
            // 
            this.txtProductName.Border.Class = "TextBoxBorder";
            this.txtProductName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtProductName.Location = new System.Drawing.Point(122, 151);
            this.txtProductName.Multiline = true;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(372, 49);
            this.txtProductName.TabIndex = 117;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(21, 151);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(73, 27);
            this.labelX2.TabIndex = 116;
            this.labelX2.Text = "商品名:";
            // 
            // txtExtraData
            // 
            // 
            // 
            // 
            this.txtExtraData.Border.Class = "TextBoxBorder";
            this.txtExtraData.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtExtraData.Location = new System.Drawing.Point(122, 216);
            this.txtExtraData.Multiline = true;
            this.txtExtraData.Name = "txtExtraData";
            this.txtExtraData.Size = new System.Drawing.Size(372, 173);
            this.txtExtraData.TabIndex = 115;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(21, 216);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(94, 27);
            this.labelX1.TabIndex = 114;
            this.labelX1.Text = "其他信息:";
            // 
            // txtOrderType
            // 
            this.txtOrderType.DisplayMember = "Text";
            this.txtOrderType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtOrderType.FormattingEnabled = true;
            this.txtOrderType.ItemHeight = 17;
            this.txtOrderType.Location = new System.Drawing.Point(124, 77);
            this.txtOrderType.Name = "txtOrderType";
            this.txtOrderType.Size = new System.Drawing.Size(124, 23);
            this.txtOrderType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtOrderType.TabIndex = 113;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(21, 77);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(73, 27);
            this.labelX11.TabIndex = 112;
            this.labelX11.Text = "订单类型:";
            // 
            // txtOrderNo
            // 
            // 
            // 
            // 
            this.txtOrderNo.Border.Class = "TextBoxBorder";
            this.txtOrderNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderNo.Location = new System.Drawing.Point(124, 14);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(372, 23);
            this.txtOrderNo.TabIndex = 111;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(21, 14);
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
            // FrmAddOrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 440);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmAddOrderInfo";
            this.Text = "新增订单信息:";
            this.Load += new System.EventHandler(this.FrmAddOrderInfo_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX20;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAmount;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.DateTimePicker txtOrderTime;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelMain;
        private DevComponents.DotNetBar.ButtonX btnAddFromExcel;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.Controls.CircularProgress progressLoading;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderNo;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx txtOrderType;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.Controls.TextBoxX txtExtraData;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtProductName;
        private DevComponents.DotNetBar.ButtonX btnShowExcel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx txtOrderInfoState;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx txtPaymentPlatform;
        private DevComponents.DotNetBar.LabelX labelX5;
    }
}