namespace MeTube.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Attributes;
    using Models.BindingModels;
    using Models;
    using Models.ViewModels;
    using SimpleMvc.Common;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class UserController : BaseController
    {
        [HttpGet]
        public IActionResult Register() => this.User.IsAuthenticated ? this.RedirectToHome() : this.View();

        [HttpPost]
        public IActionResult Register(UserRegisterBindingModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            if (!this.IsValidModel(model))
            {
                return this.BuildErrorView();
            }

            var passwordHash = PasswordUtilities.GetPasswordHash(model.Password);

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = passwordHash
            };

            using (this.Context)
            {
                this.Context.Users.Add(user);
                this.Context.SaveChanges();
            }

            this.SignIn(user.Username, user.Id);
            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Login() => this.User.IsAuthenticated ? this.RedirectToHome() : this.View();

        [HttpPost]
        public IActionResult Login(UserLoginBindingModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            if (!this.IsValidModel(model))
            {
                return this.BuildErrorView();
            }

            User user;
            using (this.Context)
            {
                user = this.Context.Users
                    .FirstOrDefault(u => u.Username == model.Username);
            }
            var passwordHash = PasswordUtilities.GetPasswordHash(model.Password);

            if (passwordHash != user.PasswordHash)
            {
                return this.BuildErrorView();
            }

            this.SignIn(user.Username, user.Id);
            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (this.User.IsAuthenticated)
            {
                this.SignOut();
            }

            return this.RedirectToHome();
        }

        [HttpGet]
        [AuthorizeLogin]
        public IActionResult Profile()
        {
            IEnumerable<TubeProfileViewModel> tubes;
            using (this.Context)
            {
                tubes = this.Context
                    .Tubes
                    .Where(t => t.UploaderId == this.DbUser.Id)
                    .AsEnumerable()
                    .Select(TubeProfileViewModel.FromTube)
                    .ToList();
            }

            this.Model.Data["username"] = this.DbUser.Username;
            this.Model.Data["email"] = this.DbUser.Email;

            var tubesResult = new StringBuilder();
            foreach (var tube in tubes)
            {
                tubesResult.AppendLine(
                    $@"<tr>
                        <td>{tube.Id}</td>
                        <td>{tube.Title}</td>
                        <td>{tube.Author}</td>
                        <td><a href=""/tubes/details?id={tube.Id}"">Details</a></td>
                    </tr>");
            }

            this.Model.Data["tubes"] = tubesResult.ToString();

            return this.View();
        }
    }
}
