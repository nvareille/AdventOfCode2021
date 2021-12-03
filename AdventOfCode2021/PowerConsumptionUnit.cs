using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class PowerConsumptionUnit
    {
        public static long ComputeConsumption(IEnumerable<char[]> input)
        {
            int count = 0;
            int max = input.First().Length;

            long gamma = 0;
            long epsilon = 0;
            
            while (count < max)
            {
                IEnumerable<IGrouping<char, char>> groups = input.Select(i => i[count]).GroupBy(i => i);
                int a = groups.FirstOrDefault(i => i.Key == '0').Count();
                int b = groups.FirstOrDefault(i => i.Key == '1').Count();

                gamma = gamma << 1;
                epsilon = epsilon << 1;

                if (b > a)
                    gamma += 1;
                else
                    epsilon += 1;

                ++count;
            }

            return (gamma * epsilon);
        }

        private static IEnumerable<char[]> GetSubset(IEnumerable<char[]> input, int idx, Func<int, int, bool> operand, char dfault)
        {
            if (input.Count() == 1)
                return (input);

            IEnumerable<IGrouping<char, char>> groups = input.Select(i => i[idx]).GroupBy(i => i);
            int a = groups.FirstOrDefault(i => i.Key == '0').Count();
            int b = groups.FirstOrDefault(i => i.Key == '1').Count();
            char bit;

            if (a == b)
                bit = dfault;
            else
                bit = (operand(a, b) ? '0' : '1');
            
            input = input.Where(i => i[idx] == bit);

            return (input);
        }

        public static ulong ComputeAirValues(IEnumerable<char[]> input)
        {
            int count = 0;
            int max = input.First().Length;
            IEnumerable<char[]> o2 = input;
            IEnumerable<char[]> co2 = input;

            while (count < max)
            {
                o2 = GetSubset(o2, count, (a, b) => a > b, '1');
                co2 = GetSubset(co2, count, (a, b) => a < b, '0');
                
                ++count;
            }

            string str = new string(o2.First());
            string str2 = new string(co2.First());

            ulong l1 = Convert.ToUInt64(str, 2);
            ulong l2 = Convert.ToUInt64(str2, 2);

            return (l1 * l2);
        }
    }
}
