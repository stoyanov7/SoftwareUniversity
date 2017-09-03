namespace _08.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogsAggregator
    {
        public static void Main(string[] args)
        {
            var logs = new SortedDictionary<string, SortedDictionary<string, int>>();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var data = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var ip = data[0];
                var user = data[1];
                var duration = int.Parse(data[2]);

                if (!logs.ContainsKey(user))
                {
                    logs.Add(user, new SortedDictionary<string, int>());
                }

                if (!logs[user].ContainsKey(ip))
                {
                    logs[user].Add(ip, 0);
                }

                logs[user][ip] += duration;
            }

            foreach (var user in logs)
            {
                var username = user.Key;
                var durations = user
                    .Value
                    .Values
                    .Sum();
                var ips = string.Join(", ", user.Value.Keys);

                Console.WriteLine($"{username}: {durations} [{ips}]");
            }
        }
    }
}