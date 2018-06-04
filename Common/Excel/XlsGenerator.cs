using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DevComponents.DotNetBar;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using TravelAgency.Model;

namespace TravelAgency.Common.Excel
{
    /// <summary>
    /// 这个类是用占位符替换生成的报表（或者是直接填空位的方式）
    /// </summary>
    public class XlsGenerator
    {

        private static readonly TravelAgency.BLL.ActionRecords _bllLoger = new TravelAgency.BLL.ActionRecords();
        private static readonly TravelAgency.BLL.VisaInfo _bllVisaInfo = new TravelAgency.BLL.VisaInfo();



        public static bool IsOutSigned(VisaInfo model)
        {
            return model.IssuePlace != "云南" && model.IssuePlace != "四川" &&
                   model.IssuePlace != "贵州" && model.IssuePlace != "重庆";
        }

        ///// <summary>
        ///// 8人报表
        ///// </summary>
        ///// <param name="visaInfoList"></param>
        ///// <param name="visaList">这个list是每有一个visainfo就有一个visa,就是对应的visa，重复也不管</param>
        //public static void GetPre8List(List<Model.VisaInfo> visaInfoList, List<Model.Visa> visaList)
        //{
        //    if (visaInfoList.Count > 8)
        //    {
        //        MessageBoxEx.Show("请选择8个人以下导出!");
        //        return;
        //    }

        //    //READEXCEL
        //    using (FileStream fs = File.OpenRead(GlobalUtils.AppPath + @"\Excel\Templates\template_(前8人）旅行社申请名单表_（表3）_添加占位符.xls"))
        //    {
        //        IWorkbook wkbook = new HSSFWorkbook(fs);
        //        ISheet sheet = wkbook.GetSheetAt(0);


        //        IRow row = sheet.GetRow(10);
        //        for (int c = 0; c < row.LastCellNum; ++c)
        //        {
        //            string dtString = DateTimeFormator.DateTimeToString(DateTimeFormator.GetNextWorkDate(DateTime.Now.AddDays(1)));
        //            string[] datearr = dtString.Split('/');
        //            //1.获取每个单元格
        //            if (row.GetCell(c).ToString() == "{1}")
        //                row.GetCell(c).SetCellValue(datearr[0].Substring(2, 2));
        //            if (row.GetCell(c).ToString() == "{2}")
        //                row.GetCell(c).SetCellValue(datearr[1]);
        //            if (row.GetCell(c).ToString() == "{3}")
        //                row.GetCell(c).SetCellValue(datearr[2]);
        //        }

        //        for (int j = 0; j < 8; j++)
        //        {
        //            row = sheet.GetRow(21 + j * 4);
        //            for (int c = 0; c < row.LastCellNum; ++c)
        //            {
        //                if (row.GetCell(c).ToString() == "{" + (4 + j * 4) + "}")
        //                    if (j < visaInfoList.Count)
        //                    {
        //                        //外领送签条件不为空
        //                        if (IsOutSigned(visaInfoList[j]) && visaList[j] != null && !string.IsNullOrEmpty(visaList[j].SubmitCondition))
        //                        {
        //                            row.GetCell(c).SetCellValue(visaInfoList[j].Name + "(" + visaList[j].SubmitCondition + ")");
        //                            continue;
        //                        }
        //                        row.GetCell(c).SetCellValue(visaInfoList[j].Name);
        //                    }
        //                    else
        //                        row.GetCell(c).SetCellValue(string.Empty);

        //                if (row.GetCell(c).ToString() == "{" + (7 + j * 4) + "}")
        //                    if (j < visaInfoList.Count && visaInfoList[j].ReturnTime != null)
        //                    {
        //                        //归国时间设置
        //                        row.GetCell(c).SetCellValue(
        //                            DateTimeFormator.DateTimeToString(visaInfoList[j].ReturnTime, DateTimeFormator.TimeFormat.Type05ReturnTime));
        //                    }
        //                    else
        //                        row.GetCell(c).SetCellValue(string.Empty);

        //            }

