namespace Torshia.Controllers
{
    using System.Collections.Generic;
    using Models.Users;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Attributes.Method;
    using SIS.Framework.Security;
    using Services.Contracts;

    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.IsLoggedIn() ? this.RedirectToHome() : this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var userexists = this.usersService
                .UserExists(model.Username, model.Password);

            if (!userexists)
            {
                return this.RedirectToAction("/Users/Register");
            }

            var role = this.usersService
                .GetUserRole(model.Username);

            var identityUser = new IdentityUser
            {
                Username = model.Username,
                Password = model.Password,
                Roles = new List<string> {role}
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

        [HttpGet]
        public IActionResult Register()
        {
            return this.IsLoggedIn() ? this.RedirectToHome() : this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return this.View();
            }

            this.usersService
                .RegisterUser(model.Username, model.Password, model.Email);

            var role = this.usersService
                .GetUserRole(model.Username);

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username,
                Roles = new List<string> {role}
            };

            this.SignIn(identityUser);

            return this.RedirectToHome();
        }
    }
}