namespace TravelAgency.OrdersManagement
{
    partial class FrmOrdersManage_Oper
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.WaitorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReplyResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GuestOrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitorOrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitorConfirmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReallyPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatformActivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JpOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderWay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperOrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JpConfirmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReplyWaitorConfirmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettlePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExchangeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMain = new DevComponents.DotNetBar.PanelEx();
            this.panelDgv = new DevComponents.DotNetBar.PanelEx();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.lbGuestInfoTypedInCount = new DevComponents.DotNetBar.LabelItem();
            this.lbReplyResultCount = new DevComponents.DotNetBar.LabelItem();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.panelBars = new DevComponents.DotNetBar.PanelEx();
            this.panelSerachBar = new DevComponents.DotNetBar.PanelEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtWaitorName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbReplyResult = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbPaymentPlatform = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtOrderNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnTimeSpanChoose = new DevComponents.DotNetBar.ButtonX();
            this.txtSchEntryTimeTo = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtSchEntryTimeFrom = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.progressLoading = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.btnClearSchConditions = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
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
            this.btnGeneratePersonalReport = new DevComponents.DotNetBar.ButtonItem();
            this.cmsDgvRb = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsItemRefreshState = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看录入订单操作信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看客人信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.订单发送消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.上传订单附件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载订单附件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.附件管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.录入订单标签信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置订单颜色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox5 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox6 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox7 = new System.Windows.Forms.ToolStripTextBox();
            this.人申请表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.机票报表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外领担保函ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.韩国担保函ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.韩国加急申请书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgWorkerLoadData = new System.ComponentModel.BackgroundWorker();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.默认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panelDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.panelBars.SuspendLayout();
            this.panelSerachBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.cmsDgvRb.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
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
            this.WaitorName,
            this.OrderNo,
            this.ReplyResult,
            this.PaymentPlatform,
            this.GroupNo,
            this.ProductName,
            this.ProductId,
            this.ProductType,
            this.PurchaseNum,
            this.OrderAmount,
            this.GuestOrderTime,
            this.WaitorOrderTime,
            this.WaitorConfirmTime,
            this.ReallyPay,
            this.PlatformActivity,
            this.JpOrderNo,
            this.OrderWay,
            this.OperOrderTime,
            this.JpConfirmTime,
            this.ReplyWaitorConfirmTime,
            this.SettlePrice,
            this.ExchangeRate,
            this.OperRemark,
            this.Id});
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1271, 506);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // WaitorName
            // 
            this.WaitorName.DataPropertyName = "WaitorName";
            this.WaitorName.HeaderText = "录入客服";
            this.WaitorName.Name = "WaitorName";
            // 
            // OrderNo
            // 
            this.OrderNo.DataPropertyName = "OrderNo";
            this.OrderNo.HeaderText = "网上平台订单号";
            this.OrderNo.Name = "OrderNo";
            // 
            // ReplyResult
            // 
            this.ReplyResult.DataPropertyName = "ReplyResult";
            this.ReplyResult.HeaderText = "回复结果";
            this.ReplyResult.Name = "ReplyResult";
            // 
            // PaymentPlatform
            // 
            this.PaymentPlatform.HeaderText = "平台";
            this.PaymentPlatform.Name = "PaymentPlatform";
            // 
            // GroupNo
            // 
            this.GroupNo.DataPropertyName = "GroupNo";
            this.GroupNo.HeaderText = "团号";
            this.GroupNo.Name = "GroupNo";
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "产品名称";
            this.ProductName.Name = "ProductName";
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "产品ID";
            this.ProductId.Name = "ProductId";
            // 
            // ProductType
            // 
            this.ProductType.DataPropertyName = "ProductType";
            this.ProductType.HeaderText = "产品类型";
            this.ProductType.Name = "ProductType";
            // 
            // PurchaseNum
            // 
            this.PurchaseNum.DataPropertyName = "PurchaseNum";
            this.PurchaseNum.HeaderText = "购买数量";
            this.PurchaseNum.Name = "PurchaseNum";
            // 
            // OrderAmount
            // 
            this.OrderAmount.DataPropertyName = "OrderAmount";
            this.OrderAmount.HeaderText = "订单金额";
            this.OrderAmount.Name = "OrderAmount";
            // 
            // GuestOrderTime
            // 
            this.GuestOrderTime.DataPropertyName = "GuestOrderTime";
            this.GuestOrderTime.HeaderText = "客人下单时间";
            this.GuestOrderTime.Name = "GuestOrderTime";
            // 
            // WaitorOrderTime
            // 
            this.WaitorOrderTime.DataPropertyName = "WaitorOrderTime";
            this.WaitorOrderTime.HeaderText = "客服下单时间";
            this.WaitorOrderTime.Name = "WaitorOrderTime";
            // 
            // WaitorConfirmTime
            // 
            this.WaitorConfirmTime.DataPropertyName = "WaitorConfirmTime";
            this.WaitorConfirmTime.HeaderText = "客服确认时间";
            this.WaitorConfirmTime.Name = "WaitorConfirmTime";
            // 
            // ReallyPay
            // 
            this.ReallyPay.DataPropertyName = "ReallyPay";
            this.ReallyPay.HeaderText = "实际支付金额";
            this.ReallyPay.Name = "ReallyPay";
            // 
            // PlatformActivity
            // 
            this.PlatformActivity.DataPropertyName = "PlatformActivity";
            this.PlatformActivity.HeaderText = "平台活动";
            this.PlatformActivity.Name = "PlatformActivity";
            // 
            // JpOrderNo
            // 
            this.JpOrderNo.DataPropertyName = "JpOrderNo";
            this.JpOrderNo.HeaderText = "下单平台订单号";
            this.JpOrderNo.Name = "JpOrderNo";
            // 
            // OrderWay
            // 
            this.OrderWay.DataPropertyName = "OrderWay";
            this.OrderWay.HeaderText = "下单方式";
            this.OrderWay.Name = "OrderWay";
            // 
            // OperOrderTime
            // 
            this.OperOrderTime.DataPropertyName = "OperOrderTime";
            this.OperOrderTime.HeaderText = "操作下单时间";
            this.OperOrderTime.Name = "OperOrderTime";
            // 
            // JpConfirmTime
            // 
            this.JpConfirmTime.DataPropertyName = "JpConfirmTime";
            this.JpConfirmTime.HeaderText = "日本确认时间";
            this.JpConfirmTime.Name = "JpConfirmTime";
            // 
            // ReplyWaitorConfirmTime
            // 
            this.ReplyWaitorConfirmTime.DataPropertyName = "ReplyWaitorConfirmTime";
            this.ReplyWaitorConfirmTime.HeaderText = "回复客服确认时间";
            this.ReplyWaitorConfirmTime.Name = "ReplyWaitorConfirmTime";
            // 
            // SettlePrice
            // 
            this.SettlePrice.DataPropertyName = "SettlePrice";
            this.SettlePrice.HeaderText = "结算成本单价";
            this.SettlePrice.Name = "SettlePrice";
            // 
            // ExchangeRate
            // 
            this.ExchangeRate.DataPropertyName = "ExchangeRate";
            this.ExchangeRate.HeaderText = "汇率";
            this.ExchangeRate.Name = "ExchangeRate";
            // 
            // OperRemark
            // 
            this.OperRemark.DataPropertyName = "OperRemark";
            this.OperRemark.HeaderText = "备注";
            this.OperRemark.Name = "OperRemark";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // panelMain
            // 
            this.panelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelMain.Controls.Add(this.panelDgv);
            this.panelMain.Controls.Add(this.panelBars);
            this.panelMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1271, 623);
            this.panelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMain.Style.GradientAngle = 90;
            this.panelMain.TabIndex = 23;
            // 
            // panelDgv
            // 
            this.panelDgv.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelDgv.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDgv.Controls.Add(this.dataGridView1);
            this.panelDgv.Controls.Add(this.bar2);
            this.panelDgv.Controls.Add(this.labelX5);
            this.panelDgv.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDgv.Location = new System.Drawing.Point(0, 93);
            this.panelDgv.Name = "panelDgv";
            this.panelDgv.Size = new System.Drawing.Size(1271, 530);
            this.panelDgv.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDgv.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelDgv.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelDgv.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelDgv.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelDgv.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelDgv.Style.GradientAngle = 90;
            this.panelDgv.TabIndex = 38;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar2.DockTabStripHeight = 30;
            this.bar2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lbGuestInfoTypedInCount,
            this.lbReplyResultCount});
            this.bar2.ItemSpacing = 5;
            this.bar2.Location = new System.Drawing.Point(0, 506);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(1271, 24);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 30;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // lbGuestInfoTypedInCount
            // 
            this.lbGuestInfoTypedInCount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbGuestInfoTypedInCount.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbGuestInfoTypedInCount.Name = "lbGuestInfoTypedInCount";
            this.lbGuestInfoTypedInCount.Text = "--";
            // 
            // lbReplyResultCount
            // 
            this.lbReplyResultCount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbReplyResultCount.ForeColor = System.Drawing.Color.Tomato;
            this.lbReplyResultCount.Name = "lbReplyResultCount";
            this.lbReplyResultCount.Text = "--";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(602, -26);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(72, 21);
            this.labelX5.TabIndex = 120;
            this.labelX5.Text = "回复结果:";
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
            this.panelBars.Size = new System.Drawing.Size(1271, 93);
            this.panelBars.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelBars.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelBars.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelBars.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelBars.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelBars.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelBars.Style.GradientAngle = 90;
            this.panelBars.TabIndex = 34;
            // 
            // panelSerachBar
            // 
            this.panelSerachBar.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelSerachBar.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelSerachBar.Controls.Add(this.labelX3);
            this.panelSerachBar.Controls.Add(this.txtWaitorName);
            this.panelSerachBar.Controls.Add(this.cbReplyResult);
            this.panelSerachBar.Controls.Add(this.labelX1);
            this.panelSerachBar.Controls.Add(this.cbPaymentPlatform);
            this.panelSerachBar.Controls.Add(this.labelX2);
            this.panelSerachBar.Controls.Add(this.txtOrderNo);
            this.panelSerachBar.Controls.Add(this.labelX4);
            this.panelSerachBar.Controls.Add(this.btnTimeSpanChoose);
            this.panelSerachBar.Controls.Add(this.txtSchEntryTimeTo);
            this.panelSerachBar.Controls.Add(this.txtSchEntryTimeFrom);
            this.panelSerachBar.Controls.Add(this.labelX14);
            this.panelSerachBar.Controls.Add(this.labelX12);
            this.panelSerachBar.Controls.Add(this.progressLoading);
            this.panelSerachBar.Controls.Add(this.btnClearSchConditions);
            this.panelSerachBar.Controls.Add(this.btnSearch);
            this.panelSerachBar.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelSerachBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSerachBar.Location = new System.Drawing.Point(0, 28);
            this.panelSerachBar.Name = "panelSerachBar";
            this.panelSerachBar.Size = new System.Drawing.Size(1271, 65);
            this.panelSerachBar.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelSerachBar.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelSerachBar.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelSerachBar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelSerachBar.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelSerachBar.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelSerachBar.Style.GradientAngle = 90;
            this.panelSerachBar.TabIndex = 24;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(584, 34);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(72, 21);
            this.labelX3.TabIndex = 124;
            this.labelX3.Text = "回复结果:";
            // 
            // txtWaitorName
            // 
            // 
            // 
            // 
            this.txtWaitorName.Border.Class = "TextBoxBorder";
            this.txtWaitorName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWaitorName.DisabledBackColor = System.Drawing.Color.White;
            this.txtWaitorName.Location = new System.Drawing.Point(488, 34);
            this.txtWaitorName.Name = "txtWaitorName";
            this.txtWaitorName.Size = new System.Drawing.Size(80, 21);
            this.txtWaitorName.TabIndex = 123;
            // 
            // cbReplyResult
            // 
            this.cbReplyResult.DisplayMember = "Text";
            this.cbReplyResult.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbReplyResult.FormattingEnabled = true;
            this.cbReplyResult.ItemHeight = 15;
            this.cbReplyResult.Location = new System.Drawing.Point(662, 34);
            this.cbReplyResult.Name = "cbReplyResult";
            this.cbReplyResult.Size = new System.Drawing.Size(79, 21);
            this.cbReplyResult.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbReplyResult.TabIndex = 121;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(428, 34);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(79, 23);
            this.labelX1.TabIndex = 122;
            this.labelX1.Text = "销售姓名:";
            // 
            // cbPaymentPlatform
            // 
            this.cbPaymentPlatform.DisplayMember = "Text";
            this.cbPaymentPlatform.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPaymentPlatform.FormattingEnabled = true;
            this.cbPaymentPlatform.ItemHeight = 15;
            this.cbPaymentPlatform.Location = new System.Drawing.Point(662, 6);
            this.cbPaymentPlatform.Name = "cbPaymentPlatform";
            this.cbPaymentPlatform.Size = new System.Drawing.Size(79, 21);
            this.cbPaymentPlatform.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbPaymentPlatform.TabIndex = 115;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(584, 6);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(72, 21);
            this.labelX2.TabIndex = 114;
            this.labelX2.Text = "交易平台:";
            // 
            // txtOrderNo
            // 
            // 
            // 
            // 
            this.txtOrderNo.Border.Class = "TextBoxBorder";
            this.txtOrderNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOrderNo.DisabledBackColor = System.Drawing.Color.White;
            this.txtOrderNo.Location = new System.Drawing.Point(70, 34);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(345, 21);
            this.txtOrderNo.TabIndex = 113;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(8, 34);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(81, 23);
            this.labelX4.TabIndex = 112;
            this.labelX4.Text = "订单号:";
            // 
            // btnTimeSpanChoose
            // 
            this.btnTimeSpanChoose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTimeSpanChoose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTimeSpanChoose.Location = new System.Drawing.Point(433, 5);
            this.btnTimeSpanChoose.Name = "btnTimeSpanChoose";
            this.btnTimeSpanChoose.Size = new System.Drawing.Size(91, 23);
            this.btnTimeSpanChoose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTimeSpanChoose.TabIndex = 61;
            this.btnTimeSpanChoose.Text = "时间区间选择";
            this.btnTimeSpanChoose.Click += new System.EventHandler(this.btnTimeSpanChoose_Click);
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
            this.txtSchEntryTimeTo.Location = new System.Drawing.Point(255, 7);
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
            this.txtSchEntryTimeTo.Size = new System.Drawing.Size(160, 21);
            this.txtSchEntryTimeTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtSchEntryTimeTo.TabIndex = 60;
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
            this.txtSchEntryTimeFrom.Location = new System.Drawing.Point(70, 7);
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
            this.txtSchEntryTimeFrom.Size = new System.Drawing.Size(160, 21);
            this.txtSchEntryTimeFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtSchEntryTimeFrom.TabIndex = 59;
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(236, 7);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(13, 21);
            this.labelX14.TabIndex = 58;
            this.labelX14.Text = "-";
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(12, 8);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(63, 21);
            this.labelX12.TabIndex = 57;
            this.labelX12.Text = "提交时间:";
            // 
            // progressLoading
            // 
            // 
            // 
            // 
            this.progressLoading.BackgroundStyle.BackgroundImageAlpha = ((byte)(64));
            this.progressLoading.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressLoading.FocusCuesEnabled = false;
            this.progressLoading.Location = new System.Drawing.Point(1028, -2);
            this.progressLoading.Name = "progressLoading";
            this.progressLoading.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.progressLoading.ProgressColor = System.Drawing.Color.YellowGreen;
            this.progressLoading.Size = new System.Drawing.Size(66, 57);
            this.progressLoading.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.progressLoading.TabIndex = 27;
            this.progressLoading.Value = 100;
            // 
            // btnClearSchConditions
            // 
            this.btnClearSchConditions.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClearSchConditions.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClearSchConditions.Location = new System.Drawing.Point(817, 6);
            this.btnClearSchConditions.Name = "btnClearSchConditions";
            this.btnClearSchConditions.Size = new System.Drawing.Size(92, 23);
            this.btnClearSchConditions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClearSchConditions.TabIndex = 26;
            this.btnClearSchConditions.Text = "清空搜索条件";
            this.btnClearSchConditions.Click += new System.EventHandler(this.btnClearSchConditions_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(817, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnGeneratePersonalReport});
            this.bar1.ItemSpacing = 5;
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1271, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 23;
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
            // btnGeneratePersonalReport
            // 
            this.btnGeneratePersonalReport.Name = "btnGeneratePersonalReport";
            // 
            // cmsDgvRb
            // 
            this.cmsDgvRb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItemRefreshState,
            this.删除ToolStripMenuItem,
            this.toolStripSeparator1,
            this.修改ToolStripMenuItem,
            this.查看录入订单操作信息ToolStripMenuItem,
            this.查看客人信息ToolStripMenuItem,
            this.toolStripSeparator2,
            this.订单发送消息ToolStripMenuItem,
            this.toolStripSeparator3,
            this.上传订单附件ToolStripMenuItem,
            this.下载订单附件ToolStripMenuItem,
            this.附件管理ToolStripMenuItem,
            this.toolStripSeparator4,
            this.录入订单标签信息ToolStripMenuItem,
            this.设置订单颜色ToolStripMenuItem});
            this.cmsDgvRb.Name = "cmsDgvRb";
            this.cmsDgvRb.Size = new System.Drawing.Size(205, 292);
            // 
            // cmsItemRefreshState
            // 
            this.cmsItemRefreshState.Name = "cmsItemRefreshState";
            this.cmsItemRefreshState.Size = new System.Drawing.Size(204, 22);
            this.cmsItemRefreshState.Text = "刷新数据库状态";
            this.cmsItemRefreshState.Click += new System.EventHandler(this.cmsItemRefreshState_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.修改ToolStripMenuItem.Text = "查看订单信息";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 查看录入订单操作信息ToolStripMenuItem
            // 
            this.查看录入订单操作信息ToolStripMenuItem.Name = "查看录入订单操作信息ToolStripMenuItem";
            this.查看录入订单操作信息ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.查看录入订单操作信息ToolStripMenuItem.Text = "查看(录入)操作信息";
            this.查看录入订单操作信息ToolStripMenuItem.Click += new System.EventHandler(this.查看录入订单操作信息ToolStripMenuItem_Click);
            // 
            // 查看客人信息ToolStripMenuItem
            // 
            this.查看客人信息ToolStripMenuItem.Name = "查看客人信息ToolStripMenuItem";
            this.查看客人信息ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.查看客人信息ToolStripMenuItem.Text = "查看补充信息";
            this.查看客人信息ToolStripMenuItem.Click += new System.EventHandler(this.查看客人信息ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(201, 6);
            // 
            // 订单发送消息ToolStripMenuItem
            // 
            this.订单发送消息ToolStripMenuItem.Name = "订单发送消息ToolStripMenuItem";
            this.订单发送消息ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.订单发送消息ToolStripMenuItem.Text = "订单发送消息";
            this.订单发送消息ToolStripMenuItem.Click += new System.EventHandler(this.订单发送消息ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(201, 6);
            // 
            // 上传订单附件ToolStripMenuItem
            // 
            this.上传订单附件ToolStripMenuItem.Name = "上传订单附件ToolStripMenuItem";
            this.上传订单附件ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.上传订单附件ToolStripMenuItem.Text = "上传订单附件";
            this.上传订单附件ToolStripMenuItem.Click += new System.EventHandler(this.上传订单附件ToolStripMenuItem_Click);
            // 
            // 下载订单附件ToolStripMenuItem
            // 
            this.下载订单附件ToolStripMenuItem.Name = "下载订单附件ToolStripMenuItem";
            this.下载订单附件ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.下载订单附件ToolStripMenuItem.Text = "下载订单附件";
            this.下载订单附件ToolStripMenuItem.Click += new System.EventHandler(this.下载订单附件ToolStripMenuItem_Click);
            // 
            // 附件管理ToolStripMenuItem
            // 
            this.附件管理ToolStripMenuItem.Name = "附件管理ToolStripMenuItem";
            this.附件管理ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.附件管理ToolStripMenuItem.Text = "订单附件管理";
            this.附件管理ToolStripMenuItem.Click += new System.EventHandler(this.附件管理ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(201, 6);
            // 
            // 录入订单标签信息ToolStripMenuItem
            // 
            this.录入订单标签信息ToolStripMenuItem.Name = "录入订单标签信息ToolStripMenuItem";
            this.录入订单标签信息ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.录入订单标签信息ToolStripMenuItem.Text = "录入(查看)订单标签信息";
            this.录入订单标签信息ToolStripMenuItem.Click += new System.EventHandler(this.录入订单标签信息ToolStripMenuItem_Click);
            // 
            // 设置订单颜色ToolStripMenuItem
            // 
            this.设置订单颜色ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripTextBox2,
            this.toolStripTextBox3,
            this.toolStripTextBox4,
            this.toolStripTextBox5,
            this.toolStripTextBox6,
            this.toolStripTextBox7,
            this.默认ToolStripMenuItem});
            this.设置订单颜色ToolStripMenuItem.Name = "设置订单颜色ToolStripMenuItem";
            this.设置订单颜色ToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.设置订单颜色ToolStripMenuItem.Text = "设置订单颜色";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.Yellow;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox2.Click += new System.EventHandler(this.toolStripTextBox2_Click);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox3.Click += new System.EventHandler(this.toolStripTextBox3_Click);
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox4.Click += new System.EventHandler(this.toolStripTextBox4_Click);
            // 
            // toolStripTextBox5
            // 
            this.toolStripTextBox5.BackColor = System.Drawing.Color.YellowGreen;
            this.toolStripTextBox5.Name = "toolStripTextBox5";
            this.toolStripTextBox5.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox5.Click += new System.EventHandler(this.toolStripTextBox5_Click);
            // 
            // toolStripTextBox6
            // 
            this.toolStripTextBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStripTextBox6.Name = "toolStripTextBox6";
            this.toolStripTextBox6.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox6.Click += new System.EventHandler(this.toolStripTextBox6_Click);
            // 
            // toolStripTextBox7
            // 
            this.toolStripTextBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolStripTextBox7.Name = "toolStripTextBox7";
            this.toolStripTextBox7.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox7.Click += new System.EventHandler(this.toolStripTextBox7_Click);
            // 
            // 人申请表ToolStripMenuItem
            // 
            this.人申请表ToolStripMenuItem.Name = "人申请表ToolStripMenuItem";
            this.人申请表ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 机票报表ToolStripMenuItem
            // 
            this.机票报表ToolStripMenuItem.Name = "机票报表ToolStripMenuItem";
            this.机票报表ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 外领担保函ToolStripMenuItem
            // 
            this.外领担保函ToolStripMenuItem.Name = "外领担保函ToolStripMenuItem";
            this.外领担保函ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 韩国担保函ToolStripMenuItem
            // 
            this.韩国担保函ToolStripMenuItem.Name = "韩国担保函ToolStripMenuItem";
            this.韩国担保函ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 韩国加急申请书ToolStripMenuItem
            // 
            this.韩国加急申请书ToolStripMenuItem.Name = "韩国加急申请书ToolStripMenuItem";
            this.韩国加急申请书ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // bgWorkerLoadData
            // 
            this.bgWorkerLoadData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoadData_DoWork);
            this.bgWorkerLoadData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerLoadData_ProgressChanged);
            this.bgWorkerLoadData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoadData_RunWorkerCompleted);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // 默认ToolStripMenuItem
            // 
            this.默认ToolStripMenuItem.Name = "默认ToolStripMenuItem";
            this.默认ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.默认ToolStripMenuItem.Text = "默认";
            this.默认ToolStripMenuItem.Click += new System.EventHandler(this.默认ToolStripMenuItem_Click);
            // 
            // FrmOrdersManage_Oper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 623);
            this.Controls.Add(this.panelMain);
            this.Name = "FrmOrdersManage_Oper";
            this.Text = "订单管理_操作";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.panelBars.ResumeLayout(false);
            this.panelSerachBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSchEntryTimeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.cmsDgvRb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.PanelEx panelMain;
        private System.Windows.Forms.ContextMenuStrip cmsDgvRb;
        private System.Windows.Forms.ToolStripMenuItem cmsItemRefreshState;
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
        private DevComponents.DotNetBar.PanelEx panelDgv;
        private DevComponents.DotNetBar.PanelEx panelBars;
        private DevComponents.DotNetBar.PanelEx panelSerachBar;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.ButtonX btnClearSchConditions;
        private DevComponents.DotNetBar.Controls.CircularProgress progressLoading;
        private System.ComponentModel.BackgroundWorker bgWorkerLoadData;
        private System.Windows.Forms.ToolStripMenuItem 人申请表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 机票报表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 外领担保函ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 韩国担保函ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 韩国加急申请书ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonItem btnGeneratePersonalReport;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX btnTimeSpanChoose;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtSchEntryTimeTo;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtSchEntryTimeFrom;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOrderNo;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbPaymentPlatform;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.ToolStripMenuItem 查看录入订单操作信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看客人信息ToolStripMenuItem;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.LabelItem lbGuestInfoTypedInCount;
        private DevComponents.DotNetBar.LabelItem lbReplyResultCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReplyResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentPlatform;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuestOrderTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitorOrderTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitorConfirmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReallyPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatformActivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn JpOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderWay;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperOrderTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn JpConfirmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReplyWaitorConfirmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettlePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExchangeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.ToolStripMenuItem 订单发送消息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtWaitorName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbReplyResult;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 上传订单附件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载订单附件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 附件管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 录入订单标签信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置订单颜色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox5;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox6;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox7;
        private System.Windows.Forms.ToolStripMenuItem 默认ToolStripMenuItem;
    }
}

