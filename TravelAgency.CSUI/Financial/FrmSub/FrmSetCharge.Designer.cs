namespace TravelAgency.CSUI.Financial.FrmSub
{
    partial class FrmSetCharge
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.GroupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.RealTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Person = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tips = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tips2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Types = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUrgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeInPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quidco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsulateCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisaPersonCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvitationCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visa_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnConfirm = new DevComponents.DotNetBar.ButtonX();
            this.panelDgv = new DevComponents.DotNetBar.PanelEx();
            this.panelBtns = new DevComponents.DotNetBar.PanelEx();
            this.lbMoneyCount = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelDgv.SuspendLayout();
            this.panelBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
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
            this.GroupNo,
            this.Country,
            this.CountryImage,
            this.RealTime,
            this.FinishTime,
            this.Person,
            this.Number,
            this.Tips,
            this.Tips2,
            this.EntryTime,
            this.Types,
            this.IsUrgent,
            this.Status,
            this.DepartureType,
            this.Client,
            this.SalesPerson,
            this.TypeInPerson,
            this.Receipt,
            this.Quidco,
            this.ConsulateCost,
            this.VisaPersonCost,
            this.InvitationCost,
            this.Picture,
            this.MailCost,
            this.OtherCost,
            this.Price,
            this.Cost,
            this.Visa_id});
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
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
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
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1132, 526);
            this.dataGridView1.TabIndex = 14;
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
            // CountryImage
            // 
            this.CountryImage.HeaderText = "国家图标";
            this.CountryImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.CountryImage.Name = "CountryImage";
            this.CountryImage.ReadOnly = true;
            this.CountryImage.Width = 200;
            // 
            // RealTime
            // 
            this.RealTime.DataPropertyName = "RealTime";
            this.RealTime.HeaderText = "送签日期";
            this.RealTime.Name = "RealTime";
            this.RealTime.ReadOnly = true;
            this.RealTime.Visible = false;
            // 
            // FinishTime
            // 
            this.FinishTime.DataPropertyName = "FinishTime";
            this.FinishTime.HeaderText = "出签日期";
            this.FinishTime.Name = "FinishTime";
            this.FinishTime.ReadOnly = true;
            this.FinishTime.Visible = false;
            // 
            // Person
            // 
            this.Person.DataPropertyName = "Person";
            this.Person.HeaderText = "送签社担当";
            this.Person.Name = "Person";
            this.Person.ReadOnly = true;
            this.Person.Visible = false;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "人数";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Visible = false;
            // 
            // Tips
            // 
            this.Tips.DataPropertyName = "Tips";
            this.Tips.HeaderText = "备注1";
            this.Tips.Name = "Tips";
            this.Tips.ReadOnly = true;
            this.Tips.Visible = false;
            // 
            // Tips2
            // 
            this.Tips2.DataPropertyName = "Tips2";
            this.Tips2.HeaderText = "备注2";
            this.Tips2.Name = "Tips2";
            this.Tips2.ReadOnly = true;
            this.Tips2.Visible = false;
            // 
            // EntryTime
            // 
            this.EntryTime.DataPropertyName = "EntryTime";
            this.EntryTime.HeaderText = "办理时间";
            this.EntryTime.Name = "EntryTime";
            this.EntryTime.ReadOnly = true;
            this.EntryTime.Visible = false;
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
            this.IsUrgent.DataPropertyName = "IsUrgent";
            this.IsUrgent.HeaderText = "是否急件";
            this.IsUrgent.Name = "IsUrgent";
            this.IsUrgent.ReadOnly = true;
            this.IsUrgent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsUrgent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IsUrgent.Visible = false;
            // 
            // Status
            // 
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
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
            this.SalesPerson.Visible = false;
            // 
            // TypeInPerson
            // 
            this.TypeInPerson.DataPropertyName = "TypeInPerson";
            this.TypeInPerson.HeaderText = "做资料员";
            this.TypeInPerson.Name = "TypeInPerson";
            this.TypeInPerson.ReadOnly = true;
            this.TypeInPerson.Visible = false;
            // 
            // Receipt
            // 
            this.Receipt.DataPropertyName = "Receipt";
            this.Receipt.HeaderText = "收款";
            this.Receipt.Name = "Receipt";
            this.Receipt.ReadOnly = true;
            // 
            // Quidco
            // 
            this.Quidco.DataPropertyName = "Quidco";
            this.Quidco.HeaderText = "返款";
            this.Quidco.Name = "Quidco";
            this.Quidco.ReadOnly = true;
            this.Quidco.Visible = false;
            // 
            // ConsulateCost
            // 
            this.ConsulateCost.DataPropertyName = "ConsulateCost";
            this.ConsulateCost.HeaderText = "领馆收费";
            this.ConsulateCost.Name = "ConsulateCost";
            this.ConsulateCost.ReadOnly = true;
            this.ConsulateCost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // VisaPersonCost
            // 
            this.VisaPersonCost.DataPropertyName = "VisaPersonCost";
            this.VisaPersonCost.HeaderText = "送签员费用";
            this.VisaPersonCost.Name = "VisaPersonCost";
            this.VisaPersonCost.ReadOnly = true;
            this.VisaPersonCost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // InvitationCost
            // 
            this.InvitationCost.DataPropertyName = "InvitationCost";
            this.InvitationCost.HeaderText = "邀请函费用";
            this.InvitationCost.Name = "InvitationCost";
            this.InvitationCost.ReadOnly = true;
            this.InvitationCost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Picture
            // 
            this.Picture.DataPropertyName = "Picture";
            this.Picture.HeaderText = "洗照片";
            this.Picture.Name = "Picture";
            this.Picture.ReadOnly = true;
            this.Picture.Visible = false;
            // 
            // MailCost
            // 
            this.MailCost.DataPropertyName = "MailCost";
            this.MailCost.HeaderText = "寄资料费";
            this.MailCost.Name = "MailCost";
            this.MailCost.ReadOnly = true;
            this.MailCost.Visible = false;
            // 
            // OtherCost
            // 
            this.OtherCost.DataPropertyName = "OtherCost";
            this.OtherCost.HeaderText = "杂费";
            this.OtherCost.Name = "OtherCost";
            this.OtherCost.ReadOnly = true;
            this.OtherCost.Visible = false;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Visible = false;
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "总价";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Visible = false;
            // 
            // Visa_id
            // 
            this.Visa_id.DataPropertyName = "Visa_id";
            this.Visa_id.HeaderText = "Visa_id";
            this.Visa_id.Name = "Visa_id";
            this.Visa_id.ReadOnly = true;
            this.Visa_id.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(495, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.Location = new System.Drawing.Point(414, 6);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 21;
            this.btnConfirm.Text = "确认修改";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
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
            this.panelDgv.Size = new System.Drawing.Size(1132, 526);
            this.panelDgv.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDgv.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelDgv.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelDgv.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelDgv.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelDgv.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelDgv.Style.GradientAngle = 90;
            this.panelDgv.TabIndex = 23;
            // 
            // panelBtns
            // 
            this.panelBtns.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelBtns.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelBtns.Controls.Add(this.lbMoneyCount);
            this.panelBtns.Controls.Add(this.btnCancel);
            this.panelBtns.Controls.Add(this.btnConfirm);
            this.panelBtns.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBtns.Location = new System.Drawing.Point(0, 526);
            this.panelBtns.Name = "panelBtns";
            this.panelBtns.Size = new System.Drawing.Size(1132, 32);
            this.panelBtns.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelBtns.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelBtns.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelBtns.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelBtns.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelBtns.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelBtns.Style.GradientAngle = 90;
            this.panelBtns.TabIndex = 27;
            // 
            // lbMoneyCount
            // 
            // 
            // 
            // 
            this.lbMoneyCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbMoneyCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMoneyCount.Location = new System.Drawing.Point(626, 6);
            this.lbMoneyCount.Name = "lbMoneyCount";
            this.lbMoneyCount.Size = new System.Drawing.Size(477, 23);
            this.lbMoneyCount.TabIndex = 23;
            this.lbMoneyCount.Text = "labelX1";
            // 
            // FrmSetCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 558);
            this.Controls.Add(this.panelDgv);
            this.Controls.Add(this.panelBtns);
            this.Name = "FrmSetCharge";
            this.Text = "设置收费";
            this.Load += new System.EventHandler(this.FrmSetCharge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelDgv.ResumeLayout(false);
            this.panelBtns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridView1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnConfirm;
        private DevComponents.DotNetBar.PanelEx panelDgv;
        private DevComponents.DotNetBar.PanelEx panelBtns;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewImageColumn CountryImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Person;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tips;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tips2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Types;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsUrgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartureType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeInPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quidco;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsulateCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisaPersonCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvitationCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visa_id;
        private DevComponents.DotNetBar.LabelX lbMoneyCount;
    }
}