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
    public class UserQueueTests
    {
        private readonly BLL.UserQueue _userQueue = new UserQueue();
        [TestMethod()]
        public void EnqueTest()
        {

        }

        [TestMethod()]
        public void PopTest()
        {

        }

        [TestMethod()]
        public void TopTest()
        {
            Model.UserQueueItem model = _userQueue.Top(UserQueue.QueueType.QueueLow);
            _userQueue.Pop(UserQueue.QueueType.QueueLow);
            _userQueue.Enque(UserQueue.QueueType.QueueLow,model);

        }
    }
}