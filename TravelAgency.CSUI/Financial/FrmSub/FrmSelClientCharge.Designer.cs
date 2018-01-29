namespace TravelAgency.CSUI.Financial.FrmSub
{
    partial class FrmSelClientCharge
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
            this.panelMAIN = new DevComponents.DotNetBar.PanelEx();
            this.chkAllChange = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lbConfig = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.lbReceipt = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panelMAIN.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMAIN
            // 
            this.panelMAIN.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelMAIN.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelMAIN.Controls.Add(this.chkAllChange);
            this.panelMAIN.Controls.Add(this.lbConfig);
            this.panelMAIN.Controls.Add(this.btnCancel);
            this.panelMAIN.Controls.Add(this.btnOK);
            this.panelMAIN.Controls.Add(this.lbReceipt);
            this.panelMAIN.Controls.Add(this.labelX3);
            this.panelMAIN.Controls.Add(this.comboBoxEx1);
            this.panelMAIN.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMAIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMAIN.Location = new System.Drawing.Point(0, 0);
            this.panelMAIN.Name = "panelMAIN";
            this.panelMAIN.Size = new System.Drawing.Size(307, 149);
            this.panelMAIN.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMAIN.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMAIN.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMAIN.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMAIN.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMAIN.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMAIN.Style.GradientAngle = 90;
            this.panelMAIN.TabIndex = 0;
            // 
            // chkAllChange
            // 
            // 
            // 
            // 
            this.chkAllChange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAllChange.Location = new System.Drawing.Point(193, 69);
            this.chkAllChange.Name = "chkAllChange";
            this.chkAllChange.Size = new System.Drawing.Size(100, 48);
            this.chkAllChange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAllChange.TabIndex = 5;
            this.chkAllChange.Text = "同时修改所有相同类型";
            // 
            // lbConfig
            // 
            // 
            // 
            // 
            this.lbConfig.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbConfig.Location = new System.Drawing.Point(200, 12);
            this.lbConfig.Name = "lbConfig";
            this.lbConfig.Size = new System.Drawing.Size(104, 23);
            this.lbConfig.TabIndex = 4;
            this.lbConfig.Text = "共有2套配置";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(157, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(61, 123);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbReceipt
            // 
            // 
            // 
            // 
            this.lbReceipt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbReceipt.Location = new System.Drawing.Point(112, 69);
            this.lbReceipt.Name = "lbReceipt";
            this.lbReceipt.Size = new System.Drawing.Size(75, 23);
            this.lbReceipt.TabIndex = 2;
            this.lbReceipt.Text = "labelX4";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(13, 69);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "客户收款:";
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 15;
            this.comboBoxEx1.Location = new System.Drawing.Point(13, 12);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(181, 21);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 0;
            // 
            // FrmSelClientCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 149);
            this.Controls.Add(this.panelMAIN);
            this.Name = "FrmSelClientCharge";
            this.Text = "选择配置";
            this.Load += new System.EventHandler(this.FrmSelConsulateCharge_Load);
            this.panelMAIN.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelMAIN;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX lbReceipt;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.LabelX lbConfig;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAllChange;
    }
}