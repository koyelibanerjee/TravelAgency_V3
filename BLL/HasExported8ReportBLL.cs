using System;
using System.Data;
using System.Collections.Generic;
using System.Globalization;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    /// <summary>
    /// HasExported8Report
    /// </summary>
    public partial class HasExported8Report
    {

        /// <summary>
        /// 检查已经导出8人报表里面是否有所选项，如果有的话，就删除
        /// </summary>
        /// <param name="visaList"></param>
        /// <param name="visaInfoList"></param>
        public void CheckExistAndRemove(List<Model.Visa> visaList, List<List<Model.VisaInfo>> visaInfoList)
        {
            for (int i = visaInfoList.Count - 1; i >= 0; i--)
            {
                for (int j = visaInfoList[i].Count - 1; j >= 0; j--)
                {
                    if (Exists(visaInfoList[i][j].VisaInfo_id))
                        visaInfoList[i].Remove(visaInfoList[i][j]);
                }
                if (visaInfoList[i].Count == 0)
                {
                    visaList.Remove(visaList[i]);
                    visaInfoList.Remove(visaInfoList[i]);
                }
            }
        }

        /// <summary>
        /// 获取指定时间段的已导出8人报表的VisaInfoList
        /// </summary>
        /// <param name="visaList"></param>
        /// <param name="visaInfoList"></param>
        public List<Model.VisaInfo> GetHasExportedVisaInfoOfTimeSpan(DateTime from, DateTime end)
        {
            BLL.VisaInfo visaInfoBll = new VisaInfo();
            //var list =
            //    GetModelList(" (EntryTime between '" + from.ToString("yyyy-MM-dd") + " 00:00:0.000' and " + " '" + end.ToString("yyyy-MM-dd") +
            //                   " 23:59:59.999') ");
            var list =
    GetModelList(" (EntryTime between '" + from.ToString("yyyy/MM/dd HH:mm:ss") + " ' and " + " '" + end.ToString("yyyy/MM/dd HH:mm:ss") +
                   "') ");

            List<Model.VisaInfo> visaInfoList = new List<Model.VisaInfo>();

            for (int i = 0; i < list.Count; i++)
            {
                visaInfoList.Add(visaInfoBll.GetModel(list[i].VisaInfo_id));
            }
            return visaInfoList;
        }
    }
}

