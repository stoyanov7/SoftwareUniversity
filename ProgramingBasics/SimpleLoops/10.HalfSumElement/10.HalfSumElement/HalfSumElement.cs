using System;

namespace _10.HalfSumElement
{
    public class HalfSumElement
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            var max = 0;

            for (var i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());

                if (num > max)
                {
                    max = num;
                }

                sum += num;
            }

            sum -= max;

            if (sum == max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sum}");
            }
            else
            {
                var diff = Math.Abs(max - sum);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
