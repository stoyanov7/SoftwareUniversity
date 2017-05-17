using System;

namespace _15.Calculator
{
    public class Calculator
    {
        public static void Main(string[] args)
        {
            var firstOperand = int.Parse(Console.ReadLine());
            var inputOperator = char.Parse(Console.ReadLine());
            var secondOperand = int.Parse(Console.ReadLine());

            var result = 0;
            switch (inputOperator)
            {
                case '+':
                    result = firstOperand + secondOperand;
                    Console.WriteLine($"{firstOperand} + {secondOperand} = {result}");
                    break;

                case '-':
                    result = firstOperand - secondOperand;
                    Console.WriteLine($"{firstOperand} - {secondOperand} = {result}");
                    break;

                case '*':
                    result = firstOperand * secondOperand;
                    Console.WriteLine($"{firstOperand} * {secondOperand} = {result}");
                    break;

                case '/':
                    result = firstOperand / secondOperand;
                    Console.WriteLine($"{firstOperand} / {secondOperand} = {result}");
                    break;
            }
        }
    }
}
