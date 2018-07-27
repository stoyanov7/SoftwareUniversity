namespace PhotoShare.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities.Constants;

    public class DeleteUserCommand : ICommand
    {
        private readonly IUserService userService;

        public DeleteUserCommand(IUserService userService) => this.userService = userService;

        public string Execute(string[] data)
        {
            var username = data[0];
            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException(string.Format(Message.NotFound, "User", username));
            }

            this.userService.Delete(username);

            return string.Format(Message.SuccessfullyDeletedUser, username);
        }
    }
}
