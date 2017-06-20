using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Websites
{
    public class Websites
    {
        public static void Main(string[] args)
        {
            var websites = new List<Website>();
            var line = Console.ReadLine();

            while (!line.Equals("end"))
            {
                ReadWebsite(websites, line);

                line = Console.ReadLine();
            }

            PrintWebsite(websites);
        }

        private static void ReadWebsite(List<Website> websites, string line)
        {
            var lineTokens = line
                .Split(" | ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.Trim())
                .ToArray();

            var host = lineTokens[0];
            var domain = lineTokens[1];
            var queries = new List<string>();

            if (lineTokens.Length > 2)
            {
                queries = lineTokens[2]
                    .Split(',')
                    .ToList();
            }

            var website = new Website(host, domain, queries);
            websites.Add(website);
        }

        private static void PrintWebsite(List<Website> websites)
        {
            foreach (var website in websites)
            {
                var result = new StringBuilder();
                result.Append($"https://www.{website.Host}.{website.Domain}");

                if (website.Queries.Any())
                {
                    result.Append($"/query?=[");
                    result.Append(string.Join("]&[", website.Queries) + "]");
                }

                Console.WriteLine(result);
            }
        }
    }
}
