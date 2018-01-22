using System.Security.AccessControl;

namespace TravelAgency.Model
{
    public class PersonalStat
    {
        public string UserName { get; set; }
        public string WorkId { get; set; }
        public int Type00Count { get; set; }
        public int Type01Count { get; set; }
        public int Type02Count { get; set; }
        public int Type03Count { get; set; }
        public int Type04Count { get; set; }

        public int Count
        {
            get
            {
                return Type00Count + Type01Count + Type02Count + Type03Count + Type04Count;
            }
        }

    }
}