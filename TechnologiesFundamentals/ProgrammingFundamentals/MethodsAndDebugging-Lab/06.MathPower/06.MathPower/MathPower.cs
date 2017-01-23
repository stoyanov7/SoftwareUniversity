using System;

public class MathPower
{
    public static void Main(string[] args)
    {
        double number = double.Parse(Console.ReadLine());
        double power = double.Parse(Console.ReadLine());
        Console.WriteLine($"{RaiseToPower(number, power)}");
    }

    private static double RaiseToPower(double number, double power)
    {
        double result = 1;

        for (int i = 0; i < power; i++)
        {
            result *= number;
        }

        return result;
    }
}