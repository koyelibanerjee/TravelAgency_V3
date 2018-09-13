using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using TravelAgency.BLL.FTPFileHandler;
using TravelAgency.Common;

namespace TravelAgency.BLL.Excel
{
    public class ExcelParser
    {

        public static List<string> ParseExcelGetGroupNos(string filename)
        {
            //1.创建工作簿对象
            IWorkbook wkbook = null;
            Model.OrderExcel excelModel = null;
            try
            {
                if (Path.GetExtension(filename).Equals(".xls"))
                {
                    wkbook = new HSSFWorkbook(new FileStream(filename, FileMode.Open));
                }
                else if (Path.GetExtension(filename).Equals(".xlsx"))
                {
                    wkbook = new XSSFWorkbook(new FileStream(filename, FileMode.Open));
                }
                else
                {
                    MessageBoxEx.Show("打开文件错误，请重试!");
                    return null;
                }

                //上传文件，生成记录
                excelModel = new OrderExcelHandler().UploadOrderExcel(filename);
            }
            catch (Exception)
            {
                MessageBoxEx.Show("文件占用，请关闭Excel后再打开文件!");
                return null;
            }

            ISheet sheet = wkbook.GetSheetAt(0);
            HashSet<string> set = new HashSet<string>();
            List<string> list = new List<string>();
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                string str = row.GetCell(0).StringCellValue;
                if (str == "团号") //跳过表头
                    continue;
                if (!set.Contains(str))
                {
                    set.Add(str);
                    list.Add(str);
                }
            }
            return list;
        }



    }
}
