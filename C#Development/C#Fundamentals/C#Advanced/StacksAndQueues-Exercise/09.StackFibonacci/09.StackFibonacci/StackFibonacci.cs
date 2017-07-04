namespace _09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        public static void Main(string[] args)
        {
            var fibonacciNumbers = new Stack<long>();
            var n = long.Parse(Console.ReadLine());

            fibonacciNumbers.Push(1);
            fibonacciNumbers.Push(1);
            fibonacciNumbers.Push(1);

            for (var i = 3; i <= n; i++)
            {
                var first = fibonacciNumbers.Pop();
                var second = fibonacciNumbers.Peek();
                fibonacciNumbers.Push(first);

                var fibonacci = first + second;
                fibonacciNumbers.Push(fibonacci);
            }

            Console.WriteLine(fibonacciNumbers.Peek());
        }
    }
}
