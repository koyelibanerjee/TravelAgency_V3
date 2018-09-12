using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.Common
{
    public class SelectionKeeper
    {

        public static HashSet<string> GetSelectedGuids(DataGridView dgv, string colName)
        {
            HashSet<string> selRows = new HashSet<string>();
            for (int i = dgv.SelectedRows.Count - 1; i >= 0; i--)
                selRows.Add(dgv.SelectedRows[i].Cells[colName].Value.ToString());
            return selRows;
        }

        public static void GetSelectedPos(DataGridView dgv, out int rowIdx, out int colIdx)
        {
            rowIdx = dgv.FirstDisplayedScrollingRowIndex;
            colIdx = dgv.FirstDisplayedScrollingColumnIndex;
        }

        public static void RestoreSelection(HashSet<string> selRows, DataGridView dgv, string colName)
        {
            if (selRows.Count > 0 && dgv.Rows.Count > 0) //如果之前有选中现在就恢复之前的
            {
                dgv.ClearSelection();
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    string guid = dgv.Rows[i].Cells[colName].Value.ToString();
                    if (selRows.Contains(guid))
                        dgv.Rows[i].Selected = true;
                }
            }
        }

        public static void RestoreSelectedPos(DataGridView dgv, int rowIdx, int colIdx)
        {
            if (dgv.Rows.Count > rowIdx && rowIdx >= 0)
                dgv.FirstDisplayedScrollingRowIndex = rowIdx;
            if (dgv.Columns.Count > colIdx && colIdx >= 0)
                dgv.FirstDisplayedScrollingColumnIndex = colIdx;
        }


    }
}
