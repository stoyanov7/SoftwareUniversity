using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Sale
{
    public decimal Price { get; set; }

    public string Town { get; set; }

    public string Product { get; set; }

    public decimal Quantity { get; set; }
}

public class SalesReport
{
    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var sales = new List<Sale>();

        for (int i = 0; i < n; i++)
        {
            var currentSaleInput = Console.ReadLine().Split(' ');

            var currentSale = new Sale
            {
                Town = currentSaleInput[0],
                Product = currentSaleInput[1],
                Price = decimal.Parse(currentSaleInput[2]),
                Quantity = decimal.Parse(currentSaleInput[3])
            };

            sales.Add(currentSale);
        }

        var result = new SortedDictionary<string, decimal>();

        foreach (var sale in sales)
        {
            if (!result.ContainsKey(sale.Town))
            {
                result[sale.Town] = 0;
            }

            result[sale.Town] += sale.Price * sale.Quantity;
        }

        foreach (var kvp in result)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value:F2}");
        }
    }
}