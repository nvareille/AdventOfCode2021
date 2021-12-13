using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Extensions
{
    public static class EnumerableExtensions
    {
        public static U Then<T, U>(this T obj, Func<T, U> fct)
        {
            return (fct(obj));
        }

        public static void IterateDoubleArray<T>(this T[][] array, Action<int, int> fct)
        {
            foreach (int x in Enumerable.Range(0, array.Length))
            {
                foreach (int y in Enumerable.Range(0, array[0].Length))
                {
                    fct(x, y);
                }
            }
        }
    }
}
