namespace MishMash.Controllers
{
    using System.Linq;
    using System.Runtime.CompilerServices;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Controllers;

    public class BaseController : Controller
    {
        public IActionResult RedirectToHome() => this.RedirectToAction("/");

        public bool IsLoggedIn() => this.Identity != null;

        protected override IViewable View([CallerMemberName] string actionName = "")
        {
            if (this.IsLoggedIn())
            {
                if (this.Identity.Roles.Contains("Admin"))
                {
                    this.Model.Data["Admin"] = "block";
                    this.Model.Data["User"] = "none";
                    this.Model.Data["Guest"] = "none";
                }
                else
                {
                    this.Model.Data["Admin"] = "none";
                    this.Model.Data["User"] = "block";
                    this.Model.Data["Guest"] = "none";
                }
            }
            else
            {
                this.Model.Data["Guest"] = "block";
                this.Model.Data["Admin"] = "none";
                this.Model.Data["User"] = "none";
            }

            return base.View(actionName);
        }
    }
}