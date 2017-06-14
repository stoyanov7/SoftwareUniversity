using System;

namespace _08.Factorial
{
    public class Factorial
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorials(n));
        }

        public static long Factorials(int n)
        {
            if (n == 0)
                return 1;

            return n * Factorials(n - 1);
        }
    }
}
