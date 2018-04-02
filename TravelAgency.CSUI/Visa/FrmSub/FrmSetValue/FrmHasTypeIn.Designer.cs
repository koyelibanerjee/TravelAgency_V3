namespace TravelAgency.CSUI.FrmSetValue
{
    partial class FrmHasTypeIn
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
            this.rbtnCancel = new System.Windows.Forms.RadioButton();
            this.rbtnDelay = new System.Windows.Forms.RadioButton();
            this.rbtnNotDone = new System.Windows.Forms.RadioButton();
            this.rBtnDone = new System.Windows.Forms.RadioButton();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.rbtnCancel);
            this.panelEx1.Controls.Add(this.rbtnDelay);
            this.panelEx1.Controls.Add(this.rbtnNotDone);
            this.panelEx1.Controls.Add(this.rBtnDone);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnOK);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(266, 99);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // rbtnCancel
            // 
            this.rbtnCancel.AutoSize = true;
            this.rbtnCancel.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnCancel.Location = new System.Drawing.Point(204, 41);
            this.rbtnCancel.Name = "rbtnCancel";
            this.rbtnCancel.Size = new System.Drawing.Size(47, 16);
            this.rbtnCancel.TabIndex = 24;
            this.rbtnCancel.TabStop = true;
            this.rbtnCancel.Text = "取消";
            this.rbtnCancel.UseVisualStyleBackColor = true;
            // 
            // rbtnDelay
            // 
            this.rbtnDelay.AutoSize = true;
            this.rbtnDelay.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnDelay.Location = new System.Drawing.Point(142, 41);
            this.rbtnDelay.Name = "rbtnDelay";
            this.rbtnDelay.Size = new System.Drawing.Size(47, 16);
            this.rbtnDelay.TabIndex = 21;
            this.rbtnDelay.TabStop = true;
            this.rbtnDelay.Text = "延迟";
            this.rbtnDelay.UseVisualStyleBackColor = true;
            // 
            // rbtnNotDone
            // 
            this.rbtnNotDone.AutoSize = true;
            this.rbtnNotDone.BackColor = System.Drawing.Color.Transparent;
            this.rbtnNotDone.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnNotDone.Location = new System.Drawing.Point(13, 41);
            this.rbtnNotDone.Name = "rbtnNotDone";
            this.rbtnNotDone.Size = new System.Drawing.Size(47, 16);
            this.rbtnNotDone.TabIndex = 23;
            this.rbtnNotDone.TabStop = true;
            this.rbtnNotDone.Text = "未做";
            this.rbtnNotDone.UseVisualStyleBackColor = false;
            // 
            // rBtnDone
            // 
            this.rBtnDone.AutoSize = true;
            this.rBtnDone.ForeColor = System.Drawing.Color.OrangeRed;
            this.rBtnDone.Location = new System.Drawing.Point(78, 41);
            this.rBtnDone.Name = "rBtnDone";
            this.rBtnDone.Size = new System.Drawing.Size(47, 16);
            this.rBtnDone.TabIndex = 22;
            this.rBtnDone.TabStop = true;
            this.rBtnDone.Text = "已做";
            this.rBtnDone.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(152, 63);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(42, 63);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(96, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "签证类型选择:";
            // 
            // FrmHasTypeIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 99);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmHasTypeIn";
            this.Text = "日本签证类型选择";
            this.Load += new System.EventHandler(this.FrmGroupOrIndividual_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.RadioButton rbtnDelay;
        private System.Windows.Forms.RadioButton rbtnNotDone;
        private System.Windows.Forms.RadioButton rBtnDone;
        private System.Windows.Forms.RadioButton rbtnCancel;
    }
}