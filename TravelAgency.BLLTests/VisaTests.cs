using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL.Tests
{
    [TestClass()]
    public class VisaTests
    {
        [TestMethod()]
        public void CopyVisaTest()
        {
            BLL.Visa bll = new Visa();
            var model = bll.GetModel(Guid.Parse("0B3F8CDF-038D-402C-9405-0D2989A58436"));
            var copyModel = bll.CopyVisa(model);
            Assert.AreEqual(model.GroupNo + "_2", copyModel.GroupNo);

            bll.Add(copyModel);
            copyModel = bll.CopyVisa(model);
            Assert.AreEqual(model.GroupNo + "_3", copyModel.GroupNo);
        }
    }
}