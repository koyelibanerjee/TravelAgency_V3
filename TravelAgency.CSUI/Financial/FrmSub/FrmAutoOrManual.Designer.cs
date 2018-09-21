namespace TravelAgency.CSUI.Financial.FrmSub
{
    partial class FrmAutoOrManual
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
            this.rbtnAuto = new System.Windows.Forms.RadioButton();
            this.rbtnManual = new System.Windows.Forms.RadioButton();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.rbtnAuto);
            this.panelEx1.Controls.Add(this.rbtnManual);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnOK);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(232, 79);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // rbtnAuto
            // 
            this.rbtnAuto.AutoSize = true;
            this.rbtnAuto.BackColor = System.Drawing.Color.Transparent;
            this.rbtnAuto.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnAuto.Location = new System.Drawing.Point(34, 12);
            this.rbtnAuto.Name = "rbtnAuto";
            this.rbtnAuto.Size = new System.Drawing.Size(47, 16);
            this.rbtnAuto.TabIndex = 35;
            this.rbtnAuto.TabStop = true;
            this.rbtnAuto.Text = "自动";
            this.rbtnAuto.UseVisualStyleBackColor = false;
            // 
            // rbtnManual
            // 
            this.rbtnManual.AutoSize = true;
            this.rbtnManual.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnManual.Location = new System.Drawing.Point(109, 12);
            this.rbtnManual.Name = "rbtnManual";
            this.rbtnManual.Size = new System.Drawing.Size(47, 16);
            this.rbtnManual.TabIndex = 34;
            this.rbtnManual.TabStop = true;
            this.rbtnManual.Text = "手动";
            this.rbtnManual.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(109, 47);
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
            this.btnOK.Location = new System.Drawing.Point(33, 47);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(47, 20);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmAutoOrManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 79);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmAutoOrManual";
            this.Text = "选择认账类型:";
            this.Load += new System.EventHandler(this.FrmAutoOrManual_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.RadioButton rbtnAuto;
        private System.Windows.Forms.RadioButton rbtnManual;
    }
}