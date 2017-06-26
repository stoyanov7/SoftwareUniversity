namespace _03.FlattenDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FlattenDictionary
    {
        public static void Main(string[] args)
        {
            var datas = new Dictionary<string, Dictionary<string, string>>();
            var line = Console.ReadLine();

            while (line != "end")
            {
                ReadData(datas, line);
                line = Console.ReadLine();
            }

            PrintData(datas);
        }

        private static void ReadData(Dictionary<string, Dictionary<string, string>> datas, string line)
        {
            var lineTokens = line
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (lineTokens[0] != "flatten")
            {
                var key = lineTokens[0];
                var innerKey = lineTokens[1];
                var innerValue = lineTokens[2];

                if (!datas.ContainsKey(key))
                {
                    datas.Add(key, new Dictionary<string, string>());
                }

                datas[key][innerKey] = innerValue;
            }
            else
            {
                var key = lineTokens[1];

                datas[key] = datas[key]
                    .ToDictionary(x => x.Key + x.Value, x => "flattened");
            }
        }

        private static void PrintData(Dictionary<string, Dictionary<string, string>> datas)
        {
            var orderedDictionary = datas
                .OrderByDescending(x => x.Key.Length)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in orderedDictionary)
            {
                Console.WriteLine(kvp.Key);

                var orderedInnerDictionary = kvp.Value
                    .Where(x => x.Value != "flattened")
                    .OrderBy(x => x.Key.Length)
                    .ToDictionary(x => x.Key, x => x.Value);

                var flattenedDictionary = kvp.Value
                    .Where(x => x.Value == "flattened")
                    .ToDictionary(x => x.Key, x => x.Value);

                var count = 1;
                foreach (var innerKvp in orderedInnerDictionary)
                {
                    Console.WriteLine($"{count}. {innerKvp.Key} - {innerKvp.Value}");
                    count++;
                }

                foreach (var flattenKvp in flattenedDictionary)
                {
                    Console.WriteLine($"{count}. {flattenKvp.Key}");
                    count++;
                }
            }
        }
    }
}