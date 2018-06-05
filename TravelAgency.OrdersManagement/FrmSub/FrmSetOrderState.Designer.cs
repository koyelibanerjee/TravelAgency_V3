namespace TravelAgency.OrdersManagement
{
    partial class FrmSetOrderState
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
            this.rbtnNormal = new System.Windows.Forms.RadioButton();
            this.rbtn已出单 = new System.Windows.Forms.RadioButton();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.rbtn待退款 = new System.Windows.Forms.RadioButton();
            this.rbtn已退款 = new System.Windows.Forms.RadioButton();
            this.rbtn未退款 = new System.Windows.Forms.RadioButton();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.rbtn未退款);
            this.panelEx1.Controls.Add(this.rbtn已退款);
            this.panelEx1.Controls.Add(this.rbtn待退款);
            this.panelEx1.Controls.Add(this.rbtnNormal);
            this.panelEx1.Controls.Add(this.rbtn已出单);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnOK);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(266, 151);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // rbtnNormal
            // 
            this.rbtnNormal.AutoSize = true;
            this.rbtnNormal.BackColor = System.Drawing.Color.Transparent;
            this.rbtnNormal.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnNormal.Location = new System.Drawing.Point(24, 48);
            this.rbtnNormal.Name = "rbtnNormal";
            this.rbtnNormal.Size = new System.Drawing.Size(53, 18);
            this.rbtnNormal.TabIndex = 23;
            this.rbtnNormal.TabStop = true;
            this.rbtnNormal.Text = "普通";
            this.rbtnNormal.UseVisualStyleBackColor = false;
            // 
            // rbtn已出单
            // 
            this.rbtn已出单.AutoSize = true;
            this.rbtn已出单.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtn已出单.Location = new System.Drawing.Point(99, 48);
            this.rbtn已出单.Name = "rbtn已出单";
            this.rbtn已出单.Size = new System.Drawing.Size(67, 18);
            this.rbtn已出单.TabIndex = 22;
            this.rbtn已出单.TabStop = true;
            this.rbtn已出单.Text = "已出单";
            this.rbtn已出单.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(157, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(29, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 27);
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
            this.labelX1.Location = new System.Drawing.Point(14, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(112, 27);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "好评状态选择:";
            // 
            // rbtn待退款
            // 
            this.rbtn待退款.AutoSize = true;
            this.rbtn待退款.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtn待退款.Location = new System.Drawing.Point(24, 84);
            this.rbtn待退款.Name = "rbtn待退款";
            this.rbtn待退款.Size = new System.Drawing.Size(67, 18);
            this.rbtn待退款.TabIndex = 24;
            this.rbtn待退款.TabStop = true;
            this.rbtn待退款.Text = "待退款";
            this.rbtn待退款.UseVisualStyleBackColor = true;
            // 
            // rbtn已退款
            // 
            this.rbtn已退款.AutoSize = true;
            this.rbtn已退款.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtn已退款.Location = new System.Drawing.Point(99, 84);
            this.rbtn已退款.Name = "rbtn已退款";
            this.rbtn已退款.Size = new System.Drawing.Size(67, 18);
            this.rbtn已退款.TabIndex = 25;
            this.rbtn已退款.TabStop = true;
            this.rbtn已退款.Text = "已退款";
            this.rbtn已退款.UseVisualStyleBackColor = true;
            // 
            // rbtn未退款
            // 
            this.rbtn未退款.AutoSize = true;
            this.rbtn未退款.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtn未退款.Location = new System.Drawing.Point(177, 84);
            this.rbtn未退款.Name = "rbtn未退款";
            this.rbtn未退款.Size = new System.Drawing.Size(67, 18);
            this.rbtn未退款.TabIndex = 26;
            this.rbtn未退款.TabStop = true;
            this.rbtn未退款.Text = "未退款";
            this.rbtn未退款.UseVisualStyleBackColor = true;
            // 
            // FrmSetOrderState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 151);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmSetOrderState";
            this.Text = "订单状态:";
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
        private System.Windows.Forms.RadioButton rbtnNormal;
        private System.Windows.Forms.RadioButton rbtn已出单;
        private System.Windows.Forms.RadioButton rbtn待退款;
        private System.Windows.Forms.RadioButton rbtn已退款;
        private System.Windows.Forms.RadioButton rbtn未退款;
    }
}