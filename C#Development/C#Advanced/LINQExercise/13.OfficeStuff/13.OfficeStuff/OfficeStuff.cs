namespace _13.OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class OfficeStuff
    {
        public static void Main(string[] args)
        {
            var companyStuffs = new Dictionary<string, Dictionary<string, long>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var lineTokens = Console.ReadLine()
                    .Split(new[] { '|', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var companyName = lineTokens[0];
                var productCount = long.Parse(lineTokens[1]);
                var productName = lineTokens[2];

                if (!companyStuffs.ContainsKey(companyName))
                {
                    companyStuffs.Add(companyName, new Dictionary<string, long>());
                }

                if (!companyStuffs[companyName].ContainsKey(productName))
                {
                    companyStuffs[companyName].Add(productName, 0);
                }

                companyStuffs[companyName][productName] += productCount;
            }

            companyStuffs = companyStuffs
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            var sb = new StringBuilder();

            foreach (var kvp in companyStuffs)
            {
                sb.Append($"{kvp.Key}: ");
                var currentLine = string.Empty;

                foreach (var innerKvp in kvp.Value)
                {
                    currentLine += $"{innerKvp.Key}-{innerKvp.Value}, ";
                }

                currentLine = currentLine.Trim(new char[] { ' ', ',' });
                sb.AppendLine(currentLine);
            }

            Console.Write(sb);
        }
    }
}