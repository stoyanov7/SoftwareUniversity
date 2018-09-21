namespace ModPanel.Services
{
    using System.Linq;
    using Contracts;
    using Data;
    using Models;
    using Models.Enums;
    using SimpleMvc.Common;

    public class UserService : IUserService
    {
        private readonly ModPanelContext context;

        public UserService() => this.context = new ModPanelContext();

        public bool Create(string email, string password, PositionType position)
        {
            using (this.context)
            {
                if (this.context.Users.Any(u => u.Email == email))
                {
                    return false;
                }

                var isAdmin = !this.context.Users.Any();
                var passwordHash = PasswordUtilities.GetPasswordHash(password);

                var user = new User
                {
                    Email = email,
                    PasswordHash = passwordHash,
                    IsAdmin = isAdmin,
                    Position = position,
                    IsApproved = isAdmin
                };

                this.context.Add(user);
                this.context.SaveChanges();

                return true;
            }
        }

        public bool UserIsApproved(string email) 
            => this.context
                .Users
                .Any(u => u.Email == email && u.IsApproved);

        public bool UserExists(string email, string password)
        {
            var passwordHash = PasswordUtilities.GetPasswordHash(password);

            return this.context
                .Users
                .Any(u => u.Email == email && u.PasswordHash == passwordHash);
        }
    }
}
