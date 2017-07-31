namespace _07.CountNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountNumbers
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var countNumbers = new SortedDictionary<int, int>();

            foreach (var number in input)
            {
                if (!countNumbers.ContainsKey(number))
                {
                    countNumbers.Add(number, 0);
                }

                countNumbers[number]++;
            }

            foreach (var kvp in countNumbers)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
