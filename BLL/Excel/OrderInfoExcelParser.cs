﻿using System;
using System.Collections.Generic;
using System.IO;
using DevComponents.DotNetBar;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using TravelAgency.BLL.FTPFileHandler;
using TravelAgency.Common;

namespace TravelAgency.BLL.Excel
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
            if (excelType == ExcelType.Type03_MaYi)
                modelList = GetModelFromExcelFengWo(wkbook);

            if (excelType == ExcelType.Type04_XieCheng)
                modelList = GetModelFromExcelXieCheng(wkbook);
            if (excelType == ExcelType.Type02_FeiZhu)
                modelList = GetModelFromExcelFeiZhu(wkbook);

            //全部添加excelid记录 //执行添加
            int res = 0;
            foreach (var item in modelList)
            {
                item.OrderExcelId = excelModel.Id;
                item.EntryTime = DateTime.Now;
                item.OperatorName = GlobalUtils.LoginUser.UserName;
                item.OperatorWorkId = GlobalUtils.LoginUser.WorkId;
                item.OrderInfoState = Enums_OrderInfo_OrderInfoState.valueKeyMap["未校验"];
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

            var headerRow = sheet.GetRow(0); //表头
            List<string> keyList = GetRowStringValueList(headerRow);

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
                    modelPay.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["佣金"];
                    modelRec.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["收入"];
                    modelRec.PaymentPlatform = Enums_OrderInfo_PaymentPlatform.valueKeyMap["大众"];
                    modelPay.PaymentPlatform = Enums_OrderInfo_PaymentPlatform.valueKeyMap["大众"];

                    string extraData = JsonHandler.GenJson(keyList, GetRowStringValueList(row));
                    modelPay.ExtraData = extraData;
                    modelRec.ExtraData = extraData;


                    res.Add(modelPay);
                    res.Add(modelRec);
                }
                catch (Exception )
                {
                    MessageBoxEx.Show("第" + (i + 1) + "行数据有误");
                }
            }
            //return res.Count == 0 ? null : res;

            return res;
        }

        /// <summary>
        /// 只拿到四项信息
        /// </summary>
        /// <param name="wbBook"></param>
        /// <returns></returns>
        private static List<Model.OrderInfo> GetModelFromExcelFeiZhu(IWorkbook wbBook)
        {
            //2.创建工作表对象
            ISheet sheet = wbBook.GetSheetAt(0);
            List<Model.OrderInfo> res = new List<Model.OrderInfo>();

            var headerRow = sheet.GetRow(4); //表头
            List<string> keyList = GetRowStringValueList(headerRow);
            int skipNum = 0;
            for (int i = 5; i <= sheet.LastRowNum; ++i) //从第6行开始才是数据
            {
                try
                {
                    var row = sheet.GetRow(i); //每行两个model,一个佣金，一个收入金额
                    var strOrderNoCellValue = row.GetCell(2).StringCellValue;
                    Model.OrderInfo orderModel = new Model.OrderInfo();

                    if (strOrderNoCellValue.StartsWith("T200P"))
                    {
                        orderModel.OrderNo = strOrderNoCellValue.Remove(0, 5).TrimEnd();
                        decimal rcvNum = DecimalHandler.Parse(row.GetCell(6).NumericCellValue.ToString());
                        decimal payNum = DecimalHandler.Parse(row.GetCell(7).NumericCellValue.ToString());
                        if (rcvNum > 0 && payNum == 0)
                        {
                            orderModel.Amount = rcvNum;
                            orderModel.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["收入"];
                        }
                        else if (rcvNum == 0 && payNum < 0)
                        {
                            orderModel.Amount = payNum;
                            var remark = row.GetCell(11)?.StringCellValue;
                            if (remark.Contains("售后退款"))
                            {
                                orderModel.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["退款"];
                            }
                            else if (remark.Contains("信用卡支付服务费"))
                            {
                                orderModel.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["其他"];
                            }
                            else if (remark.Contains("淘宝客佣金代扣款"))
                            {
                                orderModel.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["佣金"];
                            }
                            else
                            {
                                throw new Exception("解析单元格出现错误@1!!!");
                            }
                        }
                        else
                        {
                            throw new Exception("解析单元格出现错误@2!!!");
                        }

                    }
                    else if (strOrderNoCellValue.StartsWith("T10000P"))
                    {
                        orderModel.OrderNo = strOrderNoCellValue.Remove(0, 7).TrimEnd();
                        decimal rcvNum = DecimalHandler.Parse(row.GetCell(6).NumericCellValue.ToString());
                        decimal payNum = DecimalHandler.Parse(row.GetCell(7).NumericCellValue.ToString());
                        if (rcvNum > 0 && payNum == 0)
                        {
                            orderModel.Amount = rcvNum;
                            orderModel.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["收入"];
                        }
                        else if (rcvNum == 0 && payNum < 0)
                        {
                            orderModel.Amount = payNum;
                            orderModel.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["其他"];
                        }
                        else
                        {
                            throw new Exception("解析单元格出现错误@4!!!");
                        }
                    }
                    else if (strOrderNoCellValue.StartsWith("HJCOM"))
                    {

                        var remark = row.GetCell(11)?.StringCellValue.TrimEnd();
                        int idxFirstParent = remark.IndexOf('{');
                        int idxLastParent = remark.LastIndexOf('}');
                        orderModel.OrderNo = remark.Substring(idxFirstParent + 1, idxLastParent - idxFirstParent - 1);

                        decimal rcvNum = DecimalHandler.Parse(row.GetCell(6).NumericCellValue.ToString());
                        decimal payNum = DecimalHandler.Parse(row.GetCell(7).NumericCellValue.ToString());
                        if (rcvNum > 0 && payNum == 0)
                        {
                            orderModel.Amount = rcvNum;
                            orderModel.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["其他"];
                        }
                        else if (rcvNum == 0 && payNum < 0)
                        {
                            orderModel.Amount = payNum;
                            orderModel.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["佣金"];
                        }
                        else
                        {
                            throw new Exception("解析单元格出现错误@5!!!");
                        }
                    }
                    else if (strOrderNoCellValue.StartsWith("CAE"))
                    {
                        var remark = row.GetCell(11)?.StringCellValue.Trim();
                        int idx = remark.IndexOf("订单号");
                        orderModel.OrderNo = remark.Substring(idx + 3, remark.Length - (idx + 3));

                        decimal rcvNum = DecimalHandler.Parse(row.GetCell(6).NumericCellValue.ToString());
                        decimal payNum = DecimalHandler.Parse(row.GetCell(7).NumericCellValue.ToString());
                        if (rcvNum == 0 && payNum < 0)
                        {
                            orderModel.Amount = payNum;
                            orderModel.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["扣垂直积分"];
                        }
                        else
                        {
                            throw new Exception("解析单元格出现错误@1!!!");
                        }
                    }

                    else if (strOrderNoCellValue.StartsWith("aBe"))
                    {
                        var remark = row.GetCell(11)?.StringCellValue.Trim();
                        int idxFirstParent = remark.IndexOf('[');
                        int idxLastParent = remark.LastIndexOf(']');
                        orderModel.OrderNo = remark.Substring(idxFirstParent + 1, idxLastParent - idxFirstParent - 1);

                        decimal rcvNum = DecimalHandler.Parse(row.GetCell(6).NumericCellValue.ToString());
                        decimal payNum = DecimalHandler.Parse(row.GetCell(7).NumericCellValue.ToString());
                        if (rcvNum == 0 && payNum < 0)
                        {
                            orderModel.Amount = payNum;
                            orderModel.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["佣金"];
                        }
                        else
                        {
                            throw new Exception("解析单元格出现错误@8!!!");
                        }
                    }
                    else
                    {
                        ++skipNum;
                        continue;
                    }
                    orderModel.OrderTime = row.GetCell(4)?.DateCellValue;
                    orderModel.ProductName = row.GetCell(3)?.StringCellValue;
                    orderModel.PaymentPlatform = Enums_OrderInfo_PaymentPlatform.valueKeyMap["飞猪"];
                    string extraData = JsonHandler.GenJson(keyList, GetRowStringValueList(row));
                    orderModel.ExtraData = extraData;
                    res.Add(orderModel);
                }
                catch (Exception e)
                {
                    MessageBoxEx.Show("第" + (i + 1) + "行数据有误" + e.ToString());
                }
            }
            MessageBoxEx.Show("跳过" + skipNum + "条未知类型数据");
            return res;
        }

        /// <summary>
        /// 只拿到四项信息
        /// </summary>
        /// <param name="wbBook"></param>
        /// <returns></returns>
        private static List<Model.OrderInfo> GetModelFromExcelFengWo(IWorkbook wbBook)
        {
            //2.创建工作表对象
            ISheet sheet = wbBook.GetSheet("sheet");
            List<Model.OrderInfo> res = new List<Model.OrderInfo>();

            var headerRow = sheet.GetRow(0); //表头
            List<string> keyList = GetRowStringValueList(headerRow);
            for (int i = 1; i <= sheet.LastRowNum; ++i) //第0行是表头
            {
                try
                {
                    var row = sheet.GetRow(i); //每行两个model,一个佣金，一个收入金额
                    Model.OrderInfo modelPay = new Model.OrderInfo();
                    Model.OrderInfo modelRec = new Model.OrderInfo();

                    modelPay.OrderNo = row.GetCell(0)?.StringCellValue;
                    modelPay.ProductName = row.GetCell(1)?.StringCellValue;
                    modelPay.Amount = DecimalHandler.Parse(row.GetCell(9)?.NumericCellValue.ToString()); //佣金
                    modelPay.OrderTime = DateTime.Parse(row.GetCell(16)?.StringCellValue); //结算时间
                    modelPay.PaymentPlatform = Enums_OrderInfo_PaymentPlatform.valueKeyMap["蚂蜂"];
                    modelPay.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["佣金"];

                    modelRec.OrderNo = row.GetCell(0)?.StringCellValue;
                    modelRec.ProductName = row.GetCell(1)?.StringCellValue;
                    modelRec.Amount = DecimalHandler.Parse(row.GetCell(11)?.NumericCellValue.ToString()); //收入
                    modelRec.OrderTime = DateTime.Parse(row.GetCell(16)?.StringCellValue); //结算时间
                    modelRec.PaymentPlatform = Enums_OrderInfo_PaymentPlatform.valueKeyMap["大众"];
                    modelRec.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["收入"];



                    string extraData = JsonHandler.GenJson(keyList, GetRowStringValueList(row));
                    modelPay.ExtraData = extraData;
                    modelRec.ExtraData = extraData;


                    res.Add(modelPay);
                    res.Add(modelRec);
                }
                catch (Exception )
                {
                    MessageBoxEx.Show("第" + (i + 1) + "行数据有误");
                }
            }
            //return res.Count == 0 ? null : res;

            return res;
        }
        /// <summary>
        /// 结算价<0 无佣金  是退款
        //  结算价>0 有佣金>0  空或=0  没有佣金
        /// </summary>
        /// <param name="wbBook"></param>
        /// <returns></returns>
        private static List<Model.OrderInfo> GetModelFromExcelXieCheng(IWorkbook wbBook)
        {
            //2.创建工作表对象
            ISheet sheet = wbBook.GetSheetAt(0);
            List<Model.OrderInfo> res = new List<Model.OrderInfo>();

            var headerRow = sheet.GetRow(4); //表头
            List<string> keyList = GetRowStringValueList(headerRow);
            for (int i = 5; i <= sheet.LastRowNum; ++i) //第0行是表头
            {
                try
                {
                    var row = sheet.GetRow(i); //每行两个model,一个佣金，一个收入金额

                    string extraData = JsonHandler.GenJson(keyList, GetRowStringValueList(row));
                    var amount = DecimalHandler.Parse(row.GetCell(2)?.NumericCellValue.ToString());
                    if (amount < 0) //是退款
                    {
                        Model.OrderInfo modeRefund = new Model.OrderInfo();
                        modeRefund.OrderNo = row.GetCell(0)?.StringCellValue;
                        modeRefund.ProductName = row.GetCell(1)?.StringCellValue;
                        modeRefund.Amount = amount; //佣金

                        modeRefund.OrderTime = DateTime.Parse(row.GetCell(7)?.StringCellValue); //结算时间
                        modeRefund.PaymentPlatform = Enums_OrderInfo_PaymentPlatform.valueKeyMap["携程"];
                        modeRefund.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["退款"];
                        modeRefund.ExtraData = extraData;
                        res.Add(modeRefund);
                    }
                    else //收入
                    {
                        Model.OrderInfo modelPay = new Model.OrderInfo();
                        Model.OrderInfo modelRec = new Model.OrderInfo();
                        var str = row.GetCell(5)?.StringCellValue;
                        decimal amount1 = 0;
                        if (string.IsNullOrEmpty(str)) //空单元格
                        {
                            amount1 = 0;
                        }
                        else
                        {
                            int idx = str.IndexOf(' ');
                            amount1 = DecimalHandler.Parse(str.Substring(0, idx)); //去掉后缀的 RMB
                        }

                        if (amount1 > 0) //有佣金，需要两个model
                        {
                            modelPay.OrderNo = row.GetCell(0)?.StringCellValue;
                            modelPay.ProductName = row.GetCell(1)?.StringCellValue;
                            modelPay.Amount = -1 * amount1; //佣金
                            modelPay.OrderTime = DateTime.Parse(row.GetCell(7)?.StringCellValue); //结算时间
                            modelPay.PaymentPlatform = Enums_OrderInfo_PaymentPlatform.valueKeyMap["携程"];
                            modelPay.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["佣金"];


                            modelRec.OrderNo = row.GetCell(0)?.StringCellValue;
                            modelRec.ProductName = row.GetCell(1)?.StringCellValue;
                            modelRec.Amount = amount; //收入
                            modelRec.OrderTime = DateTime.Parse(row.GetCell(7)?.StringCellValue); //结算时间
                            modelRec.PaymentPlatform = Enums_OrderInfo_PaymentPlatform.valueKeyMap["携程"];
                            modelRec.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["收入"];


                            modelPay.ExtraData = extraData;
                            modelRec.ExtraData = extraData;

                            res.Add(modelPay);
                            res.Add(modelRec);
                        }
                        else //只有收入
                        {
                            modelRec.OrderNo = row.GetCell(0)?.StringCellValue;
                            modelRec.ProductName = row.GetCell(1)?.StringCellValue;
                            modelRec.Amount = amount; //收入
                            modelRec.OrderTime = DateTime.Parse(row.GetCell(7)?.StringCellValue); //结算时间
                            modelRec.PaymentPlatform = Enums_OrderInfo_PaymentPlatform.valueKeyMap["携程"];
                            modelRec.OrderType = Enums_OrderInfo_OrderType.valueKeyMap["收入"];
                            modelRec.ExtraData = extraData;

                            res.Add(modelRec);
                        }
                    }
                }
                catch (Exception )
                {
                    MessageBoxEx.Show("第" + (i + 1) + "行数据有误");
                }
            }
            return res;
        }
        private static bool _bIsStringCellValue = false;

        private static List<string> GetRowStringValueList(IRow row)
        {
            List<string> res = new List<string>();
            for (int i = 0; i < row.LastCellNum; ++i)
            {
                string val = "";
                try
                {
                    if (_bIsStringCellValue)
                    {
                        val = row.GetCell(i)?.StringCellValue;
                    }
                    else
                    {
                        val = row.GetCell(i)?.NumericCellValue.ToString();
                    }
                }
                catch (Exception )
                {
                    if (_bIsStringCellValue)
                    {
                        val = row.GetCell(i)?.NumericCellValue.ToString();
                    }
                    else
                    {
                        val = row.GetCell(i)?.StringCellValue;
                    }
                    _bIsStringCellValue = !_bIsStringCellValue;
                }
                res.Add(val);
            }

            return res;
        }
    }
}
