namespace Chushka.Services.Contracts
{
    public interface IUserService
    {
        void RegisterUser(string username, string password, string fullName, string email);

        string GetUserRole(string username);

        bool UserExists(string username, string password);
    }
}