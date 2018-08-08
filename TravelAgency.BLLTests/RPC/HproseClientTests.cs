using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.BLL.RPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL.RPC.Tests
{
    [TestClass()]
    public class HproseClientTests
    {
        [TestMethod()]
        public void UploadImageTest()
        {
            HproseClient.UploadImage(HproseClient.ImageType.type01Passport, "I:/My Documents/My Pictures/dual_monitor_wallpapers_geralt&ciri_pack_left_EN.png","aaaa1");
        }
    }
}