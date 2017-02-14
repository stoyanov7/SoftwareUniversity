using System;
using System.Globalization;

public class SoftUniCoffeeOrders
{
    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var totalPrice = 0m;

        for (var i = 0; i < n; i++)
        {
            var pricePerCapsule = decimal.Parse(Console.ReadLine());
            var orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            var capsuleCount = long.Parse(Console.ReadLine());

            var daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
            var currentPrice = (daysInMonth * capsuleCount) * pricePerCapsule;
            totalPrice += currentPrice;

            Console.WriteLine($"The price for the coffee is: ${currentPrice:F2}");
        }

        Console.WriteLine($"Total: ${totalPrice:F2}");
    }
}