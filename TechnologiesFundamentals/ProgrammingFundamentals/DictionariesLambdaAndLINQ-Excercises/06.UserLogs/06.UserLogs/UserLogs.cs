namespace _06.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserLogs
    {
        public static void Main(string[] args)
        {
            var ips = new SortedDictionary<string, Dictionary<string, int>>();
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input
                    .Split(' ')
                    .ToArray();

                var ip = tokens[0].Substring(3);
                var userName = tokens[2].Substring(5);

                if (!ips.ContainsKey(userName))
                {
                    ips[userName] = new Dictionary<string, int> {{ip, 1}};
                }
                else
                {
                    if (ips[userName].ContainsKey(ip))
                    {
                        ips[userName][ip]++;
                    }
                    else
                    {
                        ips[userName].Add(ip, 1);
                    }
                }
            }

            PrintDictionary(ips);
        }

        private static void PrintDictionary(SortedDictionary<string, Dictionary<string, int>> ips)
        {
            foreach (var userName in ips.Keys)
            {
                Console.WriteLine($"{userName}: ");

                var ordered = ips[userName]
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

                var ipString = ordered
                    .Keys
                    .Aggregate(string.Empty, (current, ip) => current + $"{ip} => {ips[userName][ip]}, ");

                ipString = ipString.Substring(0, ipString.Length - 2);
                ipString += ".";

                Console.WriteLine(ipString);
            }
        }
    }
}