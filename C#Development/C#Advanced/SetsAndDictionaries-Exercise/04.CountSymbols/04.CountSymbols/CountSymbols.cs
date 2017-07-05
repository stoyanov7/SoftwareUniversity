namespace _04.CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class CountSymbols
    {
        public static void Main(string[] args)
        {
            var countSymbols = new SortedDictionary<char, int>();
            var line = Console.ReadLine()
                .ToCharArray();

            for (int i = 0; i < line.Length; i++)
            {
                if (!countSymbols.ContainsKey(line[i]))
                {
                    countSymbols.Add(line[i], 0);
                }

                countSymbols[line[i]]++;
            }

            foreach (var kvp in countSymbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
