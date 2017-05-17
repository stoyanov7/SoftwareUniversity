using System;

namespace _02.TriplesOfLatinLetters
{
    public class TriplesOfLatinLetters
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (char a = 'a'; a < 'a' + n; a++)
            {
                for (char b = 'a'; b < 'a' + n; b++)
                {
                    for (char c = 'a'; c < 'a' + n; c++)
                    {
                        Console.WriteLine($"{a}{b}{c}");
                    }
                }
            }
        }
    }
}
