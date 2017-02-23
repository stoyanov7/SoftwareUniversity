using System;
using System.Globalization;

public class SoftuniCoffeeOrders
{
    public static void Main(string[] args)
    {
        var countOfOrders = int.Parse(Console.ReadLine());
        var totalPrice = 0m;

        for (int i = 0; i < countOfOrders; i++)
        {
            var pricePerCapsule = decimal.Parse(Console.ReadLine());
            var orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            var capsulesCount = long.Parse(Console.ReadLine());

            var daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
            var price = ((daysInMonth * capsulesCount) * pricePerCapsule);
            Console.WriteLine($"The price for the coffee is: ${price:F2}");
            totalPrice += price;
        }

        Console.WriteLine($"Total: ${totalPrice:F2}");
    }
}