using System;

public class MaxMethod
{
    public static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        int firstAndSecond = GetMax(firstNumber, secondNumber);
        int biggest = GetMax(firstAndSecond, thirdNumber);

        Console.WriteLine(biggest);
    }

    private static int GetMax(int a, int b)
    {
        return Math.Max(a, b);
    }
}