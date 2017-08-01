namespace _03.ExactSumOfRealNumbers
{
    using System;

    public class ExactSumOfRealNumbers
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0m;

            for (var i = 0; i < n; i++)
            {
                var value = decimal.Parse(Console.ReadLine());
                sum += value;
            }

            Console.WriteLine(sum);
        }
    }
}