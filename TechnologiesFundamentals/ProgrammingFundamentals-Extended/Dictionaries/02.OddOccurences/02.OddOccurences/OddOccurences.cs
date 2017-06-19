using System;
using System.Collections.Generic;

namespace _02.OddOccurences
{
    public class OddOccurences
    {
        public static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .ToLower()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!result.ContainsKey(word))
                {
                    result[word] = 0;
                }

                result[word]++;
            }

            var oddNumbersWord = new List<string>();

            foreach (var kvp in result)
            {
                var value = kvp.Value;

                if (value % 2 != 0)
                {
                    oddNumbersWord.Add(kvp.Key);
                }
            }

            Console.WriteLine(string.Join(", ", oddNumbersWord));
        }
    }
}
