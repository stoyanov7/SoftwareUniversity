namespace _02.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main(string[] args)
        {
            var commands = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var pushElements = commands[0];
            var popElements = commands[1];
            var checkNumber = commands[2];

            var stackElements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var stack = new Stack<int>(stackElements);

            for (int i = 0; i < popElements; i++)
            {
                if (stack.Any())
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(checkNumber) && stack.Any())
            {
                Console.WriteLine("true");

            }
            else
            {
                Console.WriteLine(stack.Any() ? stack.Min() : 0);
            }
        }
    }
}
