namespace Torshia.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models.Reports;
    using Data;
    using Models;
    using Models.Enums;
    using Contracts;

    public class ReportService : BaseService, IReportService
    {
        private readonly ITasksService taskService;

        public ReportService(TorshiaContext context, ITasksService tasksService)
            : base(context)
        {
            this.taskService = tasksService;
        }

        public ReportDetailsViewModel GetReportById(int id)
        {
            var reportViewModel = new ReportDetailsViewModel();

            var report = this.context
                .Reports
                .FirstOrDefault(r => r.Id == id);

            var task = this.taskService
                .GetTaskById(report.TaskId);

            reportViewModel.Id = report.Id;
            reportViewModel.TaskName = task.Title;
            reportViewModel.TaskLevel = task.Level;
            reportViewModel.Status = report.Status.ToString();
            reportViewModel.DueDate = task.DueDate;
            reportViewModel.ReportedOn = report.ReportedOn.ToString("dd/MM/yyyy");

            reportViewModel.ReporterName = this.context
                .Users
                .FirstOrDefault(u => u.Id == report.ReporterId)
                ?.Username;

            reportViewModel.Participants = task.Participants;
            reportViewModel.AffectedSectors = task.AffectedSectors;
            reportViewModel.TaskDescription = task.Description;

            return reportViewModel;
        }

        public ICollection<ReportViewModel> GetReports()
        {
            var reportViewModels = new List<ReportViewModel>();
            var reports = this.context.Reports.ToArray();

            for (var i = 0; i < reports.Length; i++)
            {
                var reportViewModel = new ReportViewModel
                {
                    Id = reports[i].Id,
                    Index = i + 1,
                    Status = reports[i].Status.ToString(),
                    TaskId = reports[i].TaskId,
                    TaskName = this.taskService.GetTaskById(reports[i].TaskId).Title,
                    TaskLevel = this.taskService.GetAffectedSectors(reports[i].TaskId).Count
                };

                reportViewModels.Add(reportViewModel);
            }

            return reportViewModels;
        }

        public void ReportTask(int taskId, string reporterName)
        {
            var reporterId = this.context
                .Users
                .FirstOrDefault(u => u.Username == reporterName)
                .Id;

            var status = this.GenerateStatus();
            var report = new Report
            {
                ReportedOn = DateTime.UtcNow,
                ReporterId = reporterId,
                TaskId = taskId,
                Status = status
            };

            this.context.Reports.Add(report);

            this.context
                .Tasks
                .FirstOrDefault(t => t.Id == taskId)
                .IsReported = true;

            this.context.SaveChanges();
        }

        private Status GenerateStatus()
        {
            var rnd = new Random();
            var stausCode = rnd.Next(1, 5);
            var status = stausCode < 4 ? Status.Completed : Status.Archived;

            return status;
        }
    }
}