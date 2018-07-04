using System.Collections.Generic;

namespace TravelAgency.Model.Enums
{
    public class RefundState
    {
       public static  List<string> List = new List<string>
       {
          "未申请",
          "待确认",
          "退款中",
          "完成退款",
          "拒绝退款" 
       };
        public const string Type00NotApply = "未申请";
        public const string Type01NotConfirm = "待确认";
        public const string Type02InProcess = "退款中";
        public const string Type03Complete= "完成退款";
        public const string Type04Refuse= "拒绝退款";
    }
}
