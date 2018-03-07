using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.Common.PictureHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common.PictureHandler.Tests
{
    [TestClass()]
    public class PassportPicHandlerTests
    {
        [TestMethod()]
        public void UploadPassportPicTest()
        {
            //PassportPicHandler.UploadPassportPic;
        }

        [TestMethod()]
        public void DeleteLocalPassportPicTest()
        {
            //PassportPicHandler.DeleteLocalPassportPic("12345", PassportPicHandler.PicType.Type01Normal);
            File.Delete("aaa.jpg");
        }
    }
}