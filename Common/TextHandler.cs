using System.Text.RegularExpressions;

namespace TravelAgency.Common
{
    public class TextHandler
    {
        /// <summary>
        /// 机票报表里面用的WU/DATIE这种
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string GetSpecialEnglishName(Model.VisaInfo model)
        {
            //由于这里可能出现多个空格，采用正则表达式进行替换
            string pattern = @"([a-zA-Z]+)(\s+)([a-zA-Z]+)";
            string englishName = model.EnglishName;
            Match m = Regex.Match(englishName, pattern);
           return Regex.Replace(englishName, pattern, "${1}" + @"/" + "${3}"); //替换为指定格式
        }
    }
}