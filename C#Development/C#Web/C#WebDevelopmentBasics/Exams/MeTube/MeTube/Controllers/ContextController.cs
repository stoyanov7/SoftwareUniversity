namespace MeTube.Controllers
{
    using Data;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;

    public class ContextController : Controller
    {
        protected ContextController()
        {
            this.Context = new MeTubeContext();
            this.Model.Data["error"] = string.Empty;
        }

        protected MeTubeContext Context { get; private set; }

        protected IActionResult RedirectToHome() => this.RedirectToAction("/home/index");
    }
}