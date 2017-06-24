using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.DictRefAdvanced
{
    public class DictRefAdvanced
    {
        public static void Main(string[] args)
        {
            var dictRefs = new Dictionary<string, List<int>>();
            var line = Console.ReadLine();

            while (line != "end")
            {
                ReadDictRef(dictRefs, line);

                line = Console.ReadLine();
            }

            foreach (var kvp in dictRefs)
            {
                var name = kvp.Key;
                var values = string.Join(", ", kvp.Value);

                Console.WriteLine($"{name} === {values}");
            }
        }

        private static void ReadDictRef(Dictionary<string, List<int>> dictRefs, string line)
        {
            var lineTokens = line.Split(new[] { '-', '>', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var name = lineTokens[0];
            var value = -1;

            if (int.TryParse(lineTokens[1], out value))
            {
                if (!dictRefs.ContainsKey(name))
                {
                    dictRefs.Add(name, new List<int>());
                }

                for (int i = 1; i < lineTokens.Length; i++)
                {
                    dictRefs[name].Add(int.Parse(lineTokens[i]));
                }
            }
            else
            {
                var otherName = lineTokens[1];

                if (dictRefs.ContainsKey(otherName))
                {
                    dictRefs[name] = new List<int>(dictRefs[otherName]);
                }
            }
        }
    }
}