namespace _03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxNumbers = new Stack<int>();
            var maxNumber = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var command = input[0];

                switch (command)
                {
                    case 1:
                        stack.Push(input[1]);

                        if (maxNumber < input[1])
                        {
                            maxNumber = input[1];
                            maxNumbers.Push(maxNumber);
                        }
                        break;
                    case 2:
                        if (stack.Pop() == maxNumber)
                        {
                            maxNumbers.Pop();

                            if (maxNumbers.Count != 0)
                            {
                                maxNumber = maxNumbers.Peek();
                            }
                            else
                            {
                                maxNumber = int.MinValue;
                            }
                        }

                        break;
                    case 3:
                        Console.WriteLine(maxNumber);
                        break;
                }
            }
        }
    }
}