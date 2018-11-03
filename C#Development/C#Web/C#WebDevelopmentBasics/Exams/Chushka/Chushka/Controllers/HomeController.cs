namespace Chushka.Controllers
{
    using SIS.Framework.ActionResults;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                this.Model["Username"] = this.Identity.Username;
            }

            return this.View();
        }
    }
}