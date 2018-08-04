namespace TeamBuilder.Services
{
    using System.Linq;
    using Contracts;
    using Data;
    using Models;
    using Models.Enums;

    public class UserService : IUserService
    {
        private readonly TeamBuilderContext context;

        public UserService(TeamBuilderContext context)
        {
            this.context = context;
        }

        public void RegisterUser(string username, string password, string repeatPassword, string firstName, string lastName, int age, Gender gender)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Age = age,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public void DeleteUser(User currentUser)
        {
            this.context.Users.Remove(currentUser);
            this.context.SaveChanges();
        }

        public bool IsUserExisting(string username)
        {
            return this.context
                .Users
                .Any(u => u.Username == username);
        }

        public bool IsUserCreatorOfTeam(string teamName, User user)
        {
            return this.context
                .Teams
                .Any(t => t.Name.ToLower() == teamName.ToLower() && 
                          t.Creator.Username.ToLower() == user.Username.ToLower());
        }

        public User GetUserByUsername(string username)
        {
            return this.context
                .Users
                .SingleOrDefault(u => u.Username == username);
        }

        public User GetUserByCredentials(string username, string password)
        {
            return this.context
                .Users
                .FirstOrDefault(u => u.Username == username &&
                                     u.Password == password);
        }
    }
}