using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double priceThreshold = double.Parse(Console.ReadLine());
        double lastAvailablePrice = double.Parse(Console.ReadLine());
        for (int i = 0; i < n - 1; i++)
        {
            double currentPrice = double.Parse(Console.ReadLine());
            double difference = PercentageCalculation(lastAvailablePrice, currentPrice);
            bool isSignificantDifference = isSignificantDifferences(difference, priceThreshold);
            string message = GetMessage(currentPrice, lastAvailablePrice, difference, isSignificantDifference);
            Console.WriteLine(message);
            lastAvailablePrice = currentPrice;
        }
    }
    private static string GetMessage(double newestPrice, double lastAvailablePrice, double difference, bool hasSignificantDifference)
    {
        string result = "";
        if (difference == 0)
        {
            result = string.Format("NO CHANGE: {0}", newestPrice);
        }
        else if (!hasSignificantDifference)
        {
            result = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastAvailablePrice, newestPrice, difference * 100);
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
    private static bool isSignificantDifferences(double difference, double threshold)
    {
        return Math.Abs(difference) >= threshold ? true : false;
    }
    private static double PercentageCalculation(double oldPrice, double newPrice)
    {
        return (newPrice - oldPrice) / oldPrice;
    }
}
