namespace TravelAgency.CSUI.Visa.FrmSub
{
    partial class FrmSetSubmitTime
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
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtFinishTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtRealTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.rbtnJapan = new System.Windows.Forms.RadioButton();
            this.rbtnKorea = new System.Windows.Forms.RadioButton();
            this.rbtnThailand = new System.Windows.Forms.RadioButton();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRealTime)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.rbtnThailand);
            this.panelEx1.Controls.Add(this.rbtnKorea);
            this.panelEx1.Controls.Add(this.rbtnJapan);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.txtRealTime);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.txtFinishTime);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnOk);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(278, 149);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(33, 35);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "出签时间:";
            // 
            // txtFinishTime
            // 
            // 
            // 
            // 
            this.txtFinishTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFinishTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFinishTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtFinishTime.ButtonDropDown.Visible = true;
            this.txtFinishTime.CustomFormat = "yyyy/MM/dd";
            this.txtFinishTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtFinishTime.IsPopupCalendarOpen = false;
            this.txtFinishTime.Location = new System.Drawing.Point(129, 35);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtFinishTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFinishTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtFinishTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtFinishTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtFinishTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFinishTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtFinishTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtFinishTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtFinishTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtFinishTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFinishTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.txtFinishTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtFinishTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtFinishTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtFinishTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtFinishTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFinishTime.MonthCalendar.TodayButtonVisible = true;
            this.txtFinishTime.Name = "txtFinishTime";
            this.txtFinishTime.Size = new System.Drawing.Size(138, 21);
            this.txtFinishTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFinishTime.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(181, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(38, 115);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(33, 8);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 11;
            this.labelX1.Text = "进签时间:";
            // 
            // txtRealTime
            // 
            // 
            // 
            // 
            this.txtRealTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRealTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRealTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtRealTime.ButtonDropDown.Visible = true;
            this.txtRealTime.CustomFormat = "yyyy/MM/dd";
            this.txtRealTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtRealTime.IsPopupCalendarOpen = false;
            this.txtRealTime.Location = new System.Drawing.Point(129, 8);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtRealTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRealTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtRealTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtRealTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtRealTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtRealTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtRealTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtRealTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtRealTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtRealTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRealTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.txtRealTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtRealTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtRealTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtRealTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtRealTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRealTime.MonthCalendar.TodayButtonVisible = true;
            this.txtRealTime.Name = "txtRealTime";
            this.txtRealTime.Size = new System.Drawing.Size(138, 21);
            this.txtRealTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtRealTime.TabIndex = 10;
            // 
            // rbtnJapan
            // 
            this.rbtnJapan.AutoSize = true;
            this.rbtnJapan.Location = new System.Drawing.Point(33, 77);
            this.rbtnJapan.Name = "rbtnJapan";
            this.rbtnJapan.Size = new System.Drawing.Size(47, 16);
            this.rbtnJapan.TabIndex = 12;
            this.rbtnJapan.TabStop = true;
            this.rbtnJapan.Text = "日本";
            this.rbtnJapan.UseVisualStyleBackColor = true;
            this.rbtnJapan.CheckedChanged += new System.EventHandler(this.rbtnJapan_CheckedChanged);
            // 
            // rbtnKorea
            // 
            this.rbtnKorea.AutoSize = true;
            this.rbtnKorea.Location = new System.Drawing.Point(105, 77);
            this.rbtnKorea.Name = "rbtnKorea";
            this.rbtnKorea.Size = new System.Drawing.Size(47, 16);
            this.rbtnKorea.TabIndex = 12;
            this.rbtnKorea.TabStop = true;
            this.rbtnKorea.Text = "韩国";
            this.rbtnKorea.UseVisualStyleBackColor = true;
            this.rbtnKorea.CheckedChanged += new System.EventHandler(this.rbtnKorea_CheckedChanged);
            // 
            // rbtnThailand
            // 
            this.rbtnThailand.AutoSize = true;
            this.rbtnThailand.Location = new System.Drawing.Point(181, 77);
            this.rbtnThailand.Name = "rbtnThailand";
            this.rbtnThailand.Size = new System.Drawing.Size(47, 16);
            this.rbtnThailand.TabIndex = 12;
            this.rbtnThailand.TabStop = true;
            this.rbtnThailand.Text = "泰国";
            this.rbtnThailand.UseVisualStyleBackColor = true;
            this.rbtnThailand.CheckedChanged += new System.EventHandler(this.rbtnThailand_CheckedChanged);
            // 
            // FrmSetSubmitTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 149);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmSetSubmitTime";
            this.Text = "设置出签时间";
            this.Load += new System.EventHandler(this.FrmSetSubmitTime_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRealTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFinishTime;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtRealTime;
        private System.Windows.Forms.RadioButton rbtnJapan;
        private System.Windows.Forms.RadioButton rbtnThailand;
        private System.Windows.Forms.RadioButton rbtnKorea;
    }
}