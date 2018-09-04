using System.Collections.Generic;

namespace TravelAgency.Model.Enums
{
    /// <summary>
    /// 不能用静态类，不然不能声明对象，有时候会用到
    /// </summary>
    public class Types
    {
        public const string Individual = "个签";
        public const string Team = "团签";
        public const string Team2Individual = "团做个";
        public const string Default = "缺省";

        public static  List<string> List = new List<string>
        {
            "全部",Individual,Team,Team2Individual,Default,"未记录","个签&&团做个"
        }; 
    }
}
