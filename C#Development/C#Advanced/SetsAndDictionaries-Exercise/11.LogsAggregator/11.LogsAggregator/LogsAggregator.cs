namespace _11.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogsAggregator
    {
        public static void Main(string[] args)
        {
            var userLogs = new SortedDictionary<string, SortedDictionary<string, int>>();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var IP = currentLine[0];
                var user = currentLine[1];
                var duration = int.Parse(currentLine[2]);

                if (!userLogs.ContainsKey(user))
                {
                    userLogs.Add(user, new SortedDictionary<string, int>());
                }

                if (!userLogs[user].ContainsKey(IP))
                {
                    userLogs[user].Add(IP, 0);
                }

                userLogs[user][IP] += duration;
            }

            foreach (var kvp in userLogs)
            {
                var user = kvp.Key;
                var duration = kvp.Value.Values.Sum();
                var IPs = string.Join(", ", kvp.Value.Keys);

                Console.WriteLine($"{user}: {duration} [{IPs}]");
            }
        }
    }
}
