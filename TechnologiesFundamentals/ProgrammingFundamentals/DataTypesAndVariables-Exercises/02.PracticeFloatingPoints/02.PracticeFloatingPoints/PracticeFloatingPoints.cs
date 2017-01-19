using System;

public class PracticeFloatingPoints
{
    public static void Main(string[] args)
    {
        decimal firstNumber = decimal.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        decimal thirdNumber = decimal.Parse(Console.ReadLine());

        Console.WriteLine($"{firstNumber}\n{secondNumber}\n{thirdNumber}");
    }
}