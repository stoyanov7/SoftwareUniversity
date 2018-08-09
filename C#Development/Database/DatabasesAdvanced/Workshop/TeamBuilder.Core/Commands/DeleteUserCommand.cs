namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities;

    public class DeleteUserCommand : ICommand
    {
        private readonly IUserService userService;

        public DeleteUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            if (!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.LoginFirst);
            }

            var user = AuthenticationManager.GetCurrentUser();

            AuthenticationManager.Logout();

            this.userService.DeleteUser(user);

            return string.Format(Constants.SuccessfullyDeletedUser, user.Username);
        }
    }
}