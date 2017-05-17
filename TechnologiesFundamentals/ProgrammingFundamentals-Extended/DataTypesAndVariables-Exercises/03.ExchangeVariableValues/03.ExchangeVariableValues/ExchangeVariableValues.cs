using System;

namespace _03.ExchangeVariableValues
{
    public class ExchangeVariableValues
    {
        public static void Main(string[] args)
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"{secondNumber}\n{firstNumber}");
        }
    }
}
