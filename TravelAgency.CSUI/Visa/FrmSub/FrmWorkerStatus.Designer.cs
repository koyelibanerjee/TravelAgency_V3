namespace TravelAgency.CSUI.Visa.FrmSub
{
    partial class FrmWorkerStatus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelDgv = new DevComponents.DotNetBar.PanelEx();
            this.dataGridView1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.WorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsBusy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanAccept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.分配给选中用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkId,
            this.UserName,
            this.IsBusy,
            this.CanAccept,
            this.Priority});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(529, 402);
            this.dataGridView1.TabIndex = 10;
            // 
            // WorkId
            // 
            this.WorkId.DataPropertyName = "WorkId";
            this.WorkId.HeaderText = "工号";
            this.WorkId.Name = "WorkId";
            this.WorkId.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "姓名";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // IsBusy
            // 
            this.IsBusy.HeaderText = "状态";
            this.IsBusy.Name = "IsBusy";
            this.IsBusy.ReadOnly = true;
            // 
            // CanAccept
            // 
            this.CanAccept.HeaderText = "接受自动分配";
            this.CanAccept.Name = "CanAccept";
            this.CanAccept.ReadOnly = true;
            // 
            // Priority
            // 
            this.Priority.DataPropertyName = "Priority";
            this.Priority.HeaderText = "优先级";
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
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
            this.分配给选中用户ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.分配给选中用户ToolStripMenuItem.Text = "刷新";
            this.分配给选中用户ToolStripMenuItem.Click += new System.EventHandler(this.分配给选中用户ToolStripMenuItem_Click);
            // 
            // FrmWorkerStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 402);
            this.Controls.Add(this.panelDgv);
            this.Name = "FrmWorkerStatus";
            this.Text = "员工状态查看";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsBusy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanAccept;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
    }
}