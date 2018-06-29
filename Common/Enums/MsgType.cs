using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common.Enums
{
    public class MsgType
    {
        public static  List<string> List = new List<string>
        {
             type00Normal,type01Refund
        };  
        public const string type00Normal = "普通";
        public const string type01Refund = "退款申请";
    }
}
