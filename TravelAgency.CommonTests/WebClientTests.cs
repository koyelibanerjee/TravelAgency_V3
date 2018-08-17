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
    public class WebClientTests
    {
        [TestMethod()]
        public void GetDataTest()
        {
            string ret = new WebClient().GetHtml("http://www.httpbin.org/get");

            var data = new WebClient().GetData("http://www.httpbin.org/get");
            ret = System.Text.Encoding.Default.GetString(data);
        }

        [TestMethod()]
        public void PostTest()
        {
            string data = "{'test string':1,'b':a}";
            var ret = new WebClient().Post("http://www.httpbin.org/post", data);
        }
    }
}