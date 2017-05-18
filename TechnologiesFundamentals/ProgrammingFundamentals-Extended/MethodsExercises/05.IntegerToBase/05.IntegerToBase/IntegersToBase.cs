using System;

namespace _05IntegerToBase
{
    public class IntegersToBase
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var toBase = int.Parse(Console.ReadLine());

            var result = IntegerToBase(number, toBase);
            Console.WriteLine(result);
        }

        private static string IntegerToBase(int number, int toBase)
        {
            var result = string.Empty;

            while (number > 0)
            {
                var remainder = number % toBase;
                result = remainder + result;
                number /= toBase;
            }

            return result;
        }
    }
}