using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Extensions;

namespace AdventOfCode2021
{
    public class Polymerizer
    {
        public static Dictionary<string, long> GenPairDict(string molecule, Dictionary<string, char> pairs)
        {
            char[] chars = new char[2];
            Dictionary<string, long> dict = new Dictionary<string, long>();

            foreach (char c in molecule)
            {
                chars[0] = chars[1];
                chars[1] = c;

                if (chars[0] != 0)
                {
                    string actual = $"{chars[0]}{chars[1]}";

                    if (!dict.ContainsKey(actual))
                        dict[actual] = 1;
                    else
                        ++dict[actual];
                }
            }

            return (dict);
        }

        private static void AddOrSet(Dictionary<string, long> actual, string key, Dictionary<string, long> dict, string key2)
        {
            if (!dict.ContainsKey(key2))
                return;

            long value = dict[key2];

            if (!actual.ContainsKey(key))
                actual[key] = value;
            else
                actual[key] += value;
        }

        public static Dictionary<string, long> PolymerizeOptiOnce(Dictionary<string, long> actual, Dictionary<string, char> pairs)
        {
            Dictionary<string, long> dict = new Dictionary<string, long>();

            foreach (KeyValuePair<string, char> pair in pairs)
            {
                char toAdd = pair.Value;
                string keyA = $"{pair.Key.First()}{toAdd}";
                string keyB = $"{toAdd}{pair.Key.Last()}";

                AddOrSet(dict, keyA, actual, pair.Key);
                AddOrSet(dict, keyB, actual, pair.Key);
            }

            return (dict);
        }


        public static Dictionary<char, long> ComputePolymerizationFactorOpti(Dictionary<string, long> dict)
        {
            Dictionary<char, long> total = new Dictionary<char, long>();

            foreach (KeyValuePair<string, long> element in dict)
            {
                char c1 = element.Key.First();
                char c2 = element.Key.Last();

                if (!total.ContainsKey(c1))
                    total[c1] = dict[element.Key];
                else
                    total[c1] += dict[element.Key];

                if (!total.ContainsKey(c2))
                    total[c2] = dict[element.Key];
                else
                    total[c2] += dict[element.Key];
            }
            
            return (total.Select(i => (i.Key, (i.Value + 1) / 2))
                .OrderByDescending(i => i.Item2)
                .ToDictionary());
        }

        public static long PolymerizeOpti(string molecule, Dictionary<string, char> pairs, int steps)
        {
            Dictionary<string, long> dict = GenPairDict(molecule, pairs);

            while (steps > 0)
            {
                dict = PolymerizeOptiOnce(dict, pairs);
                --steps;
            }

            Dictionary<char, long> result = ComputePolymerizationFactorOpti(dict);

            return (result.First().Value - result.Last().Value);
        }
    }
}
