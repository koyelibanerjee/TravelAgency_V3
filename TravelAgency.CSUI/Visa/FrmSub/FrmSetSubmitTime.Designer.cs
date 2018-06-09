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
            this.btnShowDetails = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.txtFinishTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btn3Day = new DevComponents.DotNetBar.ButtonX();
            this.btn5Day = new DevComponents.DotNetBar.ButtonX();
            this.btnNextDay = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lbGroupNo = new DevComponents.DotNetBar.LabelX();
            this.lbCountry = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishTime)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.lbCountry);
            this.panelEx1.Controls.Add(this.lbGroupNo);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.btn3Day);
            this.panelEx1.Controls.Add(this.btn5Day);
            this.panelEx1.Controls.Add(this.btnNextDay);
            this.panelEx1.Controls.Add(this.txtFinishTime);
            this.panelEx1.Controls.Add(this.btnShowDetails);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnOk);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(664, 252);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowDetails.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowDetails.Location = new System.Drawing.Point(32, 216);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(75, 23);
            this.btnShowDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowDetails.TabIndex = 1;
            this.btnShowDetails.Text = "查看明细";
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(463, 216);
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
            this.btnOk.Location = new System.Drawing.Point(320, 216);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            this.txtFinishTime.Location = new System.Drawing.Point(386, 62);
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
            this.txtFinishTime.Size = new System.Drawing.Size(229, 21);
            this.txtFinishTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFinishTime.TabIndex = 2;
            // 
            // btn3Day
            // 
            this.btn3Day.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn3Day.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn3Day.Location = new System.Drawing.Point(467, 109);
            this.btn3Day.Name = "btn3Day";
            this.btn3Day.Size = new System.Drawing.Size(71, 23);
            this.btn3Day.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn3Day.TabIndex = 3;
            this.btn3Day.Text = "三天后";
            this.btn3Day.Click += new System.EventHandler(this.btn3Day_Click);
            // 
            // btn5Day
            // 
            this.btn5Day.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn5Day.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn5Day.Location = new System.Drawing.Point(544, 109);
            this.btn5Day.Name = "btn5Day";
            this.btn5Day.Size = new System.Drawing.Size(71, 23);
            this.btn5Day.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn5Day.TabIndex = 4;
            this.btn5Day.Text = "五天后";
            this.btn5Day.Click += new System.EventHandler(this.btn5Day_Click);
            // 
            // btnNextDay
            // 
            this.btnNextDay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNextDay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNextDay.Location = new System.Drawing.Point(390, 109);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(71, 23);
            this.btnNextDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNextDay.TabIndex = 5;
            this.btnNextDay.Text = "明天";
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(30, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(333, 23);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "选中团已经全部进签完成，请设置出签时间:";
            // 
            // lbGroupNo
            // 
            // 
            // 
            // 
            this.lbGroupNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbGroupNo.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbGroupNo.FontBold = true;
            this.lbGroupNo.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbGroupNo.Location = new System.Drawing.Point(32, 40);
            this.lbGroupNo.Name = "lbGroupNo";
            this.lbGroupNo.Size = new System.Drawing.Size(224, 130);
            this.lbGroupNo.TabIndex = 7;
            this.lbGroupNo.Text = "QZC201881212的撒旦";
            this.lbGroupNo.WordWrap = true;
            // 
            // lbCountry
            // 
            // 
            // 
            // 
            this.lbCountry.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbCountry.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCountry.ForeColor = System.Drawing.Color.Tomato;
            this.lbCountry.Location = new System.Drawing.Point(32, 176);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(212, 23);
            this.lbCountry.TabIndex = 8;
            this.lbCountry.Text = "国家:日本";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(290, 62);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "出签时间:";
            // 
            // FrmSetSubmitTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 252);
            this.Controls.Add(this.panelEx1);
            this.Name = "FrmSetSubmitTime";
            this.Text = "设置出签时间";
            this.Load += new System.EventHandler(this.FrmSetSubmitTime_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFinishTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnShowDetails;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtFinishTime;
        private DevComponents.DotNetBar.ButtonX btn3Day;
        private DevComponents.DotNetBar.ButtonX btn5Day;
        private DevComponents.DotNetBar.ButtonX btnNextDay;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lbGroupNo;
        private DevComponents.DotNetBar.LabelX lbCountry;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}