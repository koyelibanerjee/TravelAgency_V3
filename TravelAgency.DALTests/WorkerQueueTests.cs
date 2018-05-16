using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DAL.Tests
{
    [TestClass()]
    public class WorkerQueueTests
    {
        [TestMethod()]
        public void GetNextWorkerTest()
        {
            for(int i = 0; i < 10; ++i)
            {
                int j = new Random().Next(1, 3);
            }
        }
    }
}