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
    public class OrdersLogsTests
    {
        private DAL.OrdersLogs _dal = new DAL.OrdersLogs();

        [TestMethod()]
        public void ExistsTest()
        {
            Assert.IsTrue(_dal.Exists(1));
        }

        [TestMethod()]
        public void GetModelTest()
        {
            var model = _dal.GetModel(1);
            Assert.IsTrue(model.UserName == "测试客服");
            //Assert.IsTrue(model.IsUrgent == false);
            //Assert.IsTrue(model.DepartmentId.Equals(Guid.Parse("0B37E284-8736-4C9A-A3C4-949E88E3FD1A")));
            //Assert.IsTrue(!model.GroupPrice.HasValue);
        }


        [TestMethod()]
        public void AddTest()
        {
            Model.OrdersLogs visaCopy = new Model.OrdersLogs();
            visaCopy.EntryTime = DateTime.Now;

            visaCopy.ActType = 1;

            var id = _dal.Add(visaCopy);
            Assert.IsTrue(_dal.Exists(id));
        }



        [TestMethod()]
        public void DeleteTest()
        {

            Model.OrdersLogs visaCopy = new Model.OrdersLogs();
            var id = _dal.Add(visaCopy);

            Assert.IsTrue(_dal.Exists(id));


            _dal.Delete(id);
            Assert.IsTrue(!_dal.Exists(id));
        }



        [TestMethod()]
        public void UpdateTest()
        {
            Model.OrdersLogs model = new Model.OrdersLogs();
            var id = _dal.Add(model);
            Assert.IsTrue(_dal.Exists(id));
            model = _dal.GetModel(id);
           
            model.WorkId = "10003";
            _dal.Update(model);

            model = _dal.GetModel(id);
            Assert.IsTrue(model.WorkId == "10003");

        }

        [TestMethod()]
        public void GetListTest()
        {
            var list = CreateTestData(10, "GetListTest3");
            var ds = _dal.GetList(" UserName = '" + "GetListTest3" + "' ");
            Assert.IsTrue(ds.Tables[0].Rows.Count == 10);
            Clear(list);
        }

        [TestMethod()]
        public void DeleteListTest()
        {
            List<int> id_list = CreateTestData(10, "DeleteListTest2");

            Clear(id_list);
            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(!_dal.Exists(id_list[i]));
            }
        }

        [TestMethod()]
        public void GetRecordCountTest()
        {
            var id_list = CreateTestData(10, "GetRecordCountTest5");
            var ret = _dal.GetRecordCount(" UserName = '" + "GetRecordCountTest5" + "' ");
            Assert.IsTrue(ret == 10);
            Clear(id_list);
        }

        [TestMethod()]
        public void GetListByPageTest()
        {
            Model.OrdersLogs model = new Model.OrdersLogs();
            string testId = "GetListByPageTest7";
            model.UserName = testId;
            model.EntryTime = DateTime.Now;
            List<int> id_list = new List<int>();
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                id_list.Add(_dal.Add(model));
            }

            var ds = _dal.GetListByPage(" UserName = '" + testId + "' ", "UserName", 1, n);
            Assert.IsTrue(ds.Tables[0].Rows.Count == n);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Assert.IsTrue(_dal.DataRowToModel(ds.Tables[0].Rows[i]).UserName == testId);
            }

            //清除数据
            Clear(id_list);
        }


        private List<int> CreateTestData(int testNum, string testCaseId)
        {
            Model.OrdersLogs model = new Model.OrdersLogs();
            model.UserName = testCaseId;
            model.EntryTime = DateTime.Now;
            var id_list = new List<int>();
            for (int i = 0; i < testNum; i++)
            {
                id_list.Add(_dal.Add(model));
            }
            return id_list;
        }


        private void Clear(List<int> id_list)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < id_list.Count; i++)
            {
                sb.AppendFormat("'{0}',", id_list[i].ToString());
            }

            string str_id_list = sb.ToString().TrimEnd(',');
            _dal.DeleteList(str_id_list);
        }
    }
}