        //            row = sheet.GetRow(23 + j * 4);
        //            for (int c = 0; c < row.LastCellNum; ++c)
        //            {
        //                if (row.GetCell(c).ToString() == "{" + (5 + j * 4) + "}")
        //                {
        //                    if (j < visaInfoList.Count && IsOutSigned(visaInfoList[j])) //是外签的话设置发行地
        //                        row.GetCell(c).SetCellValue(visaInfoList[j].IssuePlace);
        //                    else
        //                        row.GetCell(c).SetCellValue(string.Empty);
        //                }
        //            }

        //            //居住地
        //            row = sheet.GetRow(24 + j * 4);
        //            for (int c = 0; c < row.LastCellNum; ++c)
        //            {
        //                if (row.GetCell(c).ToString() == "{" + (6 + j * 4) + "}")
        //                    if (j < visaInfoList.Count)
        //                    {
        //                        string residence = visaInfoList[j].Residence;
        //                        if (visaInfoList[j].Residence.Contains(" "))
        //                        {
        //                            residence = visaInfoList[j].Residence.Split(' ')[0];
        //                            if (residence.EndsWith("省") || residence.EndsWith("市"))
        //                            {
        //                                residence = residence.Substring(0, residence.Length - 1);
        //                            }
        //                        }
        //                        row.GetCell(c).SetCellValue(residence);
        //                    }

        //                    else
        //                        row.GetCell(c).SetCellValue(string.Empty);
        //            }
        //        }

        //        //在已导出记录表中添加已导出
        //        BLL.HasExported8Report bll = new BLL.HasExported8Report();
        //        for (int i = 0; i < visaInfoList.Count; i++)
        //        {
        //            Model.HasExported8Report model = new HasExported8Report();
        //            model.VisaInfo_id = visaInfoList[i].VisaInfo_id;
        //            model.EntryTime = DateTime.Now;
        //            if (!bll.Exists(model.VisaInfo_id)) //重复导出就更新时间
        //                bll.Add(model);
        //            else
        //                bll.Update(model);
        //        }

        //        //sheet.IsPrintGridlines = true;
        //        string dstName = GlobalUtils.ShowSaveFileDlg("8人申请表.xls", "Excel XLS|*.xls");

        //        // If the file name is not an empty string open it for saving.
        //        if (!string.IsNullOrEmpty(dstName))
        //        {
        //            try
        //            {
        //                using (FileStream fs1 = File.OpenWrite(dstName))
        //                {
        //                    wkbook.Write(fs1);
        //                }
        //                Process.Start(dstName);
        //            }
        //            catch (Exception)
        //            {
        //                MessageBoxEx.Show("指定文件名的文件正在使用中，无法写入，请关闭后重试!");
        //            }
        //        }

        //    }
        //}

