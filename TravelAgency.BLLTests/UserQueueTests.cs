using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.BLL.Tests
{
    [TestClass()]
    public class UserQueueTests
    {
        [TestMethod()]
        public void GetAvailableUserTest()
        {
            for (int i = 0; i != 7; ++i)
            {
                BLL.UserQueue userQueue = new UserQueue();
                var model = userQueue.GetAvailableUser();
                if (model == null)
                {
                    MessageBox.Show("当前无可用用户!");
                    return;
                }
                MessageBox.Show(string.Format("得到一个可用用户:{0},{1}", model.WorkId, model.UserName));
            }
        }
    }
}