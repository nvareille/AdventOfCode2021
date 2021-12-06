using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Containers;

namespace AdventOfCode2021
{
    public class LanternFishComputer
    {
        public static IEnumerable<StateElement<int>> ComputeStateAfter(IEnumerable<int> s, int days)
        {
            List<StateElement<int>> states = s.Select(i => new StateElement<int>(i, 6))
                .ToList();

            while (days > 0)
            {
                int toAdd = 0;

                foreach (StateElement<int> element in states)
                {
                    if (element.Actual <= 0)
                    {
                        element.Reset();
                        ++toAdd;
                    }
                    else
                    {
                        element.Tick(i => --i.Actual);
                    }
                }
                --days;

                while (toAdd > 0)
                {
                    states.Add(new StateElement<int>(8, 6));
                    --toAdd;
                }
            }

            return (states);
        }

        public static long ComputeStateAfterOptimized(IEnumerable<int> s, int days)
        {
            long[] states = new long[9];

            foreach (int state in s)
            {
                ++states[state];
            }

            while (days > 0)
            {
                int decal = 0;
                long toAdd = states[0];

                while (decal < 8)
                {
                    states[decal] = states[decal + 1];
                    ++decal;
                }

                states[8] = toAdd;
                states[6] += toAdd;
                --days;
            }

            return (states.Sum());
        }
    }
}
