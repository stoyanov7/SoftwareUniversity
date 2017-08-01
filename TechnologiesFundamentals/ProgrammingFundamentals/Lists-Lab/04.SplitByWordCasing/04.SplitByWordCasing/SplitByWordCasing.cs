namespace _04.SplitByWordCasing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SplitByWordCasing
    {
        public static void Main(string[] args)
        {
            var separators = new[]
            {
                ' ', ',', ';', ':', '.', '!', '(', ')', '"', '\'', '/', '\\', '[', ']'
            };

            var inputList = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var lowerCase = new List<string>();
            var mixedCase = new List<string>();
            var upperCase = new List<string>();

            foreach (var currentWord in inputList)
            {
                var isAllLowerCase = true;
                var isAllUpperCase = true;

                foreach (var t in currentWord)
                {
                    if (char.IsLower(t))
                    {
                        isAllUpperCase = false;
                    }
                    else if (char.IsUpper(t))
                    {
                        isAllLowerCase = false;
                    }
                    else
                    {
                        isAllLowerCase = false;
                        isAllUpperCase = false;
                    }
                }

                if (isAllLowerCase)
                {
                    lowerCase.Add(currentWord);
                }
                else if (isAllUpperCase)
                {
                    upperCase.Add(currentWord);
                }
                else
                {
                    mixedCase.Add(currentWord);
                }
            }

            Console.WriteLine($"Lower-case: {string.Join(", ", lowerCase)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixedCase)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", upperCase)}");
        }
    } 
}