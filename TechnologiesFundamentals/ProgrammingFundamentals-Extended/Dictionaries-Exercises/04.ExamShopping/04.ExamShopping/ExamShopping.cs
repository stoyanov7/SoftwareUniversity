using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ExamShopping
{
    public class ExamShopping
    {
        public static void Main(string[] args)
        {
            var productsList = new Dictionary<string, int>();
            var shoppingLine = Console.ReadLine();

            while (shoppingLine != "shopping time")
            {
                ReadStock(productsList, shoppingLine);
                shoppingLine = Console.ReadLine();
            }

            var examLine = Console.ReadLine();

            while (examLine != "exam time")
            {
                ReadBuy(productsList, examLine);
                examLine = Console.ReadLine();
            }

            PrintLeftProducts(productsList);
        }

        private static void ReadStock(Dictionary<string, int> productsList, string shoppingLine)
        {
            var shoppingLineTokens = shoppingLine
                                .Split(' ')
                                .ToArray();

            var product = shoppingLineTokens[1];
            var quantity = int.Parse(shoppingLineTokens[2]);

            if (!productsList.ContainsKey(product))
            {
                productsList.Add(product, 0);
            }

            productsList[product] += quantity;
        }

        private static void ReadBuy(Dictionary<string, int> productsList, string examLine)
        {
            var examLineTokens = examLine
                                .Split(' ')
                                .ToArray();

            var product = examLineTokens[1];
            var quantity = int.Parse(examLineTokens[2]);

            if (productsList.ContainsKey(product))
            {
                if (productsList[product] > 0)
                {
                    productsList[product] -= quantity;
                }
                else
                {
                    Console.WriteLine($"{product} out of stock");
                }

            }
            else
            {
                Console.WriteLine($"{product} doesn't exist");
            }
        }

        private static void PrintLeftProducts(Dictionary<string, int> productsList)
        {
            var leftProducts = productsList
                .Where(p => p.Value > 0)
                .ToDictionary(p => p.Key, p => p.Value);

            foreach (var kvp in leftProducts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