        /// <summary>
        /// 8人报表
        /// </summary>
        /// <param name="visaInfoList"></param>
        /// <param name="visaList">这个list是每有一个visainfo就有一个visa,就是对应的visa，重复也不管</param>
        public static void GetGuolvJinGunMingDan(List<Model.VisaInfo> visaInfoList, List<Model.Visa> visaList)
        {
            //if (visaInfoList.Count > 8)
            //{
            //    MessageBoxEx.Show("请选择8个人以下导出!");
            //    return;
            //}

            //READEXCEL
            using (FileStream fs = File.OpenRead(GlobalUtils.AppPath + @"\Excel\Templates\（）国旅旅行社申请名单表_进馆.xls"))
            {
                IWorkbook wkbook = new HSSFWorkbook(fs);
                ISheet sheet = wkbook.GetSheetAt(0);

                IRow row = sheet.GetRow(10);
                for (int c = 0; c < row.LastCellNum; ++c)
                {
                    string dtString =
                        DateTimeFormator.DateTimeToString(DateTimeFormator.GetNextWorkDate(DateTime.Now.AddDays(1)));
                    //时间替换为下一个工作日
                    string[] datearr = dtString.Split('/');
                    //1.获取每个单元格
                    if (row.GetCell(c).ToString() == "{1}")
                        row.GetCell(c).SetCellValue(datearr[0]);
                    if (row.GetCell(c).ToString() == "{2}")
                        row.GetCell(c).SetCellValue(datearr[1]);
                    if (row.GetCell(c).ToString() == "{3}")
                        row.GetCell(c).SetCellValue(datearr[2]);
                }

                string pre = null;
                for (int j = 0; j < visaInfoList.Count; j++)
                {
                    //21行  姓名和归国时间和签证种类可以填
                    row = sheet.GetRow(21 + j * 4);

                    //如果是同一个团中的第二个人，加一个" 符号
                    if (pre != null && visaList[j].GroupNo == pre)
                        row.GetCell(2).SetCellValue("\"");
                    pre = visaList[j].GroupNo;
                    //姓名
                    if (IsOutSigned(visaInfoList[j]) && visaList[j] != null &&
                        !string.IsNullOrEmpty(visaList[j].SubmitCondition))
                    {
                        row.GetCell(8).SetCellValue(visaInfoList[j].Name + "(" + visaList[j].SubmitCondition + ")");
                    }
                    else
                    {
                        row.GetCell(8).SetCellValue(visaInfoList[j].Name);
                    }

                    //归国时间
                    row.GetCell(29).SetCellValue(
                        DateTimeFormator.DateTimeToString(visaInfoList[j].ReturnTime,
                            DateTimeFormator.TimeFormat.Type05ReturnTime));

                    //签证种类
                    if (visaList[j] != null && !string.IsNullOrEmpty(visaList[j].DepartureType))
                        row.GetCell(14).SetCellValue(visaList[j].DepartureType);

                    //23行设置发行地
                    row = sheet.GetRow(23 + j * 4);
                    if (IsOutSigned(visaInfoList[j])) //是外签的话设置发行地
                        row.GetCell(8).SetCellValue("发行地：" + visaInfoList[j].IssuePlace);
                    //else
                    //row.GetCell(11).SetCellValue(string.Empty);

                    //24行设置居住地
                    row = sheet.GetRow(24 + j * 4);

                    string residence = visaInfoList[j].Residence;
                    if (!string.IsNullOrEmpty(residence))
                    {
                        if (visaInfoList[j].Residence.Contains(" "))
                        {
                            residence = visaInfoList[j].Residence.Split(' ')[0];
                            if (residence.EndsWith("省") || residence.EndsWith("市"))
                            {
                                residence = residence.Substring(0, residence.Length - 1);
                            }
                        }
                        row.GetCell(11).SetCellValue(residence);
                    }
                    else
                    {
                        row.GetCell(11).SetCellValue(string.Empty);
                    }
                }





                //sheet.IsPrintGridlines = true;
                string dstName = GlobalUtils.ShowSaveFileDlg("8人申请表.xls", "Excel XLS|*.xls");

                // If the file name is not an empty string open it for saving.
                if (!string.IsNullOrEmpty(dstName))
                {
                    try
                    {
                        using (FileStream fs1 = File.OpenWrite(dstName))
                        {
                            wkbook.Write(fs1);
                        }
                        BLL.VisaInfo bllVisaInfo = new BLL.VisaInfo();

                        for (int i = 0; i < visaInfoList.Count; i++)
                        {
                            if (visaInfoList[i].outState == Enums.OutState.Type01Delay) //保存成功了的时候同时删除掉延后状态
                            {
                                visaInfoList[i].outState = Enums.OutState.Type01NoRecord;
                                bllVisaInfo.Update(visaInfoList[i]);
                            }
                        }

                        //在已导出记录表中添加已导出
                        BLL.HasExported8Report bll = new BLL.HasExported8Report();
                        for (int i = 0; i < visaInfoList.Count; i++)
                        {
                            Model.HasExported8Report model = new HasExported8Report();
                            model.VisaInfo_id = visaInfoList[i].VisaInfo_id;
                            model.EntryTime = DateTime.Now;
                            if (!bll.Exists(model.VisaInfo_id)) //重复导出就更新时间
                                bll.Add(model);
                            else
                                bll.Update(model);
                        }

                        for (int i = 0; i < visaInfoList.Count; i++)
                        {
                            _bllLoger.AddRecord(Common.Enums.ActType._10Exported, GlobalUtils.LoginUser, visaInfoList[i],
                                null);
                            visaInfoList[i].outState = Enums.OutState.TYPE10Exported;
                            _bllVisaInfo.Update(visaInfoList[i]);
                        }

                        Process.Start(dstName);
                    }
                    catch (Exception)
                    {
                        MessageBoxEx.Show("指定文件名的文件正在使用中，无法写入，请关闭后重试!");
                    }
                }
            }
        }

