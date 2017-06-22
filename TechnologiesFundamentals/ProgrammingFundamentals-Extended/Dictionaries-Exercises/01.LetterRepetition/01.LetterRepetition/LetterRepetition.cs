using System;
using System.Collections.Generic;

namespace _01.LetterRepetition
{
    public class LetterRepetition
    {
        public static void Main(string[] args)
        {
            var letterCount = new Dictionary<char, int>();
            var input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (!letterCount.ContainsKey(input[i]))
                {
                    letterCount[input[i]] = 0;
                }

                letterCount[input[i]]++;
            }

            foreach (var letter in letterCount)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
