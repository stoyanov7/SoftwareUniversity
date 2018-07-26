namespace PhotoShare.Core.Commands
{
    using System;
    using Contracts;

    public class AddTagToCommand : ICommand
    {
        public AddTagToCommand()
        {
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
