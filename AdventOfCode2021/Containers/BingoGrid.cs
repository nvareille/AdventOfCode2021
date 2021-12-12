using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Containers
{
    public class BingoGrid
    {
        private int[][] Grid;
        public bool Won;

        public BingoGrid(string grid)
        {
            grid = grid.Trim();
            while (grid.Contains("  "))
            {
                grid = grid.Replace("  ", " ");
            }

            while (grid.Contains("\n "))
            {
                grid = grid.Replace("\n ", "\n");
            }

            Grid = grid.Split("\n")
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Select(i => i.Split(" ")
                    .Select(int.Parse)
                    .ToArray())
                .ToArray();
        }

        public bool PutNumber(int nbr)
        {
            if (Won)
                return (false);

            int x = 0;
            while (x < Grid.Length)
            {
                int y = 0;

                while (y < Grid[x].Length)
                {
                    if (Grid[x][y] == nbr)
                    {
                        Grid[x][y] = 0;
                        return (true);
                    }
                    ++y;
                }

                ++x;
            }

            return (false);
        }

        public bool CheckWin()
        {
            int count = 0;

            while (count < Grid.Length)
            {
                if (CheckRow(count))
                    return (true);
                ++count;
            }

            count = 0;
            while (count < Grid[0].Length)
            {
                if (CheckColumn(count))
                    return (true);
                ++count;
            }

            return (false);
        }

        public bool CheckRow(int row)
        {
            int count = 0;

            while (count < Grid[row].Length)
            {
                if (Grid[row][count] != 0)
                    return (false);
                ++count;
            }

            return (true);
        }

        public bool CheckColumn(int col)
        {
            int count = 0;

            while (count < Grid.Length)
            {
                if (Grid[count][col] != 0)
                    return (false);
                ++count;
            }

            return (true);
        }

        public int Sum()
        {
            return (Grid.Select(i => i.Sum()).Sum());
        }

        public static int PlayBingo(IEnumerable<string> grids, IEnumerable<int> numbers)
        {
            IEnumerable<BingoGrid> bingoGrids = grids.Select(i => new BingoGrid(i)).ToArray();
            
            foreach (int number in numbers)
            {
                foreach (BingoGrid grid in bingoGrids)
                {
                    if (grid.PutNumber(number) && grid.CheckWin())
                    {
                        return (grid.Sum() * number);
                    }
                }
            }

            return (-1);
        }

        public static int PlayBingoLonger(IEnumerable<string> grids, IEnumerable<int> numbers)
        {
            IEnumerable<BingoGrid> bingoGrids = grids.Select(i => new BingoGrid(i)).ToArray();
            BingoGrid winner = null;
            int winnerNumber = 0;

            foreach (int number in numbers)
            {
                foreach (BingoGrid grid in bingoGrids)
                {
                    if (grid.PutNumber(number) && grid.CheckWin())
                    {
                        winner = grid;
                        winner.Won = true;
                        winnerNumber = number;
                    }
                }
            }

            return (winner?.Sum() * winnerNumber ?? -1);
        }
    }
}
