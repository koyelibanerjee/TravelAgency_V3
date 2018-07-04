using System.Collections.Generic;

namespace TravelAgency.Model.Enums
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
