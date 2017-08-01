namespace _07.ExchangeVariableValues
{
    using System;

    public class ExchangeVariableValues
    {
        public static void Main(string[] args)
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"Before:\na = {firstNumber}\nb = {secondNumber}");
            Console.WriteLine($"After:\na = {secondNumber}\nb = {firstNumber}");
        }
    } 
}