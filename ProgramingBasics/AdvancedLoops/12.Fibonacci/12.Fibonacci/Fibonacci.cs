using System;

namespace _12.Fibonacci
{
    public class Fibonacci
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if (n < 2)
            {
                Console.WriteLine("1");
                return;
            }

            var f0 = 0;
            var f1 = 1;
            var fSum = 0;

            for (var i = 0; i < n; i++)
            {
                fSum = f0 + f1;
                f0 = f1;
                f1 = fSum;
            }

            Console.WriteLine(fSum);
        }
    }
}
