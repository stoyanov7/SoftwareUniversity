namespace PhotoShare.Core.Commands
{
    using System;
    using Contracts;

    public class AcceptFriendCommand : ICommand
    {
        public AcceptFriendCommand()
        {
           
        }

        // AcceptFriend <username1> <username2>
        public string Execute(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
