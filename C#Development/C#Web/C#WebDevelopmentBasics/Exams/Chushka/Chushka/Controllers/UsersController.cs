namespace Chushka.Controllers
{
    using System.Collections.Generic;
    using Models.BindingModels;
    using Services.Contracts;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Attributes.Method;
    using SIS.Framework.Security;

    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.IsLoggedIn() ? this.RedirectToHome() : this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterBindingModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return this.View();
            }

            this.userService
                .RegisterUser(model.Username, model.Password, model.FullName, model.Email);

            var role = this.userService
                .GetUserRole(model.Username);

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username,
                Roles = new List<string> { role }
            };

            this.SignIn(identityUser);

            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.IsLoggedIn() ? this.RedirectToHome() : this.View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginBindingModel model)
        {
            var userexists = this.userService
                .UserExists(model.Username, model.Password);

            if (!userexists)
            {
                return this.RedirectToAction("/Users/Register");
            }

            var role = this.userService
                .GetUserRole(model.Username);

            var identityUser = new IdentityUser
            {
                Username = model.Username,
                Password = model.Password,
                Roles = new List<string> { role }
            };

            this.SignIn(identityUser);
            return this.RedirectToHome();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.RedirectToHome();
        }
    }
}