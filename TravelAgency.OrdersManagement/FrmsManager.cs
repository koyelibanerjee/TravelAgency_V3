using System.Collections.Generic;
using System.Windows.Forms;

namespace TravelAgency.OrdersManagement
{
    public static class FrmsManager
    {
        public static List<Form> OpenedForms { get; set; }


        public static Form MainForm
        {
            get
            {
                if (OpenedForms.Count > 0)
                    return OpenedForms[0];
                else return null;
            }
        }
        static FrmsManager()
        {
            OpenedForms = new List<Form>();
        }

        public static void CloseAllForms()
        {
            for (int i = 0; i < OpenedForms.Count; i++)
            {
                //if(!OpenedForms[i].s)
                OpenedForms[i].Close();
            }
        }
    }
}