using System;

namespace _12.EqualPairs
{
    public class EqualPairs
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pairs = new int[n];
            var pairNumber = 0;

            for (var i = 1; i <= 2 * n; i++)
            {
                pairs[pairNumber] += int.Parse(Console.ReadLine());

                if (i % 2 == 0 && i != 2 * n)
                {
                    pairNumber++;
                }
            }

            var equal = false;
            var lastValue = pairs[0];
            var minValue = int.MinValue;
            var maxValue = int.MaxValue;
            var maxDiff = 0;

            for (var i = 0; i < n; i++)
            {
                var diff = Math.Abs(lastValue - pairs[i]);

                if (diff > maxDiff && i != 0)
                {
                    maxDiff = diff;
                }

                if (pairs[i] == lastValue)
                {
                    equal = true;
                    lastValue = pairs[i];
                }
                else
                {
                    equal = false;
                    lastValue = pairs[i];
                }

                if (pairs[i] > maxValue)
                {
                    maxValue = pairs[i];
                }

                if (pairs[i] < minValue)
                {
                    minValue = pairs[i];
                }

            }

            Console.WriteLine(equal ? $"Yes, value={pairs[0]}" : $"No, maxdiff={maxDiff}");
        }
    }
}
