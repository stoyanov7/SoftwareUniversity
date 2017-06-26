namespace _02.DefaultValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DefaultValues
    {
        public static void Main(string[] args)
        {
            var wordPairs = new Dictionary<string, string>();
            var line = Console.ReadLine();

            while (line != "end")
            {
                ReadValues(wordPairs, line);
                line = Console.ReadLine();
            }

            var defaultValue = Console.ReadLine();
            PrintValues(wordPairs, defaultValue);
        }

        private static void ReadValues(Dictionary<string, string> wordPairs, string line)
        {
            var lineTokens = line
                .Split("-> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var key = lineTokens[0];
            var value = lineTokens[1];

            if (!wordPairs.ContainsKey(key))
            {
                wordPairs.Add(key, string.Empty);
            }

            wordPairs[key] = value;
        }

        private static void PrintValues(Dictionary<string, string> wordPairs, string defaultValue)
        {
            var result = wordPairs
                .Where(x => !x.Value.Equals("null"))
                .OrderByDescending(x => x.Value.Length);

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} <-> {kvp.Value}");
            }

            var defaultResult = wordPairs
                .Where(x => x.Value.Equals("null"));

            foreach (var kvp in defaultResult)
            {
                Console.WriteLine($"{kvp.Key} <-> {defaultValue}");
            }
        }
    }
}