        /// <summary>
        /// 泰国的数据源报表
        /// </summary>
        /// <param name="visaInfoList"></param>
        /// <param name="visaList"></param>
        public static void GetThailandDataSource(List<Model.VisaInfo> visaInfoList)
        {
            if (visaInfoList.Count > 217)
            {
                MessageBoxEx.Show("请选择217个人以下导出!");
                return;
            }

            //READEXCEL
            using (FileStream fs = File.OpenRead(GlobalUtils.AppPath + @"\Excel\Templates\泰国数据源报表.xls"))
            {
                IWorkbook wkbook = new HSSFWorkbook(fs);
                ISheet sheet = wkbook.GetSheet("sheet2");
                for (int i = 0; i < visaInfoList.Count; i++)
                {
                    string[] englishNames = visaInfoList[i].EnglishName.Split(' ');
                    IRow row = sheet.GetRow(i + 1);
                    row.GetCell(1).SetCellValue(visaInfoList[i].Name);
                    row.GetCell(2).SetCellValue(englishNames[0]);
                    row.GetCell(3).SetCellValue(englishNames[englishNames.Length - 1]); //防止两个空格的情况下出错
                    row.GetCell(4).SetCellValue(visaInfoList[i].Sex == "男" ? "M" : "F");
                    row.GetCell(5).SetCellValue(DateTimeFormator.DateTimeToString(visaInfoList[i].Birthday, DateTimeFormator.TimeFormat.Type11Tailand2));
                    row.GetCell(6).SetCellValue(visaInfoList[i].PassportNo);
                    row.GetCell(7).SetCellValue(DateTimeFormator.DateTimeToString(visaInfoList[i].LicenceTime, DateTimeFormator.TimeFormat.Type11Tailand2));
                    row.GetCell(8).SetCellValue(DateTimeFormator.DateTimeToString(visaInfoList[i].ExpiryDate, DateTimeFormator.TimeFormat.Type11Tailand2));
                    row.GetCell(9).SetCellValue(visaInfoList[i].BirthPlaceEnglish);
                    row.GetCell(10).SetCellValue(visaInfoList[i].IssuePlaceEnglish);
                    row.GetCell(11).SetCellValue(visaInfoList[i].Occupation);
                }

                //sheet1部分
                sheet = wkbook.GetSheet("sheet1");
                int pageIdx = 0;
                for (int i = 0; i < visaInfoList.Count; i++)
                {
                    string[] englishNames = visaInfoList[i].EnglishName.Split(' ');
                    IRow row = sheet.GetRow(pageIdx * 30 + (i % 15) + 15);
                    row.GetCell(1).SetCellValue(visaInfoList[i].Name);
                    row.GetCell(2).SetCellValue(visaInfoList[i].EnglishName);
                    row.GetCell(3).SetCellValue(visaInfoList[i].Sex == "男" ? "M" : "F");
                    row.GetCell(4).SetCellValue(DateTimeFormator.DateTimeToString(visaInfoList[i].Birthday, DateTimeFormator.TimeFormat.Type11Tailand2));
                    row.GetCell(7).SetCellValue(visaInfoList[i].PassportNo);
                    row.GetCell(9).SetCellValue(DateTimeFormator.DateTimeToString(visaInfoList[i].ExpiryDate, DateTimeFormator.TimeFormat.Type11Tailand2));
                    if ((i + 1) % 15 == 0)
                        pageIdx += 1;
                }


                //sheet.IsPrintGridlines = true;
                string dstName = GlobalUtils.ShowSaveFileDlg(DateTime.Now.Month + "." + DateTime.Now.Day + " " +
                    visaInfoList.Count + "本" + ".xls", "Excel XLS|*.xls");

                // If the file name is not an empty string open it for saving.
                if (!string.IsNullOrEmpty(dstName))
                {
                    try
                    {
                        using (FileStream fs1 = File.OpenWrite(dstName))
                        {
                            wkbook.Write(fs1);
                        }
                        Process.Start(dstName);
                    }
                    catch (Exception)
                    {
                        MessageBoxEx.Show("指定文件名的文件正在使用中，无法写入，请关闭后重试!");
                    }
                }

            }
        }


