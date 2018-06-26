using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            Dictionary<string, int> set = new Dictionary<string, int>();
            for (int i = 0; i < 100; ++i)
            {
                var user = new DAL.WorkerQueue().GetNextWorker();

                string username = user.UserName;
                Console.WriteLine(username);
                if (set.ContainsKey(username))
                    set[username]++;
                else
                    set.Add(username, 1);
            }
        }
        [TestMethod()]
        public void TestTset()
        {
            int c = Color.FromArgb(234, 242, 251).ToArgb();
        }
    }
}