namespace MeTube.Controllers
{
    using System.Linq;
    using Models;
    using Models.BindingModels;
    using SimpleMvc.Common;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class UserController : ContextController
    {
        [HttpGet]
        public IActionResult Register()
            => this.User.IsAuthenticated ? this.RedirectToHome() : this.View();

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

            var passwordHash = PasswordExtensions.GenerateSHA256String(model.Password);

            var user = new User
            {
                Username = model.Username,
                PasswordHash = passwordHash,
                Email = model.Email
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
        public IActionResult Login()
            => this.User.IsAuthenticated ? this.RedirectToHome() : this.View();

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
                user = this.Context
                    .Users
                    .FirstOrDefault(u => u.Username == model.Username);
            }

            var passwordHash = PasswordExtensions.GenerateSHA256String(model.Password);

            if (passwordHash != user.PasswordHash)
            {
                return this.BuildErrorView();
            }

            this.SignIn(user.Username, user.Id);
            return this.RedirectToHome();
        }

        private IActionResult BuildErrorView()
        {
            this.Model.Data["error"] = "You have errors in your form";
            return this.View();
        }
    }
}