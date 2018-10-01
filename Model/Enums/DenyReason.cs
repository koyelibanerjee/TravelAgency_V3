using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Model.Enums
{
   public class DenyReason
   {
       public static List<string> ValueList
       {
           get { return _valueList; }
       }

       private static List<string> _valueList = new List<string>
       {
           "过度维权","滞留倾向","滞留不归","滞留国家"
       };
   }
}
