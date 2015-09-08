using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YelpSharpPortable.Util
{
    public static class DictionaryExtension
    {
       
           /// <summary>
           /// 
           /// </summary>
           /// <typeparam name="T"></typeparam>
           /// <typeparam name="TK"></typeparam>
           /// <typeparam name="TV"></typeparam>
           /// <param name="me"></param>
           /// <param name="others"></param>
           /// <returns></returns>
            public static T MergeLeft<T, TK, TV>(this T me, params IDictionary<TK, TV>[] others)
                where T : IDictionary<TK, TV>, new()
            {
                var newMap = new T();
                foreach (var src in
                    (new List<IDictionary<TK, TV>> { me }).Concat(others))
                {
                    foreach (var p in src)
                    {
                        newMap[p.Key] = p.Value;
                    }
                }
                return newMap;
            }

        
    }
}
