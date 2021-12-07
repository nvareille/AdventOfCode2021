using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class CrabComputing
    {
        public static int GetDistanceInc(int pos, int actual)
        {
            int result = GetDistance(pos, actual);

            return (result * (result + 1) / 2);
        }

        public static int GetDistance(int pos, int actual)
        {
            if (pos > actual)
                return (pos - actual);
            return (actual - pos);
        }

        public static (int position, int fuel) ComputeClosestPosition(IEnumerable<int> inputs, Func<int, int, int> resolver)
        {
            inputs = inputs.ToArray();

            int min = inputs.Min();
            int max = inputs.Max();

            int best = -1;
            int pos = -1;
            int count = min;

            while (min + count < max)
            {
                int actual = 0;

                foreach (int i in inputs)
                {
                    actual += resolver(min + count, i);
                }
                
                if (best == -1 || actual < best)
                {
                    pos = min + count;
                    best = actual;
                }

                ++count;
            }

            return (pos, best);
        }
    }
}
