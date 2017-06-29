namespace _04.MatchingBrackets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MatchingBrackets
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                    continue;
                }

                if (input[i] == ')')
                {
                    var startIndex = stack.Pop();
                    var lastIndex = i;
                    sb.AppendLine(input.Substring(startIndex, lastIndex - startIndex + 1));
                }
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
