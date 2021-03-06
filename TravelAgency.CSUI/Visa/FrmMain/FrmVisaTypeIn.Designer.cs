﻿using System.Windows.Forms;
using TravelAgency.Common.CustomCtrls;

namespace TravelAgency.CSUI.FrmMain
{
    partial class FrmVisaTypeIn
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new DevComponents.DotNetBar.PanelEx();
            this.panelMid = new DevComponents.DotNetBar.PanelEx();
            this.picPassportNo = new TravelAgency.Common.CustomCtrls.ProPictureBox();
            this.panelbottom = new DevComponents.DotNetBar.PanelEx();
            this.btnUpLoadLocal = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveAll = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveIR = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveHeadPic = new DevComponents.DotNetBar.ButtonX();
            this.btnSavePic = new DevComponents.DotNetBar.ButtonX();
            this.checkShowConfirm = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.chkShowTimeConsume = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnAddFromImage = new DevComponents.DotNetBar.ButtonX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.rbtnJapan = new System.Windows.Forms.RadioButton();
            this.radioNone = new System.Windows.Forms.RadioButton();
            this.rbtnKorea = new System.Windows.Forms.RadioButton();
            this.rbtnThailand = new System.Windows.Forms.RadioButton();
            this.txtExpireDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtLicenseTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtBirthday = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassNo = new System.Windows.Forms.TextBox();
            this.txtIssuePlace = new System.Windows.Forms.TextBox();
            this.txtBirthPlace = new System.Windows.Forms.TextBox();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.txtEnglishName = new System.Windows.Forms.TextBox();
            this.checkRegSucShowDlg = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnAutoReadThreadStart = new DevComponents.DotNetBar.ButtonX();
            this.btnAutoRead = new DevComponents.DotNetBar.ButtonX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.btnAddToDatabase = new DevComponents.DotNetBar.ButtonX();
            this.btnReadData = new DevComponents.DotNetBar.ButtonX();
            this.btnLoadKernel = new DevComponents.DotNetBar.ButtonX();
            this.btnFreeKernel = new DevComponents.DotNetBar.ButtonX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtPicPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtIssuePlaceEnglish = new System.Windows.Forms.TextBox();
            this.txtBirthPlaceEnglish = new System.Windows.Forms.TextBox();
            this.panelRight = new DevComponents.DotNetBar.PanelEx();
            this.panelRightMid = new DevComponents.DotNetBar.PanelEx();
            this.dgvWait4Check = new ThreadSafeDataGridView();
            this.PassportNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasChecked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisaInfo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRightTop = new DevComponents.DotNetBar.PanelEx();
            this.lbRecordCount = new DevComponents.DotNetBar.LabelX();
            this.panelRightBottom = new DevComponents.DotNetBar.PanelEx();
            this.btnNoFault = new DevComponents.DotNetBar.ButtonX();
            this.txtCheckPerson = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnNext = new DevComponents.DotNetBar.ButtonX();
            this.btnPre = new DevComponents.DotNetBar.ButtonX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.btnSaveChanges = new DevComponents.DotNetBar.ButtonX();
            this.cmsDgvRb = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain.SuspendLayout();
            this.panelMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassportNo)).BeginInit();
            this.panelbottom.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpireDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicenseTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthday)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelRightMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWait4Check)).BeginInit();
            this.panelRightTop.SuspendLayout();
            this.panelRightBottom.SuspendLayout();
            this.cmsDgvRb.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelMain.Controls.Add(this.panelMid);
            this.panelMain.Controls.Add(this.panelEx2);
            this.panelMain.Controls.Add(this.panelRight);
            this.panelMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1247, 616);
            this.panelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMain.Style.GradientAngle = 90;
            this.panelMain.TabIndex = 0;
            // 
            // panelMid
            // 
            this.panelMid.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelMid.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelMid.Controls.Add(this.picPassportNo);
            this.panelMid.Controls.Add(this.panelbottom);
            this.panelMid.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMid.Location = new System.Drawing.Point(224, 0);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(697, 616);
            this.panelMid.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMid.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMid.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMid.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMid.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMid.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMid.Style.GradientAngle = 90;
            this.panelMid.TabIndex = 51;
            // 
            // picPassportNo
            // 
            this.picPassportNo.DefaultSaveFileName = null;
            this.picPassportNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPassportNo.FileName = null;
            this.picPassportNo.Image = null;
            this.picPassportNo.Location = new System.Drawing.Point(0, 0);
            this.picPassportNo.Name = "picPassportNo";
            this.picPassportNo.Size = new System.Drawing.Size(697, 577);
            this.picPassportNo.TabIndex = 45;
            this.picPassportNo.TabStop = false;
            // 
            // panelbottom
            // 
            this.panelbottom.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelbottom.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelbottom.Controls.Add(this.btnUpLoadLocal);
            this.panelbottom.Controls.Add(this.btnSaveAll);
            this.panelbottom.Controls.Add(this.btnSaveIR);
            this.panelbottom.Controls.Add(this.btnSaveHeadPic);
            this.panelbottom.Controls.Add(this.btnSavePic);
            this.panelbottom.Controls.Add(this.checkShowConfirm);
            this.panelbottom.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelbottom.Location = new System.Drawing.Point(0, 577);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(697, 39);
            this.panelbottom.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelbottom.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelbottom.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelbottom.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelbottom.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelbottom.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelbottom.Style.GradientAngle = 90;
            this.panelbottom.TabIndex = 41;
            // 
            // btnUpLoadLocal
            // 
            this.btnUpLoadLocal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpLoadLocal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpLoadLocal.Location = new System.Drawing.Point(505, 5);
            this.btnUpLoadLocal.Name = "btnUpLoadLocal";
            this.btnUpLoadLocal.Size = new System.Drawing.Size(104, 23);
            this.btnUpLoadLocal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpLoadLocal.TabIndex = 1;
            this.btnUpLoadLocal.Text = "上传本地图像";
            this.btnUpLoadLocal.Click += new System.EventHandler(this.btnUpLoadLocal_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveAll.Location = new System.Drawing.Point(386, 5);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(104, 23);
            this.btnSaveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSaveAll.TabIndex = 0;
            this.btnSaveAll.Text = "导出全部图像";
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnSaveIR
            // 
            this.btnSaveIR.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveIR.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveIR.Location = new System.Drawing.Point(264, 5);
            this.btnSaveIR.Name = "btnSaveIR";
            this.btnSaveIR.Size = new System.Drawing.Size(104, 23);
            this.btnSaveIR.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSaveIR.TabIndex = 0;
            this.btnSaveIR.Text = "导出红外图像";
            this.btnSaveIR.Click += new System.EventHandler(this.btnSaveIR_Click);
            // 
            // btnSaveHeadPic
            // 
            this.btnSaveHeadPic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveHeadPic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveHeadPic.Location = new System.Drawing.Point(138, 5);
            this.btnSaveHeadPic.Name = "btnSaveHeadPic";
            this.btnSaveHeadPic.Size = new System.Drawing.Size(104, 23);
            this.btnSaveHeadPic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSaveHeadPic.TabIndex = 0;
            this.btnSaveHeadPic.Text = "导出护照头像";
            this.btnSaveHeadPic.Click += new System.EventHandler(this.btnSaveHeadPic_Click);
            // 
            // btnSavePic
            // 
            this.btnSavePic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSavePic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSavePic.Location = new System.Drawing.Point(15, 5);
            this.btnSavePic.Name = "btnSavePic";
            this.btnSavePic.Size = new System.Drawing.Size(104, 23);
            this.btnSavePic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSavePic.TabIndex = 0;
            this.btnSavePic.Text = "导出护照图像";
            this.btnSavePic.Click += new System.EventHandler(this.btnSavePic_Click);
            // 
            // checkShowConfirm
            // 
            // 
            // 
            // 
            this.checkShowConfirm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkShowConfirm.Location = new System.Drawing.Point(615, 10);
            this.checkShowConfirm.Name = "checkShowConfirm";
            this.checkShowConfirm.Size = new System.Drawing.Size(149, 23);
            this.checkShowConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkShowConfirm.TabIndex = 16;
            this.checkShowConfirm.Text = "添加前显示提示对话框";
            this.checkShowConfirm.Visible = false;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.chkShowTimeConsume);
            this.panelEx2.Controls.Add(this.btnAddFromImage);
            this.panelEx2.Controls.Add(this.labelX13);
            this.panelEx2.Controls.Add(this.rbtnJapan);
            this.panelEx2.Controls.Add(this.radioNone);
            this.panelEx2.Controls.Add(this.rbtnKorea);
            this.panelEx2.Controls.Add(this.rbtnThailand);
            this.panelEx2.Controls.Add(this.txtExpireDate);
            this.panelEx2.Controls.Add(this.txtLicenseTime);
            this.panelEx2.Controls.Add(this.txtBirthday);
            this.panelEx2.Controls.Add(this.txtName);
            this.panelEx2.Controls.Add(this.txtPassNo);
            this.panelEx2.Controls.Add(this.txtIssuePlace);
            this.panelEx2.Controls.Add(this.txtBirthPlace);
            this.panelEx2.Controls.Add(this.txtSex);
            this.panelEx2.Controls.Add(this.txtEnglishName);
            this.panelEx2.Controls.Add(this.checkRegSucShowDlg);
            this.panelEx2.Controls.Add(this.btnAutoReadThreadStart);
            this.panelEx2.Controls.Add(this.btnAutoRead);
            this.panelEx2.Controls.Add(this.labelX11);
            this.panelEx2.Controls.Add(this.btnAddToDatabase);
            this.panelEx2.Controls.Add(this.btnReadData);
            this.panelEx2.Controls.Add(this.btnLoadKernel);
            this.panelEx2.Controls.Add(this.btnFreeKernel);
            this.panelEx2.Controls.Add(this.labelX10);
            this.panelEx2.Controls.Add(this.labelX9);
            this.panelEx2.Controls.Add(this.labelX8);
            this.panelEx2.Controls.Add(this.labelX7);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.txtPicPath);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.txtIssuePlaceEnglish);
            this.panelEx2.Controls.Add(this.txtBirthPlaceEnglish);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(224, 616);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 50;
            // 
            // chkShowTimeConsume
            // 
            // 
            // 
            // 
            this.chkShowTimeConsume.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkShowTimeConsume.Location = new System.Drawing.Point(13, 489);
            this.chkShowTimeConsume.Name = "chkShowTimeConsume";
            this.chkShowTimeConsume.Size = new System.Drawing.Size(149, 23);
            this.chkShowTimeConsume.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkShowTimeConsume.TabIndex = 24;
            this.chkShowTimeConsume.Text = "显示识别耗时";
            // 
            // btnAddFromImage
            // 
            this.btnAddFromImage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddFromImage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddFromImage.Location = new System.Drawing.Point(118, 460);
            this.btnAddFromImage.Name = "btnAddFromImage";
            this.btnAddFromImage.Size = new System.Drawing.Size(100, 23);
            this.btnAddFromImage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddFromImage.TabIndex = 23;
            this.btnAddFromImage.Text = "从图像添加";
            this.btnAddFromImage.Visible = false;
            this.btnAddFromImage.Click += new System.EventHandler(this.btnAddFromImage_Click);
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Font = new System.Drawing.Font("华文新魏", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX13.Location = new System.Drawing.Point(12, 545);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(54, 51);
            this.labelX13.TabIndex = 22;
            this.labelX13.Text = "国家/\r\n地区:";
            // 
            // rbtnJapan
            // 
            this.rbtnJapan.AutoSize = true;
            this.rbtnJapan.BackColor = System.Drawing.Color.Transparent;
            this.rbtnJapan.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnJapan.Location = new System.Drawing.Point(72, 548);
            this.rbtnJapan.Name = "rbtnJapan";
            this.rbtnJapan.Size = new System.Drawing.Size(47, 16);
            this.rbtnJapan.TabIndex = 21;
            this.rbtnJapan.TabStop = true;
            this.rbtnJapan.Text = "日本";
            this.rbtnJapan.UseVisualStyleBackColor = false;
            this.rbtnJapan.CheckedChanged += new System.EventHandler(this.rbtnJapan_CheckedChanged);
            // 
            // radioNone
            // 
            this.radioNone.AutoSize = true;
            this.radioNone.ForeColor = System.Drawing.Color.OrangeRed;
            this.radioNone.Location = new System.Drawing.Point(129, 572);
            this.radioNone.Name = "radioNone";
            this.radioNone.Size = new System.Drawing.Size(59, 16);
            this.radioNone.TabIndex = 20;
            this.radioNone.TabStop = true;
            this.radioNone.Text = "未设置";
            this.radioNone.UseVisualStyleBackColor = true;
            this.radioNone.CheckedChanged += new System.EventHandler(this.radioNone_CheckedChanged);
            // 
            // rbtnKorea
            // 
            this.rbtnKorea.AutoSize = true;
            this.rbtnKorea.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnKorea.Location = new System.Drawing.Point(72, 572);
            this.rbtnKorea.Name = "rbtnKorea";
            this.rbtnKorea.Size = new System.Drawing.Size(47, 16);
            this.rbtnKorea.TabIndex = 20;
            this.rbtnKorea.TabStop = true;
            this.rbtnKorea.Text = "韩国";
            this.rbtnKorea.UseVisualStyleBackColor = true;
            this.rbtnKorea.CheckedChanged += new System.EventHandler(this.rbtnKorea_CheckedChanged);
            // 
            // rbtnThailand
            // 
            this.rbtnThailand.AutoSize = true;
            this.rbtnThailand.ForeColor = System.Drawing.Color.OrangeRed;
            this.rbtnThailand.Location = new System.Drawing.Point(129, 548);
            this.rbtnThailand.Name = "rbtnThailand";
            this.rbtnThailand.Size = new System.Drawing.Size(47, 16);
            this.rbtnThailand.TabIndex = 20;
            this.rbtnThailand.TabStop = true;
            this.rbtnThailand.Text = "泰国";
            this.rbtnThailand.UseVisualStyleBackColor = true;
            this.rbtnThailand.CheckedChanged += new System.EventHandler(this.rbtnThailand_CheckedChanged);
            // 
            // txtExpireDate
            // 
            // 
            // 
            // 
            this.txtExpireDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtExpireDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtExpireDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtExpireDate.ButtonDropDown.Visible = true;
            this.txtExpireDate.IsPopupCalendarOpen = false;
            this.txtExpireDate.Location = new System.Drawing.Point(76, 244);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtExpireDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtExpireDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtExpireDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtExpireDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtExpireDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtExpireDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtExpireDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtExpireDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtExpireDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtExpireDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtExpireDate.MonthCalendar.DisplayMonth = new System.DateTime(2017, 10, 1, 0, 0, 0, 0);
            this.txtExpireDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtExpireDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtExpireDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtExpireDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtExpireDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtExpireDate.MonthCalendar.TodayButtonVisible = true;
            this.txtExpireDate.Name = "txtExpireDate";
            this.txtExpireDate.Size = new System.Drawing.Size(100, 21);
            this.txtExpireDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtExpireDate.TabIndex = 7;
            // 
            // txtLicenseTime
            // 
            // 
            // 
            // 
            this.txtLicenseTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLicenseTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLicenseTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtLicenseTime.ButtonDropDown.Visible = true;
            this.txtLicenseTime.IsPopupCalendarOpen = false;
            this.txtLicenseTime.Location = new System.Drawing.Point(76, 212);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtLicenseTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLicenseTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtLicenseTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtLicenseTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtLicenseTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtLicenseTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtLicenseTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtLicenseTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtLicenseTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtLicenseTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLicenseTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 10, 1, 0, 0, 0, 0);
            this.txtLicenseTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtLicenseTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtLicenseTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtLicenseTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtLicenseTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLicenseTime.MonthCalendar.TodayButtonVisible = true;
            this.txtLicenseTime.Name = "txtLicenseTime";
            this.txtLicenseTime.Size = new System.Drawing.Size(100, 21);
            this.txtLicenseTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtLicenseTime.TabIndex = 6;
            // 
            // txtBirthday
            // 
            // 
            // 
            // 
            this.txtBirthday.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBirthday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBirthday.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtBirthday.ButtonDropDown.Visible = true;
            this.txtBirthday.IsPopupCalendarOpen = false;
            this.txtBirthday.Location = new System.Drawing.Point(76, 152);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtBirthday.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBirthday.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtBirthday.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtBirthday.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtBirthday.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtBirthday.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtBirthday.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtBirthday.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtBirthday.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtBirthday.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBirthday.MonthCalendar.DisplayMonth = new System.DateTime(2017, 10, 1, 0, 0, 0, 0);
            this.txtBirthday.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtBirthday.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtBirthday.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtBirthday.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtBirthday.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBirthday.MonthCalendar.TodayButtonVisible = true;
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(100, 21);
            this.txtBirthday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtBirthday.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(76, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 1;
            // 
            // txtPassNo
            // 
            this.txtPassNo.Location = new System.Drawing.Point(76, 181);
            this.txtPassNo.Name = "txtPassNo";
            this.txtPassNo.Size = new System.Drawing.Size(100, 21);
            this.txtPassNo.TabIndex = 5;
            // 
            // txtIssuePlace
            // 
            this.txtIssuePlace.Location = new System.Drawing.Point(76, 301);
            this.txtIssuePlace.Name = "txtIssuePlace";
            this.txtIssuePlace.Size = new System.Drawing.Size(54, 21);
            this.txtIssuePlace.TabIndex = 10;
            // 
            // txtBirthPlace
            // 
            this.txtBirthPlace.Location = new System.Drawing.Point(76, 274);
            this.txtBirthPlace.Name = "txtBirthPlace";
            this.txtBirthPlace.Size = new System.Drawing.Size(54, 21);
            this.txtBirthPlace.TabIndex = 8;
            // 
            // txtSex
            // 
            this.txtSex.Location = new System.Drawing.Point(76, 125);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(100, 21);
            this.txtSex.TabIndex = 3;
            // 
            // txtEnglishName
            // 
            this.txtEnglishName.Location = new System.Drawing.Point(76, 90);
            this.txtEnglishName.Name = "txtEnglishName";
            this.txtEnglishName.Size = new System.Drawing.Size(100, 21);
            this.txtEnglishName.TabIndex = 2;
            // 
            // checkRegSucShowDlg
            // 
            // 
            // 
            // 
            this.checkRegSucShowDlg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkRegSucShowDlg.Location = new System.Drawing.Point(12, 516);
            this.checkRegSucShowDlg.Name = "checkRegSucShowDlg";
            this.checkRegSucShowDlg.Size = new System.Drawing.Size(149, 23);
            this.checkRegSucShowDlg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkRegSucShowDlg.TabIndex = 17;
            this.checkRegSucShowDlg.Text = "识别成功显示提示";
            // 
            // btnAutoReadThreadStart
            // 
            this.btnAutoReadThreadStart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAutoReadThreadStart.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAutoReadThreadStart.Location = new System.Drawing.Point(118, 430);
            this.btnAutoReadThreadStart.Name = "btnAutoReadThreadStart";
            this.btnAutoReadThreadStart.Size = new System.Drawing.Size(100, 23);
            this.btnAutoReadThreadStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAutoReadThreadStart.TabIndex = 14;
            this.btnAutoReadThreadStart.Text = "开始自动读取";
            this.btnAutoReadThreadStart.Click += new System.EventHandler(this.btnAutoReadThreadStart_Click);
            // 
            // btnAutoRead
            // 
            this.btnAutoRead.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAutoRead.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAutoRead.Location = new System.Drawing.Point(136, 605);
            this.btnAutoRead.Name = "btnAutoRead";
            this.btnAutoRead.Size = new System.Drawing.Size(97, 24);
            this.btnAutoRead.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAutoRead.TabIndex = 16;
            this.btnAutoRead.Text = "时钟版自动读取";
            this.btnAutoRead.Visible = false;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("华文新魏", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX11.Location = new System.Drawing.Point(12, 16);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(150, 23);
            this.labelX11.TabIndex = 19;
            this.labelX11.Text = "护照信息录入:";
            // 
            // btnAddToDatabase
            // 
            this.btnAddToDatabase.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddToDatabase.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddToDatabase.Location = new System.Drawing.Point(12, 459);
            this.btnAddToDatabase.Name = "btnAddToDatabase";
            this.btnAddToDatabase.Size = new System.Drawing.Size(100, 23);
            this.btnAddToDatabase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddToDatabase.TabIndex = 15;
            this.btnAddToDatabase.Text = "手动添加";
            this.btnAddToDatabase.Click += new System.EventHandler(this.btnAddToDatabase_Click);
            // 
            // btnReadData
            // 
            this.btnReadData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReadData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReadData.Location = new System.Drawing.Point(12, 430);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(100, 23);
            this.btnReadData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReadData.TabIndex = 13;
            this.btnReadData.Text = "读取签证信息";
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // btnLoadKernel
            // 
            this.btnLoadKernel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLoadKernel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLoadKernel.Location = new System.Drawing.Point(12, 399);
            this.btnLoadKernel.Name = "btnLoadKernel";
            this.btnLoadKernel.Size = new System.Drawing.Size(100, 23);
            this.btnLoadKernel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLoadKernel.TabIndex = 11;
            this.btnLoadKernel.Text = "加载识别内核";
            this.btnLoadKernel.Click += new System.EventHandler(this.btnLoadKernel_Click);
            // 
            // btnFreeKernel
            // 
            this.btnFreeKernel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFreeKernel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFreeKernel.Location = new System.Drawing.Point(118, 399);
            this.btnFreeKernel.Name = "btnFreeKernel";
            this.btnFreeKernel.Size = new System.Drawing.Size(100, 23);
            this.btnFreeKernel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFreeKernel.TabIndex = 12;
            this.btnFreeKernel.Text = "释放识别内核";
            this.btnFreeKernel.Click += new System.EventHandler(this.btnFreeKernel_Click);
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(12, 303);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(75, 23);
            this.labelX10.TabIndex = 13;
            this.labelX10.Text = "签发地:";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(12, 274);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(75, 23);
            this.labelX9.TabIndex = 13;
            this.labelX9.Text = "出生地:";
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(12, 244);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 13;
            this.labelX8.Text = "有效期:";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(12, 212);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 13;
            this.labelX7.Text = "发证日期:";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(12, 181);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 13;
            this.labelX6.Text = "护照号码:";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(12, 154);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 13;
            this.labelX5.Text = "出生日期:";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(12, 122);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 13;
            this.labelX4.Text = "性别:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 88);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 13;
            this.labelX3.Text = "英文姓名:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 52);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "本国姓名:";
            // 
            // txtPicPath
            // 
            // 
            // 
            // 
            this.txtPicPath.Border.Class = "TextBoxBorder";
            this.txtPicPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPicPath.DisabledBackColor = System.Drawing.Color.White;
            this.txtPicPath.Location = new System.Drawing.Point(12, 361);
            this.txtPicPath.Multiline = true;
            this.txtPicPath.Name = "txtPicPath";
            this.txtPicPath.PreventEnterBeep = true;
            this.txtPicPath.Size = new System.Drawing.Size(206, 32);
            this.txtPicPath.TabIndex = 10;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 332);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(88, 23);
            this.labelX1.TabIndex = 11;
            this.labelX1.Text = "图像保存路径:";
            // 
            // txtIssuePlaceEnglish
            // 
            this.txtIssuePlaceEnglish.Location = new System.Drawing.Point(136, 301);
            this.txtIssuePlaceEnglish.Name = "txtIssuePlaceEnglish";
            this.txtIssuePlaceEnglish.Size = new System.Drawing.Size(82, 21);
            this.txtIssuePlaceEnglish.TabIndex = 11;
            // 
            // txtBirthPlaceEnglish
            // 
            this.txtBirthPlaceEnglish.Location = new System.Drawing.Point(136, 274);
            this.txtBirthPlaceEnglish.Name = "txtBirthPlaceEnglish";
            this.txtBirthPlaceEnglish.Size = new System.Drawing.Size(82, 21);
            this.txtBirthPlaceEnglish.TabIndex = 9;
            // 
            // panelRight
            // 
            this.panelRight.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelRight.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelRight.Controls.Add(this.panelRightMid);
            this.panelRight.Controls.Add(this.panelRightTop);
            this.panelRight.Controls.Add(this.panelRightBottom);
            this.panelRight.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(921, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(326, 616);
            this.panelRight.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelRight.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelRight.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelRight.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelRight.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelRight.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelRight.Style.GradientAngle = 90;
            this.panelRight.TabIndex = 33;
            // 
            // panelRightMid
            // 
            this.panelRightMid.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelRightMid.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelRightMid.Controls.Add(this.dgvWait4Check);
            this.panelRightMid.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelRightMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightMid.Location = new System.Drawing.Point(0, 39);
            this.panelRightMid.Name = "panelRightMid";
            this.panelRightMid.Size = new System.Drawing.Size(326, 509);
            this.panelRightMid.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelRightMid.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelRightMid.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelRightMid.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelRightMid.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelRightMid.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelRightMid.Style.GradientAngle = 90;
            this.panelRightMid.TabIndex = 36;
            // 
            // dgvWait4Check
            // 
            this.dgvWait4Check.AllowUserToAddRows = false;
            this.dgvWait4Check.AllowUserToDeleteRows = false;
            this.dgvWait4Check.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWait4Check.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWait4Check.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWait4Check.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PassportNo,
            this._Name,
            this.Country,
            this.HasChecked,
            this.VisaInfo_id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWait4Check.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWait4Check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWait4Check.EnableHeadersVisualStyles = false;
            this.dgvWait4Check.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvWait4Check.Location = new System.Drawing.Point(0, 0);
            this.dgvWait4Check.Name = "dgvWait4Check";
            this.dgvWait4Check.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWait4Check.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWait4Check.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvWait4Check.RowTemplate.Height = 30;
            this.dgvWait4Check.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWait4Check.Size = new System.Drawing.Size(326, 509);
            this.dgvWait4Check.TabIndex = 27;
            this.dgvWait4Check.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dgvWait4Check.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvWait4Check_CellMouseUp);
            this.dgvWait4Check.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // PassportNo
            // 
            this.PassportNo.DataPropertyName = "PassportNo";
            this.PassportNo.HeaderText = "护照号";
            this.PassportNo.Name = "PassportNo";
            this.PassportNo.ReadOnly = true;
            // 
            // _Name
            // 
            this._Name.DataPropertyName = "Name";
            this._Name.HeaderText = "姓名";
            this._Name.Name = "_Name";
            this._Name.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "国家";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // HasChecked
            // 
            this.HasChecked.DataPropertyName = "HasChecked";
            this.HasChecked.HeaderText = "已校验";
            this.HasChecked.Name = "HasChecked";
            this.HasChecked.ReadOnly = true;
            // 
            // VisaInfo_id
            // 
            this.VisaInfo_id.DataPropertyName = "VisaInfo_id";
            this.VisaInfo_id.HeaderText = "VisaInfo_id";
            this.VisaInfo_id.Name = "VisaInfo_id";
            this.VisaInfo_id.ReadOnly = true;
            this.VisaInfo_id.Visible = false;
            // 
            // panelRightTop
            // 
            this.panelRightTop.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelRightTop.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelRightTop.Controls.Add(this.lbRecordCount);
            this.panelRightTop.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRightTop.Location = new System.Drawing.Point(0, 0);
            this.panelRightTop.Name = "panelRightTop";
            this.panelRightTop.Size = new System.Drawing.Size(326, 39);
            this.panelRightTop.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelRightTop.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelRightTop.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelRightTop.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelRightTop.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelRightTop.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelRightTop.Style.GradientAngle = 90;
            this.panelRightTop.TabIndex = 32;
            // 
            // lbRecordCount
            // 
            // 
            // 
            // 
            this.lbRecordCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbRecordCount.Font = new System.Drawing.Font("华文新魏", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRecordCount.Location = new System.Drawing.Point(6, 8);
            this.lbRecordCount.Name = "lbRecordCount";
            this.lbRecordCount.Size = new System.Drawing.Size(279, 23);
            this.lbRecordCount.TabIndex = 20;
            this.lbRecordCount.Text = "待校验信息:";
            // 
            // panelRightBottom
            // 
            this.panelRightBottom.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelRightBottom.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelRightBottom.Controls.Add(this.btnNoFault);
            this.panelRightBottom.Controls.Add(this.txtCheckPerson);
            this.panelRightBottom.Controls.Add(this.btnNext);
            this.panelRightBottom.Controls.Add(this.btnPre);
            this.panelRightBottom.Controls.Add(this.labelX12);
            this.panelRightBottom.Controls.Add(this.btnSaveChanges);
            this.panelRightBottom.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRightBottom.Location = new System.Drawing.Point(0, 548);
            this.panelRightBottom.Name = "panelRightBottom";
            this.panelRightBottom.Size = new System.Drawing.Size(326, 68);
            this.panelRightBottom.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelRightBottom.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelRightBottom.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelRightBottom.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelRightBottom.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelRightBottom.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelRightBottom.Style.GradientAngle = 90;
            this.panelRightBottom.TabIndex = 28;
            // 
            // btnNoFault
            // 
            this.btnNoFault.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNoFault.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNoFault.Location = new System.Drawing.Point(15, 3);
            this.btnNoFault.Name = "btnNoFault";
            this.btnNoFault.Size = new System.Drawing.Size(88, 23);
            this.btnNoFault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNoFault.TabIndex = 18;
            this.btnNoFault.Text = "确认无误";
            this.btnNoFault.Click += new System.EventHandler(this.btnNoFault_Click);
            // 
            // txtCheckPerson
            // 
            // 
            // 
            // 
            this.txtCheckPerson.Border.Class = "TextBoxBorder";
            this.txtCheckPerson.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCheckPerson.Location = new System.Drawing.Point(112, 34);
            this.txtCheckPerson.Name = "txtCheckPerson";
            this.txtCheckPerson.PreventEnterBeep = true;
            this.txtCheckPerson.Size = new System.Drawing.Size(89, 21);
            this.txtCheckPerson.TabIndex = 21;
            // 
            // btnNext
            // 
            this.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNext.Location = new System.Drawing.Point(213, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(81, 23);
            this.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNext.TabIndex = 20;
            this.btnNext.Text = "下一条";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPre.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPre.Location = new System.Drawing.Point(112, 3);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(89, 23);
            this.btnPre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPre.TabIndex = 19;
            this.btnPre.Text = "上一条";
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(39, 34);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(56, 23);
            this.labelX12.TabIndex = 22;
            this.labelX12.Text = "操作员:";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveChanges.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveChanges.Location = new System.Drawing.Point(213, 32);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(81, 23);
            this.btnSaveChanges.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSaveChanges.TabIndex = 22;
            this.btnSaveChanges.Text = "提交已校验";
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // cmsDgvRb
            // 
            this.cmsDgvRb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItemDelete});
            this.cmsDgvRb.Name = "cmsDgvRb";
            this.cmsDgvRb.Size = new System.Drawing.Size(101, 26);
            // 
            // cmsItemDelete
            // 
            this.cmsItemDelete.Name = "cmsItemDelete";
            this.cmsItemDelete.Size = new System.Drawing.Size(100, 22);
            this.cmsItemDelete.Text = "删除";
            this.cmsItemDelete.Click += new System.EventHandler(this.cmsItemDelete_Click);
            // 
            // FrmVisaTypeIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 616);
            this.Controls.Add(this.panelMain);
            this.Name = "FrmVisaTypeIn";
            this.Text = "签证录入";
            this.Load += new System.EventHandler(this.FrmCheckAutoInputInfo_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPassportNo)).EndInit();
            this.panelbottom.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpireDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicenseTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthday)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRightMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWait4Check)).EndInit();
            this.panelRightTop.ResumeLayout(false);
            this.panelRightBottom.ResumeLayout(false);
            this.cmsDgvRb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelMain;
        private DevComponents.DotNetBar.ButtonX btnNoFault;
        private DevComponents.DotNetBar.ButtonX btnSaveChanges;
        private DevComponents.DotNetBar.ButtonX btnPre;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCheckPerson;
        private DevComponents.DotNetBar.ButtonX btnNext;
        private ThreadSafeDataGridView dgvWait4Check;
        private DevComponents.DotNetBar.PanelEx panelRight;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkRegSucShowDlg;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkShowConfirm;
        private DevComponents.DotNetBar.ButtonX btnAutoReadThreadStart;
        private DevComponents.DotNetBar.ButtonX btnAutoRead;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtExpireDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtLicenseTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtBirthday;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.ButtonX btnAddToDatabase;
        private DevComponents.DotNetBar.ButtonX btnReadData;
        private DevComponents.DotNetBar.ButtonX btnLoadKernel;
        private DevComponents.DotNetBar.ButtonX btnFreeKernel;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPicPath;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassNo;
        private System.Windows.Forms.TextBox txtIssuePlace;
        private System.Windows.Forms.TextBox txtBirthPlace;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.TextBox txtEnglishName;
        private DevComponents.DotNetBar.PanelEx panelRightTop;
        private DevComponents.DotNetBar.PanelEx panelRightBottom;
        private DevComponents.DotNetBar.PanelEx panelRightMid;
        private DevComponents.DotNetBar.LabelX lbRecordCount;
        private DevComponents.DotNetBar.PanelEx panelMid;
        private DevComponents.DotNetBar.PanelEx panelbottom;
        private DevComponents.DotNetBar.ButtonX btnSavePic;
        private DevComponents.DotNetBar.ButtonX btnSaveHeadPic;
        private DevComponents.DotNetBar.ButtonX btnSaveIR;
        private DevComponents.DotNetBar.ButtonX btnSaveAll;
        private ProPictureBox picPassportNo;
        private System.Windows.Forms.ContextMenuStrip cmsDgvRb;
        private System.Windows.Forms.ToolStripMenuItem cmsItemDelete;
        private System.Windows.Forms.TextBox txtIssuePlaceEnglish;
        private System.Windows.Forms.TextBox txtBirthPlaceEnglish;
        private DevComponents.DotNetBar.LabelX labelX13;
        private System.Windows.Forms.RadioButton rbtnJapan;
        private System.Windows.Forms.RadioButton rbtnThailand;
        private System.Windows.Forms.RadioButton rbtnKorea;
        private System.Windows.Forms.RadioButton radioNone;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassportNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn HasChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisaInfo_id;
        private DevComponents.DotNetBar.ButtonX btnUpLoadLocal;
        private DevComponents.DotNetBar.ButtonX btnAddFromImage;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkShowTimeConsume;
    }
}