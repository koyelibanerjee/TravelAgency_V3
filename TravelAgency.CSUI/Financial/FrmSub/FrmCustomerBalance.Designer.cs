namespace TravelAgency.CSUI.Financial.FrmSub
{
    partial class FrmCustomerBalance
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
            this.panelDgv = new DevComponents.DotNetBar.PanelEx();
            this.dataGridView1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cmsDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.分配给选中用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmsDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDgv
            // 
            this.panelDgv.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelDgv.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDgv.Controls.Add(this.dataGridView1);
            this.panelDgv.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDgv.Location = new System.Drawing.Point(0, 0);
            this.panelDgv.Name = "panelDgv";
            this.panelDgv.Size = new System.Drawing.Size(529, 402);
            this.panelDgv.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDgv.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelDgv.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelDgv.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelDgv.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelDgv.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelDgv.Style.GradientAngle = 90;
            this.panelDgv.TabIndex = 42;
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
            this.CustomerName,
            this.Amount,
            this.BalanceAmount,
            this.UserName,
            this.EntryTime,
            this.BalanceId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
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
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(529, 402);
            this.dataGridView1.TabIndex = 10;
            // 
            // cmsDgv
            // 
            this.cmsDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.分配给选中用户ToolStripMenuItem});
            this.cmsDgv.Name = "cmsDgv";
            this.cmsDgv.Size = new System.Drawing.Size(101, 26);
            // 
            // 分配给选中用户ToolStripMenuItem
            // 
            this.分配给选中用户ToolStripMenuItem.Name = "分配给选中用户ToolStripMenuItem";
            this.分配给选中用户ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.分配给选中用户ToolStripMenuItem.Text = "刷新";
            this.分配给选中用户ToolStripMenuItem.Click += new System.EventHandler(this.分配给选中用户ToolStripMenuItem_Click);
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "客户名";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "总金额";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // BalanceAmount
            // 
            this.BalanceAmount.DataPropertyName = "BalanceAmount";
            this.BalanceAmount.HeaderText = "余额";
            this.BalanceAmount.Name = "BalanceAmount";
            this.BalanceAmount.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "认款人";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // EntryTime
            // 
            this.EntryTime.DataPropertyName = "EntryTime";
            this.EntryTime.HeaderText = "认账时间";
            this.EntryTime.Name = "EntryTime";
            this.EntryTime.ReadOnly = true;
            // 
            // BalanceId
            // 
            this.BalanceId.DataPropertyName = "BalanceId";
            this.BalanceId.HeaderText = "BalanceId";
            this.BalanceId.Name = "BalanceId";
            this.BalanceId.ReadOnly = true;
            this.BalanceId.Visible = false;
            // 
            // FrmCustomerBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 402);
            this.Controls.Add(this.panelDgv);
            this.Name = "FrmCustomerBalance";
            this.Text = "客户余额查看";
            this.Load += new System.EventHandler(this.FrmSelUser_Load);
            this.DoubleClick += new System.EventHandler(this.FrmSelUser_DoubleClick);
            this.panelDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmsDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelDgv;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cmsDgv;
        private System.Windows.Forms.ToolStripMenuItem 分配给选中用户ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceId;
    }
}