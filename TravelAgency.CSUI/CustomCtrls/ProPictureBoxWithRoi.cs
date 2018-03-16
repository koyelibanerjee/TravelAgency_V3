using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelAgency.CSUI.CustomCtrls
{
    public class ProPictureBoxWithRoi : ProPictureBox
    {

        private Point _startPoint; //画框的起始点
        //private Point _endPoint;//画框的结束点<br>bool _bLbtnDown;//判断是否绘制<br>Rectangel _rect;
        private bool _bLbtnDown = false;
        private Rectangle _rect;
        private bool _bSetRoiIng = false;
        public Image RoiImage { get; set; }
        private Action _updateDel;

        public void AddUpdateDel(Action del)
        {
            _updateDel += del;
        }

        public void StartSetRoi()
        {
            this._bSetRoiIng = true;
            this.Cursor = Cursors.Cross;
        }

        public void EndSetRoi()
        {
            this._bSetRoiIng = false;
            this.Cursor = Cursors.Default;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (_bSetRoiIng)
            {
                _startPoint = e.Location;
                //this.Invalidate();
                _bLbtnDown = true;
            }
            else { base.OnMouseDown(e); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_bSetRoiIng && _bLbtnDown)
                if (this.Image != null && _rect != null && _rect.Width > 0 && _rect.Height > 0)
                    e.Graphics.DrawRectangle(new Pen(Color.Red, 3), _rect); //重新绘制颜色为红色
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!_bSetRoiIng)
                base.OnMouseUp(e);
            else
            {
                _bLbtnDown = false; //结束绘制
                                    //返回选中区域的图像
                                    //RoiImage = Image.FROM
                                    //创建新图位图
                if (this.Image != null && _rect.Width > 0 && _rect.Height > 0)
                {
                    int width = (int)(_rect.Width * GetCurrentScale());
                    int height = (int)(_rect.Height * GetCurrentScale());
                    //Point locPoint = e.Location;
                    Point locPoint = new Point(_rect.X + _rect.Width, _rect.Y + _rect.Height); //从rect来获取就始终能获取到右下角的点
                    locPoint.X -= _rect.Width;
                    locPoint.Y -= _rect.Height;
                    Point location = GetRealMousePosition(locPoint);

                    //Console.WriteLine(location);
                    Rectangle rectDest = new Rectangle(0, 0, width, height);
                    Rectangle realRect = new Rectangle(location, new Size(width, height));
                    Bitmap bitmap = new Bitmap(width, height);
                    //创建作图区域
                    Graphics graphic = Graphics.FromImage(bitmap);
                    //截取原图相应区域写入作图区
                    graphic.DrawImage(this.Image, rectDest, realRect,
                        GraphicsUnit.Pixel);

                    //graphic.DrawImage(,,);
                    //从作图区生成新图
                    RoiImage = Image.FromHbitmap(bitmap.GetHbitmap());
                    _updateDel?.Invoke();
                }
            }
        }

        protected override void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_bSetRoiIng && _bLbtnDown)
            {
                if (e.Button != MouseButtons.Left) //判断是否按下左键
                    return;
                Point tempEndPoint = e.Location; //记录框的位置和大小
                _rect.Location = new Point(
                    Math.Min(_startPoint.X, tempEndPoint.X),
                    Math.Min(_startPoint.Y, tempEndPoint.Y));
                _rect.Size = new Size(
                    Math.Abs(_startPoint.X - tempEndPoint.X),
                    Math.Abs(_startPoint.Y - tempEndPoint.Y));
                this.Invalidate();
            }
            else
            {
                base.OnMouseMove(sender, e);
            }
        }
    }
}
