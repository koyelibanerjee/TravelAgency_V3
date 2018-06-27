using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common.Enums
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
    }
}