        /// <summary>
        /// 泰国的数据源报表
        /// </summary>
        /// <param name="visaInfoList"></param>
        /// <param name="visaList"></param>
        public static void GetBaoXianReport(List<Model.VisaInfo> visaInfoList, Model.Visa visamodel)
        {
            //if (visaInfoList.Count > 2)
            //{
            //    MessageBoxEx.Show("请选择2个人以下导出!");
            //    return;
            //}

            //READEXCEL
            using (FileStream fs = File.OpenRead(GlobalUtils.AppPath + @"\Excel\Templates\template_2人保险申请表格.xls"))
            {
                IWorkbook wkbook = new HSSFWorkbook(fs);
                ISheet sheet = wkbook.GetSheet("sheet1");
                for (int i = 0; i < visaInfoList.Count; i++)
                {
                    string[] englishNames = visaInfoList[i].EnglishName.Split(' ');
                    IRow row = sheet.GetRow(i + 5);

                    row.GetCell(0).SetCellValue(visaInfoList[i].Name + "/" + visaInfoList[i].EnglishName);
                    row.GetCell(1).SetCellValue(visaInfoList[i].PassportNo);
                    row.GetCell(2).SetCellValue(DateTimeFormator.DateTimeToString(visaInfoList[i].Birthday, DateTimeFormator.TimeFormat.Type01Normal));
                    row.GetCell(3).SetCellValue(visaInfoList[i].Sex == "男" ? "M" : "F");
                    row.GetCell(4).SetCellValue(visaInfoList[i].Phone);
                    row.GetCell(5).SetCellValue(DateTimeFormator.DateTimeToString(visamodel.InTime));
                    if (visamodel.OutTime != null)
                        row.GetCell(6).SetCellValue((visamodel.OutTime.Value - visamodel.InTime.Value).Days + 1); //默认14天
                    row.GetCell(7).SetCellValue("旅游"); //默认14天
                    row.GetCell(8).SetCellValue("申根"); //默认14天
                }

                IRow row1 = sheet.GetRow(visaInfoList.Count + 6);
                row1.GetCell(0).SetCellValue(visamodel.GroupNo);

                HSSFFont font = (HSSFFont)wkbook.CreateFont();
                font.FontName = "宋体";
                font.FontHeightInPoints = 10;


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
                    row1 = sheet.GetRow(i);
                    for (int c = 0; c < row1.LastCellNum; ++c)
                    {
                        row1.GetCell(c).CellStyle = style;
                    }
                }


                //sheet.IsPrintGridlines = true;
                string dstName = GlobalUtils.ShowSaveFileDlg("两人保险申请表.xls", "Excel XLS|*.xls");

                // If the file name is not an empty string open it for saving.
                if (!string.IsNullOrEmpty(dstName))
                {
                    try
                    {
                        using (FileStream fs1 = File.OpenWrite(dstName))
                        {
                            wkbook.Write(fs1);
                        }
                        Process.Start(dstName);
                    }
                    catch (Exception)
                    {
                        MessageBoxEx.Show("指定文件名的文件正在使用中，无法写入，请关闭后重试!");
                    }
                }

            }
        }

        public static void Test()
        {
            //if (visaInfoList.Count > 2)
            //{
            //    MessageBoxEx.Show("请选择2个人以下导出!");
            //    return;
            //}

            //READEXCEL
            using (FileStream fs = File.OpenRead(GlobalUtils.AppPath + @"I:\My Documents\My Desktop\签证\20180604_账单.xlsx"))
            {
                IWorkbook wkbook = new XSSFWorkbook(fs);
                ISheet sheet = wkbook.GetSheet("sheet1");

                var row = sheet.CreateRow(0);
                row.CreateCell(0).SetCellValue("test");


                //sheet.IsPrintGridlines = true;
                string dstName = GlobalUtils.ShowSaveFileDlg("test.xls", "Excel XLSX|*.xlsx");

                // If the file name is not an empty string open it for saving.
                if (!string.IsNullOrEmpty(dstName))
                {
                    try
                    {
                        using (FileStream fs1 = File.OpenWrite(dstName))
                        {
                            wkbook.Write(fs1);
                        }
                        Process.Start(dstName);
                    }
                    catch (Exception)
                    {
                        MessageBoxEx.Show("指定文件名的文件正在使用中，无法写入，请关闭后重试!");
                    }
                }

            }
        }



    }
}