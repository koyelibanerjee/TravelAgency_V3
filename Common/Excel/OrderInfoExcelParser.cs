using DevComponents.DotNetBar;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Common.PictureHandler;

namespace TravelAgency.Common.Excel
{
    public class OrderInfoExcelParser
    {
        private static readonly BLL.OrderInfo _bllOrderInfo = new BLL.OrderInfo();
        public enum ExcelType
        {
            Type01_DaZhong,
            Type02_FeiZhu,
            Type03_MaYi,
            Type04_XieCheng
        }

        public static int ParseExcel(string filename, ExcelType excelType)
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
                    return 0;
                }

                //上传文件，生成记录
                excelModel = new OrderExcelHandler().UploadOrderExcel(filename);
            }
            catch (Exception)
            {
                MessageBoxEx.Show("文件占用，请关闭Excel后再打开文件!");
                return 0;
            }
            List<Model.OrderInfo> modelList = new List<Model.OrderInfo>();
            if (excelType == ExcelType.Type01_DaZhong)
                modelList = GetModelFromExcelDazhong(wkbook);


            //全部添加excelid记录 //执行添加
            int res = 0;
            foreach (var item in modelList)
            {
                item.OrderExcelId = excelModel.Id;
                item.EntryTime = DateTime.Now;
                item.OperatorName = GlobalUtils.LoginUser.UserName;
                item.OperatorWorkId = GlobalUtils.LoginUser.WorkId;
                item.OrderInfoState = Enums.OrderInfo_OrderInfoState.valueKeyMap["未校验"];
                res += _bllOrderInfo.Add(item) == 0 ? 0 : 1;
            }
            return res;
        }

        /// <summary>
        /// 只拿到四项信息
        /// </summary>
        /// <param name="wbBook"></param>
        /// <returns></returns>
        private static List<Model.OrderInfo> GetModelFromExcelDazhong(IWorkbook wbBook)
        {
            //2.创建工作表对象
            ISheet sheet = wbBook.GetSheet("应付金额");
            List<Model.OrderInfo> res = new List<Model.OrderInfo>();

            List<string> keyList = new List<string> { "确认时间", "支付时间", "美团供应商ID", "产品ID",
                "产品类型", "客人姓名", "出发日期", "份数", "结算方式", "佣金比例" };
            

            for (int i = 1; i <= sheet.LastRowNum; ++i) //第0行是表头
            {
                try
                {
                    var row = sheet.GetRow(i); //每行两个model,一个佣金，一个收入金额
                    Model.OrderInfo modelPay = new Model.OrderInfo();
                    Model.OrderInfo modelRec = new Model.OrderInfo();


                    modelPay.OrderTime = DateTime.Parse(row.GetCell(0)?.StringCellValue);
                    modelRec.OrderTime = DateTime.Parse(row.GetCell(0)?.StringCellValue);
                    modelPay.OrderNo = row.GetCell(3)?.StringCellValue;
                    modelRec.OrderNo = row.GetCell(3)?.StringCellValue;
                    modelPay.ProductName = row.GetCell(6)?.StringCellValue;
                    modelRec.ProductName = row.GetCell(6)?.StringCellValue;
                    modelPay.Amount = -1 * DecimalHandler.Parse(row.GetCell(13)?.StringCellValue); //佣金乘以-1
                    modelRec.Amount = DecimalHandler.Parse(row.GetCell(14)?.StringCellValue); //佣金乘以-1
                    modelPay.OrderType = Enums.OrderInfo_OrderType.valueKeyMap["佣金"];
                    modelRec.OrderType = Enums.OrderInfo_OrderType.valueKeyMap["收入"];
                    modelRec.PaymentPlatform = Enums.OrderInfo_PaymentPlatform.valueKeyMap["大众"];
                    modelPay.PaymentPlatform = Enums.OrderInfo_PaymentPlatform.valueKeyMap["大众"];

                    List<string> valueList = new List<string>();
                    valueList.Add(row.GetCell(1)?.StringCellValue);
                    valueList.Add(row.GetCell(2)?.StringCellValue);
                    valueList.Add(row.GetCell(4)?.StringCellValue);
                    valueList.Add(row.GetCell(5)?.StringCellValue);
                    valueList.Add(row.GetCell(7)?.StringCellValue);
                    valueList.Add(row.GetCell(8)?.StringCellValue);
                    valueList.Add(row.GetCell(9)?.StringCellValue);
                    valueList.Add(row.GetCell(10)?.StringCellValue);
                    valueList.Add(row.GetCell(11)?.StringCellValue);
                    valueList.Add(row.GetCell(12)?.StringCellValue);


                    string extraData = JsonHandler.GenJson(keyList, valueList);
                    modelPay.ExtraData = extraData;
                    modelRec.ExtraData = extraData;

                    
                    res.Add(modelPay);
                    res.Add(modelRec);
                }
                catch (Exception e)
                {
                    MessageBoxEx.Show("第" + (i + 1) + "行数据有误");
                }
            }
            //return res.Count == 0 ? null : res;

            return res;
        }
    }
}
