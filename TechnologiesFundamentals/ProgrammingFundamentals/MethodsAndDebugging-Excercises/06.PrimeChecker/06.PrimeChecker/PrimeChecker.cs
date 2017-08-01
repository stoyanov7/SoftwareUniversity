namespace _06.PrimeChecker
{
    using System;

    public class PrimeChecker
    {
        public static void Main(string[] args)
        {
            var number = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(number));
        }

        private static bool IsPrime(long number)
        {
            if (number < 2)
            {
                return false;
            }
            else
            {
                for (var i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    } 
}