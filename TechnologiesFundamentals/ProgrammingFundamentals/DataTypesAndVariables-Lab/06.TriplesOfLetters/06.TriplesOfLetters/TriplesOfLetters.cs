namespace _06.TriplesOfLetters
{
    using System;

    public class TriplesOfLetters
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var firstLetter = 0; firstLetter < n; firstLetter++)
            {
                for (var secondLetter = 0; secondLetter < n; secondLetter++)
                {
                    for (var thirdLetter = 0; thirdLetter < n; thirdLetter++)
                    {
                        Console.WriteLine(
                            $"{(char) ('a' + firstLetter)}{(char) ('a' + secondLetter)}{(char) ('a' + thirdLetter)}");
                    }
                }
            }
        }
    }
}