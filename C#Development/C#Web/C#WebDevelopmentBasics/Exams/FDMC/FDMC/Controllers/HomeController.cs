namespace FDMC.Controllers
{
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            var result = string.Empty;
            if (this.User.IsAuthenticated)
            {
                result = $@"<div class=""jumbotron"">
                    <h1>Welcome, {this.User.Name}</h1>
                    <hr class=""my-2"">
                    <p>Welcome to Fluffy Duffy Munchkin Cats wishes you a cute and awesome experiences.</p>
                    </div>";
            }
            else
            {
                result = @"<div class=""jumbotron"">
                    <h1>Welcome to Fluffy Duffy Munchkin Cats</h1>   
                    <p>The simplest, cutest, most reliable website for trading cats.</p>      
                    <hr class=""my-2"">
                    <p>
                    <a href=""/User/Login"">Login</a> to trade or <a href=""/User/Register"">Register</a> if you don't have an account.
                    </p>
                    </div>";
            }

            this.Model.Data["jumbotron"] = result;
            return this.View();
        }
    }
}