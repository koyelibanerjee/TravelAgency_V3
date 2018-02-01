namespace TravelAgency.CSUI.FrmSub
{
    partial class FrmSetSubmitStatus
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
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.rbtnNoRecord = new System.Windows.Forms.RadioButton();
            this.rbtnAbOut = new System.Windows.Forms.RadioButton();
            this.rbtnOut = new System.Windows.Forms.RadioButton();
            this.rbtnIn = new System.Windows.Forms.RadioButton();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.rbtnNoRecord);
            this.panelEx1.Controls.Add(this.rbtnAbOut);
            this.panelEx1.Controls.Add(this.rbtnOut);
            this.panelEx1.Controls.Add(this.rbtnIn);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnOK);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(292, 75);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(151, 43);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(47, 20);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(75, 43);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(47, 20);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rbtnNoRecord
            // 
            this.rbtnNoRecord.AutoSize = true;
            this.rbtnNoRecord.BackColor = System.Drawing.Color.Transparent;
            this.rbtnNoRecord.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnNoRecord.Location = new System.Drawing.Point(22, 12);
            this.rbtnNoRecord.Name = "rbtnNoRecord";
            this.rbtnNoRecord.Size = new System.Drawing.Size(59, 16);
            this.rbtnNoRecord.TabIndex = 37;
            this.rbtnNoRecord.TabStop = true;
            this.rbtnNoRecord.Text = "未记录";
            this.rbtnNoRecord.UseVisualStyleBackColor = false;
            // 
            // rbtnAbOut
            // 
            this.rbtnAbOut.AutoSize = true;
            this.rbtnAbOut.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnAbOut.Location = new System.Drawing.Point(204, 12);
            this.rbtnAbOut.Name = "rbtnAbOut";
            this.rbtnAbOut.Size = new System.Drawing.Size(83, 16);
            this.rbtnAbOut.TabIndex = 34;
            this.rbtnAbOut.TabStop = true;
            this.rbtnAbOut.Text = "非正常出签";
            this.rbtnAbOut.UseVisualStyleBackColor = true;
            // 
            // rbtnOut
            // 
            this.rbtnOut.AutoSize = true;
            this.rbtnOut.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnOut.Location = new System.Drawing.Point(151, 12);
            this.rbtnOut.Name = "rbtnOut";
            this.rbtnOut.Size = new System.Drawing.Size(47, 16);
            this.rbtnOut.TabIndex = 35;
            this.rbtnOut.TabStop = true;
            this.rbtnOut.Text = "出签";
            this.rbtnOut.UseVisualStyleBackColor = true;
            // 
            // rbtnIn
            // 
            this.rbtnIn.AutoSize = true;
            this.rbtnIn.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnIn.Location = new System.Drawing.Point(87, 12);
            this.rbtnIn.Name = "rbtnIn";
            this.rbtnIn.Size = new System.Drawing.Size(47, 16);
            this.rbtnIn.TabIndex = 36;
            this.rbtnIn.TabStop = true;
            this.rbtnIn.Text = "进签";
            this.rbtnIn.UseVisualStyleBackColor = true;
            // 
            // FrmSetSubmitStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 75);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmSetSubmitStatus";
            this.Text = "送签状态选择:";
            this.Load += new System.EventHandler(this.FrmSetTypeInStatus_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.RadioButton rbtnNoRecord;
        private System.Windows.Forms.RadioButton rbtnAbOut;
        private System.Windows.Forms.RadioButton rbtnOut;
        private System.Windows.Forms.RadioButton rbtnIn;
    }
}