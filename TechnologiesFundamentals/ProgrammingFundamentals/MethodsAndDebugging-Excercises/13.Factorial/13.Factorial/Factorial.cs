namespace _13.Factorial
{
    using System;
    using System.Numerics;

    public class Factorial
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorials(number));
        }

        private static BigInteger Factorials(int number)
        {
            BigInteger factorial = 1;

            for (var i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    } 
}