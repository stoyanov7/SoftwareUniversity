using System;

namespace _09.SumDigits
{
    public class SumDigits
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;

            do
            {
                sum += (n % 10);
                n /= 10;
            } while (n > 0);

            Console.WriteLine(sum);
        }
    }
}
