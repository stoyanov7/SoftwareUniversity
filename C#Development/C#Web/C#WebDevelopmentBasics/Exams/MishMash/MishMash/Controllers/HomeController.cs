namespace MishMash.Controllers
{
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Method;

    public class HomeController : BaseController
    {
        [HttpGet]
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