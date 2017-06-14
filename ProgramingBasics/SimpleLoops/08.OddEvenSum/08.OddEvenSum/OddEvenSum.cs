using System;

namespace _08.OddEvenSum
{
    public class OddEvenSum
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sumOdd = 0;
            var sumEven = 0;

            for (var i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    sumEven += num;
                }
                else if (i % 2 != 0)
                {
                    sumOdd += num;
                }
            }

            var diff = Math.Abs(sumEven - sumOdd);

            if (sumEven == sumOdd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumEven}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff {diff}");
            }
        }
    }
}
