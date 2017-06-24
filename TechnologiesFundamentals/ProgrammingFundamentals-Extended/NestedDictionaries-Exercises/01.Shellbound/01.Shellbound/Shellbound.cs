using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Shellbound
{
    public class Shellbound
    {
        public static void Main(string[] args)
        {
            var regionShells = new Dictionary<string, HashSet<long>>();
            var line = Console.ReadLine();

            while (line != "Aggregate")
            {
                ReadShellbound(regionShells, line);

                line = Console.ReadLine();
            }

            PrintShellbound(regionShells);
        }

        private static void ReadShellbound(Dictionary<string, HashSet<long>> regionShells, string line)
        {
            var lineTokens = line
                .Split(' ')
                .ToArray();

            var city = lineTokens[0];
            var shell = int.Parse(lineTokens[1]);

            if (!regionShells.ContainsKey(city))
            {
                regionShells.Add(city, new HashSet<long>());
            }

            regionShells[city].Add(shell);
        }

        private static void PrintShellbound(Dictionary<string, HashSet<long>> regionShells)
        {
            foreach (var kvp in regionShells)
            {
                var town = kvp.Key;
                var shells = string.Join(", ", kvp.Value);
                var sumOfShells = kvp.Value.Sum();
                var countOfShells = kvp.Value.Count;
                var giantShell = sumOfShells - (sumOfShells / countOfShells);

                Console.WriteLine($"{town} -> {shells} ({giantShell})");
            }
        }
    }
}   