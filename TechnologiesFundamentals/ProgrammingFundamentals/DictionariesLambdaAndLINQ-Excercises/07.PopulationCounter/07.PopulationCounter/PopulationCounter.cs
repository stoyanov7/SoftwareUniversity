namespace _07.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        public static void Main(string[] args)
        {
            var populations = new Dictionary<string, Dictionary<string, long>>();

            string line;
            while ((line = Console.ReadLine()) != "report")
            {
                var tokens = line
                    .Split('|')
                    .ToList();

                var city = tokens[0];
                var country = tokens[1];
                var population = long.Parse(tokens[2]);

                var cityPopulation = new Dictionary<string, long>();

                if (!populations.ContainsKey(country))
                {
                    cityPopulation[city] = population;
                    populations[country] = cityPopulation;
                }
                else
                {
                    cityPopulation = populations[country];

                    if (cityPopulation.ContainsKey(city))
                    {
                        cityPopulation[city] += population;
                    }
                    else
                    {
                        cityPopulation.Add(city, population);
                    }

                    populations[country] = cityPopulation;
                }
            }

            foreach (var state in populations.OrderByDescending(x => x.Value.Sum(y => y.Value)))
            {
                var sumOfTowns = state
                    .Value
                    .Select(x => x.Value)
                    .ToList();

                Console.WriteLine($"{state.Key} (total population: {sumOfTowns.Sum()})");

                Console.Write($"=>{string.Join("=>", state.Value.OrderByDescending(x => x.Value).Select(x => $"{x.Key}: {x.Value}\r\n"))}");
            }
        }
    }
}
