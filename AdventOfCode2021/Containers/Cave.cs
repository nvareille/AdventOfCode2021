using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Containers
{
    public class Cave
    {
        public bool BigCave;
        public bool PassedIn;
        public bool PassedInTwice;
        public string Name;
        public List<Cave> Links = new List<Cave>();

        public Cave(string name)
        {
            Name = name;
            BigCave = (name.ToUpper() == name);
        }

        public void Connect(Cave cave)
        {
            Links.Add(cave);
            cave.Links.Add(this);

            Links = Links.OrderBy(i => i.Name).ToList();
            cave.Links = cave.Links.OrderBy(i => i.Name).ToList();
        }

        public void GoInLinks(CavePathAnalyzer analyzer, bool start)
        {
            if (!start && Name == "start")
                return;

            analyzer.CurrentSolution.Push(this);
            
            if (Name == "end")
            {
                analyzer.MarkSolution();
                analyzer.CurrentSolution.Pop();
                return;
            }

            if (!BigCave)
            {
                if (analyzer.Mode && PassedIn)
                    PassedInTwice = true;
                else
                    PassedIn = true;
            }

            foreach (Cave cave in Links)
            {
                if (cave.BigCave 
                    || !cave.PassedIn 
                    || (analyzer.Mode && analyzer.Caves.All(i => !i.PassedInTwice)))
                    cave.GoInLinks(analyzer, false);
            }

            if (PassedInTwice)
                PassedInTwice = false;
            else
                PassedIn = false;

            analyzer.CurrentSolution.Pop();
        }
    }
}
