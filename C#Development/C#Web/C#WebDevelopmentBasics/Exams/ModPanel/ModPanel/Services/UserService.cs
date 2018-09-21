namespace ModPanel.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;
    using Models.Enums;
    using Models.ViewModels;
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

        public IEnumerable<AdminUsersViewModel> All()
            => this.context
                .Users
                .Select(u => new AdminUsersViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    IsApproved = u.IsApproved,
                    Position = u.Position,
                    Posts = u.Posts.Count()
                })
                .ToList();

        public string Approve(int id)
        {
            var user = this.context.Users.Find(id);

            if (user != null)
            {
                user.IsApproved = true;

                this.context.SaveChanges();
            }

            return user?.Email;
        }
    }
}
