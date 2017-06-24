using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GroupContinentsCountriesAndCities
{
    public class GroupContinentsCountriesAndCities
    {
        public static void Main(string[] args)
        {
            var continents = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currentLine = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                var continent = currentLine[0];
                var country = currentLine[1];
                var city = currentLine[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new SortedDictionary<string, SortedSet<string>>());
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new SortedSet<string>());
                }

                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
