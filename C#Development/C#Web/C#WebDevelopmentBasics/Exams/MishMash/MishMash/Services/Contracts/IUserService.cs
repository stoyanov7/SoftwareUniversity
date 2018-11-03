namespace MishMash.Services.Contracts
{
    public interface IUserService
    {
        string GetUserRole(string username);

        void RegisterUser(string username, string password, string email);

        bool UserExists(string username, string password);
    }
}