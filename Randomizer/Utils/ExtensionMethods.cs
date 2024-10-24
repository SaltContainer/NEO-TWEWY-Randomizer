using System;
using System.Collections.Generic;

namespace NEO_TWEWY_Randomizer
{
    static class ExtensionMethods
    {
        public static void AddRange<T, S>(this Dictionary<T, S> source, Dictionary<T, S> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null");
            }

            foreach (var item in collection)
            {
                if (!source.ContainsKey(item.Key))
                {
                    source.Add(item.Key, item.Value);
                }
                else
                {
                    source.Remove(item.Key);
                    source.Add(item.Key, item.Value);
                }
            }
        }
    }
}
