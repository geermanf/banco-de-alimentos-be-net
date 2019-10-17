using System;
using System.Collections.Generic;
using System.Linq;

namespace Farmacity.Helpers.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> Each<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null) return collection;

            foreach (var item in collection)
                action(item);

            return collection;
        }

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return !(collection == null || !collection.Any());
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            return !collection.Any();
        }

        public static void AddRange<T>(this IList<T> list, IList<T> secondList)
        {
            if (secondList == null || secondList.Count == 0)
                return;
            foreach (var item in secondList)
                list.Add(item);
        }
    }
}
