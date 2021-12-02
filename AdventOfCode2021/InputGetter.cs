using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

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
                .Select(i => ((T)Enum.Parse(typeof(T), i[0], true), int.Parse(i[1]))));
        }
    }
}
