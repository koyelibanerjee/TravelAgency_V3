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
    public class visa_copyTests
    {
        private DAL.visa_copy _dal = new DAL.visa_copy();

        [TestMethod()]
        public void ExistsTest()
        {
            Assert.IsTrue(_dal.Exists(new Guid("774C45B9-ED57-4CF6-863D-E51E919AB1F2")));
        }

        [TestMethod()]
        public void GetModelTest()
        {
            var model = _dal.GetModel(new Guid("774C45B9-ED57-4CF6-863D-E51E919AB1F2"));
            Assert.IsTrue(model.Name == "王虹入");
            //Assert.IsTrue(model.IsUrgent == false);
            //Assert.IsTrue(model.DepartmentId.Equals(Guid.Parse("0B37E284-8736-4C9A-A3C4-949E88E3FD1A")));
            //Assert.IsTrue(!model.GroupPrice.HasValue);
        }


        [TestMethod()]
        public void AddTest()
        {
            Model.visa_copy visaCopy = new Model.visa_copy();
            visaCopy.EntryTime = DateTime.Now;
            visaCopy.GroupNo = "aaaaaa";
            visaCopy.Number = 10;
            visaCopy.IsUrgent = true;
            visaCopy.Cost = 11;
            visaCopy.DepartmentId = new Guid("5D88E43E-7FDF-4AEE-B9D0-C0947DD17442");

            var id = _dal.Add(visaCopy);
            Assert.IsTrue(_dal.Exists(id));
        }



        [TestMethod()]
        public void DeleteTest()
        {

            Model.visa_copy visaCopy = new Model.visa_copy();
            var id = _dal.Add(visaCopy);

            Assert.IsTrue(_dal.Exists(id));


            _dal.Delete(id);
            Assert.IsTrue(!_dal.Exists(id));
        }



        [TestMethod()]
        public void UpdateTest()
        {
            Model.visa_copy model = new Model.visa_copy();
            var id = _dal.Add(model);
            Assert.IsTrue(_dal.Exists(id));

            model = _dal.GetModel(id);
            Guid guid = new Guid();
            DateTime datetime = DateTime.Now;
            model.Cost = 100;
            model.Sale_id = guid;
            model.WorkId = "10003";
            model.IsUrgent = true;
            model.EntryTime = datetime;

            _dal.Update(model);

            model = _dal.GetModel(id);

            Assert.IsTrue(model.Cost == 100);
            Assert.IsTrue(model.WorkId == "10003");
            Assert.IsTrue(model.Sale_id == guid);
            //Assert.IsTrue(DateTime.Equals(model.EntryTime, datetime));
            Assert.IsTrue(model.IsUrgent.Equals(true));

        }

        [TestMethod()]
        public void GetListTest()
        {
            var list = CreateTestData(10, "GetListTest2");
            var ds = _dal.GetList(" Name = '" + "GetListTest2" + "' ");
            Assert.IsTrue(ds.Tables[0].Rows.Count == 10);
            Clear(list);
        }

        [TestMethod()]
        public void DeleteListTest()
        {
            List<Guid> id_list = CreateTestData(10, "DeleteListTest2");

            Clear(id_list);
            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(!_dal.Exists(id_list[i]));
            }
        }



        [TestMethod()]
        public void GetRecordCountTest()
        {
            var id_list = CreateTestData(10, "GetRecordCountTest3");
            var ret = _dal.GetRecordCount(" Name = '" + "GetRecordCountTest3" + "' ");
            Assert.IsTrue(ret == 10);
            Clear(id_list);
        }

        [TestMethod()]
        public void GetListByPageTest()
        {
            Model.visa_copy model = new Model.visa_copy();
            string testId = "GetListByPageTest6";
            model.Name = testId;
            model.EntryTime = DateTime.Now;
            List<Guid> id_list = new List<Guid>();
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                id_list.Add(_dal.Add(model));
            }

            var ds = _dal.GetListByPage(" Name = '" + testId + "' ", "Name", 1, n);
            Assert.IsTrue(ds.Tables[0].Rows.Count == n);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Assert.IsTrue(_dal.DataRowToModel(ds.Tables[0].Rows[i]).Name == testId);
            }

            //清除数据
            Clear(id_list);
        }


        private List<Guid> CreateTestData(int testNum, string testCaseId)
        {
            Model.visa_copy model = new Model.visa_copy();
            model.Name = testCaseId;
            model.EntryTime = DateTime.Now;
            var id_list = new List<Guid>();
            for (int i = 0; i < testNum; i++)
            {
                id_list.Add(_dal.Add(model));
            }
            return id_list;
        }


        private void Clear(List<Guid> id_list)
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