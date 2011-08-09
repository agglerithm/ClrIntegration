using System;
using System.Collections.Generic;

namespace cjrCommon.Extensions
{
    public static class CollectionExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T obj in collection)
                action(obj);
        }
    }
}