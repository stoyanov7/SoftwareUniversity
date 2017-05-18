using System;

public class Digit
{
    public static void Main(string[] args)
    {
        var number = long.Parse(Console.ReadLine());
        var index = int.Parse(Console.ReadLine());

        var result = FindNthDigit(number, index);
        Console.WriteLine(result);
    }

    private static int FindNthDigit(long number, int index)
    {
        var currentIndex = 1;

        while (number > 0)
        {
            if (currentIndex == index)
            {
                return (int)(number % 10);
            }

            currentIndex++;
            number /= 10;
        }

        return (int)(number % 10);
    }
}