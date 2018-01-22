namespace PictureBoxDemo
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.proPictureBox1 = new ProPictureBox();
            this.pbox_zoom1 = new pbox_zoom_control.pbox_zoom();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 261);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // proPictureBox1
            // 
            this.proPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.proPictureBox1.Location = new System.Drawing.Point(419, 44);
            this.proPictureBox1.Name = "proPictureBox1";
            this.proPictureBox1.Size = new System.Drawing.Size(524, 415);
            this.proPictureBox1.TabIndex = 2;
            this.proPictureBox1.TabStop = false;
            // 
            // pbox_zoom1
            // 
            this.pbox_zoom1.BackColor = System.Drawing.SystemColors.Control;
            this.pbox_zoom1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pbox_zoom1.Image")));
            this.pbox_zoom1.ImageLocation = "";
            this.pbox_zoom1.Location = new System.Drawing.Point(12, 279);
            this.pbox_zoom1.minmax = 10;
            this.pbox_zoom1.Name = "pbox_zoom1";
            this.pbox_zoom1.Size = new System.Drawing.Size(401, 353);
            this.pbox_zoom1.TabIndex = 1;
            this.pbox_zoom1.zoomfactor = 1.25D;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 660);
            this.Controls.Add(this.proPictureBox1);
            this.Controls.Add(this.pbox_zoom1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private pbox_zoom_control.pbox_zoom pbox_zoom1;
        private ProPictureBox proPictureBox1;
    }
}

