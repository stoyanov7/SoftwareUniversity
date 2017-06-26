using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CottageScraper
{
    public class CottageScraper
    {
        public static void Main(string[] args)
        {
            var materials = new Dictionary<string, List<long>>();
            var count = 0;
            var totalLength = 0d;
            var line = Console.ReadLine();

            while (line != "chop chop")
            {
                ReadMaterials(materials, ref count, ref totalLength, line);

                line = Console.ReadLine();
            }

            var type = Console.ReadLine();
            PrintMaterials(materials, count, totalLength, type);
        }

        private static void ReadMaterials(Dictionary<string, List<long>> materials, ref int count, ref double totalLength, string line)
        {
            count++;
            var lineTokens = line
                .Split("-> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var name = lineTokens[0];
            var length = int.Parse(lineTokens[1]);

            if (!materials.ContainsKey(name))
            {
                materials.Add(name, new List<long>());
            }

            materials[name].Add(length);
            totalLength += length;
        }

        private static void PrintMaterials(Dictionary<string, List<long>> materials, int count, double totalLength, string type)
        {
            var minimumLength = int.Parse(Console.ReadLine());
            var pricePerMeter = Math.Round(totalLength / count, 2);

            var usedLogsPrice = materials[type]
                .Where(x => x >= minimumLength)
                .Sum() * pricePerMeter;

            usedLogsPrice = Math.Round(usedLogsPrice, 2);

            var unusedLogsPrice = (double)materials
                .Where(x => x.Key != type)
                .ToDictionary(x => x.Key, x => x.Value)
                .Values
                .Select(x => x.Sum())
                .Sum() + materials[type]
                .Where(x => x < minimumLength)
                .Sum();

            unusedLogsPrice *= pricePerMeter * 0.25;
            unusedLogsPrice = Math.Round(unusedLogsPrice, 2);
            var totalPrice = usedLogsPrice + unusedLogsPrice;

            Console.WriteLine($"Price per meter: ${pricePerMeter:f2}");
            Console.WriteLine($"Used logs price: ${usedLogsPrice:f2}");
            Console.WriteLine($"Unused logs price: ${unusedLogsPrice:f2}");
            Console.WriteLine($"CottageScraper subtotal: ${totalPrice:f2}");
        }
    }
}