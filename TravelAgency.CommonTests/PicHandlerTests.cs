using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common.Tests
{
    [TestClass()]
    public class PicHandlerTests
    {
        [TestMethod()]
        public void DrawImageInCenterTest()
        {
            //Assert.Fail();

            Bitmap img1 = new Bitmap(800, 400);
            Bitmap img2 = new Bitmap(600, 200);
            Graphics g = Graphics.FromImage(img2);
            g.FillRectangle(Brushes.White, 0, 0, (float)img2.Width, (float)img2.Height);
            g = Graphics.FromImage(img1);
            g.FillRectangle(Brushes.Black, 0, 0, (float)img1.Width, (float)img1.Height);



            PicHandler.DrawImageInCenter(img1, img2);
            img1.Save("b.jpg");
        }

        [TestMethod()]
        public void MakeThumbnailTest()
        {
            //string filename = Image.FromFile();
            //PicHandler.MakeThumbnail(@"I:\GaoPaiPics\20171227\20171227134536.jpg",
            //@"I:\GaoPaiPics\20171227\thumb_20171227134536.jpg", 97, 0, "W");

            PicHandler.MakeThumbnail(@"I:\GaoPaiPics\20171227\20171227160402.jpg",
    @"I:\GaoPaiPics\20171227\thumb_20171227160402.jpg",GlobalUtils.ThumbNailRatio);

        }
    }
}