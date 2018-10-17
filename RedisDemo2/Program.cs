using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            IDatabase db = redis.GetDatabase();
            //db.KeyExpire()
            db.StringSet("1", "abcv");

            var value = db.StringGet("1");
            var ret = db.KeyExpire("1", TimeSpan.FromMinutes(1));
            var expTime = db.StringGetWithExpiry("1");
            var expTime1 = db.StringGetWithExpiry("2");


            //expTime.Expiry.Value.TotalMilliseconds>0
        }
    }
}
