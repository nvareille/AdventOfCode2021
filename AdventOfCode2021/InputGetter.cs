using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AdventOfCode2021.Extensions;

namespace AdventOfCode2021
{
    public class InputGetter
    {
        private static HttpClient GenerateClient(string session)
        {
            Uri baseAdress = new Uri("https://adventofcode.com/");
            CookieContainer cookieContainer = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler()
            {
                CookieContainer = cookieContainer
            };
            HttpClient client = new HttpClient(handler)
            {
                BaseAddress = baseAdress
            };

            cookieContainer.Add(baseAdress, new Cookie("session", session));

            return (client);
        }

        public static T GetInputAndTreat<T>(string session, string url, Func<string, T> fct)
        {
            HttpClient client = GenerateClient(session);
            string input = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            return (fct(input));
        }

        public static IEnumerable<int> GetInputAsIntArray(string session, string url)
        {
            HttpClient client = GenerateClient(session);
            string input = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            return (input.Split("\n")
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Select(int.Parse));
        }

        public static IEnumerable<(T, int)> GetInputAsEnumTuples<T>(string session, string url) where T : Enum
        {
            HttpClient client = GenerateClient(session);
            string input = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            return (input.Split("\n")
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Select(i => i.Split(" "))
                .Select(i => ((T) Enum.Parse(typeof(T), i[0], true), int.Parse(i[1]))));
        }

        public static IEnumerable<char[]> GetInputAsCharArrayEnumerable(string session, string url)
        {
            HttpClient client = GenerateClient(session);
            string input = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            return (input.Split("\n")
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Select(i => i.ToCharArray()));
        }

        public static IEnumerable<string> Multiparse(string session, string url, params string[] tokens)
        {
            HttpClient client = GenerateClient(session);
            string input = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            List<string> strings = new List<string>();

            foreach (string token in tokens)
            {
                int idx = input.IndexOf(token);
                string temp = input.Substring(0, idx);

                strings.Add(temp);
                input = input.Substring(idx + token.Length, input.Length - idx - token.Length);
            }

            strings.Add(input);
            return (strings);
        }

        public static IEnumerable<int> ParseNumberList(string list)
        {
            return (list.Split(',')
                .Select(int.Parse));
        }

        public static IEnumerable<string> ParseToken(string str, string token)
        {
            return (str.Split(token));
        }

        public static IEnumerable<(Coordinates a, Coordinates b)> GetCoordinateRanges(string session, string url)
        {
            HttpClient client = GenerateClient(session);
            string input = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            return (input.Split("\n")
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Select(i => i.Split(" -> ")
                    .Select(o => o.Split(",")
                        .Then(e => new Coordinates(e[0], e[1])))
                    .ToArray()
                    .Then(o => (o.First(), o.Last()))));
        }

        public static IEnumerable<(string[], string[])> GetDelimitedStringArray(string session, string url)
        {
            HttpClient client = GenerateClient(session);
            string input = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            return (input.Split("\n")
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Select(o => o.Split("|")
                    .Then(a =>
                    (
                        a.First()
                            .Trim()
                            .Split(" "),
                        a.Last()
                            .Trim()
                            .Split(" ")
                    ))));
        }

        public static int[][] GetAsIntArraySingleDigit(string session, string url)
        {
            HttpClient client = GenerateClient(session);
            string input = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            return (input
                .Split("\n")
                .Select(i =>
                    i.Select(o =>
                        int.Parse(o.ToString()))
                        .ToArray())
                .ToArray());

        }

        public static string[] GetAsStringArray(string session, string url)
        {
            HttpClient client = GenerateClient(session);
            string input = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            return (input
                .Split("\n")
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .ToArray());

        }
    }
}
