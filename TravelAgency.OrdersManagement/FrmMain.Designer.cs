namespace TravelAgency.OrdersManagement
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel3 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.btnOrderManagementWaitor = new DevComponents.DotNetBar.ButtonItem();
            this.btnOrderManagementOperator = new DevComponents.DotNetBar.ButtonItem();
            this.btnOrderInfoManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnVisaSubmit = new DevComponents.DotNetBar.ButtonItem();
            this.btnScanFrm = new DevComponents.DotNetBar.ButtonItem();
            this.btnGPManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnJiaoJiePicManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnJobAssignment = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel5 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar5 = new DevComponents.DotNetBar.RibbonBar();
            this.btnChangeLoginUser = new DevComponents.DotNetBar.ButtonItem();
            this.btnChangeUI = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel2 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar4 = new DevComponents.DotNetBar.RibbonBar();
            this.btnClientManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnConsulateManage = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar3 = new DevComponents.DotNetBar.RibbonBar();
            this.btnVisaRequestPayoutManage = new DevComponents.DotNetBar.ButtonItem();
            this.btnAppAllManage = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btntActionRecordsCount = new DevComponents.DotNetBar.ButtonItem();
            this.btnPersonalCount = new DevComponents.DotNetBar.ButtonItem();
            this.btnCommisionMoneyManage = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItem3 = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem2 = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem5 = new DevComponents.DotNetBar.RibbonTabItem();
            this.btnVip = new DevComponents.DotNetBar.ButtonItem();
            this.btnUsers = new DevComponents.DotNetBar.ButtonItem();
            this.tabMain = new DevComponents.DotNetBar.TabControl();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnMCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMCloseOther = new System.Windows.Forms.ToolStripMenuItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.btnFrmGaoPaiManage = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel3.SuspendLayout();
            this.ribbonPanel5.SuspendLayout();
            this.ribbonPanel2.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.Controls.Add(this.ribbonPanel3);
            this.ribbonControl1.Controls.Add(this.ribbonPanel5);
            this.ribbonControl1.Controls.Add(this.ribbonPanel2);
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem3,
            this.ribbonTabItem1,
            this.ribbonTabItem2,
            this.ribbonTabItem5});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControl1.Size = new System.Drawing.Size(1284, 89);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 1;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel3.Controls.Add(this.ribbonBar2);
            this.ribbonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel3.Location = new System.Drawing.Point(0, 25);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel3.Size = new System.Drawing.Size(1284, 61);
            // 
            // 
            // 
            this.ribbonPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel3.TabIndex = 3;
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar2.DragDropSupport = true;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOrderManagementWaitor,
            this.btnOrderManagementOperator,
            this.btnOrderInfoManage,
            this.btnVisaSubmit,
            this.btnScanFrm,
            this.btnGPManage,
            this.btnJiaoJiePicManage,
            this.btnJobAssignment});
            this.ribbonBar2.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(670, 58);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar2.TabIndex = 0;
            this.ribbonBar2.Text = "ribbonBar2";
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.TitleVisible = false;
            // 
            // btnOrderManagementWaitor
            // 
            this.btnOrderManagementWaitor.Icon = ((System.Drawing.Icon)(resources.GetObject("btnOrderManagementWaitor.Icon")));
            this.btnOrderManagementWaitor.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnOrderManagementWaitor.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnOrderManagementWaitor.Name = "btnOrderManagementWaitor";
            this.btnOrderManagementWaitor.SubItemsExpandWidth = 14;
            this.btnOrderManagementWaitor.Text = "客服(录入、管理)";
            this.btnOrderManagementWaitor.Click += new System.EventHandler(this.btnVisaTypeIn_Click);
            // 
            // btnOrderManagementOperator
            // 
            this.btnOrderManagementOperator.Icon = ((System.Drawing.Icon)(resources.GetObject("btnOrderManagementOperator.Icon")));
            this.btnOrderManagementOperator.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnOrderManagementOperator.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnOrderManagementOperator.Name = "btnOrderManagementOperator";
            this.btnOrderManagementOperator.SubItemsExpandWidth = 14;
            this.btnOrderManagementOperator.Text = "操作(录入、管理)";
            this.btnOrderManagementOperator.Click += new System.EventHandler(this.btnVisaInfoManage_Click);
            // 
            // btnOrderInfoManage
            // 
            this.btnOrderInfoManage.Icon = ((System.Drawing.Icon)(resources.GetObject("btnOrderInfoManage.Icon")));
            this.btnOrderInfoManage.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnOrderInfoManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnOrderInfoManage.Name = "btnOrderInfoManage";
            this.btnOrderInfoManage.SubItemsExpandWidth = 14;
            this.btnOrderInfoManage.Text = "网络平台订单";
            this.btnOrderInfoManage.Click += new System.EventHandler(this.btnOrderInfoManage_Click);
            // 
            // btnVisaSubmit
            // 
            this.btnVisaSubmit.Icon = ((System.Drawing.Icon)(resources.GetObject("btnVisaSubmit.Icon")));
            this.btnVisaSubmit.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnVisaSubmit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnVisaSubmit.Name = "btnVisaSubmit";
            this.btnVisaSubmit.SubItemsExpandWidth = 14;
            this.btnVisaSubmit.Text = "送签管理";
            this.btnVisaSubmit.Visible = false;
            // 
            // btnScanFrm
            // 
            this.btnScanFrm.Icon = ((System.Drawing.Icon)(resources.GetObject("btnScanFrm.Icon")));
            this.btnScanFrm.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnScanFrm.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnScanFrm.Name = "btnScanFrm";
            this.btnScanFrm.SubItemsExpandWidth = 14;
            this.btnScanFrm.Text = "高拍仪做资料";
            this.btnScanFrm.Visible = false;
            // 
            // btnGPManage
            // 
            this.btnGPManage.Icon = ((System.Drawing.Icon)(resources.GetObject("btnGPManage.Icon")));
            this.btnGPManage.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnGPManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnGPManage.Name = "btnGPManage";
            this.btnGPManage.SubItemsExpandWidth = 14;
            this.btnGPManage.Text = "高拍图像管理";
            this.btnGPManage.Visible = false;
            // 
            // btnJiaoJiePicManage
            // 
            this.btnJiaoJiePicManage.Icon = ((System.Drawing.Icon)(resources.GetObject("btnJiaoJiePicManage.Icon")));
            this.btnJiaoJiePicManage.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnJiaoJiePicManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnJiaoJiePicManage.Name = "btnJiaoJiePicManage";
            this.btnJiaoJiePicManage.SubItemsExpandWidth = 14;
            this.btnJiaoJiePicManage.Text = "交接表管理";
            this.btnJiaoJiePicManage.Visible = false;
            // 
            // btnJobAssignment
            // 
            this.btnJobAssignment.Icon = ((System.Drawing.Icon)(resources.GetObject("btnJobAssignment.Icon")));
            this.btnJobAssignment.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnJobAssignment.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnJobAssignment.Name = "btnJobAssignment";
            this.btnJobAssignment.SubItemsExpandWidth = 14;
            this.btnJobAssignment.Text = "任务分配";
            this.btnJobAssignment.Visible = false;
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel5.Controls.Add(this.ribbonBar5);
            this.ribbonPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel5.Location = new System.Drawing.Point(0, 25);
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel5.Size = new System.Drawing.Size(1284, 61);
            // 
            // 
            // 
            this.ribbonPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel5.TabIndex = 5;
            this.ribbonPanel5.Visible = false;
            // 
            // ribbonBar5
            // 
            this.ribbonBar5.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar5.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar5.ContainerControlProcessDialogKey = true;
            this.ribbonBar5.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar5.DragDropSupport = true;
            this.ribbonBar5.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnChangeLoginUser,
            this.btnChangeUI});
            this.ribbonBar5.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar5.Name = "ribbonBar5";
            this.ribbonBar5.Size = new System.Drawing.Size(389, 58);
            this.ribbonBar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar5.TabIndex = 0;
            // 
            // 
            // 
            this.ribbonBar5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar5.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnChangeLoginUser
            // 
            this.btnChangeLoginUser.Icon = ((System.Drawing.Icon)(resources.GetObject("btnChangeLoginUser.Icon")));
            this.btnChangeLoginUser.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnChangeLoginUser.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnChangeLoginUser.Name = "btnChangeLoginUser";
            this.btnChangeLoginUser.SubItemsExpandWidth = 14;
            this.btnChangeLoginUser.Text = "切换用户";
            this.btnChangeLoginUser.Click += new System.EventHandler(this.btnChangeLoginUser_Click);
            // 
            // btnChangeUI
            // 
            this.btnChangeUI.Icon = ((System.Drawing.Icon)(resources.GetObject("btnChangeUI.Icon")));
            this.btnChangeUI.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnChangeUI.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnChangeUI.Name = "btnChangeUI";
            this.btnChangeUI.SubItemsExpandWidth = 14;
            this.btnChangeUI.Text = "更换主题";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel2.Controls.Add(this.ribbonBar4);
            this.ribbonPanel2.Controls.Add(this.ribbonBar3);
            this.ribbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel2.Location = new System.Drawing.Point(0, 25);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel2.Size = new System.Drawing.Size(1284, 61);
            // 
            // 
            // 
            this.ribbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel2.TabIndex = 7;
            this.ribbonPanel2.Visible = false;
            // 
            // ribbonBar4
            // 
            this.ribbonBar4.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar4.ContainerControlProcessDialogKey = true;
            this.ribbonBar4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar4.DragDropSupport = true;
            this.ribbonBar4.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnClientManage,
            this.btnConsulateManage});
            this.ribbonBar4.Location = new System.Drawing.Point(172, 0);
            this.ribbonBar4.Name = "ribbonBar4";
            this.ribbonBar4.Size = new System.Drawing.Size(182, 58);
            this.ribbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar4.TabIndex = 1;
            // 
            // 
            // 
            this.ribbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnClientManage
            // 
            this.btnClientManage.Icon = ((System.Drawing.Icon)(resources.GetObject("btnClientManage.Icon")));
            this.btnClientManage.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnClientManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClientManage.Name = "btnClientManage";
            this.btnClientManage.SubItemsExpandWidth = 14;
            this.btnClientManage.Text = "客户收费管理";
            // 
            // btnConsulateManage
            // 
            this.btnConsulateManage.Icon = ((System.Drawing.Icon)(resources.GetObject("btnConsulateManage.Icon")));
            this.btnConsulateManage.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnConsulateManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnConsulateManage.Name = "btnConsulateManage";
            this.btnConsulateManage.SubItemsExpandWidth = 14;
            this.btnConsulateManage.Text = "领馆收费管理";
            // 
            // ribbonBar3
            // 
            this.ribbonBar3.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar3.ContainerControlProcessDialogKey = true;
            this.ribbonBar3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar3.DragDropSupport = true;
            this.ribbonBar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnVisaRequestPayoutManage,
            this.btnAppAllManage});
            this.ribbonBar3.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar3.Name = "ribbonBar3";
            this.ribbonBar3.Size = new System.Drawing.Size(169, 58);
            this.ribbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar3.TabIndex = 0;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnVisaRequestPayoutManage
            // 
            this.btnVisaRequestPayoutManage.Icon = ((System.Drawing.Icon)(resources.GetObject("btnVisaRequestPayoutManage.Icon")));
            this.btnVisaRequestPayoutManage.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnVisaRequestPayoutManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnVisaRequestPayoutManage.Name = "btnVisaRequestPayoutManage";
            this.btnVisaRequestPayoutManage.SubItemsExpandWidth = 14;
            this.btnVisaRequestPayoutManage.Text = "签证请款管理";
            // 
            // btnAppAllManage
            // 
            this.btnAppAllManage.Icon = ((System.Drawing.Icon)(resources.GetObject("btnAppAllManage.Icon")));
            this.btnAppAllManage.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnAppAllManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAppAllManage.Name = "btnAppAllManage";
            this.btnAppAllManage.SubItemsExpandWidth = 14;
            this.btnAppAllManage.Text = "待审批请款";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 25);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(1284, 61);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 6;
            this.ribbonPanel1.Visible = false;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btntActionRecordsCount,
            this.btnPersonalCount,
            this.btnCommisionMoneyManage});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(282, 58);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btntActionRecordsCount
            // 
            this.btntActionRecordsCount.Icon = ((System.Drawing.Icon)(resources.GetObject("btntActionRecordsCount.Icon")));
            this.btntActionRecordsCount.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btntActionRecordsCount.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btntActionRecordsCount.Name = "btntActionRecordsCount";
            this.btntActionRecordsCount.SubItemsExpandWidth = 14;
            this.btntActionRecordsCount.Text = "操作记录明细";
            // 
            // btnPersonalCount
            // 
            this.btnPersonalCount.Icon = ((System.Drawing.Icon)(resources.GetObject("btnPersonalCount.Icon")));
            this.btnPersonalCount.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnPersonalCount.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPersonalCount.Name = "btnPersonalCount";
            this.btnPersonalCount.SubItemsExpandWidth = 14;
            this.btnPersonalCount.Text = "个人工作量统计";
            // 
            // btnCommisionMoneyManage
            // 
            this.btnCommisionMoneyManage.Icon = ((System.Drawing.Icon)(resources.GetObject("btnCommisionMoneyManage.Icon")));
            this.btnCommisionMoneyManage.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnCommisionMoneyManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCommisionMoneyManage.Name = "btnCommisionMoneyManage";
            this.btnCommisionMoneyManage.SubItemsExpandWidth = 14;
            this.btnCommisionMoneyManage.Text = "工作提成管理";
            // 
            // ribbonTabItem3
            // 
            this.ribbonTabItem3.Checked = true;
            this.ribbonTabItem3.Name = "ribbonTabItem3";
            this.ribbonTabItem3.Panel = this.ribbonPanel3;
            this.ribbonTabItem3.Text = "签证管理";
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Panel = this.ribbonPanel1;
            this.ribbonTabItem1.Text = "数据统计";
            this.ribbonTabItem1.Visible = false;
            // 
            // ribbonTabItem2
            // 
            this.ribbonTabItem2.Name = "ribbonTabItem2";
            this.ribbonTabItem2.Panel = this.ribbonPanel2;
            this.ribbonTabItem2.Text = "财务管理";
            this.ribbonTabItem2.Visible = false;
            // 
            // ribbonTabItem5
            // 
            this.ribbonTabItem5.Name = "ribbonTabItem5";
            this.ribbonTabItem5.Panel = this.ribbonPanel5;
            this.ribbonTabItem5.Text = "用户管理";
            // 
            // btnVip
            // 
            this.btnVip.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnVip.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnVip.Name = "btnVip";
            this.btnVip.SubItemsExpandWidth = 14;
            this.btnVip.Text = "会员管理";
            // 
            // btnUsers
            // 
            this.btnUsers.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnUsers.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.SubItemsExpandWidth = 14;
            this.btnUsers.Text = "员工管理";
            // 
            // tabMain
            // 
            this.tabMain.CanReorderTabs = true;
            this.tabMain.CloseButtonOnTabsVisible = true;
            this.tabMain.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 89);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabMain.SelectedTabIndex = -1;
            this.tabMain.Size = new System.Drawing.Size(1284, 622);
            this.tabMain.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Dock;
            this.tabMain.TabIndex = 5;
            this.tabMain.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabMain.Text = " ";
            this.tabMain.TabItemClose += new DevComponents.DotNetBar.TabStrip.UserActionEventHandler(this.tabMain_TabItemClose);
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMCloseAll,
            this.btnMCloseOther});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(125, 48);
            // 
            // btnMCloseAll
            // 
            this.btnMCloseAll.Name = "btnMCloseAll";
            this.btnMCloseAll.Size = new System.Drawing.Size(124, 22);
            this.btnMCloseAll.Text = "全部关闭";
            this.btnMCloseAll.Click += new System.EventHandler(this.btnMCloseAll_Click);
            // 
            // btnMCloseOther
            // 
            this.btnMCloseOther.Name = "btnMCloseOther";
            this.btnMCloseOther.Size = new System.Drawing.Size(124, 22);
            this.btnMCloseOther.Text = "关闭其它";
            this.btnMCloseOther.Click += new System.EventHandler(this.btnMCloseOther_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // btnFrmGaoPaiManage
            // 
            this.btnFrmGaoPaiManage.Icon = ((System.Drawing.Icon)(resources.GetObject("btnFrmGaoPaiManage.Icon")));
            this.btnFrmGaoPaiManage.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.Medium;
            this.btnFrmGaoPaiManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnFrmGaoPaiManage.Name = "btnFrmGaoPaiManage";
            this.btnFrmGaoPaiManage.SubItemsExpandWidth = 14;
            this.btnFrmGaoPaiManage.Text = "高排图像管理";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "网络订单管理系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel3.ResumeLayout(false);
            this.ribbonPanel5.ResumeLayout(false);
            this.ribbonPanel2.ResumeLayout(false);
            this.ribbonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel3;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.ButtonItem btnOrderInfoManage;
        private DevComponents.DotNetBar.ButtonItem btnVisaSubmit;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel5;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem3;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem5;
        private DevComponents.DotNetBar.ButtonItem btnVip;
        private DevComponents.DotNetBar.ButtonItem btnUsers;
        private DevComponents.DotNetBar.TabControl tabMain;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem btnMCloseAll;
        private System.Windows.Forms.ToolStripMenuItem btnMCloseOther;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonItem btnOrderManagementOperator;
        private DevComponents.DotNetBar.ButtonItem btnOrderManagementWaitor;
        private DevComponents.DotNetBar.ButtonItem btnScanFrm;
        private DevComponents.DotNetBar.ButtonItem btnGPManage;
        private DevComponents.DotNetBar.ButtonItem btnFrmGaoPaiManage;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btntActionRecordsCount;
        private DevComponents.DotNetBar.ButtonItem btnPersonalCount;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel2;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem2;
        private DevComponents.DotNetBar.RibbonBar ribbonBar3;
        private DevComponents.DotNetBar.ButtonItem btnVisaRequestPayoutManage;
        private DevComponents.DotNetBar.RibbonBar ribbonBar4;
        private DevComponents.DotNetBar.ButtonItem btnClientManage;
        private DevComponents.DotNetBar.ButtonItem btnConsulateManage;
        private DevComponents.DotNetBar.ButtonItem btnCommisionMoneyManage;
        private DevComponents.DotNetBar.ButtonItem btnAppAllManage;
        private DevComponents.DotNetBar.ButtonItem btnJobAssignment;
        private DevComponents.DotNetBar.RibbonBar ribbonBar5;
        private DevComponents.DotNetBar.ButtonItem btnChangeLoginUser;
        private DevComponents.DotNetBar.ButtonItem btnJiaoJiePicManage;
        private DevComponents.DotNetBar.ButtonItem btnChangeUI;
    }
}