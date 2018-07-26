namespace PhotoShare.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using ModelsDto;
    using Services.Contracts;

    public class ModifyUserCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly ITownService townService;

        public ModifyUserCommand(IUserService userService, ITownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            string username = data[0];
            string property = data[1];
            string value = data[2];

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
               throw new ArgumentException($"User {username} not found!");
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;

            if (property == "Password")
            {
                SetPassword(userId, value);
            }else if (property == "BornTown")
            {
                SetBornTown(userId, value);
            }
            else if (property == "CurrentTown")
            {
                SetCurrentTown(userId, value);
            }
            else
            {
                throw new ArgumentException($"Property {property} not supported");
            }
            return $"User {username} {property} is {value}.";
        }

        private void SetCurrentTown(int userId, string name)
        {
            var townExists = this.townService.Exists(name);

            if (!townExists)
            {
                throw new ArgumentException(($"Value {name} not valid.\nTown {name} not found!"));
            }

            var townId = this.townService.ByName<TownDto>(name).Id;

            this.userService.SetCurrentTown(userId, townId);
        }

        private void SetBornTown(int userId, string name)
        {
           var townExists = this.townService.Exists(name);

            if (!townExists)
            {
                throw new ArgumentException(($"Value {name} not valid.\nTown {name} not found!"));
            }

            var townId = this.townService.ByName<TownDto>(name).Id;

            this.userService.SetBornTown(userId, townId);
        }

        private void SetPassword(int userId, string password)
        {
            var isLower = password.Any(x => char.IsLower(x));
            var isDigit = password.Any(x => char.IsDigit(x));

            if (!isLower||!isDigit)
            {
                throw new ArgumentException($"Value {password} not valid.\nInvalid Password");
            }

            this.userService.ChangePassword(userId, password);
        }
    }
}
