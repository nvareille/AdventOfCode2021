using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Extensions;

namespace AdventOfCode2021
{
    public class OrigamiEngine
    {
        public bool[][] Grid;
        public IEnumerable<(char, int)> Folds;

        public OrigamiEngine((IEnumerable<(int, int)>, IEnumerable<(char, int)>) input)
        {
            Grid = InitGrid(input.Item1);
            FillGrid(input.Item1);
            Folds = input.Item2;
        }

        private bool[][] InitGrid((int, int) input)
        {
            int maxX = input.Item1;
            int maxY = input.Item2;
            bool[][] grid = new bool[maxX][];

            foreach (int x in Enumerable.Range(0, maxX))
            {
                grid[x] = new bool[maxY];
            }

            return (grid);
        }

        private bool[][] InitGrid(IEnumerable<(int, int)> input)
        {
            input = input.ToArray();

            return (InitGrid((input.Max(i => i.Item2 + 1), input.Max(i => i.Item1 + 1))));
        }

        private void FillGrid(IEnumerable<(int, int)> input)
        {
            foreach ((int, int) coordinates in input)
            {
                Grid[coordinates.Item2][coordinates.Item1] = true;
            }
        }

        private bool[][] GetNewGrid((char, int) fold)
        {
            bool[][] gridA = null;
            bool[][] gridB = null;
            bool[][] gridC = null;

            if (fold.Item1 == 'y')
            {
                int partA = Grid.Length - fold.Item2 - 1;
                int partB = fold.Item2;

                gridA = InitGrid((partA, Grid[0].Length));
                gridA.IterateDoubleArray((x, y) => gridA[x][y] = Grid[x][y]);

                gridB = InitGrid((partB + 1, Grid[0].Length));
                gridB.IterateDoubleArray((x, y) => gridB[x][y] = Grid[partA + x][y]);

                gridC = InitGrid((partB + 1, Grid[0].Length));
                gridB.IterateDoubleArray((x, y) => gridC[gridC.Length - 1 - x][y] = gridB[x][y]);
                gridA.IterateDoubleArray((x, y) => gridA[x][y] = (gridA[x][y] || gridC[x][y]));
            }

            if (fold.Item1 == 'x')
            {
                int partA = fold.Item2;
                int partB = Grid[0].Length - fold.Item2;

                gridA = InitGrid((Grid.Length, partA));
                gridA.IterateDoubleArray((x, y) => gridA[x][y] = Grid[x][y]);

                gridB = InitGrid((Grid.Length, partB));
                gridB.IterateDoubleArray((x, y) => gridB[x][y] = Grid[x][y + partB - 1]);

                gridC = InitGrid((Grid.Length, partB));
                gridB.IterateDoubleArray((x, y) => gridC[x][partB - y - 1] = gridB[x][y]);
                gridA.IterateDoubleArray((x, y) => gridA[x][y] = (gridA[x][y] || gridC[x][y]));

                /*
                int partA = fold.Item2;
                int partB = Grid[0].Length - fold.Item2;

                gridA = InitGrid((Grid.Length, partA));
                gridA.IterateDoubleArray((x, y) => gridA[x][y] = Grid[x][y]);

                gridB = InitGrid((Grid.Length, partB));
                gridB.IterateDoubleArray((x, y) => gridB[x][y] = Grid[x][partA + y]);

                gridC = InitGrid((Grid.Length, partB));
                gridB.IterateDoubleArray((x, y) => gridC[x][gridC[0].Length - 1 - y] = gridB[x][y]);
                gridA.IterateDoubleArray((x, y) => gridA[x][y] = (gridA[x][y] || gridC[x][y]));*/
            }

            return (gridA);
        }

        public void Fold()
        {
            foreach ((char, int) fold in Folds)
            {
                Grid = GetNewGrid(fold);
            }
        }

        public void FoldOnce()
        {
            (char, int) fold = Folds.First();

            Folds = Folds.Skip(1);
            Grid = GetNewGrid(fold);
        }

        public int GetDots()
        {
            return (Grid.SelectMany(i => i).Count(i => i));
        }

        public void Debug(Action<string> c, Action saut)
        {
            foreach (bool[] bools in Grid)
            {
                foreach (bool b in bools)
                {
                    c(b ? "#" : ".");
                }

                saut();
            }
        }
    }
}
