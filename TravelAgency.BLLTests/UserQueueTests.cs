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
        BLL.UserQueue userQueueBll = new BLL.UserQueue();
        [TestMethod()]
        public void GetAvailableUserTest()
        {
            for (int i = 0; i != 7; ++i)
            {

                var model = userQueueBll.GetAvailableUser();
                if (model == null)
                {
                    MessageBox.Show("当前无可用用户!");
                    return;
                }
                MessageBox.Show(string.Format("得到一个可用用户:{0},{1}", model.WorkId, model.UserName));
            }
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Model.UserQueueItem model = new Model.UserQueueItem();
            model.IsBusy = false;
            model.WorkId = "10309";
            model.UserName = "吴思亭";
            model.CanAccept = true;
            userQueueBll.Update(model);
        }

        [TestMethod()]
        public void ChangeUserBusyStateTest()
        {
            userQueueBll.ChangeUserBusyState("10304", false);
        }

        [TestMethod()]
        public void ChangeUserCanAcceptStateTest()
        {
            userQueueBll.ChangeUserCanAcceptState("10304", false);
            userQueueBll.ChangeUserCanAcceptState("10304", true);
        }
    }
}