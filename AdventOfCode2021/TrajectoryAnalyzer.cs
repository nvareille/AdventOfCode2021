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
        public static IEnumerable<(int, int)> ComputeVelocities(((int, int), (int, int)) coordinates)
        {
            (int, int) cX = coordinates.Item1;
            (int, int) cY = coordinates.Item2;
            int x = 1000;

            while (x > -1000)
            {
                int y = 1000;

                --x;

                while (y > -1000)
                {
                    --y;

                    if (IterateShot(cX, cY, x, y) > Int32.MinValue)
                        yield return (x, y);
                }
            }
        }

        public static int Compute(((int, int), (int, int)) coordinates)
        {
            (int max, int x, int y) max = (int.MinValue, 0, 0);
            (int, int) cX = coordinates.Item1;
            (int, int) cY = coordinates.Item2;
            int x = cX.Item2;

            while (x > 0)
            {
                int y = 1000;
                
                --x;

                while (y > -1000)
                {
                    --y;

                    int result = IterateShot(cX, cY, x, y);

                    if (result > max.max)
                        max = (result, x, y);
                }
            }

            return (max.max);
        }

        public static int IterateShot((int, int) cX, (int, int) cY, int x, int y)
        {
            int posX = 0;
            int posY = 0;
            int maxY = Int32.MinValue;

            while (posX is > -1000 and < 1000
                   && posY > -1000)
            {
                if (maxY < posY)
                    maxY = posY;

                if (posX >= cX.Item1 
                    && posX <= cX.Item2
                    && posY >= cY.Item1
                    && posY <= cY.Item2)
                    return (maxY);

                posX += x;
                posY += y;

                /* Merci @Paul-Maxime */
                x += -Math.Sign(x);
                --y;
            }

            return (Int32.MinValue);
        }
    }
}
