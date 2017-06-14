using System;

namespace _11.OddEvenPosition
{
    public class OddEvenPosition
    {
        public static void Main(string[] args)
        {
            var n = double.Parse(Console.ReadLine());
            var oddSum = 0d;
            var oddMin = 1000000000.0;
            var oddMax = -1000000000.0;
            var evenSum = 0d;
            var evenMin = 1000000000.0;
            var evenMax = -1000000000.0;

            for (var i = 1; i <= n; i++)
            {
                var num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += num;
                    evenMin = Math.Min(evenMin, num);
                    evenMax = Math.Max(evenMax, num);
                }
                else
                {
                    oddSum += num;
                    oddMin = Math.Min(oddMin, num);
                    oddMax = Math.Max(oddMax, num);
                }
            }

            Console.WriteLine($"OddSum={oddSum}");

            if (oddMin == 1000000000.0)
            {
                Console.WriteLine("OddMin=No");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin}");
            }

            if (oddMax == -1000000000.0)
            {
                Console.WriteLine("OddMax=No");
            }
            else
            {
                Console.WriteLine($"OddMax={oddMax}");
            }

            Console.WriteLine($"EvenSum={evenSum}");

            if (evenMin == 1000000000.0)
            {
                Console.WriteLine("evenMin=No");
            }
            else
            {
                Console.WriteLine($"evenMin={evenMin}");
            }

            if (evenMax == -1000000000.0)
            {
                Console.WriteLine("evenMax=No");
            }
            else
            {
                Console.WriteLine($"evenMax={evenMax}");
            }
        }
    }
}