namespace WorkForce.Models
{
    using System;
    using Employees;
    using Events;

    public class Job : IJob
    {
        private readonly IEmployee employee;
        private int hoursRequired;

        public Job(string name, int hoursRequired, IEmployee employee)
        {
            this.Name = name;
            this.hoursRequired = hoursRequired;
            this.employee = employee;
        }

        public event EventHandler<JobEventArgs> JobDone;

        public string Name { get; }

        public void Update()
        {
            this.hoursRequired -= this.employee.WorkHoursPerWeek;

            if (this.hoursRequired <= 0)
            {
                this.OnJobDone();
            }
        }

        public void OnJobDone()
        {
            Console.WriteLine($"Job {this.Name} done!");
            this.JobDone?.Invoke(this, new JobEventArgs(this));
        }

        public override string ToString() => $"Job: {this.Name} Hours Remaining: {this.hoursRequired}";
    }
}