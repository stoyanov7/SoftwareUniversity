namespace _08.MapDistricts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MapDistricts
    {
        public static void Main(string[] args)
        {
            var citiesWithPopulation = new Dictionary<string, List<long>>();
            var populations = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var minimumPopulation = long.Parse(Console.ReadLine());

            foreach (var item in populations)
            {
                var populationsTokens = item
                    .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var name = populationsTokens.First();
                var population = long.Parse(populationsTokens.Last());

                if (!citiesWithPopulation.ContainsKey(name))
                {
                    citiesWithPopulation.Add(name, new List<long>());
                }

                citiesWithPopulation[name].Add(population);
            }

            citiesWithPopulation = 
                citiesWithPopulation.Where(c => c.Value.Sum() >= minimumPopulation)
                .OrderByDescending(c => c.Key)
                .OrderByDescending(c => c.Value.Sum())
                .ToDictionary(c => c.Key, c => c.Value);

            foreach (var kvp in citiesWithPopulation)
            {
                var city = kvp.Key;
                var population = kvp
                    .Value
                    .OrderByDescending(x => x)
                    .Take(5);

                Console.WriteLine($"{city}: {string.Join(" ", population)}");
            }
        }
    }
}