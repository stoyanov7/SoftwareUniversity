using System;
using System.Numerics;

namespace _03.BigFactorial
{
    public class BigFactorial
    {
        public static void Main(string[] args)
        {
            var number = BigInteger.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(number));
        }

        private static BigInteger Factorial(BigInteger n)
        {

            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
