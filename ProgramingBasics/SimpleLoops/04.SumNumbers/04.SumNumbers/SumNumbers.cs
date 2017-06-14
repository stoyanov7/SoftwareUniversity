using System;

namespace _04.SumNumbers
{
    public class SumNumbers
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            var num = 0;

            for (var i = 0; i < n; i++)
            {
                num = int.Parse(Console.ReadLine());
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}
