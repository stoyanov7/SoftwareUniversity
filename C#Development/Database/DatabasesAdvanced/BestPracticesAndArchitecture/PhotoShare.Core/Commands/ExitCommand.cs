namespace PhotoShare.Core.Commands
{
    using System;
    using Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}