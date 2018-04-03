namespace ScanCtrlTest
{
    partial class FrmTackePicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTackePicture));
            this.axScanCtrl1 = new AxSCANCTRLLib.AxScanCtrl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panelBtns = new DevComponents.DotNetBar.PanelEx();
            this.lbSuccess = new DevComponents.DotNetBar.LabelX();
            this.btnChoosePath = new System.Windows.Forms.Button();
            this.btnOpenSavePath = new System.Windows.Forms.Button();
            this.rbtnGaoPai = new System.Windows.Forms.RadioButton();
            this.rbtnJiaojie = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.axScanCtrl1)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // axScanCtrl1
            // 
            this.axScanCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axScanCtrl1.Enabled = true;
            this.axScanCtrl1.Location = new System.Drawing.Point(0, 0);
            this.axScanCtrl1.Name = "axScanCtrl1";
            this.axScanCtrl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axScanCtrl1.OcxState")));
            this.axScanCtrl1.Size = new System.Drawing.Size(1018, 645);
            this.axScanCtrl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "打开视频";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(46, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "关闭视频";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "设备列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "分辨率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "扫描尺寸";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "旋转角度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "色彩";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(46, 294);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "属性";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(46, 326);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 29);
            this.button4.TabIndex = 9;
            this.button4.Text = "放大";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(46, 357);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(126, 29);
            this.button5.TabIndex = 10;
            this.button5.Text = "缩小";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(46, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 20);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(46, 134);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(125, 20);
            this.comboBox2.TabIndex = 12;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(46, 177);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(125, 20);
            this.comboBox3.TabIndex = 13;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(46, 220);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(125, 20);
            this.comboBox4.TabIndex = 14;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(46, 263);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(125, 20);
            this.comboBox5.TabIndex = 15;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(46, 398);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "纠偏裁边";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(46, 420);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(60, 16);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "去底色";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 451);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "保存路径:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 466);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 51);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "D:\\1.jpg";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(107, 523);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(81, 42);
            this.button6.TabIndex = 20;
            this.button6.Text = "抓拍";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.axScanCtrl1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1018, 645);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 21;
            // 
            // panelBtns
            // 
            this.panelBtns.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelBtns.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelBtns.Controls.Add(this.rbtnJiaojie);
            this.panelBtns.Controls.Add(this.rbtnGaoPai);
            this.panelBtns.Controls.Add(this.lbSuccess);
            this.panelBtns.Controls.Add(this.btnChoosePath);
            this.panelBtns.Controls.Add(this.button1);
            this.panelBtns.Controls.Add(this.button2);
            this.panelBtns.Controls.Add(this.button6);
            this.panelBtns.Controls.Add(this.label1);
            this.panelBtns.Controls.Add(this.textBox1);
            this.panelBtns.Controls.Add(this.label2);
            this.panelBtns.Controls.Add(this.label6);
            this.panelBtns.Controls.Add(this.label3);
            this.panelBtns.Controls.Add(this.checkBox2);
            this.panelBtns.Controls.Add(this.label4);
            this.panelBtns.Controls.Add(this.checkBox1);
            this.panelBtns.Controls.Add(this.label5);
            this.panelBtns.Controls.Add(this.comboBox5);
            this.panelBtns.Controls.Add(this.button3);
            this.panelBtns.Controls.Add(this.comboBox4);
            this.panelBtns.Controls.Add(this.button4);
            this.panelBtns.Controls.Add(this.comboBox3);
            this.panelBtns.Controls.Add(this.btnOpenSavePath);
            this.panelBtns.Controls.Add(this.button5);
            this.panelBtns.Controls.Add(this.comboBox2);
            this.panelBtns.Controls.Add(this.comboBox1);
            this.panelBtns.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelBtns.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBtns.Location = new System.Drawing.Point(1018, 0);
            this.panelBtns.Name = "panelBtns";
            this.panelBtns.Size = new System.Drawing.Size(200, 645);
            this.panelBtns.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelBtns.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelBtns.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelBtns.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelBtns.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelBtns.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelBtns.Style.GradientAngle = 90;
            this.panelBtns.TabIndex = 25;
            // 
            // lbSuccess
            // 
            // 
            // 
            // 
            this.lbSuccess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbSuccess.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSuccess.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbSuccess.Location = new System.Drawing.Point(12, 596);
            this.lbSuccess.Name = "lbSuccess";
            this.lbSuccess.Size = new System.Drawing.Size(185, 23);
            this.lbSuccess.TabIndex = 22;
            this.lbSuccess.Text = "待机中...";
            // 
            // btnChoosePath
            // 
            this.btnChoosePath.Location = new System.Drawing.Point(171, 466);
            this.btnChoosePath.Name = "btnChoosePath";
            this.btnChoosePath.Size = new System.Drawing.Size(17, 51);
            this.btnChoosePath.TabIndex = 21;
            this.btnChoosePath.Text = "...";
            this.btnChoosePath.UseVisualStyleBackColor = true;
            this.btnChoosePath.Click += new System.EventHandler(this.btnChoosePath_Click);
            // 
            // btnOpenSavePath
            // 
            this.btnOpenSavePath.Location = new System.Drawing.Point(12, 523);
            this.btnOpenSavePath.Name = "btnOpenSavePath";
            this.btnOpenSavePath.Size = new System.Drawing.Size(81, 42);
            this.btnOpenSavePath.TabIndex = 10;
            this.btnOpenSavePath.Text = "打开保存文件夹";
            this.btnOpenSavePath.UseVisualStyleBackColor = true;
            this.btnOpenSavePath.Click += new System.EventHandler(this.btnOpenSavePath_Click);
            // 
            // rbtnGaoPai
            // 
            this.rbtnGaoPai.AutoSize = true;
            this.rbtnGaoPai.Location = new System.Drawing.Point(12, 572);
            this.rbtnGaoPai.Name = "rbtnGaoPai";
            this.rbtnGaoPai.Size = new System.Drawing.Size(71, 16);
            this.rbtnGaoPai.TabIndex = 23;
            this.rbtnGaoPai.TabStop = true;
            this.rbtnGaoPai.Text = "高拍图像";
            this.rbtnGaoPai.UseVisualStyleBackColor = true;
            this.rbtnGaoPai.CheckedChanged += new System.EventHandler(this.rbtnGaoPai_CheckedChanged);
            // 
            // rbtnJiaojie
            // 
            this.rbtnJiaojie.AutoSize = true;
            this.rbtnJiaojie.Location = new System.Drawing.Point(107, 572);
            this.rbtnJiaojie.Name = "rbtnJiaojie";
            this.rbtnJiaojie.Size = new System.Drawing.Size(71, 16);
            this.rbtnJiaojie.TabIndex = 24;
            this.rbtnJiaojie.TabStop = true;
            this.rbtnJiaojie.Text = "交接图像";
            this.rbtnJiaojie.UseVisualStyleBackColor = true;
            this.rbtnJiaojie.CheckedChanged += new System.EventHandler(this.rbtnJiaojie_CheckedChanged);
            // 
            // FrmTackePicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 645);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelBtns);
            this.Name = "FrmTackePicture";
            this.Text = "高拍仪";
            this.Load += new System.EventHandler(this.LoadWindow);
            ((System.ComponentModel.ISupportInitialize)(this.axScanCtrl1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelBtns.ResumeLayout(false);
            this.panelBtns.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxSCANCTRLLib.AxScanCtrl axScanCtrl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button6;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelBtns;
        private System.Windows.Forms.Button btnOpenSavePath;
        private System.Windows.Forms.Button btnChoosePath;
        private DevComponents.DotNetBar.LabelX lbSuccess;
        private System.Windows.Forms.RadioButton rbtnGaoPai;
        private System.Windows.Forms.RadioButton rbtnJiaojie;
    }
}

