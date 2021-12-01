using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class SonarSweep
    {
        public static int GetDepthIncrease(IEnumerable<int> input)
        {
            int count = 0;
            int depth = input.First();

            foreach (int i in input.Skip(1))
            {
                if (i > depth)
                    ++count;
                depth = i;
            }

            return (count);
        }

        private static int GetWindowDepth(IEnumerable<int> input, int idx, int window)
        {
            int windowIdx = 0;
            int depth = 0;

            while (windowIdx < window)
            {
                depth += input.ElementAt(windowIdx + idx);
                ++windowIdx;
            }

            return (depth);
        }

        public static int GetDepthIncreaseWindow(IEnumerable<int> input, int window = 3)
        {
            int count = 0;
            int idx = 1;
            int depth = GetWindowDepth(input, 0, window);

            while (idx <= input.Count() - window)
            {
                int tempDepth = GetWindowDepth(input, idx, window);

                if (depth < tempDepth)
                    ++count;
                depth = tempDepth;
                ++idx;
            }

            return (count);
        }
    }
}
