using System;

public class MultiplyEvensByOdds
{
    public static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(GetMultiplyOfEvenAndOdds(number));
    }

    private static int GetMultiplyOfEvenAndOdds(int number)
    {
        return Math.Abs(GetSumOfOddDigits(number) * GetSumOfEvenGidits(number));
    }

    private static int GetSumOfOddDigits(int number)
    {
        return GetSumOfDigits(number, 1);
    }

    private static int GetSumOfEvenGidits(int number)
    {
        return GetSumOfDigits(number, 0);
    }

    private static int GetSumOfDigits(int number, int remainder)
    {
        var result = 0;

        foreach (var symbol in number.ToString())
        {
            var digit = symbol - '0';
            if (digit % 2 == remainder)
            {
                result += digit;
            }
        }

        return result;
    }
}