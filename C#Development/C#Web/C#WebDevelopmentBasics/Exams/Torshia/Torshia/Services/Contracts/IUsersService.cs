namespace Torshia.Services.Contracts
{
    public interface IUsersService
    {
        string GetUserRole(string username);

        void RegisterUser(string username, string password, string email);

        bool UserExists(string username, string password);
    }
}