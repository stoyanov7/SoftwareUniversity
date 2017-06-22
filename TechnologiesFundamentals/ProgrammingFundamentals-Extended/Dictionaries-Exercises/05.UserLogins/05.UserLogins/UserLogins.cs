using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.UserLogins
{
    public class UserLogins
    {
        public static void Main(string[] args)
        {
            var usernameAndPassword = new Dictionary<string, string>();
            var userLine = Console.ReadLine();

            while (userLine != "login")
            {
                ReadUserAndPassword(usernameAndPassword, userLine);
                userLine = Console.ReadLine();
            }

            var loginLine = Console.ReadLine();
            var count = 0;

            while (loginLine != "end")
            {
                var loginLineTokens = loginLine
                    .Split("->".ToCharArray())
                    .Select(e => e.Trim())
                    .ToArray();

                var username = loginLineTokens.First();
                var password = loginLineTokens.Last();
                var issuccessful = false;

                if (usernameAndPassword.ContainsKey(username))
                {
                    if (usernameAndPassword[username] == password)
                    {
                        issuccessful = true;
                    }
                }

                if (issuccessful)
                {
                    Console.WriteLine($"{username}: logged in successfully"); 
                }
                else
                {
                    Console.WriteLine($"{username}: login failed");
                    count++;
                }

                loginLine = Console.ReadLine();
            }

            Console.WriteLine($"unsuccessful login attempts: {count}");
        }

        private static void ReadUserAndPassword(Dictionary<string, string> usernameAndPassword, string userLine)
        {
            var userLineTokens = userLine
                .Split("->".ToCharArray())
                .Select(e => e.Trim())
                .ToArray();

            var username = userLineTokens.First();
            var password = userLineTokens.Last();

            if (!usernameAndPassword.ContainsKey(username))
            {
                usernameAndPassword.Add(username, string.Empty);
            }

            usernameAndPassword[username] = password;
        }
    }
}
