namespace Torshia.Controllers
{
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Method;
    using Services.Contracts;

    public class HomeController : BaseController
    {
        private readonly ITasksService tasksService;

        public HomeController(ITasksService tasksService)
        {
            this.tasksService = tasksService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                this.Model["Username"] = this.Identity.Username;
                this.Model["Tasks"] = this.tasksService.AllNonReported();
            }

            return this.View();
        }
    }
}