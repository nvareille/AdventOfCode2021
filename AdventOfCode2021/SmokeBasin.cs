using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class SmokeBasin
    {
        private static int GetPointValue(int[][] input, int x, int y, bool replace = false)
        {
            try
            {
                int point = input[x][y];

                if (replace)
                    input[x][y] = -1;
                return (point);
            }
            catch (Exception)
            {
                return (10000);
            }
            
        }

        private static bool IsLowPoint(int point, int[][] input, int x, int y)
        {
            return (point < GetPointValue(input, x - 1, y)
                    && point < GetPointValue(input, x + 1, y)
                    && point < GetPointValue(input, x, y - 1)
                    && point < GetPointValue(input, x, y + 1));
        }

        public static int ComputeRiskLevel(int[][] input)
        {
            int x = 0;
            int sum = 0;

            while (x < input.Length)
            {
                int y = 0;

                while (y < input[x].Length)
                {
                    int point = input[x][y];

                    if (IsLowPoint(point, input, x, y))
                        sum += point + 1;

                    ++y;
                }

                ++x;
            }

            return (sum);
        }

        public static IEnumerable<int> FindBasins(int[][] input)
        {
            IEnumerable<(int x, int y)> points = FindLowerPoints(input);

            foreach ((int x, int y) point in points)
            {
                yield return (IteratePoints(input, point.x, point.y).Sum());
            }
        }

        private static IEnumerable<int> IteratePoints(int[][] input, int x, int y)
        {
            (int x, int y, int value)[] points = new[]
            {
                (x + 1, y, GetPointValue(input, x + 1, y, true)),
                (x - 1, y, GetPointValue(input, x - 1, y, true)),
                (x, y + 1, GetPointValue(input, x, y + 1, true)),
                (x, y - 1, GetPointValue(input, x, y - 1, true)),
            };

            foreach ((int x, int y, int value) point in points)
            {
                if (point.value >= 0 && point.value < 9)
                {
                    yield return (1);
                    yield return (IteratePoints(input, point.x, point.y).Sum());
                }
            }
        }

        private static IEnumerable<(int x, int y)> FindLowerPoints(int[][] input)
        {
            int x = 0;

            while (x < input.Length)
            {
                int y = 0;

                while (y < input[x].Length)
                {
                    int point = input[x][y];

                    if (IsLowPoint(point, input, x, y))
                        yield return (x, y);

                    ++y;
                }

                ++x;
            }
        }
    }
}
