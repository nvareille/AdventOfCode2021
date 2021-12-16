using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Extensions
{
    public static class StringExtensions
    {
        public static string ToAlpha(this string str)
        {
            return (new string(str.OrderBy(i => i).ToArray()));
        }

        public static int CommonLetters(this string str1, string str2)
        {
            return (str1.Count(str2.Contains));
        }

        public static long FromBinaryLong(this string str)
        {
            return (Convert.ToInt64(str, 2));
        }
    }
}
