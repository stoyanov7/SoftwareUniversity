namespace _01.ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ReverseNumbers
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(input);
            var sb = new StringBuilder();

            while (stack.Count != 0)
            {
                sb.Append($"{stack.Pop()} ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
