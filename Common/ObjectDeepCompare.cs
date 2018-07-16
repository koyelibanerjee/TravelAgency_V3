using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common
{
    public class ObjectDeepCompare
    {

        /// <summary>
        /// 判断两个相同引用类型的对象的属性值是否相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj1">对象1</param>
        /// <param name="obj2">对象2</param>
        /// <param name="type">按type类型中的属性进行比较</param>
        /// <returns></returns>
        public static bool CompareObjectsDeep<T>(T obj1, T obj2, Type type)
        {
            //为空判断
            if (obj1 == null && obj2 == null)
                return true;
            else if (obj1 == null || obj2 == null)
                return false;

            Type t = type;
            PropertyInfo[] props = t.GetProperties();
            foreach (var po in props)
            {
                if (IsCanCompare(po.PropertyType))
                {
                    if (po.GetValue(obj1) == null && po.GetValue(obj2) == null)
                        continue;
                    if (po.GetValue(obj1) == null && po.GetValue(obj2) != null)
                        return false;
                    if (po.GetValue(obj2) == null && po.GetValue(obj1) != null)
                        return false;
                    if (!po.GetValue(obj1).Equals(po.GetValue(obj2)))
                        return false;
                }
                else
                {
                    return CompareObjectsDeep(po.GetValue(obj1), po.GetValue(obj2), po.PropertyType);
                }
            }

            return true;
        }

        /// <summary>
        /// 该类型是否可直接进行值的比较
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static bool IsCanCompare(Type t)
        {
            if (t.IsValueType)
            {
                return true;
            }
            else
            {
                //String是特殊的引用类型，它可以直接进行值的比较
                if (t.FullName == typeof(String).FullName)
                {
                    return true;
                }
                return false;
            }
        }


        public static bool CompareListDeep<T>(List<T> list1, List<T> list2, Type t)
        {
            if (list1 == null && list2 == null)
                return true;
            if (list1 == null && list2 != null)
                return false;
            if (list2 == null && list1 != null)
                return false;
            if (list1.Count != list2.Count)
                return false;

            for (var i = 0; i < list1.Count; i++)
                if (CompareObjectsDeep(list1[i], list2[i], t) == false)
                    return false;
            return true;
        }

    }
}
