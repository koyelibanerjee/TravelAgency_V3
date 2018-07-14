using System.Collections.Generic;

namespace TravelAgency.Model.Enums
{
    public class MsgType
    {
        public static  List<string> List = new List<string>
        {
             Type00Normal,Type01Refund
        };  
        public const string Type00Normal = "普通";
        public const string Type01Refund = "退款申请";
    }
}
