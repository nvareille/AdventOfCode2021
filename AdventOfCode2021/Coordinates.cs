using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Coordinates
    {
        public int X;
        public int Y;

        public Coordinates() { }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinates(string x, string y)
        {
            X = int.Parse(x);
            Y = int.Parse(y);
        }
    }
}
