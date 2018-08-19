namespace HProseFileTransferServerWinForm
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lbCount = new DevComponents.DotNetBar.LabelX();
            this.lvLogs = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EntryTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Operation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Details = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifycms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示主窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1.SuspendLayout();
            this.notifycms.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.lbCount);
            this.panelEx1.Controls.Add(this.lvLogs);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(804, 446);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelX1.Location = new System.Drawing.Point(12, 386);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(256, 48);
            this.labelX1.TabIndex = 39;
            this.labelX1.Text = "服务运行中";
            // 
            // lbCount
            // 
            // 
            // 
            // 
            this.lbCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbCount.Location = new System.Drawing.Point(291, 400);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(539, 34);
            this.lbCount.TabIndex = 38;
            this.lbCount.Text = "上传文件:xxx项，下载文件xxx项。";
            // 
            // lvLogs
            // 
            // 
            // 
            // 
            this.lvLogs.Border.Class = "ListViewBorder";
            this.lvLogs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.EntryTime,
            this.Operation,
            this.Details,
            this.State});
            this.lvLogs.DisabledBackColor = System.Drawing.Color.Empty;
            this.lvLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvLogs.FullRowSelect = true;
            this.lvLogs.Location = new System.Drawing.Point(0, 0);
            this.lvLogs.Name = "lvLogs";
            this.lvLogs.Size = new System.Drawing.Size(804, 380);
            this.lvLogs.TabIndex = 36;
            this.lvLogs.UseCompatibleStateImageBehavior = false;
            this.lvLogs.View = System.Windows.Forms.View.Details;
            // 
            // No
            // 
            this.No.Text = "编号";
            this.No.Width = 67;
            // 
            // EntryTime
            // 
            this.EntryTime.Text = "时间";
            this.EntryTime.Width = 77;
            // 
            // Operation
            // 
            this.Operation.Text = "操作";
            this.Operation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Operation.Width = 77;
            // 
            // Details
            // 
            this.Details.Text = "内容";
            this.Details.Width = 482;
            // 
            // State
            // 
            this.State.Text = "状态";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifycms;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "东瀛假日签证识别管理系统文件传输服务";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // notifycms
            // 
            this.notifycms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示主窗体ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.notifycms.Name = "notifycms";
            this.notifycms.Size = new System.Drawing.Size(137, 48);
            // 
            // 显示主窗体ToolStripMenuItem
            // 
            this.显示主窗体ToolStripMenuItem.Name = "显示主窗体ToolStripMenuItem";
            this.显示主窗体ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.显示主窗体ToolStripMenuItem.Text = "显示主窗体";
            this.显示主窗体ToolStripMenuItem.Click += new System.EventHandler(this.显示主窗体ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 446);
            this.Controls.Add(this.panelEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "东瀛假日签证识别管理系统文件传输服务";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelEx1.ResumeLayout(false);
            this.notifycms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.ListViewEx lvLogs;
        private System.Windows.Forms.ColumnHeader EntryTime;
        private System.Windows.Forms.ColumnHeader Operation;
        private System.Windows.Forms.ColumnHeader Details;
        private System.Windows.Forms.ColumnHeader State;
        private DevComponents.DotNetBar.LabelX lbCount;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip notifycms;
        private System.Windows.Forms.ToolStripMenuItem 显示主窗体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ColumnHeader No;
    }
}

