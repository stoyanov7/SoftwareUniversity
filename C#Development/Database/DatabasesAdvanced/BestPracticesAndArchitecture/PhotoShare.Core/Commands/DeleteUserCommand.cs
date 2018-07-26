namespace PhotoShare.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;

    public class DeleteUserCommand : ICommand
    {
        private readonly IUserService userService;

        public DeleteUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // DeleteUser <username>
        public string Execute(string[] data)
        {
            string username = data[0];

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }

             this.userService.Delete(username);

            return $"User {username} was deleted from the database!";
        }
    }
}
