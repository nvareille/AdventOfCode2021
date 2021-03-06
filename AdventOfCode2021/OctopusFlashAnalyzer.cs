using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Extensions;

namespace AdventOfCode2021
{
    public class OctopusFlashAnalyzer
    {
        public int[][] Input;
        public List<(int x, int y)> Flashed = new();

        public OctopusFlashAnalyzer(int[][] input)
        {
            Input = input;
        }

        private void ProduceEnergyAt(int x, int y)
        {
            if (x < 0 || x >= Input.Length
                || y < 0 || y>= Input[0].Length)
                return;

            if (!Flashed.Any(i => i.x == x && i.y == y))
                ++Input[x][y];
        }

        private bool CheckNeedIterate()
        {
            bool c = false;

            Input.IterateDoubleArray((x, y) =>
            {
                if (Input[x][y] > 9) 
                    c = true;
            });

            return (c);
        }

        private int Iterate()
        {
            Flashed.Clear();
            Input.IterateDoubleArray((x, y) => ++Input[x][y]);
            
            bool c = CheckNeedIterate();
            
            while (c)
            {
                Input.IterateDoubleArray((x, y) =>
                {
                    if (Input[x][y] > 9)
                    {
                        Input[x][y] = 0;
                        
                        ProduceEnergyAt(x - 1, y - 1);
                        ProduceEnergyAt(x, y - 1);
                        ProduceEnergyAt(x + 1, y - 1);

                        ProduceEnergyAt(x - 1, y);
                        ProduceEnergyAt(x + 1, y);

                        ProduceEnergyAt(x - 1, y + 1);
                        ProduceEnergyAt(x, y + 1);
                        ProduceEnergyAt(x + 1, y + 1);

                        Flashed.Add((x, y));
                    }
                });

                c = CheckNeedIterate();
            }
            
            return (Flashed.Count);
        }

        public int ComputeFlashSteps(int steps)
        {
            int sum = 0;

            while (steps > 0)
            {
                sum += Iterate();

                --steps;
            }

            return (sum);
        }

        public int ComputeSynchroneFlashSteps()
        {
            int step = 0;
            int target = Input.Length * Input[0].Length;

            while (true)
            {
                ++step;

                Iterate();
                if (Flashed.Count == target)
                    return (step);
            }
        }
    }
}
