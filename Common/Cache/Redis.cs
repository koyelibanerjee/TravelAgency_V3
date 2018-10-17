using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StackExchange.Redis;

//using ServiceStack.CacheAccess;
//using ServiceStack.Redis;

namespace TravelAgency.Common.Cache
{
    public class Redis
    {
        //public static readonly IRedisClient Client = null;

        //static Redis()
        //{
        //    string url = AppSettingHandler.ReadConfig("RedisServer");
        //    if (string.IsNullOrEmpty(url))
        //    {
        //        url = "192.168.128.200:6379";
        //        AppSettingHandler.AddConfig("RedisServer", "192.168.128.200:6379");
        //    }
        //    var strs = url.Split(':');
        //    Client = new RedisClient(strs[0], int.Parse(strs[1]));
        //}

        private static ConnectionMultiplexer redis = null;
        public static IDatabase Client = null;

        static Redis()
        {
            string url = AppSettingHandler.ReadConfig("RedisServer");
            if (string.IsNullOrEmpty(url))
            {
                url = "192.168.128.200:6379";
                AppSettingHandler.AddConfig("RedisServer", "192.168.128.200:6379");
            }
            redis = ConnectionMultiplexer.Connect(url);
            Client = redis.GetDatabase();
        }
    }
}
