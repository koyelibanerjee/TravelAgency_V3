using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.DAL;
using TravelAgency.Model;

namespace TravelAgency.BLL
{
    public class StatisticsBll
    {
        public string tablename;
        private DAL.StatisticsDal dal = new StatisticsDal();

        public int GetCountByTimeSpan(string from, string to)
        {
            string where = "entrytime between '" + from.ToString() + "' and '" + to.ToString() + "'";
            return dal.GetRecordCount(tablename, where);
        }


        public int GetCountByTimeSpan(DateTime from, DateTime to)
        {
            return GetCountByTimeSpan(from.ToString(), to.ToString()); //精确到s了的
        }

        public int GetCountOfYear(int year)
        {
            string strFrom = year + "-01-01 00:00:00";
            string strTo = year + "-12-31 23:59:59";
            return GetCountByTimeSpan(strFrom, strTo);
        }

        public int GetCountOfCurYear()
        {
            return GetCountOfYear(DateTime.Now.Year);
        }

        public int GetCountOfMonth(int year, int month)
        {
            int lastday = TimeHandlers.TimeParser.GetMonthLastDate(year, month);
            string strFrom = String.Format("{0}-{1}-01 00:00:00", year, month);
            string strTo = String.Format("{0}-{1}-{2} 23:59:59", year, month, lastday);
            return GetCountByTimeSpan(strFrom, strTo);
        }

        public int GetCountOfCurMonth()
        {
            return GetCountOfMonth(DateTime.Now.Year, DateTime.Now.Month);
        }

        public int GetCountOfCurWeek()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            string strFrom;
            string strTo;
            int day;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                day = DateTime.Now.Day - 6;
            else
                day = DateTime.Now.Day - (DateTime.Now.DayOfWeek - DayOfWeek.Monday);
            strFrom = String.Format("{0}-{1}-{2} 00:00:00", year, month, day);
            strTo = String.Format("{0}-{1}-{2} 23:59:59", year, month, day + 6);
            return GetCountByTimeSpan(strFrom, strTo);
        }



        //public int GetCountOfWeek(int year, int month,int index) //指定第几周
        //{
        //    DateTime date = new DateTime(year,month,1);

        //    string strFrom = String.Format("{0}-{1}-01 00:00:00", year, month);
        //    string strTo = String.Format("{0}-{1}-{2} 23:59:59", year, month, lastday);
        //    return GetCountByTimeSpan(strFrom, strTo);
        //}

        public int GetCountOfDay(int year, int month, int day)
        {
            string strFrom = String.Format("{0}-{1}-{2} 00:00:00", year, month, day);
            string strTo = String.Format("{0}-{1}-{2} 23:59:59", year, month, day);
            return GetCountByTimeSpan(strFrom, strTo);
        }

        public int GetCountOfCurDay()
        {
            return GetCountOfDay(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        /// <summary>
        /// 取操作记录的数目按照时间区间,如果传入空则不管时间区间
        /// </summary>
        /// <param name="ActType"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetActRecordCount(string acttype, string username, string from, string to)
        {

            string where = " acttype = '" + acttype + "' and username ='" + username + "' ";
            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
                where += " and (entrytime between '" + from + "' and '" + to + "') ";
            return dal.GetActRecordCount(where);
        }

        public List<Model.PersonalStat> GetPersonalStats(string from, string to)
        {
            //取得签证部所有人
            List<Model.AuthUser> userList = new BLL.AuthUser().GetModelList(" departmentid='A86ED375-76DB-45DF-A4E9-D0BB8815D49C' ");

            BLL.StatisticsBll statBll = new VisaInfoStatisticsBll();
            List<Model.PersonalStat> statList = new List<PersonalStat>();
            for (int i = 0; i < userList.Count; i++)
            {
                PersonalStat stat = new PersonalStat();
                stat.WorkId = userList[i].WorkId;
                stat.UserName = userList[i].UserName;
                stat.Type00Count = statBll.GetActRecordCount("00录入(扫描)", stat.UserName, from, to);
                stat.Type01Count = statBll.GetActRecordCount("01录入(设置团号)", stat.UserName, from, to);
                stat.Type01Count += statBll.GetActRecordCount("01录入(添加到已有团号)", stat.UserName, from, to); //这两者统计到一起
                stat.Type02Count = statBll.GetActRecordCount("02录入做资料", stat.UserName, from, to);
                stat.Type03Count = statBll.GetActRecordCount("03修改资料", stat.UserName, from, to);
                stat.Type04Count = statBll.GetActRecordCount("04校验", stat.UserName, from, to);
                statList.Add(stat);
            }

            statList.Sort((model1, model2) => { return model1.Count < model2.Count ? 1 : -1; }); //按照总量排序
            return statList;
        }


    }
}