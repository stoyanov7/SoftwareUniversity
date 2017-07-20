namespace _04.SpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SpecialWords
    {
        public static void Main(string[] args)
        {
            var countWords = new Dictionary<string, int>();
            var separators = new[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' };

            var specialWords = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var wordsInText = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var specialWord in specialWords)
            {
                var specialWordCount = 0;

                foreach (var word in wordsInText)
                {
                    if (specialWord.Equals(word))
                    {
                        specialWordCount++;
                    }
                }

                Console.WriteLine($"{specialWord} - {specialWordCount}");
            }
        }
    }
}
