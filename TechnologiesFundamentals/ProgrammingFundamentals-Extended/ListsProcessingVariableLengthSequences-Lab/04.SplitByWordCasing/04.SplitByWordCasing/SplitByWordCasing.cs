using System;
using System.Collections.Generic;

namespace _04.SplitByWordCasing
{
    public class SplitByWordCasing
    {
        public static void Main(string[] args)
        {
            var separators = new[] { ' ', ',', ';', ':', '.', '!', '(', ')', '"', '\'', '/', '\\', '[', ']' };

            var text = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var lowerCase = new List<string>();
            var mixedCase = new List<string>();
            var upperCase = new List<string>();

            foreach (var word in text)
            {
                var isAllLowerCase = true;
                var isAllUpperrCase = true;

                for (int i = 0; i < word.Length; i++)
                {
                    if (char.IsLower(word[i]))
                    {
                        isAllUpperrCase = false;
                    }
                    else if (char.IsUpper(word[i]))
                    {
                        isAllLowerCase = false;
                    }
                    else
                    {
                        isAllLowerCase = false;
                        isAllUpperrCase = false;
                    }
                }

                if (isAllLowerCase)
                {
                    lowerCase.Add(word);
                }
                else if (isAllUpperrCase)
                {
                    upperCase.Add(word);
                }
                else
                {
                    mixedCase.Add(word);
                }
            }

            Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCase));
        }
    }
}
