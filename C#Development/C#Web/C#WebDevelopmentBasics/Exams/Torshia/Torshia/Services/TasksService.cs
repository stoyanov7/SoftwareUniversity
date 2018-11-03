namespace Torshia.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models.Tasks;
    using Models;
    using Models.Enums;
    using Contracts;

    public class TasksService : BaseService, ITasksService
    {
        public TasksService(TorshiaContext context)
            : base(context)
        {
        }

        public ICollection<TaskViewModel> AllNonReported()
        {
            var taskViewModels = new List<TaskViewModel>();

            var tasks = this.context
                .Tasks
                .Where(t => t.IsReported == false);

            foreach (var task in tasks)
            {
                var taskViewModel = new TaskViewModel
                {
                    TaskId = task.Id,
                    Title = task.Title,
                    Level = this.GetAffectedSectors(task.Id).Count
                };

                taskViewModels.Add(taskViewModel);
            }

            return taskViewModels;
        }

        public void CreateTask(
            string title,
            string description,
            string dueDate,
            string participants,
            ICollection<string> affectedSectors)
        {
            var task = new Task
            {
                Title = title,
                Description = description,
                DueDate = DateTime.ParseExact(dueDate, "yyyy-MM-dd", null),
                IsReported = false,
                Participants = participants
            };

            this.context.Tasks.Add(task);
            this.context.SaveChanges();

            this.FillAffectedSectors(affectedSectors, title);
        }

        public ICollection<Sector> GetAffectedSectors(int taskId)
        {
            var sectors = this.context
                .TasksSectors
                .Where(ts => ts.TaskId == taskId)
                .Select(ts => ts.Sector)
                .ToList();

            return sectors;
        }

        public TaskDetailsViewModel GetTaskById(int id)
        {
            var taskViewModel = new TaskDetailsViewModel();

            var task = this.context
                .Tasks
                .FirstOrDefault(t => t.Id == id);

            var sectors = this.GetAffectedSectors(id);

            taskViewModel.Title = task.Title;
            taskViewModel.Description = task.Description;
            taskViewModel.DueDate = task.DueDate.ToString("dd/MM/yyyy");
            taskViewModel.Participants = task.Participants;
            taskViewModel.AffectedSectors =
                sectors.Any() ? string.Join(", ", sectors.Select(a => a.ToString())) : "No affected sectors";
            taskViewModel.Level = sectors.Count;

            return taskViewModel;
        }

        private void FillAffectedSectors(IEnumerable<string> affectedSectors, string taskTitle)
        {
            var taskId = this.context
                .Tasks
                .FirstOrDefault(t => t.Title == taskTitle)
                .Id;

            foreach (var affectedSector in affectedSectors)
            {
                var taskSector = new TaskSector
                {
                    Sector = (Sector) Enum.Parse(typeof(Sector), affectedSector, true),
                    TaskId = taskId
                };

                this.context
                    .TasksSectors
                    .Add(taskSector);
            }

            this.context.SaveChanges();
        }
    }
}