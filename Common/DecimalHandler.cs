using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common
{
    public class DecimalHandler
    {
        /// <summary>
        /// 失败返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal Parse(string str)
        {
            if (string.IsNullOrEmpty(str))
                return decimal.Zero;
            if (str.Contains("%")) //含有百分号的解析
            {
                try
                {
                    return decimal.Parse(str.Replace("%", "")) / 100;
                }
                catch (Exception)
                {
                    return decimal.Zero;
                }
            }
            try
            {
                return decimal.Parse(str);
            }
            catch (Exception)
            {
                return decimal.Zero;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="digit">小数点位数</param>
        /// <returns></returns>
        public static string DecimalToString(Decimal? d, int digit)
        {
            if (digit == -1)
                return DecimalToString(d);
            return Math.Round(d ?? 0, digit).ToString();
        }

        /// <summary>
        /// 自适应去掉尾部的0
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string DecimalToString(Decimal? d)
        {
            string str = (d ?? 0).ToString();
            if (str.Contains("."))
            {
                str = str.TrimEnd('0'); //移除所有尾部0
                if (str.EndsWith("."))
                    return str.TrimEnd('.');
            }
            return str;
        }

        /// <summary>
        /// 转换成百分比，23% 不带小数位了
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string DecimalToPercent(Decimal? d)
        {
            decimal d1 = d ?? 0;
            d1 *= 100;
            return DecimalToString(d1, 0) + "%";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="digit">小数点位数</param>
        /// <returns></returns>
        public static decimal Round(Decimal d, int digit)
        {
            return Math.Round(d, digit);
        }
    }
}
