using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Extensions;

namespace AdventOfCode2021
{
    public class CaveBeacon
    {
        public int Difficulty;
        public int X;
        public int Y;

        public CaveBeacon(int difficulty, int x, int y)
        {
            Difficulty = difficulty;
            X = x;
            Y = y;
        }

        public IEnumerable<CaveBeacon> CreateAdjacent(int[][] cave)
        {
            if (X < cave[0].Length - 1)
                yield return new CaveBeacon(Difficulty + cave[Y][X + 1], X + 1, Y);
            if (Y < cave.Length - 1)
                yield return new CaveBeacon(Difficulty + cave[Y + 1][X], X, Y + 1);
        }
    }

    public class ChitonCave
    {
        public int[][] Cave;
        public int Solution = 10000000;
        public (int X, int Y) Goal;

        public ChitonCave(int[][] cave)
        {
            Cave = cave;
            Goal = (Cave[0].Length - 1, Cave.Length - 1);
        }
        
        private void RecursiveCrawl(List<CaveBeacon> beacons)
        {
            List<CaveBeacon> next = new List<CaveBeacon>();

            while (beacons.Any())
            {
                IEnumerable<IGrouping<string, CaveBeacon>> temp = beacons.SelectMany(i => i.CreateAdjacent(Cave))
                    .ToArray()
                    .GroupBy(i => $"{i.X} {i.Y}");

                foreach (var grouping in temp)
                {
                    CaveBeacon beacon = grouping.OrderByDescending(i => i.Difficulty)
                        .First();
                    
                    if (beacon.X == Goal.X && beacon.Y == Goal.Y)
                    {
                        if (beacon.Difficulty < Solution)
                            Solution = beacon.Difficulty;

                        continue;
                    }

                    next.Add(beacon);
                }

                beacons = next;
            }

            /*passed[y][x] = true;
            Current += Cave[y][x];

            if (x == Goal.Item1 && y == Goal.Item2)
            {
                ComputeDifficulty();
                Current -= Cave[y][x];
                passed[y][x] = false;
                return;
            }

            if (x < passed[0].Length - 1 && !passed[y][x + 1])
                RecursiveCrawl(passed, x + 1, y);
            if (y < passed.Length - 1 && !passed[y + 1][x])
                RecursiveCrawl(passed, x, y + 1);
            /*if (x > 0 && !passed[y][x - 1])
                RecursiveCrawl(passed, x - 1, y);
            if (y > 0 && !passed[y - 1][x])
                RecursiveCrawl(passed, x, y - 1);*/

            /*Current -= Cave[y][x];
            passed[y][x] = false;*/
        }

        public int GetPathDifficulty()
        {
            bool[][] passage = EnumerableExtensions.Gen2DArray<bool>(Cave.Length, Cave[0].Length);
            List<CaveBeacon> beacons = new List<CaveBeacon>();

            beacons.Add(new CaveBeacon(0, 0, 0));
            RecursiveCrawl(beacons);

            return (Solution);
        }
    }
}
