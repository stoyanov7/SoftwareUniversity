namespace PhotoShare.Core.Commands
{
    using System;

    using Contracts;

    public class AddFriendCommand : ICommand
    {
        public AddFriendCommand()
        {
           
        }

        // AddFriend <username1> <username2>
        public string Execute(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
