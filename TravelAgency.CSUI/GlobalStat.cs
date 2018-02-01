using System;
using TravelAgency.BLL;
using TravelAgency.Common;

namespace TravelAgency.CSUI
{
    /// <summary>
    /// 全局用的更新统计类
    /// </summary>
    public static class GlobalStat
    {
        public static FrmMain.FrmMain MainFrm;
        private static BLL.VisaInfoStatisticsBll _bllVisaInfoStat = new VisaInfoStatisticsBll();
        private static BLL.VisaStatisticsBll _bllVisaStat = new VisaStatisticsBll();

        static GlobalStat()
        {
            MainFrm = FrmsManager.OpenedForms[0] as FrmMain.FrmMain;
        }

        public static void UpdateStatistics()
        {
            int dayCount = _bllVisaInfoStat.GetCountOfCurDay();
            DateTime date = DateTime.Now.Date.AddDays(-1.0);
            int daypreCount = _bllVisaInfoStat.GetCountOfDay(date.Year, date.Month, date.Day);
            int weekCount = _bllVisaInfoStat.GetCountOfCurWeek();
            int monthCount = _bllVisaInfoStat.GetCountOfCurMonth();

            string str = String.Format("签证统计:今日:{1}, 昨日:{0}, 本周:{2}, 本月: {3} 本", daypreCount, dayCount, weekCount, monthCount);

            MainFrm.SetLbVisaInfoCount(str);

            dayCount = _bllVisaStat.GetCountOfCurDay();
            weekCount = _bllVisaStat.GetCountOfCurWeek();
            monthCount = _bllVisaStat.GetCountOfCurMonth();

            //str = String.Format("签证统计:昨日已做:{1} 今日已做:{0}, 本周已做:{1}, 本月已做: {2}");


        }

    }
}