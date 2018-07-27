namespace PhotoShare.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Contracts;
    using ModelsDto;
    using Services.Contracts;
    using Utilities.Constants;

    public class RegisterUserCommand : ICommand
    {
        private readonly IUserService userService;

        public RegisterUserCommand(IUserService userService) => this.userService = userService;

        public string Execute(string[] data)
        {
            var username = data[0];
            var password = data[1];
            var repeatPassword = data[2];
            var email = data[3];

            var registerUserDto = new RegisterUserDto
            {
                Username = username,
                Password = password,
                Email = email
            };

            if (!this.IsValid(registerUserDto))
            {
                throw new ArgumentException(Message.InvalidData);
            }

            var userExists = this.userService.Exists(username);

            if (userExists)
            {
                throw new InvalidOperationException(string.Format(Message.UsernameAlreadyTaken, username));
            }

            if (password != repeatPassword)
            {
                throw new ArgumentException(Message.PasswordNotMath);
            }

            this.userService.Register(username, password, email);

            return string.Format(Message.SuccessfullyRegisteredUsername, username);
        }

        private bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
