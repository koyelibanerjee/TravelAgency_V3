using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.Common
{
    public class CtrlParser
    {
        public static string Parse2String(Control txt)
        {
            string trimText = txt.Text.Trim();
            return trimText == "" ? null : trimText;
        }

        public static int? Parse2Int(Control txt)
        {
            string trimText = txt.Text.Trim();
            int? res = null;

            if (trimText != "")
            {
                try
                {
                    res = int.Parse(trimText);
                }
                catch (Exception)
                {

                }
            }
            return res;
        }

        public static decimal? Parse2Decimal(Control txt)
        {
            string trimText = txt.Text.Trim();
            decimal? res = null;

            if (trimText != "")
            {
                try
                {
                    res = decimal.Parse(trimText);
                }
                catch (Exception)
                {

                }

            }
            return res;
        }

        public static DateTime? Parse2Datetime(Control txt)
        {
            string trimText = txt.Text.Trim();
            DateTime? res = null;

            if (trimText != "")
            {
                try
                {
                    res = DateTime.Parse(trimText);
                }
                catch (Exception)
                {

                }

            }
            return res;
        }


    }
}
