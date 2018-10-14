using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceStack.CacheAccess;
using TravelAgency;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RedisDemo
{

    class Program
    {
        //static RedisClient client = new RedisClient("127.0.0.1", 6379);
        static readonly IRedisClient _client = new RedisClient("192.168.174.134", 6379);
        private static TravelAgency.BLL.VisaInfo _bllVisaInfo = new TravelAgency.BLL.VisaInfo();
        private static TravelAgency.BLL.Visa _bllVisa = new TravelAgency.BLL.Visa();

        static void Main(string[] args)
        {
            //testModel();
            //testList();
            testExpireTime();
            Console.WriteLine("complete");
            Console.Read();
        }

        static void testModel()
        {
            var model = _bllVisaInfo.GetModel(new Guid("E3DDD58D-0D8C-455C-987D-43F16B3658F1"));
            //_client.Set()
            _client.Set(model.VisaInfo_id.ToString(), model);
            var model1 = _client.Get<TravelAgency.Model.VisaInfo>(model.VisaInfo_id.ToString());
            _client.Remove("e3ddd58d-0d8c-455c-987d-43f16b3658f1");
            var model2 = _client.Get<TravelAgency.Model.VisaInfo>(model.VisaInfo_id.ToString());
            //model2==null
            Console.WriteLine("获取数据:{0}", model1.Birthday);
        }

        static void testList()
        {
            //var list = _bllVisaInfo.GetModelList("visa_id = '" + "ae827177-8490-4735-9aa5-17fb7d8a2921'");
            //var list = _bllVisaInfo.GetModelList("");
            var list = _bllVisa.GetModelList("");

            //_client.Set("ae827177-8490-4735-9aa5-17fb7d8a2921", list);
            //var list1 = _client.Get<List<TravelAgency.Model.VisaInfo>>("ae827177-8490-4735-9aa5-17fb7d8a2921");

            _client.SetAll(list.ToDictionary((v) => { return "visa:" + v.Visa_id.ToString(); }));


            //_client.GetAll<string, TravelAgency.Model.VisaInfo>();

        }

        static void testList2()
        {

        }

        [TestMethod]
        static void testExpireTime()
        {
            _client.Set("key1", "value1", TimeSpan.FromSeconds(5));
            var value1 = _client.Get<string>("key1");
            Assert.IsTrue(value1 == "value1");
            TimeSpan s = _client.GetTimeToLive("key1");
            Thread.Sleep(5000);
            value1 = _client.Get<string>("key1");
            Assert.IsTrue(value1 == null);
            //s = _client.GetTimeToLive("key1").TotalMilliseconds<0;
        }



    }
}
