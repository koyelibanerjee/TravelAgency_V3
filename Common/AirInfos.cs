using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common
{
    public class AirInfos
    {
        public static readonly Dictionary<int, List<string>> AirInfoDict = new Dictionary<int, List<string>>
        {
            {0,new List<string>() {"成都空港NH948便にて成田空港到着","東京成田空港NH947便にて中国ヘ", "东京去   东京回" }},
            {1,new List<string>(){"成都双流空港より成都から3U8085便にて成田空港へ。","成田空港より3U8086（1410/1530）便にて帰国へ","东京去   东京回"} },
            {2,new List<string>() {"成都双流国际机场3U8087便にて関西空港へ。到着後、ホテルへ","关西空港より3U8088便にて帰国へ","大阪去   大阪回" } },
            {3,new List<string>() {"成都双流空港より上海からCA459便にて成田空港へ。","成田空港よりCA460便にて帰国へ","东京去   东京回" } },
            {4,new List<string>() {"上海浦东空港より上海からMU279便にて新千岁空港へ。","新千岁空港よりMU280便にて帰国へ","札幌去   札幌回" } },
            {5,new List<string>() {"上海浦东空港より上海からMU287便にて那霸空港へ。","那霸空港よりMU288便にて帰国へ","冲绳去   冲绳回" } },
            {6,new List<string>() {"成都双流空港より上海から3U8085便にて成田空港へ。","成田空港より3U8088便にて帰国へ", "东京去   大阪回" } }
        };
    }
}
