namespace _09.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserLogs
    {
        public static void Main(string[] args)
        {
            var users = new Dictionary<string, List<string>>();
            var line = Console.ReadLine();

            while (line != "end")
            {
                ReadUserLogs(users, line);
                line = Console.ReadLine();
            }

            PrintUserLogs(users);
        }

        private static void ReadUserLogs(Dictionary<string, List<string>> users, string line)
        {
            var lineTokens = line
                .Split(new[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var user = lineTokens.Last();
            var IP = lineTokens[1];

            if (!users.ContainsKey(user))
            {
                users.Add(user, new List<string>());
            }

            users[user].Add(IP);
        }

        private static void PrintUserLogs(Dictionary<string, List<string>> users)
        {
            foreach (var user in users.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}: ");

                var distinctIp = user.Value
                    .Distinct()
                    .ToArray();

                for (var i = 0; i < distinctIp.Count(); i++)
                {
                    var IPAdress = distinctIp[i];
                    var count = user
                        .Value
                        .Where(x => x == distinctIp[i])
                        .Count();

                    if (i == distinctIp.Count() - 1)
                    {
                        Console.WriteLine($"{IPAdress} => {count}.");
                    }
                    else
                    {
                        Console.Write($"{IPAdress} => {count}, ");
                    }
                }
            }
        }
    }
}