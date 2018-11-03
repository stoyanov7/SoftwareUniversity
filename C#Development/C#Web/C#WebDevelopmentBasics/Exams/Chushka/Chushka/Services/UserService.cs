namespace Chushka.Services
{
    using System.Linq;
    using Contracts;
    using Data;
    using Models;
    using Models.Enums;

    public class UserService : IUserService
    {
        private readonly ChushkaContext context;

        public UserService(ChushkaContext context)
        {
            this.context = context;
        }

        public void RegisterUser(string username, string password, string fullName, string email)
        {
            var role = this.context.Users.Any() ? RoleType.User : RoleType.Admin;

            var user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                FullName = fullName,
                Role = role
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public string GetUserRole(string username)
        {
            return this.context
                .Users
                .FirstOrDefault(u => u.Username == username)
                .Role
                .ToString();
        }

        public bool UserExists(string username, string password)
        {
            return this.context
                .Users
                .Any(u => u.Username == username && u.Password == password);
        }
    }
}