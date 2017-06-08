namespace _07.SalesReport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SalesReport
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var totalSales = new SortedDictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                var currentSale = ReadSales();

                if (!totalSales.ContainsKey(currentSale.Town))
                {
                    totalSales[currentSale.Town] = 0;
                }

                totalSales[currentSale.Town] += currentSale.Quantity * currentSale.Price;
            }

            foreach (var kvp in totalSales)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:F2}");
            }
        }

        private static Sale ReadSales()
        {
            var inputTokens = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var town = inputTokens[0];
            var product = inputTokens[1];
            var price = decimal.Parse(inputTokens[2]);
            var quantity = decimal.Parse(inputTokens[3]);

            var sales = new Sale(town, product, price, quantity);

            return sales;
        }
    }
}