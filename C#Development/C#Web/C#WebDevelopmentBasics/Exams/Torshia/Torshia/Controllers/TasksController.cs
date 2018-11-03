namespace Torshia.Controllers
{
    using Models.Tasks;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Attributes.Method;
    using Services.Contracts;

    public class TasksController : BaseController
    {
        private readonly ITasksService tasksService;

        public TasksController(ITasksService tasksService)
        {
            this.tasksService = tasksService;
        }

        [HttpGet]
        [Authorize("Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize("Admin")]
        public IActionResult Create(TaskFullViewModel model)
        {
            this.tasksService.CreateTask(
                model.Title,
                model.Description,
                model.DueDate,
                model.Participants,
                model.AffectedSectors);

            return this.RedirectToHome();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(TaskIdViewModel model)
        {
            var taskViewModel = this.tasksService.GetTaskById(model.Id);

            this.Model["Title"] = taskViewModel.Title;
            this.Model["Description"] = taskViewModel.Description;
            this.Model["AffectedSectors"] = taskViewModel.AffectedSectors;
            this.Model["Level"] = taskViewModel.Level;
            this.Model["DueDate"] = taskViewModel.DueDate;
            this.Model["Participants"] = taskViewModel.Participants;

            return this.View();
        }
    }
}