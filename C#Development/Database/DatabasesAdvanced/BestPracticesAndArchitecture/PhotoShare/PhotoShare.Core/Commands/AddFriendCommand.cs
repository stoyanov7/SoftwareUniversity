namespace PhotoShare.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using ModelsDto;
    using Services.Contracts;

    public class AddFriendCommand : ICommand
    {
        private readonly IUserService userService;

        public AddFriendCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // AddFriend <username1> <username2>
        public string Execute(string[] data)
        {
            var username = data[0];
            var friendUsername = data[1];

            var userExist = this.userService.Exists(username);
            var friendExist = this.userService.Exists(friendUsername);

            if (userExist)
            {
                throw new ArgumentException($"{username} not found!");
            }

            if (friendExist)
            {
                throw new ArgumentException($"{friendUsername} not found!");
            }

            var user = this.userService.ByUsername<UserFriendsDto>(username);
            var friend = this.userService.ByUsername<UserFriendsDto>(friendUsername);

            var isSentRequestFromUser = user
                .Friends
                .Any(x => x.Username == friend.Username);

            var isSentRequestFromFriend = friend
                .Friends
                .Any(x => x.Username == user.Username);

            if (isSentRequestFromUser && isSentRequestFromFriend)
            {
                throw new InvalidOperationException($"{friend.Username} is already a friend to {user.Username}");
            }
            else if (isSentRequestFromUser && !isSentRequestFromFriend)
            {
                throw new InvalidOperationException("Request is already sent!");
            }
            else if (isSentRequestFromFriend && !isSentRequestFromUser)
            {
                throw new InvalidOperationException("Request is already sent!");
            }

            this.userService.AddFriend(user.Id, friend.Id);

            return $"Friend {friend} added to {user}!";
        }
    }
}
