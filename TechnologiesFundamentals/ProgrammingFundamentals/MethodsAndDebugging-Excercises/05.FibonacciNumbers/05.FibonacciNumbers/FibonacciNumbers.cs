using System;

public class FibonacciNumbers
{
    public static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(Fibonacci(number));
    }

    private static long Fibonacci(int number)
    {
        if (number == 0 || number == 1)
        {
            return 1;
        }
        else
        {
            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }
    }
}