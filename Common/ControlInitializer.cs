using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.Common
{
    public class ControlInitializer
    {
        public static void InitCombo(ComboBox cb, List<string> valueList,
            ComboBoxStyle style = ComboBoxStyle.DropDownList, int initIdx = 0)
        {
            cb.DropDownStyle = style;
            foreach (var item in valueList)
            {
                cb.Items.Add(item);
            }
            cb.SelectedIndex = initIdx;
        }

    }
}
