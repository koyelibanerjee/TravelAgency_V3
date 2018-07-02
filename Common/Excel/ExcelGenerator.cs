using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using DevComponents.DotNetBar;
using NPOI.HSSF.UserModel;
using NPOI.OpenXmlFormats.Dml;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using TravelAgency.BLL;
using TravelAgency.Common.Enums;
using TravelAgency.Common.PictureHandler;
using TravelAgency.Model;
using BorderStyle = NPOI.SS.UserModel.BorderStyle;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;
using VisaInfo = TravelAgency.Model.VisaInfo;

namespace TravelAgency.Common.Excel
{
    /// <summary>
    /// 这个类是自己生成的Excel
    /// </summary>
    public static class ExcelGenerator
    {
        private static bool SaveFile(string dstName, IWorkbook wk)
        {
            if (string.IsNullOrEmpty(dstName))
                return false;
            try
            {
                using (FileStream fs = new FileStream(dstName, FileMode.Create))
                    wk.Write(fs);
            }
            catch (Exception)
            {
                MessageBoxEx.Show("指定文件名的文件正在使用中，无法写入，请关闭后重试!");
                return false;
            }

            Process.Start(dstName);
            return true;
        }

        /// <summary>
        /// 个签意见书
        /// </summary>
        /// <param name="list"></param>
        /// <param name="remark"></param>
        /// <param name="groupNo"></param>
        /// <returns></returns>
        public static bool GetIndividualVisaExcel(List<TravelAgency.Model.VisaInfo> list, string remark, string groupNo)
        {

            string dstName = GlobalUtils.ShowSaveFileDlg(groupNo + ".xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;

            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("签证申请人名单");

            //2.1创建表头

            IRow rowHeader = sheet.CreateRow(0);
            rowHeader.CreateCell(0).SetCellValue("签证申请人名单");
            for (int i = 1; i <= 13; i++)
            {
                rowHeader.CreateCell(i).SetCellValue(""); //这里还是必须创建一下，不然第一行就只有一个单元格，后面再来设置边框的时候就会出问题
            }

            rowHeader.HeightInPoints = 50;

            IRow row = sheet.CreateRow(1);
            row.CreateCell(0).SetCellValue("编号");
            row.CreateCell(1).SetCellValue("姓名(中文)");
            row.CreateCell(2).SetCellValue("姓名(英文)");
            row.CreateCell(3).SetCellValue("性别");
            row.CreateCell(4).SetCellValue("护照发行地");
            row.CreateCell(5).SetCellValue("居住地点");
            row.CreateCell(6).SetCellValue("出生年月日");
            row.CreateCell(7).SetCellValue("职业");
            row.CreateCell(8).SetCellValue("出境记录");
            row.CreateCell(9).SetCellValue("婚姻");
            row.CreateCell(10).SetCellValue("身份确认");
            row.CreateCell(11).SetCellValue("经济能力确认");
            row.CreateCell(12).SetCellValue("备注");
            row.CreateCell(13).SetCellValue("旅行社意见");
            //row.CreateCell(14).SetCellValue("护照号");
            //row.CreateCell(15).SetCellValue("手机号");

            //2.2设置列宽度
            sheet.SetColumnWidth(0, 5 * 256); //编号
            sheet.SetColumnWidth(1, 15 * 256); //姓名(中文)
            sheet.SetColumnWidth(2, 20 * 256); //姓名(英文)
            sheet.SetColumnWidth(3, 5 * 256); //性别
            sheet.SetColumnWidth(4, 10 * 256); //护照发行地
            sheet.SetColumnWidth(5, 25 * 256); //居住地点
            sheet.SetColumnWidth(6, 15 * 256); //出生年月日
            sheet.SetColumnWidth(7, 10 * 256); //职业
            sheet.SetColumnWidth(8, 10 * 256); //出境记录
            sheet.SetColumnWidth(9, 10 * 256); //婚姻
            sheet.SetColumnWidth(10, 20 * 256); //身份确认
            sheet.SetColumnWidth(11, 25 * 256); //经济能力确认
            sheet.SetColumnWidth(12, 10 * 256); //备注
            sheet.SetColumnWidth(13, 10 * 256); //旅行社意见
            //sheet.SetColumnWidth(14, 15 * 256);//护照号
            //sheet.SetColumnWidth(15, 15 * 256);//手机号
            //3.插入行和单元格
            for (int i = 0; i != list.Count; ++i)
            {
                //创建单元格
                row = sheet.CreateRow(i + 2);
                //设置行高
                row.HeightInPoints = 100;
                //设置值
                row.CreateCell(0).SetCellValue(i + 1);
                row.CreateCell(1).SetCellValue(list[i].Name);
                row.CreateCell(2).SetCellValue(list[i].EnglishName);
                row.CreateCell(3).SetCellValue(list[i].Sex);
                row.CreateCell(4).SetCellValue(list[i].IssuePlace);
                row.CreateCell(5).SetCellValue(list[i].Residence);
                row.CreateCell(6).SetCellValue(DateTimeFormator.DateTimeToString(list[i].Birthday));
                row.CreateCell(7).SetCellValue(list[i].Occupation);
                row.CreateCell(8).SetCellValue(list[i].DepartureRecord);
                row.CreateCell(9).SetCellValue(list[i].Marriaged);
                row.CreateCell(10).SetCellValue(list[i].Identification);
                row.CreateCell(11).SetCellValue(list[i].FinancialCapacity);
                row.CreateCell(12).SetCellValue(remark);
                row.CreateCell(13).SetCellValue(list[i].AgencyOpinion);
                //row.CreateCell(14).SetCellValue(list[i].PassportNo);
                //row.CreateCell(15).SetCellValue(list[i].Phone);
            }

            //4.1设置对齐风格和边框
            ICellStyle style = wkbook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = HorizontalAlignment.Center;
            style.WrapText = true; //文本自动换行
            style.BorderTop = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            HSSFFont font = (HSSFFont)wkbook.CreateFont();
            font.FontHeightInPoints = 12;
            style.SetFont(font);

            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                row = sheet.GetRow(i);
                for (int c = 0; c < row.LastCellNum; ++c)
                {
                    row.GetCell(c).CellStyle = style;
                }
            }

            ICellStyle headerStyle = wkbook.CreateCellStyle();
            headerStyle.VerticalAlignment = VerticalAlignment.Center;
            headerStyle.Alignment = HorizontalAlignment.Center;
            headerStyle.BorderTop = BorderStyle.Thin;
            headerStyle.BorderBottom = BorderStyle.Thin;
            headerStyle.BorderLeft = BorderStyle.Thin;
            headerStyle.BorderRight = BorderStyle.Thin;
            HSSFFont font1 = (HSSFFont)wkbook.CreateFont();
            font1.FontHeightInPoints = 15;
            headerStyle.SetFont(font1);
            for (int i = 0; i < rowHeader.LastCellNum; i++)
                rowHeader.GetCell(i).CellStyle = headerStyle;


            //4.2合并单元格
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 13)); //表头合并
            if (list.Count != 0)
                sheet.AddMergedRegion(new CellRangeAddress(2, sheet.LastRowNum, 12, 12)); //备注列合并

