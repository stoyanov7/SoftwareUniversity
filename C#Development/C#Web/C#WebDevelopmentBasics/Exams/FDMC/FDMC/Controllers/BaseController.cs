namespace FDMC.Controllers
{
    using System.Linq;
    using Data;
    using Models;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.Context = new KittenContext();
            this.Model.Data["error"] = string.Empty;
        }

        protected KittenContext Context { get; private set; }

        protected User DbUser { get; private set; }

        protected IActionResult RedirectToHome() => this.RedirectToAction("/home/index");

        protected virtual IActionResult BuildErrorView()
        {
            this.Model.Data["error"] = "You have errors in your form.";
            return this.View();
        }

        public override void OnAuthentication()
        {
            const string authenticated = @"<li class=""nav-item active"">
	                <a class=""nav-link h5"" href=""/"">Home</a>
                </li>
                <li class=""nav-item active"">
	                <a class=""nav-link h5"" href=""/kitten/all"">All Kittens</a>
                </li>
                <li class=""nav-item active"">
	                <a class=""nav-link h5"" href=""/kitten/add"">Add Kittens</a>
                </li>
                <li class=""nav-item active"">
	                <a class=""nav-link h5"" href=""/user/logout"">Logout</a>
                </li>";

            const string notAuthenticated = @"<li class=""nav-item active col-md-4"">
	                <a class=""nav-link h5"" href=""/"">Home</a>
                </li>
                <li class=""nav-item active col-md-4"">
	                <a class=""nav-link h5"" href=""/user/login"">Login</a>
                </li>
                <li class=""nav-item active col-md-4"">
	                <a class=""nav-link h5"" href=""/user/register"">Register</a>
                </li>";

            this.Model.Data["topMenu"] = this.User.IsAuthenticated ?
                authenticated : notAuthenticated;


            if (this.User.IsAuthenticated)
            {
                this.DbUser = this.Context.Users
                    .FirstOrDefault(u => u.Username == this.User.Name);
            }

            base.OnAuthentication();
        }
    }
}