namespace PhotoShare.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities.Constants;

    public class AddTownCommand : ICommand
    {
        private readonly ITownService townService;

        public AddTownCommand(ITownService townService) => this.townService = townService;

        public string Execute(string[] data)
        {
            var townName = data[0];
            var country = data[1];

            var townExists = this.townService.Exists(townName);

            if (townExists)
            {
                throw new ArgumentException(string.Format(Message.AlreadyExist, "Town", townName));
            }

            var town = this.townService.Add(townName, country);

            return string.Format(Message.SuccessfullyAdded, "Town", townName);
        }
    }
}
