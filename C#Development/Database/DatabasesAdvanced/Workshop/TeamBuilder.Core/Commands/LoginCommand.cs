namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities;

    public class LoginCommand : ICommand
    {
        private readonly IUserService userService;

        public LoginCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Validator.CheckLength(2, args);

            var username = args[0];
            var password = args[1];

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.LogoutFirst);
            }

            var user = this.userService.GetUserByCredentials(username, password);

            if (user == null)
            {
                throw new ArgumentException(Constants.UserOrPasswordIsInvalid);
            }

            AuthenticationManager.Login(user);

            return string.Format(Constants.SuccessfullyLogedinUser, username);
        }
    }
}