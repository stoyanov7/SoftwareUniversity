namespace PhotoShare.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using ModelsDto;
    using Services.Contracts;
    using Utilities.Constants;

    public class ModifyUserCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly ITownService townService;

        public ModifyUserCommand(IUserService userService, ITownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }

        public string Execute(string[] data)
        {
            var username = data[0];
            var property = data[1];
            var value = data[2];

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
               throw new ArgumentException(string.Format(Message.NotFound, "User", username));
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;

            switch (property)
            {
                case "Password":
                    this.SetPassword(userId, value);
                    break;
                case "BornTown":
                    this.SetBornTown(userId, value);
                    break;
                case "CurrentTown":
                    this.SetCurrentTown(userId, value);
                    break;
                default:
                    throw new ArgumentException(Message.PropertyNotSupported, property);
            }

            return string.Format(Message.SuccessfullyModifiedUser, username, property, value);
        }

        private void SetCurrentTown(int userId, string name)
        {
            var townExists = this.townService.Exists(name);

            if (!townExists)
            {
                throw new ArgumentException(string.Format(Message.InvalidTown, name, name));
            }

            var townId = this.townService.ByName<TownDto>(name).Id;
            this.userService.SetCurrentTown(userId, townId);
        }

        private void SetBornTown(int userId, string name)
        {
           var townExists = this.townService.Exists(name);

            if (!townExists)
            {
                throw new ArgumentException(string.Format(Message.InvalidTown, name, name));
            }

            var townId = this.townService.ByName<TownDto>(name).Id;
            this.userService.SetBornTown(userId, townId);
        }

        private void SetPassword(int userId, string password)
        {
            var isLower = password.Any(char.IsLower);
            var isDigit = password.Any(char.IsDigit);

            if (!isLower || !isDigit)
            {
                throw new ArgumentException(string.Format(Message.InvalidPassword, password));
            }

            this.userService.ChangePassword(userId, password);
        }
    }
}
