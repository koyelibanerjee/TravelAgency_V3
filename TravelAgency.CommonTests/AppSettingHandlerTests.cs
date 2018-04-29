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
    public class AppSettingHandlerTests
    {
        [TestMethod()]
        public void ReadConfigTest()
        {
            string value = AppSettingHandler.ReadConfig("FTPServer");

            value = AppSettingHandler.ReadConfig("FTPServer1");
        }

        [TestMethod()]
        public void AddConfigTest()
        {
            AppSettingHandler.AddConfig("test1", "abc");
            AppSettingHandler.AddConfig("test2", "abcd");
            AppSettingHandler.AddConfig("testyxptest", "abcde");
            string value = AppSettingHandler.ReadConfig("test1");
            value = AppSettingHandler.ReadConfig("test2");
            value = AppSettingHandler.ReadConfig("testyxptest");
        }

        [TestMethod()]
        public void ModifyConfigTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestStringLen()
        {
            string str = "订单号abc的";
            Assert.IsTrue(str.Length == 7);
        }

    }
}