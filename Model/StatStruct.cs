using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Model
{
    public class StatStruct
    {
        public string Country { get; set; }
        public string DepartureType { get; set; }
        public decimal CommisionSingle { get; set; }
        public int Count { get; set; }
        public decimal CommisionTotal { get; set; }
    }
}
