using System;
using System.Globalization;

namespace TravelAgency.Common
{

    /// <summary>
    /// 一些时间相关的处理
    /// </summary>
    public static class DateTimeFormator
    {
        public enum TimeFormat
        {
            Type01Normal,//用的最多的
            Type02JapanTotal, //日本送签总表
            Type03Tailand,//泰国团队
            Type04Chinese,//中国
            Type05ReturnTime,//归国时间
            Type06LongTime, //精确到秒
            Type07DayStart,
            Type08DayEnd,
            Type09Jipiao,
            Type10Normal2,
            Type11Tailand2,
            Type12Tailand3,
            Type13Tailand4,
            Type14LongTime1//精确到分
        }
        public static string DateTimeToString(DateTime? dateTime, TimeFormat format = TimeFormat.Type01Normal)
        {

            if (dateTime != null)
            {
                try
                {
                    DateTime dt = (DateTime)dateTime;
                    string res = string.Empty;

                    switch (format)
                    {
                        case TimeFormat.Type01Normal:
                            res = dt.ToString("yyyy/MM/dd");
                            break;
                        case TimeFormat.Type02JapanTotal:
                            res = dt.ToString("yyyy.MM.dd");
                            break;
                        case TimeFormat.Type03Tailand:
                            res = dt.ToString("dd-MMM-yyyy", new CultureInfo("en-US")).ToUpper();
                            break;
                        case TimeFormat.Type04Chinese:
                            res = dt.ToString("yyyy年MM月dd日");
                            break;
                        case TimeFormat.Type05ReturnTime:
                            res = dt.ToString("MM/dd");
                            break;
                        case TimeFormat.Type06LongTime:
                            res = dt.ToString("yyyy/MM/dd HH:mm:ss"); //默认的就是"2018/1/10 19:31:33"
                            break;
                        case TimeFormat.Type07DayStart:
                            res = dt.ToString("yyyy/MM/dd" + " 00:00:00");
                            break;
                        case TimeFormat.Type08DayEnd:
                            res = dt.ToString("yyyy/MM/dd" + " 16:00:00");
                            break;
                        case TimeFormat.Type09Jipiao:
                            res = dt.ToString("ddMMM", new CultureInfo("en-US")).ToUpper(); //20DEC这样
                            break;
                        case TimeFormat.Type10Normal2:
                            res = dt.ToString("yyyy-MM-dd");
                            break;
                        case TimeFormat.Type11Tailand2: //数据源报表用
                            res = dt.ToString("d-MMM-yy", new CultureInfo("en-US"));
                            break;
                        case TimeFormat.Type12Tailand3: //机票报表用
                            res = dt.ToString("dd MMM yyyy", new CultureInfo("en-US")).ToUpper();
                            break;
                        case TimeFormat.Type13Tailand4:
                            res = dt.ToString("dd MMM", new CultureInfo("en-US")).ToUpper();
                            break;
                        case TimeFormat.Type14LongTime1:
                            res = dt.ToString("yyyy/MM/dd HH:mm");
                            break;
                    }
                    return res;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 归国时间的格式
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string DateTimeToStringOfReturnTime(DateTime? dateTime)
        {
            try
            {
                if (dateTime != null)
                {
                    DateTime dt = (DateTime)dateTime;
                    return dt.ToString("MM/dd");
                    //return dt.ToString("yy");
                }
                return "";
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }

        public static DateTime GetNextWorkDate(DateTime time)
        {
            if (time.DayOfWeek == DayOfWeek.Saturday)
            {
                return time.AddDays((double)2);
            }
            if (time.DayOfWeek == DayOfWeek.Sunday)
            {
                return time.AddDays((double)1);
            }
            return time;
        }


        //使用C#把发表的时间改为几个月,几天前,几小时前,几分钟前,或几秒前
        //2008年03月15日 星期六 02:35
        public static string DateStringFromNow(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.TotalDays > 60)
            {
                return dt.ToShortDateString();
            }
            else
            {
                if (span.TotalDays > 30)
                {
                    return
                    "1个月前";
                }
                else
                {
                    if (span.TotalDays > 14)
                    {
                        return
                        "2周前";
                    }
                    else
                    {
                        if (span.TotalDays > 7)
                        {
                            return
                            "1周前";
                        }
                        else
                        {
                            if (span.TotalDays > 1)
                            {
                                return
                                string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                            }
                            else
                            {
                                if (span.TotalHours > 1)
                                {
                                    return
                                    string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                                }
                                else
                                {
                                    if (span.TotalMinutes > 1)
                                    {
                                        return
                                        string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                                    }
                                    else
                                    {
                                        if (span.TotalSeconds >= 1)
                                        {
                                            return
                                            string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                                        }
                                        else
                                        {
                                            return
                                            "1秒前";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //C#中使用TimeSpan计算两个时间的差值
        //可以反加两个日期之间任何一个时间单位。
        private static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            return dateDiff;
        }


        //说明：
        /**/
        /*1.DateTime值类型代表了一个从公元0001年1月1日0点0分0秒到公元9999年12月31日23点59分59秒之间的具体日期时刻。因此，你可以用DateTime值类型来描述任何在想象范围之内的时间。一个DateTime值代表了一个具体的时刻
        2.TimeSpan值包含了许多属性与方法，用于访问或处理一个TimeSpan值
        下面的列表涵盖了其中的一部分：
        Add：与另一个TimeSpan值相加。 
        Days:返回用天数计算的TimeSpan值。 
        Duration:获取TimeSpan的绝对值。 
        Hours:返回用小时计算的TimeSpan值 
        Milliseconds:返回用毫秒计算的TimeSpan值。 
        Minutes:返回用分钟计算的TimeSpan值。 
        Negate:返回当前实例的相反数。 
        Seconds:返回用秒计算的TimeSpan值。 
        Subtract:从中减去另一个TimeSpan值。 
        Ticks:返回TimeSpan值的tick数。 
        TotalDays:返回TimeSpan值表示的天数。 
        TotalHours:返回TimeSpan值表示的小时数。 
        TotalMilliseconds:返回TimeSpan值表示的毫秒数。 
        TotalMinutes:返回TimeSpan值表示的分钟数。 
        TotalSeconds:返回TimeSpan值表示的秒数。
        */

        /**/
        /// <summary>
        /// 日期比较
        /// </summary>
        /// <param name="today">当前日期</param>
        /// <param name="writeDate">输入日期</param>
        /// <param name="n">比较天数</param>
        /// <returns>大于天数返回true，小于返回false</returns>
        private static bool CompareDate(string today, string writeDate, int n)
        {
            DateTime Today = Convert.ToDateTime(today);
            DateTime WriteDate = Convert.ToDateTime(writeDate);
            WriteDate = WriteDate.AddDays(n);
            if (Today >= WriteDate)
                return false;
            else
                return true;
        }



    }
}