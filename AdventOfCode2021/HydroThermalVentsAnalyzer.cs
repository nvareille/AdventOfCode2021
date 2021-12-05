using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Extensions;

namespace AdventOfCode2021
{
    public class HydroThermalVentsAnalyzer
    {
        private int[][] Map;
        private IEnumerable<(Coordinates a, Coordinates b)> Inputs;

        public HydroThermalVentsAnalyzer(IEnumerable<(Coordinates a, Coordinates b)> inputs)
        {
            Inputs = inputs.ToArray();
            (int x, int y) max = GetMaxValues(Inputs);

            Map = new int[max.x + 1][];

            int count = 0;
            while (count <= max.x)
            {
                Map[count] = new int[max.y + 1];
                ++count;
            }
        }

        private (int x, int y) GetMaxValues(IEnumerable<(Coordinates a, Coordinates b)> inputs)
        {
            IEnumerable<Coordinates> points = inputs.SelectMany(i => new Coordinates[]
            {
                i.a,
                i.b
            }).ToArray();

            return
            (
                points.Max(i => i.X), 
                points.Max(i => i.Y)
            );
        }

        public int GetOverlapingPoints(bool diagonal = false)
        {
            foreach ((Coordinates a, Coordinates b) input in Inputs)
            {
                int x = 0;
                int y = 0;

               ConditionBrancher<(int x, int y)> brancher = new ConditionBrancher<(int x, int y)>()
                   .Append(data => input.a.X + data.x > input.b.X, () => --x)
                   .Append(data => input.a.X + data.x < input.b.X, () => ++x)
                   .Append(data => input.a.Y + data.y > input.b.Y, () => --y)
                   .Append(data => input.a.Y + data.y < input.b.Y, () => ++y);

               if (diagonal == false
                   && (input.a.X != input.b.X 
                       && input.a.Y != input.b.Y))
                    continue;

                while (input.a.X + x != input.b.X 
                       || input.a.Y + y != input.b.Y)
                {
                    ++Map[input.a.X + x][input.a.Y + y];

                    brancher.Evaluate((x, y), false);
                }

                ++Map[input.a.X + x][input.a.Y + y];
            }

            return (Map.SelectMany(i => i)
                .Count(i => i >= 2));
        }
    }
}
