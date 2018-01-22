using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.Common.PinyinParse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common.PinyinParse.Tests
{
    [TestClass()]
    public class PinYinConverterHelpTests
    {
        [TestMethod()]
        public void GetTotalPingYinTest()
        {
            //Assert.Fail();

            var list = PinYinConverterHelp.GetTotalPingYin("詹天佑").TotalPingYin;



        }
    }
}