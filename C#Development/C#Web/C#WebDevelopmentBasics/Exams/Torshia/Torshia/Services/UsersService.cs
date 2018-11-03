namespace Torshia.Services
{
    using System.Linq;
    using Data;
    using Models;
    using Models.Enums;
    using Contracts;

    public class UsersService : BaseService, IUsersService
    {
        public UsersService(TorshiaContext context)
            : base(context)
        {
        }

        public string GetUserRole(string username)
        {
            return this.context
                .Users
                .FirstOrDefault(u => u.Username == username)
                .Role
                .ToString();
        }

        public void RegisterUser(string username, string password, string email)
        {
            var role = this.context.Users.Any() ? UserRole.User : UserRole.Admin;

            var user = new User
            {
                Username = username,
                Email = email,
                Password = password, Role = role
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public bool UserExists(string username, string password)
        {
            return this.context
                .Users
                .Any(u => u.Username == username && u.Password == password);
        }
    }
}