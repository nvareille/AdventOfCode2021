using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class SyntaxChecker
    {
        private static (char open, char close, int score)[] Tokens = new[]
        {
            ('(', ')', 3),
            ('[', ']', 57),
            ('{', '}', 1197),
            ('<', '>', 25137),
        };
        
        public static long ComputeScoreErrors(string[] strs)
        {
            return (strs.Select(i => ComputeLineScore(i, false))
                .Sum());
        }

        public static long ComputeAutocompleteScore(string[] strs)
        {
            IEnumerable<long> scores = strs.Select(i => ComputeLineScore(i, true))
                .Where(i => i != 0)
                .OrderByDescending(i => i)
                .ToArray();

            return (scores.ElementAt(scores.Count() / 2));
        }

        public static long ComputeLineScore(string str, bool mode = false)
        {
            Stack<char> semantics = new Stack<char>();
            Dictionary<char, int> scores = new();
            long total = 0;

            if (mode)
            {
                int count = 1;

                foreach ((char open, char close, int score) token in Tokens)
                {
                    scores[token.open] = count;
                    ++count;
                }
            }

            foreach (char c in str)
            {
                if (Tokens.Any(i => i.open == c))
                    semantics.Push(c);
                else
                {
                    (char open, char close, int score) found = Tokens.First(i => i.close == c);
                    char matching = semantics.Pop();

                    if (matching != found.open)
                    {
                        if (!mode)
                            return (found.score);
                        return (0);
                    }
                }
            }

            if (!mode)
                return (0);

            while (semantics.Any())
            {
                char matching = semantics.Pop();

                total *= 5;
                total += scores[matching];
            }

            return (total);
        }
    }
}
