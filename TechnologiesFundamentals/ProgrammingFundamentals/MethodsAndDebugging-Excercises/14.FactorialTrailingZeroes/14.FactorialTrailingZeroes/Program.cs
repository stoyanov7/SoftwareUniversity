using System;
using System.Numerics;

public class FactorialTrailingZeroes
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        GetTrailingZeroes(Factorial(n));
    }

    private static BigInteger Factorial(int n)
    {
        BigInteger factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }

        return factorial;
    }

    private static void GetTrailingZeroes(BigInteger number)
    {
        BigInteger zeroCount = 0;
        while (number % 10 == 0)
        {
            number /= 10;
            zeroCount++;
        }

        Console.WriteLine(zeroCount);
    }
}