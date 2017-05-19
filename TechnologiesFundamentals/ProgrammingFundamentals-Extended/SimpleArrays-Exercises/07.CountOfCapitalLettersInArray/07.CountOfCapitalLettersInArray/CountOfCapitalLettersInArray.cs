using System;
using System.Linq;

namespace _07.CountOfCapitalLettersInArray
{
    public class CountOfCapitalLettersInArray
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                var currentWord = arr[i];

                if (currentWord.Length == 1)
                {
                    char character = currentWord[0];

                    if (character >= 'A' || character <= 'Z')
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
