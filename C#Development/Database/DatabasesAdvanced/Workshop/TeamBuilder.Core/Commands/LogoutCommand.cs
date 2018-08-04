namespace TeamBuilder.Core.Commands
{
    using Contracts;
    using Utilities;

    public class LogoutCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Validator.CheckLength(0, args);

            AuthenticationManager.Authorize();
            var currentUser = AuthenticationManager.GetCurrentUser();

            AuthenticationManager.Logout();

            return $"User {currentUser.Username} successfully logged out!";
        }
    }
}