namespace _06.AMinerTask
{
    using System;
    using System.Collections.Generic;

    public class AMinerTask
    {
        public static void Main(string[] args)
        {
            var products = new Dictionary<string, decimal>();
            var line = Console.ReadLine();

            while (line != "stop")
            {
                var resource = line;
                var quantity = decimal.Parse(Console.ReadLine());

                if (!products.ContainsKey(resource))
                {
                    products.Add(resource, 0);
                }

                products[resource] += quantity;

                line = Console.ReadLine();
            }

            foreach (var kvp in products)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}