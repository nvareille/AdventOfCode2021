using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Extensions;

namespace AdventOfCode2021
{
    public class TrajectoryAnalyzer
    {
        public static int Compute(((int, int), (int, int)) coordinates)
        {
            (int max, int x, int y) max = (int.MinValue, 0, 0);
            (int, int) cX = coordinates.Item1;
            (int, int) cY = coordinates.Item2;
            int wayX = (cX.Item1 <= 0 ? -1 : 1);
            int wayY = (cX.Item2 <= 0 ? -1 : 1);
            
            int x = 100000;

            while (x > -100000)
            {
                int y = 100000;
                
                --x;

                while (y > -100000)
                {
                    --y;

                    int result = IterateShot(cX, cY, x, y)
                        .Then(i =>
                        {
                            if (i.Any())
                            {
                                return i.OrderByDescending(i => i)
                                    .FirstOrDefault();
                            }

                            return (max.max);
                        });

                    if (result > max.max)
                        max = (result, x, y);
                }
            }

            return (max.max);
        }

        public static IEnumerable<int> IterateShot((int, int) cX, (int, int) cY, int x, int y)
        {
            int posX = 0;
            int posY = 0;
            int maxY = Int32.MinValue;

            while (posX is > -1000 and < 1000
                   && posY is > -1000 and < 1000)
            {
                if (maxY < y)
                    maxY = y;

                if (posX >= cX.Item1 
                    && posX <= cX.Item2
                    && posY >= cY.Item1
                    && posY <= cY.Item2)
                    yield return (maxY);

                posX += x;
                posY += y;

                if (x > 0)
                    ++x;
                else if (x < 0)
                    --x;
                --y;
            }
        }
    }
}
