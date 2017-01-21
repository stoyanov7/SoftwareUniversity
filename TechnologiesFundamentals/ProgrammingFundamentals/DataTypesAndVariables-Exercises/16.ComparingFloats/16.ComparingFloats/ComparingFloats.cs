using System;

public class ComparingFloats
{
    public static void Main(string[] args)
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double eps = 0.000001;

        Console.WriteLine(Math.Abs(firstNumber - secondNumber) < eps ? "True" : "False");
    }
}