using System;

class MathPower
{
    public static void Main(string[] args)
    {
        double number = double.Parse(Console.ReadLine());
        double power = double.Parse(Console.ReadLine());
        Console.WriteLine($"{RaiseToPower(number, power)}");
    }

    private static double RaiseToPower(double number, double power)
    {
        return Math.Pow(number, power);
    }
}
