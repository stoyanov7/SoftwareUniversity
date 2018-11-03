namespace Torshia.Controllers
{
    using Models.Reports;
    using Models.Tasks;
    using SIS.Framework.ActionResults;
    using SIS.Framework.Attributes.Action;
    using SIS.Framework.Attributes.Method;
    using Services.Contracts;

    public class ReportsController : BaseController
    {
        private readonly IReportService reportService;

        public ReportsController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet]
        [Authorize("Admin")]
        public IActionResult All()
        {
            var model = this.reportService.GetReports();
            this.Model["Reports"] = model;

            return this.View();
        }

        [HttpGet]
        [Authorize("Admin")]
        public IActionResult Details(ReportIdViewModel model)
        {
            var reportViewModel = this.reportService.GetReportById(model.Id);

            this.Model["Id"] = reportViewModel.Id;
            this.Model["TaskName"] = reportViewModel.TaskName;
            this.Model["TaskLevel"] = reportViewModel.TaskLevel;
            this.Model["Status"] = reportViewModel.Status;
            this.Model["DueDate"] = reportViewModel.DueDate;
            this.Model["ReportedOn"] = reportViewModel.ReportedOn;
            this.Model["ReporterName"] = reportViewModel.ReporterName;
            this.Model["Participants"] = reportViewModel.Participants;
            this.Model["AffectedSectors"] = reportViewModel.AffectedSectors;
            this.Model["TaskDescription"] = reportViewModel.TaskDescription;

            return this.View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Report(TaskIdViewModel model)
        {
            this.reportService.ReportTask(model.Id, this.Identity.Username);

            return this.RedirectToHome();
        }
    }
}