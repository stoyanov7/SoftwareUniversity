namespace ModPanel.Controllers
{
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.Model.Data["anonymousDisplay"] = "flex";
            this.Model.Data["userDisplay"] = "none";
            this.Model.Data["adminDisplay"] = "none";
            this.Model.Data["show-error"] = "none";
        }

        protected IActionResult RedirectToHome() => this.RedirectToAction("/home/index");

        protected IActionResult RedirectToLogin() => this.RedirectToAction("/users/login");

        protected void ShowError(string error)
        {
            this.Model.Data["show-error"] = "block";
            this.Model.Data["error"] = error;
        }
    }
}