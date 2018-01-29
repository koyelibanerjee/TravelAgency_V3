using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Model
{
    public class CommissionModel
    {
        public string Type { get; set; }

        public int Type00ScanedIn { get; set; }
        public int Type02TypeInData { get; set; }
        public int Type05SendSubmission { get; set; }
        public int Type06GetSubmission { get; set; }

        public int Type07AccompanySubmission { get; set; }
        public int Type08Plan { get; set; }
    }
}
