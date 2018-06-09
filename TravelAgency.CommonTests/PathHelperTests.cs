using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common.Tests
{
    [TestClass()]
    public class PathHelperTests
    {
        [TestMethod()]
        public void GetUserDesktopTest()
        {
            string path = PathHelper.GetUserDesktop();
        }
    }
}