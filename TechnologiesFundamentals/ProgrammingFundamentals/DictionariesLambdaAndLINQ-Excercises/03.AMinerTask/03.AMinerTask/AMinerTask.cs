using System;
using System.Collections.Generic;

public class AMinerTask
{
    public static void Main(string[] args)
    {
        var products = new Dictionary<string, decimal>();
        var input = Console.ReadLine();

        while (!input.Equals("stop"))
        {
            var resource = input;
            var quantity = decimal.Parse(Console.ReadLine());

            if (!products.ContainsKey(resource))
            {
                products[resource] = 0;
            }

            products[resource] += quantity;

            input = Console.ReadLine();
        }

        foreach (var element in products)
        {
            Console.WriteLine($"{element.Key} -> {element.Value}");
        }
    }
}