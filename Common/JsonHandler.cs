using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common
{
    public class JsonHandler
    {
        public static string GenJson(List<string> key, List<string> value)
        {
            if (key.Count != value.Count)
                throw new Exception("键值对数量不匹配!");

            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            for (int i = 0; i < key.Count; ++i)
            {
                sb.Append("\"" + key[i] + "\"");
                sb.Append(":");
                sb.Append("\"" + value[i] + "\",");
            }
            sb.Remove(sb.Length - 1,1);
            sb.Append("}");
            return sb.ToString(); 
        }

    }
}
