namespace PhotoShare.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using ModelsDto;
    using Services.Contracts;

    public class AcceptFriendCommand : ICommand
    {
        private readonly IUserService userService;

        public AcceptFriendCommand(IUserService userrService)
        {
            this.userService = userrService;
        }

        public string Execute(string[] data)
        {
            var firstUsername = data[0];
            var secondUsername = data[1];

            if (!this.userService.Exists(firstUsername))
            {
                throw new ArgumentException($"User {firstUsername} not found!");
            }
            else if (!this.userService.Exists(secondUsername))
            {
                throw new ArgumentException($"User {secondUsername} not found!");
            }

            var user = this.userService.ByUsername<UserFriendsDto>(firstUsername);
            var friend = this.userService.ByUsername<UserFriendsDto>(secondUsername);

            if (user.Friends.Any(x => x.Username == secondUsername)) 
            {
                throw new InvalidOperationException($"{firstUsername} is already a friend to {secondUsername}");
            }
            else if (friend.Friends.Any(x => x.Username == firstUsername)) 
            {
                throw new InvalidOperationException($"{secondUsername} is already a friend to {firstUsername}");
            }

            this.userService.AcceptFriend(user.Id, friend.Id);

            user.Friends.Add(new FriendDto { Username = friend.Username });
            friend.Friends.Add(new FriendDto { Username = user.Username });

            return $"Friend {friend.Username} added to {user.Username}";
        }
    }
}
