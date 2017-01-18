using System;

public class TriplesOfLetters
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int firstLetter = 0; firstLetter < n; firstLetter++)
        {
            for (int secondLetter = 0; secondLetter < n; secondLetter++)
            {
                for (int thirdLetter = 0; thirdLetter < n; thirdLetter++)
                {
                    Console.WriteLine("{0}{1}{2}", 
                        (char)('a' + firstLetter), (char)('a' + secondLetter), (char)('a' + thirdLetter));
                }
            }
        }
    }
}