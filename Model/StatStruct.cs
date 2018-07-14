using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Model
{
    public class StatStruct_Sale
    {
        public string Country { get; set; }
        public int Count1 { get; set; } //一类提成数量
        public decimal Commision1 { get; set; }

        public int Count2 { get; set; } //二类提成数量
        public decimal Commision2 { get; set; }

        public int Count3 { get; set; } //三类提成数量
        public decimal Commision3 { get; set; }

        public int CountDirect { get; set; } //直客提成数量
        public decimal CommisionDirect { get; set; }
        public decimal CommisionTotal { get; set; }
    }
}
