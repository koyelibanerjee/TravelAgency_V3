using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;

namespace TravelAgency.Common.Excel
{
    public class NOPIHelper
    {

        public static void InsertRow(NPOI.SS.UserModel.ISheet sheet, int insertRowIdx, NPOI.SS.UserModel.IRow row)
        {
            sheet.ShiftRows(insertRowIdx,sheet.LastRowNum,1);
        }



    }
}
