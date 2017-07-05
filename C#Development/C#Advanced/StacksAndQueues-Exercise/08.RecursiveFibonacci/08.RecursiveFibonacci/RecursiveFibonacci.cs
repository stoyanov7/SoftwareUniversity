namespace _08.RecursiveFibonacci
{
    using System;

    public class RecursiveFibonacci
    {
        private static long[] fibonacciArray;

        public static void Main(string[] args)
        {
            fibonacciArray = new long[50];
            fibonacciArray[0] = 1;
            fibonacciArray[1] = 1;

            var n = long.Parse(Console.ReadLine());
            var result = GetFibonacci(n);

            Console.WriteLine(result);
        }

        public static long GetFibonacci(long n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (fibonacciArray[n - 1] != 0)
            {
                return fibonacciArray[n - 1];
            }

            fibonacciArray[n - 1] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            return fibonacciArray[n - 1];
        }
    }
}