using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TravelAgency.Common;

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
    private Point? _clickedPoint;
    private ProTransformation _transformation;
    private bool _firstSetScale = true;
    public ProTransformation Transformation
    {
        set
        {
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
    }

    /// <summary>
    /// 修正大小，防止太大或者太小
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private ProTransformation FixTranslation(ProTransformation value)
    {
        double maxScale = CalcFitScale(); //最大缩小10倍
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
        var pos1 = transformation.ConvertToIm(e.Location);
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

    private void OnMouseUp(object sender, MouseEventArgs mouseEventArgs)
    {
        _clickedPoint = null;
        Cursor = System.Windows.Forms.Cursors.Default;
    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (_clickedPoint == null)
            return;
        var p = _transformation.ConvertToIm((Size)e.Location);
        Transformation = _transformation.SetTranslate(_clickedPoint.Value - p);
        Invalidate();
    }

    private void OnMouseDown(object sender, MouseEventArgs e)
    {
        Focus();
        Cursor = System.Windows.Forms.Cursors.SizeAll;
        _clickedPoint = _transformation.ConvertToIm(e.Location);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Image == null)
            return;
        if (_firstSetScale && SetFitScale())
            _firstSetScale = false;
        var imRect = Transformation.ConvertToIm(ClientRectangle);
        Console.WriteLine(imRect.Width + "," + imRect.Height);
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
