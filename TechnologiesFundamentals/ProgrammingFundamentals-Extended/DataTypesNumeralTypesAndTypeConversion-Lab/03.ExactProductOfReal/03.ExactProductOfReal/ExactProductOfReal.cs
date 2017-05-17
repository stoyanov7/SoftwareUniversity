using System;

namespace _03.ExactProductOfReal
{
    public class ExactProductOfReal
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            decimal sum = decimal.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                sum *= decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}
