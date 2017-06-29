namespace _01.ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class ReverseStrings
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
