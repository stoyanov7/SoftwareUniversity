namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Models.Enums;
    using Services.Contracts;
    using Utilities;

    public class RegisterUserCommand : ICommand
    {
        private readonly IUserService userService;

        public RegisterUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Validator.CheckLength(7, args);

            var username = args[0];
            Validator.ValidateUsername(username);

            var password = args[1];
            Validator.ValidatePassword(password);

            var repeatedPassword = args[2];
            if (password != repeatedPassword)
            {
                throw new InvalidOperationException(Constants.PasswordDoesNotMatch);
            }

            var firstName = args[3];
            var lastName = args[4];

            Validator.ValidateNames(firstName,
                string.Format(Constants.NameNotValid, "First"));

            Validator.ValidateNames(lastName,
                string.Format(Constants.NameNotValid, "Last"));

            var isNumber = int.TryParse(args[5], out var age);
            if (!isNumber || age <= 0)
            {
                throw new ArgumentException(Constants.AgeNotValid);

            }

            var isGenderValid = Enum.TryParse<Gender>(args[6], out var gender);
            if (!isGenderValid)
            {
                throw new ArgumentException(Constants.GenderNotValid);
            }

            if (this.userService.IsUserExisting(username))
            {
                throw new InvalidOperationException(string.Format(Constants.UsernameIsTaken, username));
            }

            this.userService
                .RegisterUser(username, password, repeatedPassword, firstName, lastName, age, gender);

            return string.Format(Constants.SuccessfullyRegisteredUser, username);
        }
    }
}