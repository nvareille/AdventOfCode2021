using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Enums;

namespace AdventOfCode2021
{
    public class SubmarineGPS
    {
        public static int ComputeDistance(IEnumerable<(Direction, int)> tuples)
        {
            int depth = 0;
            int distance = 0;

            foreach ((Direction, int) tuple in tuples)
            {
                switch (tuple.Item1)
                {
                    case Direction.Down:
                        depth += tuple.Item2;
                        break;
                    case Direction.Up:
                        depth -= tuple.Item2;
                        break;
                    case Direction.Forward:
                        distance += tuple.Item2;
                        break;
                }
            }

            return (depth * distance);
        }

        public static int ComputeDistanceAim(IEnumerable<(Direction, int)> tuples)
        {
            int aim = 0;
            int depth = 0;
            int distance = 0;

            foreach ((Direction, int) tuple in tuples)
            {
                switch (tuple.Item1)
                {
                    case Direction.Down:
                        aim += tuple.Item2;
                        break;
                    case Direction.Up:
                        aim -= tuple.Item2;
                        break;
                    case Direction.Forward:
                        distance += tuple.Item2;
                        depth += tuple.Item2 * aim;
                        break;
                }
            }

            return (depth * distance);
        }
    }
}
