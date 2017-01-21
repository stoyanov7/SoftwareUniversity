using System;

public class ExchangeVariableValues
{
    static void Main(string[] args)
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        Console.WriteLine($"Before:\na = {firstNumber}\nb = {secondNumber}");
        Console.WriteLine($"After:\na = {secondNumber}\nb = {firstNumber}");
    }
}