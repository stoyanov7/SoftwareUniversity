namespace _10.PriceChangeAlert
{
    using System;

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
            var result = string.Empty;

            if (difference == 0)
            {
                result = $"NO CHANGE: {newestPrice}";
            }
            else if (!hasSignificantDifference)
            {
                result = $"MINOR CHANGE: {lastAvailablePrice} to {newestPrice} ({difference * 100:F2}%)";
            }
            else if (hasSignificantDifference && difference > 0)
            {
                result = $"PRICE UP: {lastAvailablePrice} to {newestPrice} ({difference * 100:F2}%)";
            }
            else if (hasSignificantDifference && difference < 0)
            {
                result = $"PRICE DOWN: {lastAvailablePrice} to {newestPrice} ({difference * 100:F2}%)";
            }
            return result;
        }

        private static bool isSignificantDifferences(double difference, double threshold) => Math.Abs(difference) >= threshold ? true : false;

        private static double PercentageCalculation(double oldPrice, double newPrice) => (newPrice - oldPrice) / oldPrice;
    } 
}