namespace _10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        public static void Main(string[] args)
        {
            var data = new Dictionary<string, Dictionary<string, long>>();
            var line = Console.ReadLine();

            while (line != "report")
            {
                ReadPopulation(data, line);
                line = Console.ReadLine();
            }

            PrintPopulation(data);
        }

        private static void ReadPopulation(Dictionary<string, Dictionary<string, long>> data, string line)
        {
            var lineTokens = line
                .Split('|')
                .ToArray();

            var city = lineTokens[0];
            var country = lineTokens[1];
            var population = long.Parse(lineTokens[2]);

            if (!data.ContainsKey(country))
            {
                data.Add(country, new Dictionary<string, long>());
            }

            if (!data[country].ContainsKey(city))
            {
                data[country].Add(city, 0L);
            }

            data[country][city] += population;
        }

        private static void PrintPopulation(Dictionary<string, Dictionary<string, long>> data)
        {
            foreach (var kvp in data.OrderByDescending(c => c.Value.Values.Sum()))
            {
                var country = kvp.Key;
                var countryPopulation = kvp.Value.Values.Sum();
                Console.WriteLine($"{country} (total population: {countryPopulation})");

                foreach (var innerKvp in kvp.Value.OrderByDescending(c => c.Value))
                {
                    var city = innerKvp.Key;
                    var cityPopulation = innerKvp.Value;
                    Console.WriteLine($"=>{city}: {cityPopulation}");
                }
            }
        }
    }
}