            //5.执行写入磁盘
            return SaveFile(dstName, wkbook);

        }


        /// <summary>
        /// 校验导出的时候的团签和团做个是否属于同一个团号
        /// </summary>
        /// <param name="visaList"></param>
        /// <returns></returns>
        public static bool CheckGroupNoMatch(List<Model.Visa> visaList)
        {
            string pattern = "[a-zA-Z]+\\d+";
            var strSet = new HashSet<string>();
            for (int i = 0; i < visaList.Count; i++)
            {
                if (!Regex.IsMatch(visaList[i].GroupNo, pattern))
                    return false;
                var match = Regex.Match(visaList[i].GroupNo, pattern).Groups[0].Value;
                strSet.Add(match);
            }
            return strSet.Count == 1;

        }


        ///// <summary>
        ///// 团签综合名单报表（用于设置团号界面单独一个团的导出）（depracated,使用下面的版本，支持多个团一起导出）
        ///// </summary>
        ///// <param name="list"></param>
        ///// <param name="groupNo"></param>
        ///// <returns></returns>
        //public static bool GetTeamVisaExcelOfJapan(List<TravelAgency.Model.VisaInfo> list, string groupNo)
        //{
        //    //1.创建工作簿对象
        //    IWorkbook wkbook = new HSSFWorkbook();
        //    //2.创建工作表对象
        //    ISheet sheet = wkbook.CreateSheet("签证申请名单");

        //    //2.1创建表头
        //    IRow row = sheet.CreateRow(0);
        //    row.CreateCell(0).SetCellValue("序号");
        //    row.CreateCell(1).SetCellValue("姓名");
        //    row.CreateCell(2).SetCellValue("英文姓名");
        //    row.CreateCell(3).SetCellValue("性别");
        //    row.CreateCell(4).SetCellValue("出生地");
        //    row.CreateCell(5).SetCellValue("出生日期");
        //    row.CreateCell(6).SetCellValue("护照号");
        //    row.CreateCell(7).SetCellValue("签发地");
        //    row.CreateCell(8).SetCellValue("签发日期");
        //    row.CreateCell(9).SetCellValue("有效期至");
        //    row.CreateCell(10).SetCellValue("职业");
        //    row.CreateCell(11).SetCellValue("联系电话");
        //    row.CreateCell(12).SetCellValue("客户");
        //    row.CreateCell(13).SetCellValue("销售");



        //    //2.2设置列宽度
        //    sheet.SetColumnWidth(0, 5 * 256);//序号
        //    sheet.SetColumnWidth(1, 15 * 256);//姓名
        //    sheet.SetColumnWidth(2, 25 * 256);//英文姓名
        //    sheet.SetColumnWidth(3, 5 * 256);//性别
        //    sheet.SetColumnWidth(4, 10 * 256);//出生地
        //    sheet.SetColumnWidth(5, 20 * 256); //出生日期
        //    sheet.SetColumnWidth(6, 20 * 256);//护照号
        //    sheet.SetColumnWidth(7, 10 * 256);//签发地
        //    sheet.SetColumnWidth(8, 20 * 256);//签发日期
        //    sheet.SetColumnWidth(9, 20 * 256);//有效期至
        //    sheet.SetColumnWidth(10, 20 * 256);//职业
        //    sheet.SetColumnWidth(11, 20 * 256);//联系电话
        //    sheet.SetColumnWidth(12, 20 * 256);//客户
        //    sheet.SetColumnWidth(13, 20 * 256);//销售

        //    //3.插入行和单元格
        //    for (int i = 0; i != list.Count; ++i)
        //    {
        //        //创建单元格
        //        row = sheet.CreateRow(i + 1);
        //        ////设置行高
        //        //row.HeightInPoints = 50;
        //        //设置值
        //        row.CreateCell(0).SetCellValue(i + 1);
        //        row.CreateCell(1).SetCellValue(list[i].Name);
        //        row.CreateCell(2).SetCellValue(list[i].EnglishName);
        //        row.CreateCell(3).SetCellValue(list[i].Sex);
        //        row.CreateCell(4).SetCellValue(list[i].Birthplace);
        //        row.CreateCell(5).SetCellValue(DateTimeFormator.DateTimeToString(list[i].Birthday));
        //        row.CreateCell(6).SetCellValue(list[i].PassportNo);
        //        row.CreateCell(7).SetCellValue(list[i].IssuePlace);
        //        row.CreateCell(8).SetCellValue(DateTimeFormator.DateTimeToString(list[i].LicenceTime));
        //        row.CreateCell(9).SetCellValue(DateTimeFormator.DateTimeToString(list[i].ExpiryDate));
        //        row.CreateCell(10).SetCellValue(list[i].Occupation);
        //        row.CreateCell(11).SetCellValue(list[i].Phone);
        //        row.CreateCell(12).SetCellValue(list[i].Client);
        //        row.CreateCell(13).SetCellValue(list[i].Salesperson);
        //    }

        //    HSSFFont font = (HSSFFont)wkbook.CreateFont();
        //    font.FontName = "宋体";
        //    font.FontHeightInPoints = 12;

        //    //4.1设置对齐风格和边框
        //    ICellStyle style = wkbook.CreateCellStyle();
        //    style.VerticalAlignment = VerticalAlignment.Center;
        //    style.Alignment = HorizontalAlignment.Center;
        //    style.BorderTop = BorderStyle.Thin;
        //    style.BorderBottom = BorderStyle.Thin;
        //    style.BorderLeft = BorderStyle.Thin;
        //    style.BorderRight = BorderStyle.Thin;
        //    style.SetFont(font);
        //    for (int i = 0; i <= sheet.LastRowNum; i++)
        //    {
        //        row = sheet.GetRow(i);
        //        for (int c = 0; c < row.LastCellNum; ++c)
        //        {
        //            row.GetCell(c).CellStyle = style;
        //        }
        //    }
        //    //4.2合并单元格
        //    if (list.Count != 0)
        //    {
        //        sheet.AddMergedRegion(new CellRangeAddress(1, sheet.LastRowNum, 12, 12));
        //        sheet.AddMergedRegion(new CellRangeAddress(1, sheet.LastRowNum, 13, 13));
        //    }
        //    //5.执行写入磁盘
        //    string dstName = GlobalUtils.ShowSaveFileDlg(groupNo + ".xls", "office 2003 excel|*.xls");
        //    return SaveFile(dstName, wkbook);
        //}


        /// <summary>
        /// 团签综合名单报表(用于之后可能会涉及到多个团一起导出的地方)
        /// </summary>
        /// <param name="visaList"></param>
        /// <param name="visainfoList"></param>
        /// <returns></returns>
        public static bool GetTeamVisaExcelOfJapan(List<TravelAgency.Model.Visa> visaList,
            List<List<TravelAgency.Model.VisaInfo>> visainfoList)
        {

            string dstName = GlobalUtils.ShowSaveFileDlg(visaList[0].GroupNo + ".xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;

            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("签证申请名单");

            //2.1创建表头
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("序号");
            row.CreateCell(1).SetCellValue("姓名");
            row.CreateCell(2).SetCellValue("英文姓名");
            row.CreateCell(3).SetCellValue("性别");
            row.CreateCell(4).SetCellValue("出生地");
            row.CreateCell(5).SetCellValue("出生日期");
            row.CreateCell(6).SetCellValue("护照号");
            row.CreateCell(7).SetCellValue("签发地");
            row.CreateCell(8).SetCellValue("签发日期");
            row.CreateCell(9).SetCellValue("有效期至");
            row.CreateCell(10).SetCellValue("职业");
            row.CreateCell(11).SetCellValue("联系电话");
            row.CreateCell(12).SetCellValue("客户");
            row.CreateCell(13).SetCellValue("销售");

            //2.2设置列宽度
            sheet.SetColumnWidth(0, 5 * 256); //序号
            sheet.SetColumnWidth(1, 15 * 256); //姓名
            sheet.SetColumnWidth(2, 25 * 256); //英文姓名
            sheet.SetColumnWidth(3, 5 * 256); //性别
            sheet.SetColumnWidth(4, 10 * 256); //出生地
            sheet.SetColumnWidth(5, 20 * 256); //出生日期
            sheet.SetColumnWidth(6, 20 * 256); //护照号
            sheet.SetColumnWidth(7, 10 * 256); //签发地
            sheet.SetColumnWidth(8, 20 * 256); //签发日期
            sheet.SetColumnWidth(9, 20 * 256); //有效期至
            sheet.SetColumnWidth(10, 20 * 256); //职业
            sheet.SetColumnWidth(11, 20 * 256); //联系电话
            sheet.SetColumnWidth(12, 20 * 256); //客户
            sheet.SetColumnWidth(13, 20 * 256); //销售

            //3.插入行和单元格
            int idx = 0;
            List<Model.VisaInfo> visainfos = new List<VisaInfo>(); //全部加入一个List顺便
            for (int i = 0; i < visaList.Count; i++)
            {
                for (int j = 0; j < visainfoList[i].Count; j++, ++idx)
                {
                    //创建单元格
                    row = sheet.CreateRow(idx + 1);
                    ////设置行高
                    //row.HeightInPoints = 50;
                    //设置值
                    row.CreateCell(0).SetCellValue(idx + 1);
                    row.CreateCell(1).SetCellValue(visainfoList[i][j].Name);
                    row.CreateCell(2).SetCellValue(visainfoList[i][j].EnglishName);
                    row.CreateCell(3).SetCellValue(visainfoList[i][j].Sex);
                    row.CreateCell(4).SetCellValue(visainfoList[i][j].Birthplace);
                    row.CreateCell(5).SetCellValue(DateTimeFormator.DateTimeToString(visainfoList[i][j].Birthday));
                    row.CreateCell(6).SetCellValue(visainfoList[i][j].PassportNo);
                    row.CreateCell(7).SetCellValue(visainfoList[i][j].IssuePlace);
                    row.CreateCell(8).SetCellValue(DateTimeFormator.DateTimeToString(visainfoList[i][j].LicenceTime));
                    row.CreateCell(9).SetCellValue(DateTimeFormator.DateTimeToString(visainfoList[i][j].ExpiryDate));
                    row.CreateCell(10).SetCellValue(visainfoList[i][j].Occupation);
                    row.CreateCell(11).SetCellValue(visainfoList[i][j].Phone);
                    row.CreateCell(12).SetCellValue(visainfoList[i][j].Client);
                    row.CreateCell(13).SetCellValue(visainfoList[i][j].Salesperson);
                    visainfos.Add(visainfoList[i][j]);
                }
            }


            HSSFFont font = (HSSFFont)wkbook.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 12;

            //4.1设置对齐风格和边框
            ICellStyle style = wkbook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = HorizontalAlignment.Center;
            style.BorderTop = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.SetFont(font);
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                row = sheet.GetRow(i);
                for (int c = 0; c < row.LastCellNum; ++c)
                {
                    row.GetCell(c).CellStyle = style;
                }
            }



            //4.2合并单元格
            idx = 0;
            List<int> lenArr1 = new List<int>() { 0 };
            List<int> lenArr2 = new List<int>() { 0 };
            string pre1 = visainfos[0].Client;
            string pre2 = visainfos[0].Salesperson;

            for (int i = 1; i < visainfos.Count; i++)
            {
                if (visainfos[i].Client != pre1)
                {
                    pre1 = visainfos[i].Client;
                    lenArr1.Add(i);
                }
                if (visainfos[i].Salesperson != pre2)
                {
                    pre2 = visainfos[i].Salesperson;
                    lenArr2.Add(i);
                }
            }

            //合并相同单元格
            if (lenArr1.Count == 1) //全部相同
            {
                sheet.AddMergedRegion(new CellRangeAddress(1, sheet.LastRowNum, 12, 12));
            }
            else
            {
                for (int i = 1; i < lenArr1.Count; i++)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(1 + lenArr1[i - 1], lenArr1[i], 12, 12));
                }
                sheet.AddMergedRegion(new CellRangeAddress(1 + lenArr1[lenArr1.Count - 1], sheet.LastRowNum, 12, 12));
                //最后一个合并
            }

            //
            if (lenArr2.Count == 1) //全部相同
            {
                sheet.AddMergedRegion(new CellRangeAddress(1, sheet.LastRowNum, 13, 13));
            }
            else
            {
                for (int i = 1; i < lenArr2.Count; i++)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(1 + lenArr2[i - 1], lenArr2[i], 13, 13));
                }
                sheet.AddMergedRegion(new CellRangeAddress(1 + lenArr2[lenArr2.Count - 1], sheet.LastRowNum, 13, 13));
                //最后一个合并
            }


            //5.执行写入磁盘
            return SaveFile(dstName, wkbook);
        }



        /// <summary>
        /// 团签报表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="groupNo"></param>
        /// <returns></returns>
        public static bool GetTeamVisaExcelOfThailand(List<TravelAgency.Model.VisaInfo> list, string groupNo)
        {
            string dstName = GlobalUtils.ShowSaveFileDlg(groupNo + ".xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;

            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("签证申请名单");

            //2.1创建表头
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("姓名");
            row.CreateCell(1).SetCellValue("英文姓");
            row.CreateCell(2).SetCellValue("英文名");
            row.CreateCell(3).SetCellValue("性别");
            row.CreateCell(4).SetCellValue("出生日期");
            row.CreateCell(5).SetCellValue("护照号");
            row.CreateCell(6).SetCellValue("签发日期");
            row.CreateCell(7).SetCellValue("有效期至");
            row.CreateCell(8).SetCellValue("出生地点拼音");
            row.CreateCell(9).SetCellValue("签发地点拼音");
            row.CreateCell(10).SetCellValue("英文姓名");

            //2.2设置列宽度
            sheet.SetColumnWidth(0, 20 * 256); //序号
            sheet.SetColumnWidth(1, 20 * 256); //姓名
            sheet.SetColumnWidth(2, 20 * 256); //英文姓名
            sheet.SetColumnWidth(3, 20 * 256); //性别
            sheet.SetColumnWidth(4, 20 * 256); //出生地
            sheet.SetColumnWidth(5, 20 * 256); //出生日期
            sheet.SetColumnWidth(6, 20 * 256); //护照号
            sheet.SetColumnWidth(7, 20 * 256); //签发地
            sheet.SetColumnWidth(8, 20 * 256); //签发日期
            sheet.SetColumnWidth(9, 20 * 256); //有效期至
            sheet.SetColumnWidth(10, 20 * 256); //职业

            //3.插入行和单元格
            for (int i = 0; i != list.Count; ++i)
            {
                //创建单元格
                row = sheet.CreateRow(i + 1);
                ////设置行高
                //row.HeightInPoints = 50;
                //设置值
                row.CreateCell(0).SetCellValue(list[i].Name);
                row.CreateCell(1).SetCellValue(list[i].EnglishName.Split(' ')[0]);
                row.CreateCell(2).SetCellValue(list[i].EnglishName.Split(' ')[1]);
                if (list[i].Sex == "男")
                {
                    row.CreateCell(3).SetCellValue("F");
                }
                else
                {
                    row.CreateCell(3).SetCellValue("M");
                }

                row.CreateCell(4)
                    .SetCellValue(DateTimeFormator.DateTimeToString(list[i].Birthday,
                        DateTimeFormator.TimeFormat.Type03Tailand));
                row.CreateCell(5).SetCellValue(list[i].PassportNo);
                row.CreateCell(6)
                    .SetCellValue(DateTimeFormator.DateTimeToString(list[i].LicenceTime,
                        DateTimeFormator.TimeFormat.Type03Tailand));
                row.CreateCell(7)
                    .SetCellValue(DateTimeFormator.DateTimeToString(list[i].ExpiryDate,
                        DateTimeFormator.TimeFormat.Type03Tailand));
                List<string> pinyins =
                    Common.PinyinParse.PinYinConverterHelp.GetTotalPingYin(list[i].Birthplace).TotalPingYin;

                row.CreateCell(8).SetCellValue(pinyins[pinyins.Count - 1].ToUpper());
                //TODO:这个地方拼音还有点问题，因为可能有多个,先暂时取最后一个
                pinyins = Common.PinyinParse.PinYinConverterHelp.GetTotalPingYin(list[i].IssuePlace).TotalPingYin;
                row.CreateCell(9).SetCellValue(pinyins[pinyins.Count - 1].ToUpper());
                row.CreateCell(10).SetCellValue(list[i].EnglishName);
            }

            //4.1设置对齐风格和边框
            ICellStyle style = wkbook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = HorizontalAlignment.Left;
            style.BorderTop = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                row = sheet.GetRow(i);
                for (int c = 0; c < row.LastCellNum; ++c)
                {
                    row.GetCell(c).CellStyle = style;
                }
            }
            ////4.2合并单元格
            //sheet.AddMergedRegion(new CellRangeAddress(1, sheet.LastRowNum, 12, 12));
            //sheet.AddMergedRegion(new CellRangeAddress(1, sheet.LastRowNum, 13, 13));

            //5.执行写入磁盘
            return SaveFile(dstName, wkbook);
        }


        /// <summary>
        /// 每日个签送钱客人情况表
        /// </summary>
        /// <param name="visaList"></param>
        /// <param name="visaInfoList"></param>
        /// <returns></returns>
        public static bool GetEverydayExcel(List<Model.Visa> visaList, List<List<VisaInfo>> visaInfoList)
        {
            string dstName = GlobalUtils.ShowSaveFileDlg("每日送签客人情况表.xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;
            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("每日送签客人情况");

            //2.1创建表头
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("");
            row.CreateCell(1).SetCellValue("姓名");
            row.CreateCell(2).SetCellValue("签发地");
            row.CreateCell(3).SetCellValue("居住地");
            row.CreateCell(4).SetCellValue("签证类型");
            row.CreateCell(5).SetCellValue("归国时间");
            row.CreateCell(6).SetCellValue("关系");
            row.CreateCell(7).SetCellValue("");

            //2.2设置列宽度
            sheet.SetColumnWidth(0, 5 * 256);
            sheet.SetColumnWidth(1, 10 * 256);
            sheet.SetColumnWidth(2, 10 * 256);
            sheet.SetColumnWidth(3, 10 * 256);
            sheet.SetColumnWidth(4, 10 * 256);
            sheet.SetColumnWidth(5, 13 * 256);
            sheet.SetColumnWidth(6, 10 * 256);
            sheet.SetColumnWidth(7, 35 * 256);

            //3.插入行和单元格
            int rowNum = 0;
            for (int i = 0; i != visaList.Count; ++i)
            {
                for (int j = 0; j < visaInfoList[i].Count; j++)
                {
                    ++rowNum;
                    row = sheet.CreateRow(rowNum);
                    row.CreateCell(0).SetCellValue(rowNum);
                    row.CreateCell(1).SetCellValue(visaInfoList[i][j].Name);
                    row.CreateCell(2).SetCellValue(visaInfoList[i][j].IssuePlace);
                    string residence = visaInfoList[i][j].Residence;
                    if (visaInfoList[i][j].Residence.Contains(" "))
                    {
                        residence = visaInfoList[i][j].Residence.Split(' ')[0];
                        if (residence.EndsWith("省") || residence.EndsWith("市"))
                        {
                            residence = residence.Substring(0, residence.Length - 1);
                        }
                    }

                    row.CreateCell(3).SetCellValue(residence);
                    row.CreateCell(4).SetCellValue(visaList[i].DepartureType);
                    row.CreateCell(5)
                        .SetCellValue(DateTimeFormator.DateTimeToString(visaInfoList[i][j].ReturnTime,
                            DateTimeFormator.TimeFormat.Type05ReturnTime));
                    row.CreateCell(6).SetCellValue(visaList[i].Remark);
                    row.CreateCell(7).SetCellValue(visaList[i].SubmitCondition);
                    //row.CreateCell(7).SetCellValue(string.Empty); //最后一列不赋值
                }
                //创建单元格

                //设置行高
                //row.HeightInPoints = 50;
                //设置值


            }

            HSSFFont font = (HSSFFont)wkbook.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 11;

            //4.1设置对齐风格和边框
            ICellStyle style = wkbook.CreateCellStyle();
            style.SetFont(font);
            style.BorderTop = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                row = sheet.GetRow(i);
                for (int c = 0; c < row.LastCellNum; ++c)
                {
                    row.GetCell(c).CellStyle = style;
                }
            }

            //4.2合并单元格
            int dp = 1;
            for (int i = 0; i != visaList.Count; ++i)
            {
                sheet.AddMergedRegion(new CellRangeAddress(dp, dp + visaInfoList[i].Count - 1, 6, 6));

                //单独处理合并区域的单元格格式
                ICellStyle mergeStyle = wkbook.CreateCellStyle();
                mergeStyle.SetFont(font);
                mergeStyle.VerticalAlignment = VerticalAlignment.Center;
                mergeStyle.Alignment = HorizontalAlignment.Center;
                mergeStyle.BorderTop = BorderStyle.Thin;
                mergeStyle.BorderBottom = BorderStyle.Thin;
                mergeStyle.BorderLeft = BorderStyle.Thin;
                mergeStyle.BorderRight = BorderStyle.Thin;
                sheet.GetRow(dp).Cells[6].CellStyle = mergeStyle;
                dp += visaInfoList[i].Count;
            }


            //5.执行写入磁盘
            return SaveFile(dstName, wkbook);
        }

        public static bool GetPrintTable(List<Model.VisaInfo> visaInfoList)
        {
            string dstName = GlobalUtils.ShowSaveFileDlg("打印报表.xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;

            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("签证申请人名单");

            //2.1创建表头
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("编号");
            row.CreateCell(1).SetCellValue("二维码信息");
            row.CreateCell(2).SetCellValue("姓名");
            row.CreateCell(3).SetCellValue("英文名");
            row.CreateCell(4).SetCellValue("护照号");

            //2.2设置列宽度
            sheet.SetColumnWidth(0, 5 * 256); //编号
            sheet.SetColumnWidth(1, 25 * 256); //姓名(中文)
            sheet.SetColumnWidth(2, 25 * 256); //姓名(中文)
            sheet.SetColumnWidth(3, 25 * 256); //姓名(中文)
            sheet.SetColumnWidth(4, 25 * 256); //姓名(中文)
            //3.插入行和单元格
            for (int i = 0; i != visaInfoList.Count; ++i)
            {
                //创建单元格
                row = sheet.CreateRow(i + 1);

                row.CreateCell(0).SetCellValue(i + 1);
                row.CreateCell(1).SetCellValue(QRCode.MyQRCode.GenQrInfo(visaInfoList[i]));
                row.CreateCell(2).SetCellValue(visaInfoList[i].Name);
                row.CreateCell(3).SetCellValue(visaInfoList[i].EnglishName);
                row.CreateCell(4).SetCellValue(visaInfoList[i].PassportNo);
            }

            ////4.1设置对齐风格和边框
            //ICellStyle style = wkbook.CreateCellStyle();
            ////style.VerticalAlignment = VerticalAlignment.Center;
            ////style.Alignment = HorizontalAlignment.Center;
            //style.BorderTop = BorderStyle.Thin;
            //style.BorderBottom = BorderStyle.Thin;
            //style.BorderLeft = BorderStyle.Thin;
            //style.BorderRight = BorderStyle.Thin;
            //for (int i = 0; i <= sheet.LastRowNum; i++)
            //{
            //    row = sheet.GetRow(i);
            //    for (int c = 0; c < row.LastCellNum; ++c)
            //    {
            //        row.GetCell(c).CellStyle = style;
            //    }
            //}

            //5.执行写入磁盘
            return SaveFile(dstName, wkbook);
        }

        public static bool GetPrintTable(List<Model.VisaInfo_Tmp> visaInfoList)
        {

            string dstName = PathHelper.GetUserDesktop() + "\\打印报表保存路径";
            if (!Directory.Exists(dstName))
                Directory.CreateDirectory(dstName);
            dstName += "\\" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Directory.CreateDirectory(dstName);
            dstName += "\\打印报表.xls";

            //string dstName = GlobalUtils.ShowSaveFileDlg("打印报表.xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;

            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("签证申请人名单");

            //2.1创建表头
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("编号");
            row.CreateCell(1).SetCellValue("二维码信息");
            row.CreateCell(2).SetCellValue("姓名");
            row.CreateCell(3).SetCellValue("英文名");
            row.CreateCell(4).SetCellValue("护照号");

            //2.2设置列宽度
            sheet.SetColumnWidth(0, 5 * 256); //编号
            sheet.SetColumnWidth(1, 25 * 256); //姓名(中文)
            sheet.SetColumnWidth(2, 25 * 256); //姓名(中文)
            sheet.SetColumnWidth(3, 25 * 256); //姓名(中文)
            sheet.SetColumnWidth(4, 25 * 256); //姓名(中文)
            //3.插入行和单元格
            for (int i = 0; i != visaInfoList.Count; ++i)
            {
                //创建单元格
                row = sheet.CreateRow(i + 1);

                row.CreateCell(0).SetCellValue(i + 1);
                row.CreateCell(1).SetCellValue(QRCode.MyQRCode.GenQrInfo(visaInfoList[i]));
                row.CreateCell(2).SetCellValue(visaInfoList[i].Name);
                row.CreateCell(3).SetCellValue(visaInfoList[i].EnglishName);
                row.CreateCell(4).SetCellValue(visaInfoList[i].PassportNo);
            }

            if (string.IsNullOrEmpty(dstName))
                return false;
            try
            {
                using (FileStream fs = new FileStream(dstName, FileMode.Create))
                    wkbook.Write(fs);
            }
            catch (Exception)
            {
                MessageBoxEx.Show("指定文件名的文件正在使用中，无法写入，请关闭后重试!");
                return false;
            }

            Process.Start(Path.GetDirectoryName(dstName));
            return true;
        }


        /// <summary>
        /// 导出日本签证时间表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="remark"></param>
        /// <param name="groupNo"></param>
        /// <returns></returns>
        public static bool GetAllCountExcel(List<TravelAgency.Model.Visa> list)
        {
            string dstName = GlobalUtils.ShowSaveFileDlg("日本签证时间表.xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;

            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("日本签证时间表");

            list.Sort((model1, model2) =>
            {
                int res = String.Compare(model1.SalesPerson, model2.SalesPerson, StringComparison.Ordinal);
                if (res == 0)
                    res = String.Compare(model1.client, model2.client, StringComparison.Ordinal);
                return res;
            }); //按照客户排序

            //2.1创建表头

            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("团号");
            row.CreateCell(1).SetCellValue("送签日期");
            row.CreateCell(2).SetCellValue("出签日期");
            row.CreateCell(3).SetCellValue("送签社担当");
            row.CreateCell(4).SetCellValue("人数");
            row.CreateCell(5).SetCellValue("资料寄出时间");
            row.CreateCell(6).SetCellValue("销售人员");
            row.CreateCell(7).SetCellValue("客户");
            row.CreateCell(8).SetCellValue("操作");
            row.CreateCell(9).SetCellValue("其他备注");


            //2.2设置列宽度
            sheet.SetColumnWidth(0, 60 * 256); //团号");
            sheet.SetColumnWidth(1, 15 * 256); //送签日期");
            sheet.SetColumnWidth(2, 15 * 256); //出签日期");
            sheet.SetColumnWidth(3, 15 * 256); //送签社担当")
            sheet.SetColumnWidth(4, 8 * 256); //人数");
            sheet.SetColumnWidth(5, 12 * 256); //资料寄出时间
            sheet.SetColumnWidth(6, 17 * 256); //销售人员");
            sheet.SetColumnWidth(7, 10 * 256); //客户");
            sheet.SetColumnWidth(8, 10 * 256); //操作");
            sheet.SetColumnWidth(9, 10 * 256); //其他备注");
            //3.插入行和单元格
            for (int i = 0; i != list.Count; ++i)
            {
                //创建单元格
                row = sheet.CreateRow(i + 1);
                ////设置行高
                //row.HeightInPoints = 50;
                //设置值
                //if (list[i].Country == "泰国") //泰国在导出的时候恢复显示人名
                //    row.CreateCell(0).SetCellValue(GetGroupNo(list[i]));
                //else
                row.CreateCell(0).SetCellValue(list[i].GroupNo);
                row.CreateCell(1)
                    .SetCellValue(DateTimeFormator.DateTimeToString(list[i].RealTime,
                        DateTimeFormator.TimeFormat.Type02JapanTotal));
                row.CreateCell(2)
                    .SetCellValue(DateTimeFormator.DateTimeToString(list[i].FinishTime,
                        DateTimeFormator.TimeFormat.Type02JapanTotal));
                row.CreateCell(3).SetCellValue(list[i].Person);
                row.CreateCell(4).SetCellValue(list[i].Number.ToString());
                row.CreateCell(5).SetCellValue(""); //资料寄出时间先不设置
                row.CreateCell(6).SetCellValue(list[i].SalesPerson);
                row.CreateCell(7).SetCellValue(list[i].client);
                row.CreateCell(8).SetCellValue(list[i].Operator);
                row.CreateCell(9).SetCellValue(""); //其他备注先不设置
            }


            ////4.2合并单元格
            //sheet.AddMergedRegion(new CellRangeAddress(2, sheet.LastRowNum, 12, 12));
            //sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 15));
            HSSFFont font = (HSSFFont)wkbook.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 11;


            //4.1设置对齐风格和边框
            ICellStyle style = wkbook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = HorizontalAlignment.Left;
            style.BorderTop = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.SetFont(font);
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                row = sheet.GetRow(i);
                for (int c = 0; c < row.LastCellNum; ++c)
                {
                    row.GetCell(c).CellStyle = style;
                }
            }

            //5.执行写入磁盘
            return SaveFile(dstName, wkbook);
        }

        /// <summary>
        /// 泰国在导出的时候恢复显示人名
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private static string GetGroupNo(Model.Visa model)
        {
            string prefix = string.Empty;
            BLL.VisaInfo bllVisaInfo = new BLL.VisaInfo();
            var visaInfoList = bllVisaInfo.GetModelListByVisaIdOrderByPosition(model.Visa_id);
            if (model.Country == "泰国" && visaInfoList.Count == 0) //手动加的
            {
                return model.GroupNo;
            }
            if (model.Types == Types.Individual)
            {
                prefix = "QZC"; //个签自动加上前缀
                if (!string.IsNullOrEmpty(model.Country)
                    && CountryCode.Dict.ContainsKey(model.Country)
                    && !string.IsNullOrEmpty(CountryCode.Dict[model.Country]))
                    prefix += CountryCode.Dict[model.Country];

                if (model.Country == "泰国" || model.Country == "韩国")
                {
                    if (model.SubmitTime.Value.ToString() != "0001/1/1 0:00:00")
                        prefix += model.SubmitTime.Value.ToString("yyyyMMdd");
                    else
                        prefix += DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    if (model.PredictTime.Value.ToString() != "0001/1/1 0:00:00")
                        prefix += model.PredictTime.Value.ToString("yyyyMMdd");
                    else
                        prefix += DateTime.Now.ToString("yyyyMMdd");
                }
            }
            var visaName = prefix;
            if (model.Types == Types.Team2Individual) //团做个保留前面一截
            {
                string pattern = "[a-zA-Z]+\\d+";
                var matched = Regex.Match(model.GroupNo, pattern);
                visaName += matched.Groups[0].Value;
            }
            var list = new BLL.VisaInfo().GetModelListByVisaIdOrderByPosition(model.Visa_id); //再加上人名
            for (int i = 0; i < list.Count; ++i) //团签和团做个后面都跟上姓名
            {
                visaName += list[i].Name;
                if (i == list.Count - 1)
                    break;
                visaName += "、";
            }

            if (!string.IsNullOrEmpty(model.DepartureType) && model.DepartureType != "单次")
                visaName += "(" + model.DepartureType + ")";
            return visaName;
        }


        public static bool GetStatisticTable(List<Model.ActionRecords> actionList)
        {
            string dstName = GlobalUtils.ShowSaveFileDlg("记录明细统计.xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;
            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("操作记录明细");

            //2.1创建表头
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("编号");
            row.CreateCell(1).SetCellValue("操作");
            row.CreateCell(2).SetCellValue("工号");
            row.CreateCell(3).SetCellValue("姓名");
            row.CreateCell(4).SetCellValue("时间");

            //2.2设置列宽度
            sheet.SetColumnWidth(0, 5 * 256); //编号
            sheet.SetColumnWidth(1, 25 * 256); //操作
            sheet.SetColumnWidth(2, 25 * 256); //工号
            sheet.SetColumnWidth(3, 25 * 256); //姓名
            sheet.SetColumnWidth(4, 25 * 256); //时间

            // 在 在  i poi  中日期是以  e double  类型表示的 ， 所 以要格式化
            ICellStyle cellStyle = wkbook.CreateCellStyle();
            IDataFormat format = wkbook.CreateDataFormat();
            cellStyle.DataFormat = format.GetFormat("yyyy-MM-dd HH:mm:ss");

            //3.插入行和单元格
            for (int i = 0; i != actionList.Count; ++i)
            {
                //创建单元格
                row = sheet.CreateRow(i + 1);

                row.CreateCell(0).SetCellValue(i + 1);
                row.CreateCell(1).SetCellValue(actionList[i].ActType);
                row.CreateCell(2).SetCellValue(actionList[i].WorkId);
                row.CreateCell(3).SetCellValue(actionList[i].UserName);
                row.CreateCell(4).CellStyle = cellStyle;
                row.GetCell(4).SetCellValue(actionList[i].EntryTime.Value);
            }

            //5.执行写入磁盘
            return SaveFile(dstName, wkbook);
        }


        public static bool GetStatisticPersonalTable(List<Model.PersonalStat> statList)
        {
            string dstName = GlobalUtils.ShowSaveFileDlg("个人记录统计.xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;
            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("个人记录统计");

            //2.1创建表头
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("编号");
            row.CreateCell(1).SetCellValue("姓名");
            row.CreateCell(2).SetCellValue(Enums.ActType._01TypeIn);
            row.CreateCell(3).SetCellValue(Enums.ActType._02TypeInData);
            row.CreateCell(4).SetCellValue(Enums.ActType._03Modify);
            row.CreateCell(5).SetCellValue(Enums.ActType._04Checked);
            row.CreateCell(6).SetCellValue("总计");

            //2.2设置列宽度
            sheet.SetColumnWidth(0, 5 * 256);
            sheet.SetColumnWidth(1, 15 * 256);
            sheet.SetColumnWidth(2, 15 * 256);
            sheet.SetColumnWidth(3, 15 * 256);
            sheet.SetColumnWidth(4, 15 * 256);
            sheet.SetColumnWidth(5, 15 * 256);
            sheet.SetColumnWidth(6, 15 * 256);


            int count1 = 0, count2 = 0, count3 = 0, count4 = 0;
            //3.插入行和单元格

            for (int i = 0; i != statList.Count; ++i)
            {
                //创建单元格
                row = sheet.CreateRow(i + 1);

                row.CreateCell(0).SetCellValue(i + 1);
                row.CreateCell(1).SetCellValue(statList[i].UserName);
                row.CreateCell(2).SetCellValue(statList[i].Type01Count);
                row.CreateCell(3).SetCellValue(statList[i].Type02Count);
                row.CreateCell(4).SetCellValue(statList[i].Type03Count);
                row.CreateCell(5).SetCellValue(statList[i].Type04Count);
                row.CreateCell(6).SetCellValue(statList[i].Count);
                count1 += statList[i].Type01Count;
                count2 += statList[i].Type02Count;
                count3 += statList[i].Type03Count;
                count4 += statList[i].Type04Count;
            }
            row = sheet.CreateRow(statList.Count + 1);
            row.CreateCell(1).SetCellValue("总计");
            row.CreateCell(2).SetCellValue(count1);
            row.CreateCell(3).SetCellValue(count2);
            row.CreateCell(4).SetCellValue(count3);
            row.CreateCell(5).SetCellValue(count4);
            row.CreateCell(6).SetCellValue(count1 + count2 + count3 + count4);

            //5.执行写入磁盘
            return SaveFile(dstName, wkbook);
        }


        public static bool GetYuanShenMuban(List<Model.VisaInfo> visaInfoList, List<string> airInfos)
        {
            string dstName = GlobalUtils.ShowSaveFileDlg("身元模板.xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;
            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("身元模板");

            //2.1创建表头
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("姓名");
            row.CreateCell(1).SetCellValue("拼音");
            row.CreateCell(2).SetCellValue("性别");
            row.CreateCell(3).SetCellValue("签发地");
            row.CreateCell(4).SetCellValue("出生年月日");
            row.CreateCell(5).SetCellValue("护照号");
            row.CreateCell(6).SetCellValue("职位");

            //2.2设置列宽度
            sheet.SetColumnWidth(0, 25 * 256); //编号
            sheet.SetColumnWidth(1, 23 * 256); //姓名(中文)
            sheet.SetColumnWidth(2, 20 * 256); //姓名(中文)
            sheet.SetColumnWidth(3, 22 * 256); //姓名(中文)
            sheet.SetColumnWidth(4, 24 * 256); //姓名(中文)
            sheet.SetColumnWidth(5, 23 * 256); //姓名(中文)
            sheet.SetColumnWidth(6, 20 * 256); //姓名(中文)
            //3.插入行和单元格
            for (int i = 0; i != visaInfoList.Count; ++i)
            {
                //创建单元格
                row = sheet.CreateRow(i + 1);

                row.CreateCell(0).SetCellValue(visaInfoList[i].Name);
                row.CreateCell(1).SetCellValue(visaInfoList[i].EnglishName);
                row.CreateCell(2).SetCellValue(visaInfoList[i].Sex);
                row.CreateCell(3).SetCellValue(visaInfoList[i].IssuePlace);
                row.CreateCell(4).SetCellValue(visaInfoList[i].Birthday.Value.ToString("yyyy/MM/dd"));
                row.CreateCell(5).SetCellValue(visaInfoList[i].PassportNo);
                row.CreateCell(6).SetCellValue(visaInfoList[i].Occupation);
            }

            row = sheet.CreateRow(visaInfoList.Count + 1);
            row.HeightInPoints = 50;
            row.CreateCell(0).SetCellValue(airInfos[0]);
            row.CreateCell(1).SetCellValue(airInfos[1]);
            row.CreateCell(2).SetCellValue(airInfos[2]);


            HSSFFont font = (HSSFFont)wkbook.CreateFont();
            font.FontName = "宋体";
            font.FontHeightInPoints = 11;

            //4.1设置对齐风格和边框
            ICellStyle style = wkbook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = HorizontalAlignment.Left;
            style.BorderTop = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.WrapText = true;
            style.SetFont(font);
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                row = sheet.GetRow(i);
                for (int c = 0; c < row.LastCellNum; ++c)
                {
                    row.GetCell(c).CellStyle = style;
                }
            }

            //5.执行写入磁盘

            return SaveFile(dstName, wkbook);
        }


        public static void Get8PassPicTable(List<Model.VisaInfo> visaInfoList)
        {
            //if (visaInfoList == null || visaInfoList.Count < 1)
            //    return;

            //if (visaInfoList.Count > 8)
            //{
            //    MessageBoxEx.Show("请选择8人以下导出!!!");
            //    return;
            //}

            IWorkbook wkbook = new XSSFWorkbook();
            ISheet sheet = wkbook.CreateSheet("sheet1");
            sheet.SetColumnWidth(0, 12960);
            sheet.SetColumnWidth(1, 12960);

            int num = 15;
            int rowcnt = (int)Math.Ceiling(num / 8.0) * 6;


            for (int i = 0; i < rowcnt; i++)
            {
                if (i % 6 < 4)
                {
                    var row = sheet.CreateRow(i).HeightInPoints = 198.75f;
                }

                else
                {
                    var row = sheet.CreateRow(i);
                }

            }

            for (int i = 0; i < num; i++)
            {
                //添加二维码图片
                var picturebuffer = File.ReadAllBytes(@"E:\东瀛假日签证识别管理系统\护照图像保存路径\E00678234.jpg");
                int pictureIdx = wkbook.AddPicture(picturebuffer, PictureType.JPEG);
                var patriach = sheet.CreateDrawingPatriarch();
                IClientAnchor anchor = new XSSFClientAnchor(0, 0, 0, 0, i % 2, i / 2, i % 2 + 1, i / 2 + 1);
                patriach.CreatePicture(anchor, pictureIdx);
            }

            //READEXCEL
            //using (FileStream fs = File.OpenRead(@"E:\东瀛假日签证识别管理系统\Excel\Templates\template_泰国8人首页.xlsx"))
            //{
            //    IWorkbook wkbook = new XSSFWorkbook(fs);
            //    ISheet sheet = wkbook.GetSheet("sheet1");
            //    var height1 = sheet.GetRow(0).HeightInPoints;
            //    //var height2 = sheet.GetRow(4).HeightInPoints;
            //    var width = sheet.GetColumnWidth(0);

            //    for (int i = 0; i < 16; i++)
            //    {

            //    }


            string dstName = GlobalUtils.ShowSaveFileDlg("8人首页.xlsx", "Excel XLSX|*.xlsx");

            SaveFile(dstName, wkbook);

            //}
        }


        public static bool TestGen()
        {
            string dstName = GlobalUtils.ShowSaveFileDlg("身元模板.xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;
            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("身元模板");

            string root = @"I:\My Documents\My Desktop\JobSeek\slns\Java\ZYC_Term4\src";
            var folderList = Directory.GetDirectories(root);

            //3.插入行和单元格
            int idx = 0;
            for (int i = 0; i != folderList.Length; ++i)
            {
                var fileList = Directory.GetFiles(folderList[i]);

                for (int j = 0; j < fileList.Length; j++)
                {
                    //创建单元格
                    var row = sheet.CreateRow(idx++);
                    var prefix = folderList[i].Substring(folderList[i].LastIndexOf('\\') + 1,
                        folderList[i].Length - folderList[i].LastIndexOf('\\') - 1);
                    row.CreateCell(0).SetCellValue(prefix + "/" + Path.GetFileNameWithoutExtension(fileList[j]));
                }


            }



            //5.执行写入磁盘

            return SaveFile(dstName, wkbook);
        }


        public static bool GetOrdersTableWator(List<Model.Orders> list)
        {

            string dstName = GlobalUtils.ShowSaveFileDlg("Orders" + ".xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;

            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("sheet1");

            //2.1创建表头
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("编号");
            row.CreateCell(1).SetCellValue("网上平台订单号");
            row.CreateCell(2).SetCellValue("操作姓名");
            row.CreateCell(3).SetCellValue("订单状态");
            row.CreateCell(4).SetCellValue("客人基础信息已录入");
            row.CreateCell(5).SetCellValue("回复结果");
            row.CreateCell(6).SetCellValue("操作备注");
            row.CreateCell(7).SetCellValue("录入客服");
            row.CreateCell(8).SetCellValue("平台");
            row.CreateCell(9).SetCellValue("团号");
            row.CreateCell(10).SetCellValue("产品名称");
            row.CreateCell(11).SetCellValue("产品ID");
            row.CreateCell(12).SetCellValue("产品类型");
            row.CreateCell(13).SetCellValue("购买数量");
            row.CreateCell(14).SetCellValue("订单金额");
            row.CreateCell(15).SetCellValue("客人下单时间");
            row.CreateCell(16).SetCellValue("客服下单时间");
            row.CreateCell(17).SetCellValue("客服确认时间");
            row.CreateCell(18).SetCellValue("实际支付金额");
            row.CreateCell(19).SetCellValue("平台活动");
            row.CreateCell(20).SetCellValue("退款状态");
            //row.CreateCell(14).SetCellValue("护照号");
            //row.CreateCell(15).SetCellValue("手机号");

            //2.2设置列宽度
            sheet.SetColumnWidth(0, 5 * 256); //编号
            //3.插入行和单元格
            for (int i = 0; i != list.Count; ++i)
            {
                //创建单元格
                row = sheet.CreateRow(i + 1);
                //设置行高
                row.HeightInPoints = 100;
                //设置值
                row.CreateCell(0).SetCellValue(i + 1);
                row.CreateCell(1).SetCellValue(list[i].OrderNo);
                row.CreateCell(2).SetCellValue(list[i].OperName);
                row.CreateCell(3).SetCellValue(list[i].OrderState);
                row.CreateCell(4).SetCellValue(list[i].GuestInfoTypedIn.HasValue ? (list[i].GuestInfoTypedIn.Value ? "是" : "否") : "否");
                row.CreateCell(5).SetCellValue(list[i].ReplyResult);
                row.CreateCell(6).SetCellValue(list[i].OperRemark);
                row.CreateCell(7).SetCellValue(list[i].WaitorName);
                row.CreateCell(8).SetCellValue(Enums.OrderInfo_PaymentPlatform.KeyToValue(list[i].PaymentPlatform));
                row.CreateCell(9).SetCellValue(list[i].GroupNo);
                row.CreateCell(10).SetCellValue(list[i].ProductName);
                row.CreateCell(11).SetCellValue(list[i].ProductId ?? 0);
                row.CreateCell(12).SetCellValue(list[i].ProductType);
                row.CreateCell(13).SetCellValue(list[i].PurchaseNum ?? 0);
                row.CreateCell(14).SetCellValue(list[i].OrderAmount.ToString());
                row.CreateCell(15).SetCellValue(list[i].GuestOrderTime.ToString());
                row.CreateCell(16).SetCellValue(list[i].WaitorOrderTime.ToString());
                row.CreateCell(17).SetCellValue(list[i].WaitorConfirmTime.ToString());
                row.CreateCell(18).SetCellValue(list[i].ReallyPay.ToString());
                row.CreateCell(19).SetCellValue(list[i].PlatformActivity);
                row.CreateCell(20).SetCellValue(list[i].RefundState);
                //row.CreateCell(14).SetCellValue(list[i].PassportNo);
                //row.CreateCell(15).SetCellValue(list[i].Phone);
            }

            //4.1设置对齐风格和边框
            ICellStyle style = wkbook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = HorizontalAlignment.Center;
            style.WrapText = true; //文本自动换行
            style.BorderTop = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            HSSFFont font = (HSSFFont)wkbook.CreateFont();
            font.FontHeightInPoints = 12;
            style.SetFont(font);

            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                row = sheet.GetRow(i);
                for (int c = 0; c < row.LastCellNum; ++c)
                {
                    row.GetCell(c).CellStyle = style;
                }
            }
            //5.执行写入磁盘
            return SaveFile(dstName, wkbook);
        }

        public static bool GetOrdersTableOper(List<Model.Orders> list)
        {

            string dstName = GlobalUtils.ShowSaveFileDlg("Orders" + ".xls", "office 2003 excel|*.xls");
            if (string.IsNullOrEmpty(dstName))
                return false;

            //1.创建工作簿对象
            IWorkbook wkbook = new HSSFWorkbook();
            //2.创建工作表对象
            ISheet sheet = wkbook.CreateSheet("sheet1");

            

            //2.1创建表头
            IRow row = sheet.CreateRow(0);

            var headerList = new List<string>
            {
                "编号",
                "录入客服",
                "网上平台订单号",
                 "回复结果",
                 "平台",
                "团号",
                "产品名称",
                "产品ID",
                "产品类型",
                "购买数量",
                "订单金额",
                "客人下单时间",
                "客服下单时间",
                "客服确认时间",
                "实际支付金额",
                "平台活动",
                "下单平台订单号",
                "下单方式",
                "操作下单时间",
                "日本确认时间",
                "回复客服确认时间",
                "结算成本单价",
                "汇率",
                "备注",
            };

           for(int i=0;i<headerList.Count;++i)
                row.CreateCell(i).SetCellValue(headerList[i]);

            //2.2设置列宽度
            sheet.SetColumnWidth(0, 5 * 256); //编号
            //3.插入行和单元格
            for (int i = 0; i != list.Count; ++i)
            {
                //创建单元格
                row = sheet.CreateRow(i + 1);
                //设置行高
                row.HeightInPoints = 100;
                //设置值
                row.CreateCell(0).SetCellValue(i + 1);
                row.CreateCell(1).SetCellValue(list[i].WaitorName);
                row.CreateCell(2).SetCellValue(list[i].OrderNo);
                row.CreateCell(3).SetCellValue(list[i].ReplyResult);
                row.CreateCell(4).SetCellValue(Enums.OrderInfo_PaymentPlatform.KeyToValue(list[i].PaymentPlatform));
                row.CreateCell(5).SetCellValue(list[i].GroupNo);
                row.CreateCell(6).SetCellValue(list[i].ProductName);
                row.CreateCell(7).SetCellValue(list[i].ProductId ?? 0);
                row.CreateCell(8).SetCellValue(list[i].ProductType);
                row.CreateCell(9).SetCellValue(list[i].PurchaseNum ?? 0);
                row.CreateCell(10).SetCellValue(list[i].OrderAmount.ToString());
                row.CreateCell(11).SetCellValue(list[i].GuestOrderTime.ToString());
                row.CreateCell(12).SetCellValue(list[i].WaitorOrderTime.ToString());
                row.CreateCell(13).SetCellValue(list[i].WaitorConfirmTime.ToString());
                row.CreateCell(14).SetCellValue(list[i].ReallyPay.ToString());
                row.CreateCell(15).SetCellValue(list[i].PlatformActivity);
                row.CreateCell(16).SetCellValue(list[i].JpOrderNo);
                row.CreateCell(17).SetCellValue(list[i].OrderWay);
                row.CreateCell(18).SetCellValue(list[i].OperOrderTime.ToString());
                row.CreateCell(19).SetCellValue(list[i].JpConfirmTime.ToString());
                row.CreateCell(20).SetCellValue(list[i].ReplyWaitorConfirmTime.ToString());
                row.CreateCell(21).SetCellValue(list[i].SettlePrice.ToString());
                row.CreateCell(22).SetCellValue(list[i].ExchangeRate.ToString());
                row.CreateCell(23).SetCellValue(list[i].OperRemark);
            }

            //4.1设置对齐风格和边框
            ICellStyle style = wkbook.CreateCellStyle();
            style.VerticalAlignment = VerticalAlignment.Center;
            style.Alignment = HorizontalAlignment.Center;
            style.WrapText = true; //文本自动换行
            style.BorderTop = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            HSSFFont font = (HSSFFont)wkbook.CreateFont();
            font.FontHeightInPoints = 12;
            style.SetFont(font);

            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                row = sheet.GetRow(i);
                for (int c = 0; c < row.LastCellNum; ++c)
                {
                    row.GetCell(c).CellStyle = style;
                }
            }

            //5.执行写入磁盘
            return SaveFile(dstName, wkbook);
        }

    }
}
