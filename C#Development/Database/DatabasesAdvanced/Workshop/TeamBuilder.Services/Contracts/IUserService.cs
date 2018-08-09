namespace TeamBuilder.Services.Contracts
{
    using Models;
    using Models.Enums;

    public interface IUserService
    {
        void RegisterUser(string username, string password, string repeatPassword, string firstName, string lastName, int age, Gender gender);

        void DeleteUser(User currentUser);

        bool IsUserExisting(string username);

        bool IsUserCreatorOfTeam(string teamName, User user);

        User GetUserByUsername(string username);

        User GetUserByCredentials(string username, string password);
    }
}