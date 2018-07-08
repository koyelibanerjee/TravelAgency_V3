using System;
using System.Collections.Generic;
using TravelAgency.Model;

namespace TravelAgency.BLL
{
    public class CommisionBll
    {
        private BLL.StatisticsBll _bll = new StatisticsBll();

        /// <summary>
        /// 生成where条件
        /// </summary>
        /// <param name="username"></param>
        /// <param name="country"></param>
        /// <param name="acttype"></param>
        /// <returns></returns>
        public string GenOtherWhere(string username, string country, string acttype)
        {
            string where = " username='" + username + "' and acttype='" + acttype+"' ";
            if (acttype == "00录入(扫描)") //如果是录入，不考虑是个签还是团签
            {
                if (country == "日本个签" || country == "日本团签") //单独处理日本的
                {
                    where += " and country = '日本' ";
                }
                else if (country == "其他") //其他就是未设置国家的
                {
                    where += " and (country is null or len(country)=0) ";
                }
                else //其他国家直接
                {
                    where += " and country = '" + country + "' ";
                }
            }
            else
            {
                if (country == "日本个签") //单独处理日本的
                {
                    where += " and country = '日本' and (type = '个签' or type='团做个')"; //个签按照团做个进行统计
                }
                else if (country == "日本团签") //单独处理日本团签
                {
                    where += " and country = '日本' and type = '团签'";
                }

                else //其他国家直接
                {
                    where += " and country = '" + country + "' ";
                }
            }

            return where;
        }
        #region 得到一个人指定时间的指定国家指定操作类型的数目
        /// <summary>
        /// 统计每个人对于每个国家每种操作类型的记录数目
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="username"></param>
        /// <param name="country"></param>
        /// <param name="acttype"></param>
        /// <returns></returns>
        public int GetPersonnalActCount(string from, string to, string username, string country, string acttype)
        {
            return _bll.GetCountByTimeSpan(from, to, GenOtherWhere(username, country, acttype));
        }

        #region 统计指定年月日
        public int GetCountOfYear(int year, string username, string country, string acttype)
        {
            return _bll.GetCountOfYear(year, GenOtherWhere(username, country, acttype));
        }
        public int GetCountOfMonth(int year, int month, string username, string country, string acttype)
        {
            return _bll.GetCountOfMonth(year, month, GenOtherWhere(username, country, acttype));

        }
        public int GetCountOfDay(int year, int month, int day, string username, string country, string acttype)
        {
            return _bll.GetCountOfDay(year, month, day, GenOtherWhere(username, country, acttype));
        }
        #endregion
        #region 统计当前年月周
        public int GetCountOfCurMonth(string username, string country, string acttype)
        {
            return _bll.GetCountOfCurMonth(GenOtherWhere(username, country, acttype));
        }

        public int GetCountOfCurWeek(string username, string country, string acttype)
        {
            return _bll.GetCountOfCurWeek(GenOtherWhere(username, country, acttype));

        }
        public int GetCountOfCurDay(string username, string country, string acttype)
        {
            return _bll.GetCountOfCurDay(GenOtherWhere(username, country, acttype));
        }
        #endregion
        #endregion


        #region 得到一个人的指定时间段的CommisionModel的List
        /// <summary>
        /// 返回一个人所有国家的提成列表
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<Model.CommissionModel> GetPersonCommisonList(string from, string to, string username)
        {
            string countrys = "日本个签,日本团签,韩国,澳大利亚,新西兰贴纸,新西兰电子签,希腊,捷克,法国,西班牙," +
                                    "英国,南非,美国,泰国,新加坡,马来西亚,越南,保险,印度,德国,加拿大,其他"; //最后的德国和加拿大是我自己加的，其他是扫描的时候用来判断未设置国家的情况
            string[] countrylist = countrys.Split(',');
            List<Model.CommissionModel> res = new List<CommissionModel>();
            for (int i = 0; i != countrylist.Length; ++i)
            {
                Model.CommissionModel model = new Model.CommissionModel();
                model.Type = countrylist[i];
                if (i == 1)
                    model.Type00ScanedIn = 0;
                else
                    model.Type00ScanedIn = GetPersonnalActCount(from, to, username, countrylist[i], "00录入(扫描)");
                model.Type02TypeInData = GetPersonnalActCount(from, to, username, countrylist[i], "02录入做资料");
                model.Type05SendSubmission = 0;
                model.Type06GetSubmission = 0;
                model.Type07AccompanySubmission = 0;
                model.Type08Plan = 0;
                res.Add(model);
            }

            return res;
        }

        #region 统计指定年月日
        public List<Model.CommissionModel> GetPersonCommisonListOfYear(int year, string username)
        {
            string strFrom = year + "-01-01 00:00:00";
            string strTo = year + "-12-31 23:59:59";
            return GetPersonCommisonList(strFrom, strTo, username);
        }
        public List<Model.CommissionModel> GetPersonCommisonListOfMonth(int year, int month, string username)
        {
            int lastday = TimeHandlers.TimeParser.GetMonthLastDate(year, month);
            string strFrom = String.Format("{0}-{1}-01 00:00:00", year, month);
            string strTo = String.Format("{0}-{1}-{2} 23:59:59", year, month, lastday);
            return GetPersonCommisonList(strFrom, strTo, username);
        }
        public List<Model.CommissionModel> GetPersonCommisonListOfDay(int year, int month, int day, string username)
        {
            string strFrom = String.Format("{0}-{1}-{2} 00:00:00", year, month, day);
            string strTo = String.Format("{0}-{1}-{2} 23:59:59", year, month, day);
            return GetPersonCommisonList(strFrom, strTo, username);
        }
        #endregion
        #region 统计当前年月周
        public List<Model.CommissionModel> GetPersonCommisonListOfCurYear(string username)
        {
            return GetPersonCommisonListOfYear(DateTime.Now.Year, username);
        }
        public List<Model.CommissionModel> GetPersonCommisonListOfCurMonth(string username)
        {
            return GetPersonCommisonListOfMonth(DateTime.Now.Year, DateTime.Now.Month, username);
        }

        public List<Model.CommissionModel> GetPersonCommisonListOfCurWeek(string username)
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
            strFrom = $"{year}-{month}-{day} 00:00:00";
            strTo = $"{year}-{month}-{day + 6} 23:59:59";
            return GetPersonCommisonList(strFrom, strTo, username);
        }
        public List<Model.CommissionModel> GetPersonCommisonListOfCurDay(string otherwhere = "")
        {
            return GetPersonCommisonListOfDay(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, otherwhere);
        }
        #endregion
        #endregion







    }
}