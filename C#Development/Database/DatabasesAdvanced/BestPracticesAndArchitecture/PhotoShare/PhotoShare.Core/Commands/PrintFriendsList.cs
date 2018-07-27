namespace PhotoShare.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;
    using Services.Contracts;

    public class PrintFriendsListCommand : ICommand
    {
        private readonly IUserService userService;

        public PrintFriendsListCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            var username = args[0];

            if (!this.userService.Exists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var user = this.userService.ByUsername<User>(username);
            var friends = user
                .FriendsAdded
                .Select(x => x.Friend.Username)
                .ToList();

            return friends.Count == 0 
                ? "No friends for this user.:(" 
                : $"Friends:\n-{string.Join("\n-", friends)}";
        }
    }
}
