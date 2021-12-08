using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Extensions;

namespace AdventOfCode2021
{
    public class WireSegments
    {
        private static int[] MatchingSimpleWires = new int[]
        {
            2,
            3,
            4,
            7
        };

        public static int FindMatchingSimpleWires(IEnumerable<(string[], string[])> input)
        {
            return (input
                .SelectMany(i => i.Item2)
                .Count(i => MatchingSimpleWires.Contains(i.Length)));
        }

        public static int FindComplexMatchingWires(IEnumerable<(string[], string[])> input)
        {
            int sum = 0;

            foreach ((string[], string[]) i in input)
            {
                Dictionary<string, int> numbers = GenDictionnary(i.Item1);
                string[] array = i.Item2;

                sum += numbers[array[0].ToAlpha()] * 1000;
                sum += numbers[array[1].ToAlpha()] * 100;
                sum += numbers[array[2].ToAlpha()] * 10;
                sum += numbers[array[3].ToAlpha()];
            }

            return (sum);
        }

        private static Dictionary<string, int> GenDictionnary(string[] input) 
        {
            Dictionary<string, int> numbers = new Dictionary<string, int>
            {
                {input.First(i => i.Length == 2).ToAlpha(), 1},
                {input.First(i => i.Length == 3).ToAlpha(), 7},
                {input.First(i => i.Length == 4).ToAlpha(), 4},
                {input.First(i => i.Length == 7).ToAlpha(), 8},
            };

            List<string> fiveSegments = input
                .Where(i => i.Length == 5)
                .ToList();

            List<string> sixSegments = input
                .Where(i => i.Length == 6)
                .ToList();

            string one = numbers.First(i => i.Value == 1).Key;
            string three = fiveSegments.First(i => i.CommonLetters(one) == 2);

            fiveSegments.Remove(three);

            string nine = sixSegments.First(i => i.CommonLetters(three) == 5);

            sixSegments.Remove(nine);

            string five = fiveSegments.First(i => i.CommonLetters(nine) == 5);
            string two = fiveSegments.First(i => i != five);
            string six = sixSegments.First(i => i.CommonLetters(five) == 5);
            string zero = sixSegments.First(i => i != six);

            numbers[zero.ToAlpha()] = 0;
            numbers[two.ToAlpha()] = 2;
            numbers[three.ToAlpha()] = 3;
            numbers[five.ToAlpha()] = 5;
            numbers[six.ToAlpha()] = 6;
            numbers[nine.ToAlpha()] = 9;

            return (numbers);
        }
    }
}
