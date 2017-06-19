using System;
using System.Numerics;

namespace _01.Factorial
{
    public class Factorial : NegativeNumberException
    {
        public static void Main(string[] args)
        {
            var wrongInput = true;

            while (wrongInput)
            {
                Console.Write("Enter n = ");
                var input = int.Parse(Console.ReadLine());

                try
                {
                    var result = CalculateFactorial(input);
                    Console.WriteLine($"n! = {result}");
                    wrongInput = false;
                }
                catch (NegativeNumberException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
        }

        private static BigInteger CalculateFactorial(int num)
        {
            if (num < 0)
                throw new NegativeNumberException("Cannot use negative number!");

                if (num == 0)
                return 1;

            else
                return num * CalculateFactorial(num - 1);
        }
    }
}
