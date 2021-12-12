using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Containers;

namespace AdventOfCode2021
{
    public class CavePathAnalyzer
    {
        public bool Mode;
        public List<Cave> Caves = new List<Cave>();
        public Stack<Cave> CurrentSolution = new Stack<Cave>();
        public List<Cave[]> FoundSolutions = new List<Cave[]>();

        public CavePathAnalyzer(IEnumerable<(string, string)> map, bool mode = false)
        {
            Mode = mode;
            BuildMap(map);
        }

        private void BuildMap(IEnumerable<(string, string)> map)
        {
            IEnumerable<string> caveNames = map.SelectMany(i => new string[]
            {
                i.Item1,
                i.Item2
            }).Distinct().OrderBy(i => i);

            foreach (string name in caveNames)
            {
                Caves.Add(new Cave(name));
            }

            ConnectCaves(map);
        }

        private void ConnectCaves(IEnumerable<(string, string)> map)
        {
            foreach ((string, string) tuple in map)
            {
                Cave[] caves = new Cave[]
                {
                    Caves.First(i => i.Name == tuple.Item1),
                    Caves.First(i => i.Name == tuple.Item2)
                };

                caves[0].Connect(caves[1]);
            }
        }

        public int AnalyzePaths()
        {
            Cave start = Caves.First(i => i.Name == "start");

            start.GoInLinks(this, true);
            
            return (FoundSolutions.Count());
        }

        public void MarkSolution()
        {
            Cave[] result = CurrentSolution.Reverse().ToArray();

            FoundSolutions.Add(result);
        }
    }
}
