namespace TravelAgency.CSUI.Financial.FrmSub
{
    partial class FrmAppAll
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
            this.panelMain = new DevComponents.DotNetBar.PanelEx();
            this.cbPerson = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.cbBankFrom = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbBank = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbBankTo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbAccount = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtDetails = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX24 = new DevComponents.DotNetBar.LabelX();
            this.labelX23 = new DevComponents.DotNetBar.LabelX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.txtAmountSpend = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbAmount = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.txtGroupNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelMain.Controls.Add(this.cbPerson);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.btnOK);
            this.panelMain.Controls.Add(this.cbBankFrom);
            this.panelMain.Controls.Add(this.cbBank);
            this.panelMain.Controls.Add(this.cbBankTo);
            this.panelMain.Controls.Add(this.cbAccount);
            this.panelMain.Controls.Add(this.txtDetails);
            this.panelMain.Controls.Add(this.labelX24);
            this.panelMain.Controls.Add(this.labelX23);
            this.panelMain.Controls.Add(this.labelX18);
            this.panelMain.Controls.Add(this.txtAmountSpend);
            this.panelMain.Controls.Add(this.lbAmount);
            this.panelMain.Controls.Add(this.labelX12);
            this.panelMain.Controls.Add(this.txtGroupNo);
            this.panelMain.Controls.Add(this.labelX11);
            this.panelMain.Controls.Add(this.labelX7);
            this.panelMain.Controls.Add(this.labelX3);
            this.panelMain.Controls.Add(this.labelX2);
            this.panelMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(599, 217);
            this.panelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMain.Style.GradientAngle = 90;
            this.panelMain.TabIndex = 0;
            // 
            // cbPerson
            // 
            this.cbPerson.DisplayMember = "Text";
            this.cbPerson.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPerson.FormattingEnabled = true;
            this.cbPerson.ItemHeight = 15;
            this.cbPerson.Location = new System.Drawing.Point(121, 90);
            this.cbPerson.Name = "cbPerson";
            this.cbPerson.Size = new System.Drawing.Size(174, 21);
            this.cbPerson.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbPerson.TabIndex = 107;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(306, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 106;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(164, 182);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 106;
            this.btnOK.Text = "确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbBankFrom
            // 
            this.cbBankFrom.DisplayMember = "Text";
            this.cbBankFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBankFrom.FormattingEnabled = true;
            this.cbBankFrom.ItemHeight = 15;
            this.cbBankFrom.Location = new System.Drawing.Point(121, 117);
            this.cbBankFrom.Name = "cbBankFrom";
            this.cbBankFrom.Size = new System.Drawing.Size(174, 21);
            this.cbBankFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBankFrom.TabIndex = 105;
            // 
            // cbBank
            // 
            this.cbBank.DisplayMember = "Text";
            this.cbBank.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBank.FormattingEnabled = true;
            this.cbBank.ItemHeight = 15;
            this.cbBank.Location = new System.Drawing.Point(121, 63);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(174, 21);
            this.cbBank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBank.TabIndex = 104;
            // 
            // cbBankTo
            // 
            this.cbBankTo.DisplayMember = "Text";
            this.cbBankTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBankTo.FormattingEnabled = true;
            this.cbBankTo.ItemHeight = 15;
            this.cbBankTo.Location = new System.Drawing.Point(121, 36);
            this.cbBankTo.Name = "cbBankTo";
            this.cbBankTo.Size = new System.Drawing.Size(174, 21);
            this.cbBankTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBankTo.TabIndex = 103;
            // 
            // cbAccount
            // 
            this.cbAccount.DisplayMember = "Text";
            this.cbAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAccount.FormattingEnabled = true;
            this.cbAccount.ItemHeight = 15;
            this.cbAccount.Location = new System.Drawing.Point(121, 9);
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.Size = new System.Drawing.Size(174, 21);
            this.cbAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbAccount.TabIndex = 102;
            // 
            // txtDetails
            // 
            // 
            // 
            // 
            this.txtDetails.Border.Class = "TextBoxBorder";
            this.txtDetails.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDetails.Location = new System.Drawing.Point(396, 67);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.PreventEnterBeep = true;
            this.txtDetails.Size = new System.Drawing.Size(174, 71);
            this.txtDetails.TabIndex = 83;
            // 
            // labelX24
            // 
            // 
            // 
            // 
            this.labelX24.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX24.Location = new System.Drawing.Point(35, 90);
            this.labelX24.Name = "labelX24";
            this.labelX24.Size = new System.Drawing.Size(80, 23);
            this.labelX24.TabIndex = 101;
            this.labelX24.Text = "开户名:";
            // 
            // labelX23
            // 
            // 
            // 
            // 
            this.labelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX23.Location = new System.Drawing.Point(35, 12);
            this.labelX23.Name = "labelX23";
            this.labelX23.Size = new System.Drawing.Size(80, 23);
            this.labelX23.TabIndex = 98;
            this.labelX23.Text = "汇款账户:";
            // 
            // labelX18
            // 
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Location = new System.Drawing.Point(315, 67);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(75, 23);
            this.labelX18.TabIndex = 96;
            this.labelX18.Text = "摘要:";
            // 
            // txtAmountSpend
            // 
            // 
            // 
            // 
            this.txtAmountSpend.Border.Class = "TextBoxBorder";
            this.txtAmountSpend.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAmountSpend.Location = new System.Drawing.Point(121, 144);
            this.txtAmountSpend.Name = "txtAmountSpend";
            this.txtAmountSpend.PreventEnterBeep = true;
            this.txtAmountSpend.Size = new System.Drawing.Size(174, 21);
            this.txtAmountSpend.TabIndex = 95;
            // 
            // lbAmount
            // 
            // 
            // 
            // 
            this.lbAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbAmount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAmount.ForeColor = System.Drawing.Color.Green;
            this.lbAmount.Location = new System.Drawing.Point(424, 144);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(146, 23);
            this.lbAmount.TabIndex = 94;
            this.lbAmount.Text = "请款金额:12000元";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(35, 144);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(80, 23);
            this.labelX12.TabIndex = 91;
            this.labelX12.Text = "支出金额:";
            // 
            // txtGroupNo
            // 
            // 
            // 
            // 
            this.txtGroupNo.Border.Class = "TextBoxBorder";
            this.txtGroupNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGroupNo.Location = new System.Drawing.Point(396, 12);
            this.txtGroupNo.Multiline = true;
            this.txtGroupNo.Name = "txtGroupNo";
            this.txtGroupNo.PreventEnterBeep = true;
            this.txtGroupNo.Size = new System.Drawing.Size(174, 49);
            this.txtGroupNo.TabIndex = 90;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(315, 11);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(96, 23);
            this.labelX11.TabIndex = 72;
            this.labelX11.Text = "团号:";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(35, 119);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(80, 23);
            this.labelX7.TabIndex = 74;
            this.labelX7.Text = "支出银行:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(35, 65);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(80, 23);
            this.labelX3.TabIndex = 77;
            this.labelX3.Text = "开户行:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(35, 36);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(80, 23);
            this.labelX2.TabIndex = 73;
            this.labelX2.Text = "汇款银行:";
            // 
            // FrmAppAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 217);
            this.Controls.Add(this.panelMain);
            this.Name = "FrmAppAll";
            this.Text = "提交请款申请";
            this.Load += new System.EventHandler(this.FrmAppAll_Load);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelMain;
        private DevComponents.DotNetBar.LabelX labelX24;
        private DevComponents.DotNetBar.LabelX labelX23;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAmountSpend;
        private DevComponents.DotNetBar.LabelX lbAmount;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGroupNo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDetails;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbAccount;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBankTo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBankFrom;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBank;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbPerson;
    }
}