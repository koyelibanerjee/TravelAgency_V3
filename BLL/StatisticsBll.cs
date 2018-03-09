using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.DAL;
using TravelAgency.Model;

namespace TravelAgency.BLL
{
    public class StatisticsBll
    {
        public string tablename = "ActionRecords";
        private DAL.StatisticsDal dal = new StatisticsDal();
        public const string CommonOtherWhere = " acttype = '02录入做资料' "; //这个类是用来统计总共工作量的
        //也被继承用来做其他统计
        /// <summary>
        /// 按照时间区间求记录数目
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="otherwhere"></param>
        /// <returns></returns>
        public int GetCountByTimeSpan(string from, string to, string otherwhere = CommonOtherWhere)
        {
            string where = null;
            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
                where = "entrytime between '" + from.ToString() + "' and '" + to.ToString() + "'";

            if (!string.IsNullOrEmpty(otherwhere))
                if (!string.IsNullOrEmpty(where))
                    where += " and " + otherwhere;
                else
                    where += otherwhere;
            return dal.GetActRecordCount(where);
        }




        //public int GetCountByTimeSpan(DateTime from, DateTime to)
        //{
        //    return GetCountByTimeSpan(from.ToString(), to.ToString()); //精确到s了的
        //}
        #region 统计指定年月日
        public int GetCountOfYear(int year, string otherwhere = CommonOtherWhere)
        {
            string strFrom = year + "-01-01 00:00:00";
            string strTo = year + "-12-31 23:59:59";
            return GetCountByTimeSpan(strFrom, strTo, otherwhere);
        }



        public int GetCountOfMonth(int year, int month, string otherwhere = CommonOtherWhere)
        {
            int lastday = TimeHandlers.TimeParser.GetMonthLastDate(year, month);
            string strFrom = String.Format("{0}-{1}-01 00:00:00", year, month);
            string strTo = String.Format("{0}-{1}-{2} 23:59:59", year, month, lastday);
            return GetCountByTimeSpan(strFrom, strTo, otherwhere);
        }


        public int GetCountOfDay(int year, int month, int day, string otherwhere = CommonOtherWhere)
        {
            string strFrom = String.Format("{0}-{1}-{2} 00:00:00", year, month, day);
            string strTo = String.Format("{0}-{1}-{2} 23:59:59", year, month, day);
            return GetCountByTimeSpan(strFrom, strTo, otherwhere);
        }
        #endregion
        #region 统计当前年月周
        public int GetCountOfCurYear(string otherwhere = CommonOtherWhere)
        {
            return GetCountOfYear(DateTime.Now.Year, otherwhere);
        }
        public int GetCountOfCurMonth(string otherwhere = CommonOtherWhere)
        {
            return GetCountOfMonth(DateTime.Now.Year, DateTime.Now.Month, otherwhere);
        }

        public int GetCountOfCurWeek(string otherwhere = CommonOtherWhere)
        {
            var date = DateTime.Now.DayOfWeek == DayOfWeek.Sunday ? //找到所在周的起始(周一)
                DateTime.Now.Date.AddDays(-6.0) : DateTime.Now.Date.AddDays(DayOfWeek.Monday - DateTime.Now.DayOfWeek);
            string strFrom = $"{date.Year}-{date.Month}-{date.Day} 00:00:00";
            date = date.AddDays(6.0);//找到所在周的结束
            string strTo = $"{date.Year}-{date.Month}-{date.Day} 23:59:59";
            return GetCountByTimeSpan(strFrom, strTo, otherwhere);
        }
        public int GetCountOfCurDay(string otherwhere = CommonOtherWhere)
        {
            return GetCountOfDay(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, otherwhere);
        }
        #endregion



        //public int GetCountOfWeek(int year, int month,int index) //指定第几周
        //{
        //    DateTime date = new DateTime(year,month,1);

        //    string strFrom = String.Format("{0}-{1}-01 00:00:00", year, month);
        //    string strTo = String.Format("{0}-{1}-{2} 23:59:59", year, month, lastday);
        //    return GetCountByTimeSpan(strFrom, strTo);
        //}

        #region 统计个人工作量，不管提成的部分
        /// <summary>
        /// 取操作记录的数目按照时间区间,如果传入空则不管时间区间
        /// </summary>
        /// <param name="ActType"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetActRecordCount(string acttype, string username, string from, string to, string otherwhere = "")
        {
            string where = " acttype = '" + acttype + "' and username ='" + username + "' ";
            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
                where += " and (entrytime between '" + from + "' and '" + to + "') ";

            if (!string.IsNullOrEmpty(otherwhere))
                where += " and " + otherwhere;
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
        #endregion
    }
}