using System;

namespace _03PriceChangeAlert
{
    public class PriceChangeAlert
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var priceThreshold = double.Parse(Console.ReadLine());
            var lastAvailablePrice = double.Parse(Console.ReadLine());

            for (var i = 0; i < n - 1; i++)
            {
                var currentPrice = double.Parse(Console.ReadLine());
                var difference = PercentageCalculation(lastAvailablePrice, currentPrice);
                var isSignificantDifference = isSignificantDifferences(difference, priceThreshold);
                var message = GetMessage(currentPrice, lastAvailablePrice, difference, isSignificantDifference);

                Console.WriteLine(message);
                lastAvailablePrice = currentPrice;
            }
        }

        private static string GetMessage(double newestPrice, double lastAvailablePrice, double difference, bool hasSignificantDifference)
        {
            var result = "";

            if (difference == 0)
            {
                result = string.Format($"NO CHANGE: {newestPrice}");
            }
            else if (!hasSignificantDifference)
            {
                result = string.Format($"MINOR CHANGE: {0} to {1} ({2:F2}%)", lastAvailablePrice, newestPrice, difference * 100);
            }
            else if (hasSignificantDifference && difference > 0)
            {
                result = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastAvailablePrice, newestPrice, difference * 100);
            }
            else if (hasSignificantDifference && difference < 0)
            {
                result = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastAvailablePrice, newestPrice, difference * 100);
            }

            return result;
        }

        private static bool isSignificantDifferences(double difference, double threshold) => Math.Abs(difference) >= threshold ? true : false;

        private static double PercentageCalculation(double oldPrice, double newPrice) => (newPrice - oldPrice) / oldPrice;
    }
}