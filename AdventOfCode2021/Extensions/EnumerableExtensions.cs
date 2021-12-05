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
    }
}
