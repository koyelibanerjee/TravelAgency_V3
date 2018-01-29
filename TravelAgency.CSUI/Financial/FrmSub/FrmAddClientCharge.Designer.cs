namespace TravelAgency.CSUI.Financial.FrmSub
{
    partial class FrmAddClientCharge
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtRemark = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.cbReceipt = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbDepartureType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbCountry = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbClient = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.txtRemark);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnOK);
            this.panelEx1.Controls.Add(this.cbReceipt);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.cbDepartureType);
            this.panelEx1.Controls.Add(this.cbType);
            this.panelEx1.Controls.Add(this.cbClient);
            this.panelEx1.Controls.Add(this.cbCountry);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(421, 267);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(23, 40);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(46, 23);
            this.labelX5.TabIndex = 30;
            this.labelX5.Text = "客户:";
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRemark.Border.Class = "TextBoxBorder";
            this.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRemark.DisabledBackColor = System.Drawing.Color.White;
            this.txtRemark.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtRemark.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.Location = new System.Drawing.Point(223, 42);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PreventEnterBeep = true;
            this.txtRemark.Size = new System.Drawing.Size(186, 153);
            this.txtRemark.TabIndex = 29;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(240, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(98, 227);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 27;
            this.btnOK.Text = "确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbReceipt
            // 
            this.cbReceipt.DisplayMember = "Text";
            this.cbReceipt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbReceipt.ForeColor = System.Drawing.Color.Black;
            this.cbReceipt.FormattingEnabled = true;
            this.cbReceipt.ItemHeight = 15;
            this.cbReceipt.Location = new System.Drawing.Point(96, 174);
            this.cbReceipt.Name = "cbReceipt";
            this.cbReceipt.Size = new System.Drawing.Size(107, 21);
            this.cbReceipt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbReceipt.TabIndex = 3;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelX7.Location = new System.Drawing.Point(223, 12);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(68, 23);
            this.labelX7.TabIndex = 2;
            this.labelX7.Text = "备注:";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(23, 174);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 2;
            this.labelX4.Text = "客户收款:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(23, 127);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(63, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "出境类型:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(23, 98);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(46, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "类型:";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(23, 69);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(46, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "国家:";
            // 
            // cbDepartureType
            // 
            this.cbDepartureType.DisplayMember = "Text";
            this.cbDepartureType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDepartureType.ForeColor = System.Drawing.Color.Black;
            this.cbDepartureType.FormattingEnabled = true;
            this.cbDepartureType.ItemHeight = 15;
            this.cbDepartureType.Location = new System.Drawing.Point(96, 127);
            this.cbDepartureType.Name = "cbDepartureType";
            this.cbDepartureType.Size = new System.Drawing.Size(107, 21);
            this.cbDepartureType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDepartureType.TabIndex = 0;
            // 
            // cbType
            // 
            this.cbType.DisplayMember = "Text";
            this.cbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbType.ForeColor = System.Drawing.Color.Black;
            this.cbType.FormattingEnabled = true;
            this.cbType.ItemHeight = 15;
            this.cbType.Location = new System.Drawing.Point(96, 98);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(107, 21);
            this.cbType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbType.TabIndex = 0;
            // 
            // cbCountry
            // 
            this.cbCountry.DisplayMember = "Text";
            this.cbCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCountry.ForeColor = System.Drawing.Color.Black;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.ItemHeight = 15;
            this.cbCountry.Location = new System.Drawing.Point(96, 69);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(107, 21);
            this.cbCountry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbCountry.TabIndex = 0;
            // 
            // cbClient
            // 
            this.cbClient.DisplayMember = "Text";
            this.cbClient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbClient.ForeColor = System.Drawing.Color.Black;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.ItemHeight = 15;
            this.cbClient.Location = new System.Drawing.Point(96, 42);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(107, 21);
            this.cbClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbClient.TabIndex = 0;
            // 
            // FrmAddClientCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 267);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmAddClientCharge";
            this.Text = "客户收费选择:";
            this.Load += new System.EventHandler(this.FrmConsulateCharge_Load);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbCountry;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbType;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbDepartureType;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbReceipt;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRemark;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbClient;
    }
}