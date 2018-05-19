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
    public class OrdersTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Model.Orders model = new Model.Orders();

            model.MoneyType = "aaa";
            model.OrderNo = "12345";
            new BLL.Orders().Add(model);

        }

        [TestMethod]
        public void GetModelTest()
        {
            Model.Orders model = new BLL.Orders().GetModel(6);

            model.GuestEMail = "abcde";
            new BLL.Orders().Update(model);

        }

    }
}