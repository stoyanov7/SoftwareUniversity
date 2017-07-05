namespace _02.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Reverse();
            var stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                var firstNumber = int.Parse(stack.Pop());
                var @operator = stack.Pop();
                var secondNumber = int.Parse(stack.Pop());

                if (@operator == "+")
                {
                    stack.Push((firstNumber + secondNumber).ToString());
                }
                else
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
