using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Model.Cache
{
    public class EditingVisa
    {
        public string Visa_Id { get; set; }

        public string GroupNo { get; set; }

        public string EditingPerson { get; set; }
        public string EditingWorkId { get; set; }

        public DateTime StartEditTime { get; set; }

    }
}
