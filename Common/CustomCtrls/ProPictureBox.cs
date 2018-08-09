using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace TravelAgency.Common.CustomCtrls
{
    public struct ProTransformation
    {
        public Point Translation { get { return _translation; } }
        public double Scale { get { return _scale; } }
        private readonly Point _translation;
        private readonly double _scale;


        public ProTransformation(Point translation, double scale)
        {
            _translation = translation;
            _scale = scale;
        }
        public Point ConvertToIm(Point p)
        {
            return new Point((int)(p.X * _scale + _translation.X), (int)(p.Y * _scale + _translation.Y));
        }

        public Size ConvertToIm(Size p)
        {
            return new Size((int)(p.Width * _scale), (int)(p.Height * _scale));
        }

        public Rectangle ConvertToIm(Rectangle r)
        {
            return new Rectangle(ConvertToIm(r.Location), ConvertToIm(r.Size));
        }

        public Point ConvertToPb(Point p)
        {
            return new Point((int)((p.X - _translation.X) / _scale), (int)((p.Y - _translation.Y) / _scale));
        }

        public Size ConvertToPb(Size p)
        {
            return new Size((int)(p.Width / _scale), (int)(p.Height / _scale));
        }

        public Rectangle ConvertToPb(Rectangle r)
        {
            return new Rectangle(ConvertToPb(r.Location), ConvertToPb(r.Size));
        }

        public ProTransformation SetTranslate(Point p)
        {
            return new ProTransformation(p, _scale);
        }

        public ProTransformation AddTranslate(Point p)
        {
            return SetTranslate(new Point(p.X + _translation.X, p.Y + _translation.Y));
        }

        public ProTransformation SetScale(double scale)
        {
            return new ProTransformation(_translation, scale);
        }
    }

    public class ProPictureBox : PictureBox
    {
        public string DefaultSaveFileName { get; set; }
        private Point? _clickedPoint;
        private ProTransformation _transformation;
        private bool _firstSetScale = true;
        public string FileName { get; set; }


        #region 重写Image属性，add imagechanged event
        public new Image Image
        {
            get { return base.Image; }
            set
            {
                //if (base.Image != null)
                //    base.Image.Dispose();
                base.Image = value;
                //_imageChanged?.Invoke(this, new EventArgs()); //TODO:暂时屏蔽，有bug
            }
        }

        private EventHandler _imageChanged;
        public event EventHandler ImageChanged
        {
            add { _imageChanged += value; }
            remove
            {
                if (_imageChanged != null)
                    if (value != null)
                        // ReSharper disable once DelegateSubtraction
                        _imageChanged -= value;
            }
        }
        #endregion



        private System.Windows.Forms.ContextMenuStrip cmsPicBox;
        private System.Windows.Forms.ToolStripMenuItem 保存图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 旋转图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 左旋90度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 右旋90度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 垂直翻转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 水平翻转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 本地查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开文件夹ToolStripMenuItem;


        public Point GetRealMousePosition(Point p)
        {
            return this.Transformation.ConvertToIm(p);
        }

        public double GetCurrentScale()
        {
            return this.Transformation.Scale;
        }

        public void ResetFitScale() //强制恢复大小匹配的模式
        {
            SetFitScale();
            Invalidate();
        }

        public ProTransformation Transformation
        {
            set
            {
                if (Image == null)
                    return;
                _transformation = FixTranslation(value);
            }
            get
            {
                return _transformation;
            }
        }

        public ProPictureBox()
        {
            _transformation = new ProTransformation(new Point(100, 0), .5f);

            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
            MouseUp += OnMouseUp;
            MouseWheel += OnMouseWheel;
            Resize += OnResize;
            ImageChanged += OnImageChanged;


            #region 右键菜单初始化
            this.cmsPicBox = new System.Windows.Forms.ContextMenuStrip();
            this.保存图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.旋转图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.左旋90度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.右旋90度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.垂直翻转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.水平翻转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.本地查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // 
            // cmsPicBox
            // 
            this.cmsPicBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.保存图像ToolStripMenuItem,
                this.旋转图像ToolStripMenuItem,this.本地查看ToolStripMenuItem,this.打开文件夹ToolStripMenuItem});
            this.cmsPicBox.Name = "cmsPicBox";
            this.cmsPicBox.Size = new System.Drawing.Size(153, 70);
            // 
            // 保存图像ToolStripMenuItem
            // 
            this.保存图像ToolStripMenuItem.Name = "保存图像ToolStripMenuItem";
            this.保存图像ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存图像ToolStripMenuItem.Text = "保存图像";
            this.保存图像ToolStripMenuItem.Click += new System.EventHandler(this.保存图像ToolStripMenuItem_Click);
            // 
            // 旋转图像ToolStripMenuItem
            // 
            this.旋转图像ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.左旋90度ToolStripMenuItem,
                this.右旋90度ToolStripMenuItem,
                this.垂直翻转ToolStripMenuItem,
                this.水平翻转ToolStripMenuItem});
            this.旋转图像ToolStripMenuItem.Name = "旋转图像ToolStripMenuItem";
            this.旋转图像ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.旋转图像ToolStripMenuItem.Text = "旋转图像";
            // 
            // 左旋90度ToolStripMenuItem
            // 
            this.左旋90度ToolStripMenuItem.Name = "左旋90度ToolStripMenuItem";
            this.左旋90度ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.左旋90度ToolStripMenuItem.Text = "左旋90度";
            this.左旋90度ToolStripMenuItem.Click += new System.EventHandler(this.左旋90度ToolStripMenuItem_Click);
            // 
            // 右旋90度ToolStripMenuItem
            // 
            this.右旋90度ToolStripMenuItem.Name = "右旋90度ToolStripMenuItem";
            this.右旋90度ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.右旋90度ToolStripMenuItem.Text = "右旋90度";
            this.右旋90度ToolStripMenuItem.Click += new System.EventHandler(this.右旋90度ToolStripMenuItem_Click);
            // 
            // 垂直翻转ToolStripMenuItem
            // 
            this.垂直翻转ToolStripMenuItem.Name = "垂直翻转ToolStripMenuItem";
            this.垂直翻转ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.垂直翻转ToolStripMenuItem.Text = "垂直翻转";
            this.垂直翻转ToolStripMenuItem.Click += new System.EventHandler(this.垂直翻转ToolStripMenuItem_Click);
            // 
            // 水平翻转ToolStripMenuItem
            // 
            this.水平翻转ToolStripMenuItem.Name = "水平翻转ToolStripMenuItem";
            this.水平翻转ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.水平翻转ToolStripMenuItem.Text = "水平翻转";
            this.水平翻转ToolStripMenuItem.Click += new System.EventHandler(this.水平翻转ToolStripMenuItem_Click);

            // 
            // 本地查看ToolStripMenuItem
            // 
            this.本地查看ToolStripMenuItem.Name = "本地查看ToolStripMenuItem";
            this.本地查看ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.本地查看ToolStripMenuItem.Text = "本地查看";
            this.本地查看ToolStripMenuItem.Click += new System.EventHandler(this.本地查看ToolStripMenuItem_Click);

            // 
            // 打开文件夹ToolStripMenuItem
            // 
            this.打开文件夹ToolStripMenuItem.Name = "打开文件夹ToolStripMenuItem";
            this.打开文件夹ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开文件夹ToolStripMenuItem.Text = "打开文件夹";
            this.打开文件夹ToolStripMenuItem.Click += new System.EventHandler(this.打开文件夹ToolStripMenuItem_Click);

            #endregion

        }

        private void OnImageChanged(object sender, EventArgs e)
        {
            if (this.Image != null)
                ResetFitScale();
        }

        #region 右键菜单事件
        private void 左旋90度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate90FlipNone);
        }

        private void 右旋90度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate270FlipNone);
        }

        private void 垂直翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate180FlipX);
        }

        private void 水平翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate180FlipY);
        }
        private void 本地查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FileName))
                Process.Start(FileName);
            else
                MessageBoxEx.Show("找不到对应文件!");
        }

        private void 打开文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FileName))
                Process.Start(Path.GetDirectoryName(FileName));
            else
                MessageBoxEx.Show("找不到对应文件!");
        }

        private void RotateImage(RotateFlipType type)
        {
            if (this.Image != null)
            {
                Bitmap img = new Bitmap(Image);
                img.RotateFlip(type);
                this.Image = img;
                _firstSetScale = true;//更新状态，可以重设比例大小
            }
        }

        private void 保存图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Image == null)
                return;
            string filename = ShowSaveFileDlg(DefaultSaveFileName);
            if (!string.IsNullOrEmpty(filename))
                Image.Save(filename);
        }

        /// <summary>
        /// 返回openfileDialog的文件名（为了不产生依赖项，直接拿过来了）
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public static string ShowSaveFileDlg(string filename, string Filter = "图像文件|*.jpg")
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = Filter;
            saveFileDialog1.Title = "Save";
            if (!string.IsNullOrEmpty(filename))
                saveFileDialog1.FileName = filename;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return null;

            if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                return saveFileDialog1.FileName;

            return null;
        }

        #endregion


        /// <summary>
        /// 修正大小，防止太大或者太小
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private ProTransformation FixTranslation(ProTransformation value)
        {
            double maxScale = CalcFitScale(); //最大缩小到跟边框一样大小
            if (value.Scale > maxScale)
                value = value.SetScale(maxScale);
            if (value.Scale < 0.3)
                value = value.SetScale(0.3);
            var rectSize = value.ConvertToIm(ClientRectangle.Size);
            var max = new Size(Image.Width - rectSize.Width, Image.Height - rectSize.Height);

            value = value.SetTranslate((new Point(Math.Min(value.Translation.X, max.Width), Math.Min(value.Translation.Y, max.Height))));
            if (value.Translation.X < 0 || value.Translation.Y < 0)
            {
                value = value.SetTranslate(new Point(Math.Max(value.Translation.X, 0), Math.Max(value.Translation.Y, 0)));
            }
            return value;
        }

        private void OnResize(object sender, EventArgs eventArgs)
        {
            if (Image == null)
                return;
            Transformation = Transformation;
        }

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            var transformation = _transformation;
            var pos1 = transformation.ConvertToIm(e.Location); //转换到图像实际的位置
            //Console.WriteLine(pos1);
            //Console.WriteLine(this.Transformation.Scale);
            if (e.Delta > 0)
                transformation = (transformation.SetScale(Transformation.Scale / 1.25));
            else
                transformation = (transformation.SetScale(Transformation.Scale * 1.25));
            ////这里再处理一下缩小到了小于等于

            var pos2 = transformation.ConvertToIm(e.Location);
            transformation = transformation.AddTranslate(pos1 - (Size)pos2);
            Transformation = transformation;
            Invalidate();
        }

        //protected override void OnValidating(CancelEventArgs e)
        //{
        //    base.OnValidating(e);
        //}

        protected virtual void OnMouseUp(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Right)
                cmsPicBox.Show(MousePosition);

            _clickedPoint = null;
            Cursor = System.Windows.Forms.Cursors.Default;
        }

        protected virtual void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_clickedPoint == null)
                return;
            var p = _transformation.ConvertToIm((Size)e.Location);
            Transformation = _transformation.SetTranslate(_clickedPoint.Value - p);
            Invalidate();
        }

        protected virtual void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Focus();
                Cursor = System.Windows.Forms.Cursors.SizeAll;
                _clickedPoint = _transformation.ConvertToIm(e.Location);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image == null)
                return;
            if (_firstSetScale && SetFitScale())
                _firstSetScale = false;
            var imRect = Transformation.ConvertToIm(ClientRectangle);
            //Console.WriteLine(imRect.Width + "," + imRect.Height);
            //e.Graphics.DrawImage(Image, ClientRectangle, imRect, GraphicsUnit.Pixel);
            DrawImageInCenter(e, imRect, ClientRectangle);
        }

        private void DrawImageInCenter(PaintEventArgs e, Rectangle imRect, Rectangle clientRect)
        {
            //if (imRect.Width > Image.Width || imRect.Height > Image.Height)
            //{
            //    //先对图像进行合适的填充
            //    //Bitmap imgResized = new Bitmap(imRect.Width, imRect.Height); //先建立一张图像
            //    //Graphics g = Graphics.FromImage(imgResized);

            //    //g.DrawImage(Image, (imRect.Width - Image.Width) / 2.0f, (imRect.Height - Image.Height) / 2.0f);
            //    //PicHandler.DrawImageInCenter(imgResized, Image);

            //    e.Graphics.DrawImage(Image, ClientRectangle, 
            //        (imRect.Width - Image.Width) / 2.0f
            //        , (imRect.Height - Image.Height) / 2.0f, 
            //        imRect.Width * 1.0f, imRect.Height * 1.0f, 
            //        GraphicsUnit.Pixel);
            //    //e.Graphics.DrawImage(, ClientRectangle);

            //}
            //else
            //Bitmap imgResized = new Bitmap(imRect.Width, imRect.Height); //先建立一张图像
            //Graphics g = Graphics.FromImage(imgResized);
            //g.DrawImage(Image,0.0f,0.0f);
            //e.Graphics.DrawImage(imgResized, ClientRectangle, imRect, GraphicsUnit.Pixel);

            e.Graphics.DrawImage(Image, ClientRectangle, imRect, GraphicsUnit.Pixel);
        }


        //public void DecideInitialTransformation()
        //{
        //    Transformation = new ProTransformation(Point.Empty, int.MaxValue);
        //}

        /// <summary>
        /// 用于初始显示的时候设置合适的scale
        /// </summary>
        /// <returns></returns>
        private bool SetFitScale()
        {
            if (Image == null)
                return false;
            var fitScale = CalcFitScale();
            Transformation = Transformation.SetScale(fitScale);
            return true;
        }

        private float CalcFitScale()
        {
            if (Image == null)
                return -1.0f;
            var fitScale = Math.Max(
                (double)Image.Width / ClientRectangle.Width,
                (double)Image.Height / ClientRectangle.Height); //刚好适应picturebox大小的scale 
            return (float)fitScale;
        }

    }
}