namespace TravelAgency.CSUI.FrmMain
{
    partial class FrmVisaManage
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnPageFirst = new DevComponents.DotNetBar.ButtonItem();
            this.btnPagePre = new DevComponents.DotNetBar.ButtonItem();
            this.btnPageNext = new DevComponents.DotNetBar.ButtonItem();
            this.btnPageLast = new DevComponents.DotNetBar.ButtonItem();
            this.cbCurPage = new DevComponents.DotNetBar.ComboBoxItem();
            this.btnGoto = new DevComponents.DotNetBar.ButtonItem();
            this.lbRecordCount = new DevComponents.DotNetBar.LabelItem();
            this.lbl = new DevComponents.DotNetBar.LabelItem();
            this.cbPageSize = new DevComponents.DotNetBar.ComboBoxItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.lbCurPage = new DevComponents.DotNetBar.LabelItem();
            this.lbPeopleCount = new DevComponents.DotNetBar.LabelItem();
            this.dataGridView1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.GroupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.PredictTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeInPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Types = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUrgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visa_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemRefreshDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsItemShowGroupNo = new System.Windows.Forms.ToolStripMenuItem();
            this.修改做资料状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改选中类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.导出报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日本团队综合名单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个签意见书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.金桥大名单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日本送签时间表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外领担保函ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息同意处理书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.机票报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.阪阪川航ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.东阪川航ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.东东川航ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.东东国航ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.东东全日空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新北东航ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.韩国ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.韩国担保函ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.韩国加急申请书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.泰国ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据源报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.泰签担保函ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.机票报表ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.东航机票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.川航机票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.泰航机票ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.两人保险报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBars = new DevComponents.DotNetBar.PanelEx();
            this.panelSerachBar = new DevComponents.DotNetBar.PanelEx();
            this.btnAddVisa = new DevComponents.DotNetBar.ButtonX();
            this.txtSalesPerson = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtClient = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbDepatureType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cbState = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cbCountry = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbIsUrgent = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnGetTodayExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnShowToday = new DevComponents.DotNetBar.ButtonX();
            this.cbDisplayType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.progressLoading = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.btnClearSchConditions = new DevComponents.DotNetBar.ButtonX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.txtSchGroupNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lb1 = new DevComponents.DotNetBar.LabelX();
            this.txtSchEntryTimeTo = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtSchEntryTimeFrom = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.btnShowAll = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.bgWorkerLoadData = new System.ComponentModel.BackgroundWorker();
            this.labelItem8 = new DevComponents.DotNetBar.LabelItem();
            this.panelDgv = new DevComponents.DotNetBar.PanelEx();
            this.cmsAddToGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加到团号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmsDgv.SuspendLayout();
            this.panelBars.SuspendLayout();
            this.panelSerachBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeFrom)).BeginInit();
            this.panelDgv.SuspendLayout();
            this.cmsAddToGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.bar1.DockTabStripHeight = 30;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPageFirst,
            this.btnPagePre,
            this.btnPageNext,
            this.btnPageLast,
            this.cbCurPage,
            this.btnGoto,
            this.lbRecordCount,
            this.lbl,
            this.cbPageSize,
            this.labelItem2,
            this.lbCurPage,
            this.lbPeopleCount});
            this.bar1.ItemSpacing = 5;
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1288, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 25;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnPageFirst
            // 
            this.btnPageFirst.Name = "btnPageFirst";
            this.btnPageFirst.Text = "首页";
            this.btnPageFirst.Click += new System.EventHandler(this.btnPageFirst_Click);
            // 
            // btnPagePre
            // 
            this.btnPagePre.Name = "btnPagePre";
            this.btnPagePre.Text = "上一页";
            this.btnPagePre.Click += new System.EventHandler(this.btnPagePre_Click);
            // 
            // btnPageNext
            // 
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.Text = "下一页";
            this.btnPageNext.Click += new System.EventHandler(this.btnPageNext_Click);
            // 
            // btnPageLast
            // 
            this.btnPageLast.Name = "btnPageLast";
            this.btnPageLast.Text = "尾页";
            this.btnPageLast.Click += new System.EventHandler(this.btnPageLast_Click);
            // 
            // cbCurPage
            // 
            this.cbCurPage.DropDownHeight = 106;
            this.cbCurPage.ItemHeight = 17;
            this.cbCurPage.Name = "cbCurPage";
            // 
            // btnGoto
            // 
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Text = "Go";
            // 
            // lbRecordCount
            // 
            this.lbRecordCount.Name = "lbRecordCount";
            this.lbRecordCount.Text = "共有记录";
            // 
            // lbl
            // 
            this.lbl.Name = "lbl";
            this.lbl.Text = "每页显示";
            // 
            // cbPageSize
            // 
            this.cbPageSize.DropDownHeight = 106;
            this.cbPageSize.ItemHeight = 17;
            this.cbPageSize.Name = "cbPageSize";
            this.cbPageSize.TextChanged += new System.EventHandler(this.cbPageSize_TextChanged);
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "条";
            // 
            // lbCurPage
            // 
            this.lbCurPage.Name = "lbCurPage";
            // 
            // lbPeopleCount
            // 
            this.lbPeopleCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPeopleCount.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbPeopleCount.Name = "lbPeopleCount";
            this.lbPeopleCount.Text = "共:80人";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupNo,
            this.Country,
            this.Number,
            this.CountryImage,
            this.PredictTime,
            this.EntryTime,
            this.TypeInPerson,
            this.Types,
            this.IsUrgent,
            this.Status,
            this.DepartureType,
            this.Client,
            this.SalesPerson,
            this.Visa_id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1288, 478);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // GroupNo
            // 
            this.GroupNo.DataPropertyName = "GroupNo";
            this.GroupNo.HeaderText = "团号";
            this.GroupNo.Name = "GroupNo";
            this.GroupNo.ReadOnly = true;
            this.GroupNo.Width = 300;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "国家";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "人数";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // CountryImage
            // 
            this.CountryImage.HeaderText = "国家图标";
            this.CountryImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.CountryImage.Name = "CountryImage";
            this.CountryImage.ReadOnly = true;
            this.CountryImage.Width = 200;
            // 
            // PredictTime
            // 
            this.PredictTime.DataPropertyName = "PredictTime";
            this.PredictTime.HeaderText = "出发时间";
            this.PredictTime.Name = "PredictTime";
            this.PredictTime.ReadOnly = true;
            // 
            // EntryTime
            // 
            this.EntryTime.DataPropertyName = "EntryTime";
            this.EntryTime.HeaderText = "办理时间";
            this.EntryTime.Name = "EntryTime";
            this.EntryTime.ReadOnly = true;
            // 
            // TypeInPerson
            // 
            this.TypeInPerson.DataPropertyName = "TypeInPerson";
            this.TypeInPerson.HeaderText = "办理人";
            this.TypeInPerson.Name = "TypeInPerson";
            this.TypeInPerson.ReadOnly = true;
            // 
            // Types
            // 
            this.Types.DataPropertyName = "Types";
            this.Types.HeaderText = "类型";
            this.Types.Name = "Types";
            this.Types.ReadOnly = true;
            // 
            // IsUrgent
            // 
            this.IsUrgent.HeaderText = "是否急件";
            this.IsUrgent.Name = "IsUrgent";
            this.IsUrgent.ReadOnly = true;
            this.IsUrgent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsUrgent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // DepartureType
            // 
            this.DepartureType.DataPropertyName = "DepartureType";
            this.DepartureType.HeaderText = "出境类型";
            this.DepartureType.Name = "DepartureType";
            this.DepartureType.ReadOnly = true;
            // 
            // Client
            // 
            this.Client.DataPropertyName = "Client";
            this.Client.HeaderText = "客户";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            // 
            // SalesPerson
            // 
            this.SalesPerson.DataPropertyName = "SalesPerson";
            this.SalesPerson.HeaderText = "销售";
            this.SalesPerson.Name = "SalesPerson";
            this.SalesPerson.ReadOnly = true;
            // 
            // Visa_id
            // 
            this.Visa_id.DataPropertyName = "Visa_id";
            this.Visa_id.HeaderText = "Visa_id";
            this.Visa_id.Name = "Visa_id";
            this.Visa_id.ReadOnly = true;
            this.Visa_id.Visible = false;
            // 
            // cmsDgv
            // 
            this.cmsDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.cmsItemRefreshDatabase,
            this.toolStripSeparator3,
            this.cmsItemShowGroupNo,
            this.修改做资料状态ToolStripMenuItem,
            this.修改选中类型ToolStripMenuItem,
            this.toolStripSeparator2,
            this.导出报表ToolStripMenuItem});
            this.cmsDgv.Name = "cmsDgv";
            this.cmsDgv.Size = new System.Drawing.Size(185, 192);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.复制ToolStripMenuItem.Text = "复制单元格所选内容";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // cmsItemRefreshDatabase
            // 
            this.cmsItemRefreshDatabase.Name = "cmsItemRefreshDatabase";
            this.cmsItemRefreshDatabase.Size = new System.Drawing.Size(184, 22);
            this.cmsItemRefreshDatabase.Text = "刷新数据库状态";
            this.cmsItemRefreshDatabase.Click += new System.EventHandler(this.cmsItemRefreshDatabase_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // cmsItemShowGroupNo
            // 
            this.cmsItemShowGroupNo.Name = "cmsItemShowGroupNo";
            this.cmsItemShowGroupNo.Size = new System.Drawing.Size(184, 22);
            this.cmsItemShowGroupNo.Text = "查看选中团号";
            this.cmsItemShowGroupNo.Click += new System.EventHandler(this.cmsItemShowGroupNo_Click);
            // 
            // 修改做资料状态ToolStripMenuItem
            // 
            this.修改做资料状态ToolStripMenuItem.Name = "修改做资料状态ToolStripMenuItem";
            this.修改做资料状态ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.修改做资料状态ToolStripMenuItem.Text = "修改做资料状态";
            this.修改做资料状态ToolStripMenuItem.Click += new System.EventHandler(this.修改做资料状态ToolStripMenuItem_Click);
            // 
            // 修改选中类型ToolStripMenuItem
            // 
            this.修改选中类型ToolStripMenuItem.Name = "修改选中类型ToolStripMenuItem";
            this.修改选中类型ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.修改选中类型ToolStripMenuItem.Text = "修改选中类型";
            this.修改选中类型ToolStripMenuItem.Click += new System.EventHandler(this.修改选中类型ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // 导出报表ToolStripMenuItem
            // 
            this.导出报表ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打印报表ToolStripMenuItem,
            this.日本ToolStripMenuItem,
            this.韩国ToolStripMenuItem,
            this.泰国ToolStripMenuItem,
            this.两人保险报表ToolStripMenuItem});
            this.导出报表ToolStripMenuItem.Name = "导出报表ToolStripMenuItem";
            this.导出报表ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.导出报表ToolStripMenuItem.Text = "导出报表";
            // 
            // 打印报表ToolStripMenuItem
            // 
            this.打印报表ToolStripMenuItem.Name = "打印报表ToolStripMenuItem";
            this.打印报表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.打印报表ToolStripMenuItem.Text = "打印报表";
            this.打印报表ToolStripMenuItem.Click += new System.EventHandler(this.打印报表ToolStripMenuItem_Click);
            // 
            // 日本ToolStripMenuItem
            // 
            this.日本ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.日本团队综合名单ToolStripMenuItem,
            this.个签意见书ToolStripMenuItem,
            this.金桥大名单ToolStripMenuItem,
            this.日本送签时间表ToolStripMenuItem,
            this.人报表ToolStripMenuItem,
            this.外领担保函ToolStripMenuItem,
            this.信息同意处理书ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.机票报表ToolStripMenuItem,
            this.阪阪川航ToolStripMenuItem,
            this.东阪川航ToolStripMenuItem,
            this.东东川航ToolStripMenuItem,
            this.东东国航ToolStripMenuItem,
            this.东东全日空ToolStripMenuItem,
            this.新北东航ToolStripMenuItem});
            this.日本ToolStripMenuItem.Name = "日本ToolStripMenuItem";
            this.日本ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.日本ToolStripMenuItem.Text = "日本";
            // 
            // 日本团队综合名单ToolStripMenuItem
            // 
            this.日本团队综合名单ToolStripMenuItem.Name = "日本团队综合名单ToolStripMenuItem";
            this.日本团队综合名单ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.日本团队综合名单ToolStripMenuItem.Text = "日本团队综合名单";
            this.日本团队综合名单ToolStripMenuItem.Click += new System.EventHandler(this.日本团队综合名单ToolStripMenuItem_Click);
            // 
            // 个签意见书ToolStripMenuItem
            // 
            this.个签意见书ToolStripMenuItem.Name = "个签意见书ToolStripMenuItem";
            this.个签意见书ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.个签意见书ToolStripMenuItem.Text = "个签意见书";
            this.个签意见书ToolStripMenuItem.Click += new System.EventHandler(this.个签意见书ToolStripMenuItem_Click);
            // 
            // 金桥大名单ToolStripMenuItem
            // 
            this.金桥大名单ToolStripMenuItem.Name = "金桥大名单ToolStripMenuItem";
            this.金桥大名单ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.金桥大名单ToolStripMenuItem.Text = "金桥大名单";
            this.金桥大名单ToolStripMenuItem.Click += new System.EventHandler(this.金桥大名单ToolStripMenuItem_Click);
            // 
            // 日本送签时间表ToolStripMenuItem
            // 
            this.日本送签时间表ToolStripMenuItem.Name = "日本送签时间表ToolStripMenuItem";
            this.日本送签时间表ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.日本送签时间表ToolStripMenuItem.Text = "日本送签时间表";
            this.日本送签时间表ToolStripMenuItem.Click += new System.EventHandler(this.日本送签时间表ToolStripMenuItem_Click);
            // 
            // 人报表ToolStripMenuItem
            // 
            this.人报表ToolStripMenuItem.Name = "人报表ToolStripMenuItem";
            this.人报表ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.人报表ToolStripMenuItem.Text = "8人申请表";
            this.人报表ToolStripMenuItem.Click += new System.EventHandler(this.人报表ToolStripMenuItem_Click);
            // 
            // 外领担保函ToolStripMenuItem
            // 
            this.外领担保函ToolStripMenuItem.Name = "外领担保函ToolStripMenuItem";
            this.外领担保函ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.外领担保函ToolStripMenuItem.Text = "外领担保函";
            this.外领担保函ToolStripMenuItem.Click += new System.EventHandler(this.外领担保函ToolStripMenuItem_Click);
            // 
            // 信息同意处理书ToolStripMenuItem
            // 
            this.信息同意处理书ToolStripMenuItem.Name = "信息同意处理书ToolStripMenuItem";
            this.信息同意处理书ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.信息同意处理书ToolStripMenuItem.Text = "信息同意处理书";
            this.信息同意处理书ToolStripMenuItem.Click += new System.EventHandler(this.信息同意处理书ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem1.Text = "身元模板";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // 机票报表ToolStripMenuItem
            // 
            this.机票报表ToolStripMenuItem.Name = "机票报表ToolStripMenuItem";
            this.机票报表ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.机票报表ToolStripMenuItem.Text = "机票报表";
            this.机票报表ToolStripMenuItem.Click += new System.EventHandler(this.机票报表ToolStripMenuItem_Click);
            // 
            // 阪阪川航ToolStripMenuItem
            // 
            this.阪阪川航ToolStripMenuItem.Name = "阪阪川航ToolStripMenuItem";
            this.阪阪川航ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.阪阪川航ToolStripMenuItem.Text = "阪阪川航";
            this.阪阪川航ToolStripMenuItem.Click += new System.EventHandler(this.阪阪川航ToolStripMenuItem_Click);
            // 
            // 东阪川航ToolStripMenuItem
            // 
            this.东阪川航ToolStripMenuItem.Name = "东阪川航ToolStripMenuItem";
            this.东阪川航ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.东阪川航ToolStripMenuItem.Text = "东阪川航";
            this.东阪川航ToolStripMenuItem.Click += new System.EventHandler(this.东阪川航ToolStripMenuItem_Click);
            // 
            // 东东川航ToolStripMenuItem
            // 
            this.东东川航ToolStripMenuItem.Name = "东东川航ToolStripMenuItem";
            this.东东川航ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.东东川航ToolStripMenuItem.Text = "东东川航";
            this.东东川航ToolStripMenuItem.Click += new System.EventHandler(this.东东川航ToolStripMenuItem_Click);
            // 
            // 东东国航ToolStripMenuItem
            // 
            this.东东国航ToolStripMenuItem.Name = "东东国航ToolStripMenuItem";
            this.东东国航ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.东东国航ToolStripMenuItem.Text = "东东国航";
            this.东东国航ToolStripMenuItem.Click += new System.EventHandler(this.东东国航ToolStripMenuItem_Click);
            // 
            // 东东全日空ToolStripMenuItem
            // 
            this.东东全日空ToolStripMenuItem.Name = "东东全日空ToolStripMenuItem";
            this.东东全日空ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.东东全日空ToolStripMenuItem.Text = "东东全日空";
            this.东东全日空ToolStripMenuItem.Click += new System.EventHandler(this.东东全日空ToolStripMenuItem_Click);
            // 
            // 新北东航ToolStripMenuItem
            // 
            this.新北东航ToolStripMenuItem.Name = "新北东航ToolStripMenuItem";
            this.新北东航ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.新北东航ToolStripMenuItem.Text = "新北东航";
            this.新北东航ToolStripMenuItem.Click += new System.EventHandler(this.新北东航ToolStripMenuItem_Click);
            // 
            // 韩国ToolStripMenuItem
            // 
            this.韩国ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.韩国担保函ToolStripMenuItem,
            this.韩国加急申请书ToolStripMenuItem});
            this.韩国ToolStripMenuItem.Name = "韩国ToolStripMenuItem";
            this.韩国ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.韩国ToolStripMenuItem.Text = "韩国";
            // 
            // 韩国担保函ToolStripMenuItem
            // 
            this.韩国担保函ToolStripMenuItem.Name = "韩国担保函ToolStripMenuItem";
            this.韩国担保函ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.韩国担保函ToolStripMenuItem.Text = "韩国担保函";
            this.韩国担保函ToolStripMenuItem.Click += new System.EventHandler(this.韩国担保函ToolStripMenuItem_Click);
            // 
            // 韩国加急申请书ToolStripMenuItem
            // 
            this.韩国加急申请书ToolStripMenuItem.Name = "韩国加急申请书ToolStripMenuItem";
            this.韩国加急申请书ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.韩国加急申请书ToolStripMenuItem.Text = "韩国加急申请书";
            this.韩国加急申请书ToolStripMenuItem.Click += new System.EventHandler(this.韩国加急申请书ToolStripMenuItem_Click);
            // 
            // 泰国ToolStripMenuItem
            // 
            this.泰国ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据源报表ToolStripMenuItem,
            this.泰签担保函ToolStripMenuItem,
            this.toolStripSeparator4,
            this.机票报表ToolStripMenuItem1,
            this.东航机票ToolStripMenuItem,
            this.川航机票ToolStripMenuItem,
            this.泰航机票ToolStripMenuItem});
            this.泰国ToolStripMenuItem.Name = "泰国ToolStripMenuItem";
            this.泰国ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.泰国ToolStripMenuItem.Text = "泰国";
            // 
            // 数据源报表ToolStripMenuItem
            // 
            this.数据源报表ToolStripMenuItem.Name = "数据源报表ToolStripMenuItem";
            this.数据源报表ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.数据源报表ToolStripMenuItem.Text = "数据源报表";
            this.数据源报表ToolStripMenuItem.Click += new System.EventHandler(this.数据源报表ToolStripMenuItem_Click);
            // 
            // 泰签担保函ToolStripMenuItem
            // 
            this.泰签担保函ToolStripMenuItem.Name = "泰签担保函ToolStripMenuItem";
            this.泰签担保函ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.泰签担保函ToolStripMenuItem.Text = "泰签担保函";
            this.泰签担保函ToolStripMenuItem.Click += new System.EventHandler(this.泰签担保函ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // 机票报表ToolStripMenuItem1
            // 
            this.机票报表ToolStripMenuItem1.Name = "机票报表ToolStripMenuItem1";
            this.机票报表ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.机票报表ToolStripMenuItem1.Text = "机票报表";
            this.机票报表ToolStripMenuItem1.Click += new System.EventHandler(this.机票报表ToolStripMenuItem1_Click);
            // 
            // 东航机票ToolStripMenuItem
            // 
            this.东航机票ToolStripMenuItem.Name = "东航机票ToolStripMenuItem";
            this.东航机票ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.东航机票ToolStripMenuItem.Text = "东航机票";
            this.东航机票ToolStripMenuItem.Click += new System.EventHandler(this.东航机票ToolStripMenuItem_Click);
            // 
            // 川航机票ToolStripMenuItem
            // 
            this.川航机票ToolStripMenuItem.Name = "川航机票ToolStripMenuItem";
            this.川航机票ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.川航机票ToolStripMenuItem.Text = "川航机票";
            this.川航机票ToolStripMenuItem.Click += new System.EventHandler(this.川航机票ToolStripMenuItem_Click);
            // 
            // 泰航机票ToolStripMenuItem
            // 
            this.泰航机票ToolStripMenuItem.Name = "泰航机票ToolStripMenuItem";
            this.泰航机票ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.泰航机票ToolStripMenuItem.Text = "泰航机票";
            this.泰航机票ToolStripMenuItem.Click += new System.EventHandler(this.泰航机票ToolStripMenuItem_Click);
            // 
            // 两人保险报表ToolStripMenuItem
            // 
            this.两人保险报表ToolStripMenuItem.Name = "两人保险报表ToolStripMenuItem";
            this.两人保险报表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.两人保险报表ToolStripMenuItem.Text = "两人保险报表";
            this.两人保险报表ToolStripMenuItem.Click += new System.EventHandler(this.两人保险报表ToolStripMenuItem_Click);
            // 
            // panelBars
            // 
            this.panelBars.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelBars.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelBars.Controls.Add(this.panelSerachBar);
            this.panelBars.Controls.Add(this.bar1);
            this.panelBars.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelBars.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBars.Location = new System.Drawing.Point(0, 0);
            this.panelBars.Name = "panelBars";
            this.panelBars.Size = new System.Drawing.Size(1288, 96);
            this.panelBars.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelBars.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelBars.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelBars.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelBars.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelBars.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelBars.Style.GradientAngle = 90;
            this.panelBars.TabIndex = 30;
            // 
            // panelSerachBar
            // 
            this.panelSerachBar.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelSerachBar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelSerachBar.Controls.Add(this.btnAddVisa);
            this.panelSerachBar.Controls.Add(this.txtSalesPerson);
            this.panelSerachBar.Controls.Add(this.txtClient);
            this.panelSerachBar.Controls.Add(this.cbDepatureType);
            this.panelSerachBar.Controls.Add(this.labelX7);
            this.panelSerachBar.Controls.Add(this.labelX5);
            this.panelSerachBar.Controls.Add(this.labelX6);
            this.panelSerachBar.Controls.Add(this.cbState);
            this.panelSerachBar.Controls.Add(this.labelX4);
            this.panelSerachBar.Controls.Add(this.cbCountry);
            this.panelSerachBar.Controls.Add(this.labelX3);
            this.panelSerachBar.Controls.Add(this.cbIsUrgent);
            this.panelSerachBar.Controls.Add(this.labelX2);
            this.panelSerachBar.Controls.Add(this.btnGetTodayExcel);
            this.panelSerachBar.Controls.Add(this.btnShowToday);
            this.panelSerachBar.Controls.Add(this.cbDisplayType);
            this.panelSerachBar.Controls.Add(this.progressLoading);
            this.panelSerachBar.Controls.Add(this.btnClearSchConditions);
            this.panelSerachBar.Controls.Add(this.labelX15);
            this.panelSerachBar.Controls.Add(this.txtSchGroupNo);
            this.panelSerachBar.Controls.Add(this.lb1);
            this.panelSerachBar.Controls.Add(this.txtSchEntryTimeTo);
            this.panelSerachBar.Controls.Add(this.txtSchEntryTimeFrom);
            this.panelSerachBar.Controls.Add(this.labelX14);
            this.panelSerachBar.Controls.Add(this.labelX12);
            this.panelSerachBar.Controls.Add(this.btnShowAll);
            this.panelSerachBar.Controls.Add(this.btnSearch);
            this.panelSerachBar.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelSerachBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSerachBar.Location = new System.Drawing.Point(0, 28);
            this.panelSerachBar.Name = "panelSerachBar";
            this.panelSerachBar.Size = new System.Drawing.Size(1288, 68);
            this.panelSerachBar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelSerachBar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelSerachBar.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelSerachBar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelSerachBar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelSerachBar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelSerachBar.Style.GradientAngle = 90;
            this.panelSerachBar.TabIndex = 29;
            // 
            // btnAddVisa
            // 
            this.btnAddVisa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddVisa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddVisa.Location = new System.Drawing.Point(1121, 3);
            this.btnAddVisa.Name = "btnAddVisa";
            this.btnAddVisa.Size = new System.Drawing.Size(66, 53);
            this.btnAddVisa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddVisa.TabIndex = 48;
            this.btnAddVisa.Text = "添加团号";
            this.btnAddVisa.Click += new System.EventHandler(this.btnAddVisa_Click);
            // 
            // txtSalesPerson
            // 
            // 
            // 
            // 
            this.txtSalesPerson.Border.Class = "TextBoxBorder";
            this.txtSalesPerson.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSalesPerson.Location = new System.Drawing.Point(738, 36);
            this.txtSalesPerson.Name = "txtSalesPerson";
            this.txtSalesPerson.Size = new System.Drawing.Size(60, 21);
            this.txtSalesPerson.TabIndex = 42;
            // 
            // txtClient
            // 
            // 
            // 
            // 
            this.txtClient.Border.Class = "TextBoxBorder";
            this.txtClient.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClient.Location = new System.Drawing.Point(738, 6);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(60, 21);
            this.txtClient.TabIndex = 43;
            // 
            // cbDepatureType
            // 
            this.cbDepatureType.DisplayMember = "Text";
            this.cbDepatureType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDepatureType.FormattingEnabled = true;
            this.cbDepatureType.ItemHeight = 15;
            this.cbDepatureType.Location = new System.Drawing.Point(614, 5);
            this.cbDepatureType.Name = "cbDepatureType";
            this.cbDepatureType.Size = new System.Drawing.Size(82, 21);
            this.cbDepatureType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDepatureType.TabIndex = 47;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(555, 7);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(66, 21);
            this.labelX7.TabIndex = 46;
            this.labelX7.Text = "出境类型:";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(704, 38);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(37, 21);
            this.labelX5.TabIndex = 44;
            this.labelX5.Text = "销售:";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(704, 6);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(37, 21);
            this.labelX6.TabIndex = 45;
            this.labelX6.Text = "客户:";
            // 
            // cbState
            // 
            this.cbState.DisplayMember = "Text";
            this.cbState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbState.FormattingEnabled = true;
            this.cbState.ItemHeight = 15;
            this.cbState.Location = new System.Drawing.Point(614, 36);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(82, 21);
            this.cbState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbState.TabIndex = 41;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(555, 35);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(46, 21);
            this.labelX4.TabIndex = 40;
            this.labelX4.Text = "状态:";
            // 
            // cbCountry
            // 
            this.cbCountry.DisplayMember = "Text";
            this.cbCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.ItemHeight = 15;
            this.cbCountry.Location = new System.Drawing.Point(471, 5);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(79, 21);
            this.cbCountry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbCountry.TabIndex = 36;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(419, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(46, 21);
            this.labelX3.TabIndex = 35;
            this.labelX3.Text = "国家:";
            // 
            // cbIsUrgent
            // 
            this.cbIsUrgent.DisplayMember = "Text";
            this.cbIsUrgent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIsUrgent.FormattingEnabled = true;
            this.cbIsUrgent.ItemHeight = 15;
            this.cbIsUrgent.Location = new System.Drawing.Point(471, 35);
            this.cbIsUrgent.Name = "cbIsUrgent";
            this.cbIsUrgent.Size = new System.Drawing.Size(79, 21);
            this.cbIsUrgent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbIsUrgent.TabIndex = 34;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(414, 36);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(68, 21);
            this.labelX2.TabIndex = 33;
            this.labelX2.Text = "是否急件:";
            // 
            // btnGetTodayExcel
            // 
            this.btnGetTodayExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetTodayExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetTodayExcel.Location = new System.Drawing.Point(1011, 4);
            this.btnGetTodayExcel.Name = "btnGetTodayExcel";
            this.btnGetTodayExcel.Size = new System.Drawing.Size(104, 53);
            this.btnGetTodayExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGetTodayExcel.TabIndex = 32;
            this.btnGetTodayExcel.Text = "日本(个签)\r\n送签客人情况统计";
            this.btnGetTodayExcel.Click += new System.EventHandler(this.btnGetTodayExcel_Click);
            // 
            // btnShowToday
            // 
            this.btnShowToday.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowToday.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowToday.Location = new System.Drawing.Point(902, 34);
            this.btnShowToday.Name = "btnShowToday";
            this.btnShowToday.Size = new System.Drawing.Size(92, 23);
            this.btnShowToday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowToday.TabIndex = 31;
            this.btnShowToday.Text = "显示今日";
            this.btnShowToday.Click += new System.EventHandler(this.btnShowToday_Click);
            // 
            // cbDisplayType
            // 
            this.cbDisplayType.DisplayMember = "Text";
            this.cbDisplayType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDisplayType.FormattingEnabled = true;
            this.cbDisplayType.ItemHeight = 15;
            this.cbDisplayType.Location = new System.Drawing.Point(333, 6);
            this.cbDisplayType.Name = "cbDisplayType";
            this.cbDisplayType.Size = new System.Drawing.Size(79, 21);
            this.cbDisplayType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDisplayType.TabIndex = 30;
            // 
            // progressLoading
            // 
            // 
            // 
            // 
            this.progressLoading.BackgroundStyle.BackgroundImageAlpha = ((byte)(64));
            this.progressLoading.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressLoading.FocusCuesEnabled = false;
            this.progressLoading.Location = new System.Drawing.Point(1203, 5);
            this.progressLoading.Name = "progressLoading";
            this.progressLoading.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.progressLoading.ProgressColor = System.Drawing.Color.YellowGreen;
            this.progressLoading.Size = new System.Drawing.Size(73, 55);
            this.progressLoading.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.progressLoading.TabIndex = 27;
            this.progressLoading.Value = 100;
            // 
            // btnClearSchConditions
            // 
            this.btnClearSchConditions.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearSchConditions.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClearSchConditions.Location = new System.Drawing.Point(804, 34);
            this.btnClearSchConditions.Name = "btnClearSchConditions";
            this.btnClearSchConditions.Size = new System.Drawing.Size(92, 23);
            this.btnClearSchConditions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClearSchConditions.TabIndex = 26;
            this.btnClearSchConditions.Text = "清空搜索条件";
            this.btnClearSchConditions.Click += new System.EventHandler(this.btnClearSchConditions_Click);
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(298, 7);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(46, 21);
            this.labelX15.TabIndex = 24;
            this.labelX15.Text = "类型:";
            // 
            // txtSchGroupNo
            // 
            // 
            // 
            // 
            this.txtSchGroupNo.Border.Class = "TextBoxBorder";
            this.txtSchGroupNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchGroupNo.Location = new System.Drawing.Point(62, 7);
            this.txtSchGroupNo.Name = "txtSchGroupNo";
            this.txtSchGroupNo.Size = new System.Drawing.Size(230, 21);
            this.txtSchGroupNo.TabIndex = 23;
            // 
            // lb1
            // 
            // 
            // 
            // 
            this.lb1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb1.Location = new System.Drawing.Point(7, 8);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(49, 21);
            this.lb1.TabIndex = 22;
            this.lb1.Text = "团号:";
            // 
            // txtSchEntryTimeTo
            // 
            // 
            // 
            // 
            this.txtSchEntryTimeTo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSchEntryTimeTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeTo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtSchEntryTimeTo.ButtonDropDown.Visible = true;
            this.txtSchEntryTimeTo.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtSchEntryTimeTo.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtSchEntryTimeTo.IsPopupCalendarOpen = false;
            this.txtSchEntryTimeTo.Location = new System.Drawing.Point(249, 36);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtSchEntryTimeTo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeTo.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtSchEntryTimeTo.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtSchEntryTimeTo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeTo.MonthCalendar.DisplayMonth = new System.DateTime(2017, 11, 1, 0, 0, 0, 0);
            this.txtSchEntryTimeTo.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtSchEntryTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtSchEntryTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchEntryTimeTo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtSchEntryTimeTo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeTo.MonthCalendar.TodayButtonVisible = true;
            this.txtSchEntryTimeTo.Name = "txtSchEntryTimeTo";
            this.txtSchEntryTimeTo.Size = new System.Drawing.Size(163, 21);
            this.txtSchEntryTimeTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtSchEntryTimeTo.TabIndex = 21;
            // 
            // txtSchEntryTimeFrom
            // 
            // 
            // 
            // 
            this.txtSchEntryTimeFrom.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSchEntryTimeFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeFrom.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtSchEntryTimeFrom.ButtonDropDown.Visible = true;
            this.txtSchEntryTimeFrom.CustomFormat = "yyyy/MM/dd HH:mm";
            this.txtSchEntryTimeFrom.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtSchEntryTimeFrom.IsPopupCalendarOpen = false;
            this.txtSchEntryTimeFrom.Location = new System.Drawing.Point(62, 35);
            // 
            // 
            // 
            // 
            // 
            // 
            this.txtSchEntryTimeFrom.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeFrom.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.txtSchEntryTimeFrom.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtSchEntryTimeFrom.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeFrom.MonthCalendar.DisplayMonth = new System.DateTime(2017, 11, 1, 0, 0, 0, 0);
            this.txtSchEntryTimeFrom.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.txtSchEntryTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtSchEntryTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtSchEntryTimeFrom.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtSchEntryTimeFrom.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchEntryTimeFrom.MonthCalendar.TodayButtonVisible = true;
            this.txtSchEntryTimeFrom.Name = "txtSchEntryTimeFrom";
            this.txtSchEntryTimeFrom.Size = new System.Drawing.Size(163, 21);
            this.txtSchEntryTimeFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtSchEntryTimeFrom.TabIndex = 20;
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(230, 35);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(13, 21);
            this.labelX14.TabIndex = 19;
            this.labelX14.Text = "-";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(7, 35);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(63, 21);
            this.labelX12.TabIndex = 17;
            this.labelX12.Text = "录入时间:";
            // 
            // btnShowAll
            // 
            this.btnShowAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowAll.Location = new System.Drawing.Point(902, 5);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(91, 23);
            this.btnShowAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowAll.TabIndex = 14;
            this.btnShowAll.Text = "显示全部";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(804, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // bgWorkerLoadData
            // 
            this.bgWorkerLoadData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoadData_DoWork);
            this.bgWorkerLoadData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerLoadData_ProgressChanged);
            this.bgWorkerLoadData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoadData_RunWorkerCompleted);
            // 
            // labelItem8
            // 
            this.labelItem8.Name = "labelItem8";
            this.labelItem8.Text = "显示类型:";
            // 
            // panelDgv
            // 
            this.panelDgv.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelDgv.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDgv.Controls.Add(this.dataGridView1);
            this.panelDgv.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDgv.Location = new System.Drawing.Point(0, 96);
            this.panelDgv.Name = "panelDgv";
            this.panelDgv.Size = new System.Drawing.Size(1288, 478);
            this.panelDgv.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDgv.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelDgv.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelDgv.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelDgv.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelDgv.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelDgv.Style.GradientAngle = 90;
            this.panelDgv.TabIndex = 37;
            this.panelDgv.Text = "panelEx1";
            // 
            // cmsAddToGroup
            // 
            this.cmsAddToGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加到团号ToolStripMenuItem});
            this.cmsAddToGroup.Name = "cmsAddToGroup";
            this.cmsAddToGroup.Size = new System.Drawing.Size(149, 26);
            // 
            // 添加到团号ToolStripMenuItem
            // 
            this.添加到团号ToolStripMenuItem.Name = "添加到团号ToolStripMenuItem";
            this.添加到团号ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加到团号ToolStripMenuItem.Text = "添加到此团号";
            this.添加到团号ToolStripMenuItem.Click += new System.EventHandler(this.添加到团号ToolStripMenuItem_Click);
            // 
            // FrmVisaManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 574);
            this.Controls.Add(this.panelDgv);
            this.Controls.Add(this.panelBars);
            this.Name = "FrmVisaManage";
            this.Text = "团号管理";
            this.Load += new System.EventHandler(this.FrmVisaManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmsDgv.ResumeLayout(false);
            this.panelBars.ResumeLayout(false);
            this.panelSerachBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeFrom)).EndInit();
            this.panelDgv.ResumeLayout(false);
            this.cmsAddToGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnPageFirst;
        private DevComponents.DotNetBar.ButtonItem btnPagePre;
        private DevComponents.DotNetBar.ButtonItem btnPageNext;
        private DevComponents.DotNetBar.ButtonItem btnPageLast;
        private DevComponents.DotNetBar.ComboBoxItem cbCurPage;
        private DevComponents.DotNetBar.ButtonItem btnGoto;
        private DevComponents.DotNetBar.LabelItem lbRecordCount;
        private DevComponents.DotNetBar.LabelItem lbl;
        private DevComponents.DotNetBar.ComboBoxItem cbPageSize;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.LabelItem lbCurPage;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cmsDgv;
        private System.Windows.Forms.ToolStripMenuItem cmsItemShowGroupNo;
        private System.Windows.Forms.ToolStripMenuItem cmsItemRefreshDatabase;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private DevComponents.DotNetBar.PanelEx panelBars;
        private DevComponents.DotNetBar.PanelEx panelSerachBar;
        private DevComponents.DotNetBar.Controls.CircularProgress progressLoading;
        private DevComponents.DotNetBar.ButtonX btnClearSchConditions;
        private DevComponents.DotNetBar.LabelX labelX15;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSchGroupNo;
        private DevComponents.DotNetBar.LabelX lb1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtSchEntryTimeTo;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtSchEntryTimeFrom;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.ButtonX btnShowAll;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadData;
        private DevComponents.DotNetBar.LabelItem labelItem8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbDisplayType;
        private DevComponents.DotNetBar.PanelEx panelDgv;
        private System.Windows.Forms.ContextMenuStrip cmsAddToGroup;
        private System.Windows.Forms.ToolStripMenuItem 添加到团号ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX btnShowToday;
        private System.Windows.Forms.ToolStripMenuItem 导出报表ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX btnGetTodayExcel;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbIsUrgent;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbCountry;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbState;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.ToolStripMenuItem 打印报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改选中类型ToolStripMenuItem;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSalesPerson;
        private DevComponents.DotNetBar.Controls.TextBoxX txtClient;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbDepatureType;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.ToolStripMenuItem 日本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日本团队综合名单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个签意见书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 金桥大名单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日本送签时间表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 机票报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 外领担保函ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 韩国ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 泰国ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据源报表ToolStripMenuItem;
        private DevComponents.DotNetBar.LabelItem lbPeopleCount;
        private System.Windows.Forms.ToolStripMenuItem 泰签担保函ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 机票报表ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 韩国担保函ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX btnAddVisa;
        private System.Windows.Forms.ToolStripMenuItem 修改做资料状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 韩国加急申请书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 信息同意处理书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 东航机票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 川航机票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 泰航机票ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 阪阪川航ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 东阪川航ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 东东川航ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 东东国航ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 东东全日空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新北东航ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewImageColumn CountryImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn PredictTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeInPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Types;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsUrgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartureType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visa_id;
        private System.Windows.Forms.ToolStripMenuItem 两人保险报表ToolStripMenuItem;
    }
}