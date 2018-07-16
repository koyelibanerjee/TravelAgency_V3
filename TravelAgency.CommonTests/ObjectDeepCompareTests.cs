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
    public class ObjectDeepCompareTests
    {
        [TestMethod()]
        public void ComparePropertiesTest()
        {
            TravelAgency.BLL.Visa visa = new BLL.Visa();
            var item1 = visa.GetModel(Guid.Parse("4DD4384A-7800-4C42-BFF1-B8DA652C2CE5"));
            var item2 = visa.GetModel(Guid.Parse("4DD4384A-7800-4C42-BFF1-B8DA652C2CE5"));

            Assert.AreNotEqual(item1, item2);

            Assert.AreEqual(ObjectDeepCompare.CompareObjectsDeep(item1, item2, typeof(Model.Visa)), true);
            item2.IsUrgent = item2.IsUrgent.HasValue ? !item2.IsUrgent : true;
            Assert.IsFalse(ObjectDeepCompare.CompareObjectsDeep(item1, item2, typeof(Model.Visa)));

        }

        [TestMethod()]
        public void CompareListDeepTest()
        {
            TravelAgency.BLL.Visa visa = new BLL.Visa();
            var list1 = visa.GetListByPage(1, 10, "");
            var list2 = visa.GetListByPage(1, 10, "");
            Assert.IsTrue(ObjectDeepCompare.CompareListDeep(list1,list2,typeof(Model.Visa)));
            var item2 = list1[0];
            item2.IsUrgent = item2.IsUrgent.HasValue ? !item2.IsUrgent : true;
            Assert.IsFalse(ObjectDeepCompare.CompareListDeep(list1, list2, typeof(Model.Visa)));
        }
    }
}