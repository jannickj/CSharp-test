using System;
using System.Collections.Generic;
using System.Linq;

namespace Opg1
{
    /// <summary>
    /// Implement the missing method(s).
    /// Your implementation must pass as many tests as possible.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Find the nearest to a given value and return it.
        /// If multiple matches are found the first is returned.
        /// </summary>
        /// <param name="list">List to look through.</param>
        /// <param name="value">Value to find nearest for.</param>
        /// <returns>The nearest value.</returns>
        public static int? FindNearest(this IEnumerable<int> list, int value)
        {
            if(!list.Any())
                return null;

            return list.
                   TakeWhileIncluding(v => v != value).                         // To archieve best case time O(1)
                   Select(v => Tuple.Create(v, Math.Abs(v - value))).           // calculates how far each number is from value
                   Aggregate((t1,t2) => t1.Item2 <= t2.Item2 ? t1 : t2).Item1 ; // Fold over the list keeping the smallest each time
                                                                                //  and keep the old if they are the same
            
        }

        /// <summary>
        /// TakeWhile but includes the elemenet that halted it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The sequence</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns></returns>
        public static IEnumerable<T> TakeWhileIncluding<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach(T elem in list)
            {
                yield return elem;
                if (!predicate(elem))
                    yield break;
            }
        }

        /// <summary>
        /// Find a node that satisfy a given predicate and return it.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="Node{T}"/>.</typeparam>
        /// <param name="node">The current node.</param>
        /// <param name="predicate">The given predicate to satisfy.</param>
        /// <param name="next">Child selector.</param>
        /// <returns>Node satisfying the condtion, else null</returns>
        public static Node<T> FindWhere<T>(this Node<T> node, Func<Node<T>, bool> predicate, Func<Node<T>, IEnumerable<Node<T>>> next)
        {
            if (predicate(node))
                return node;

            var children = next(node);
            return children.
                   Select(c => c.FindWhere(predicate, next)). // Change the child into the element that satisfies the predicate
                   FirstOrDefault(c => c != null);            // Discard all the children that found nothing
        }


    }
}
