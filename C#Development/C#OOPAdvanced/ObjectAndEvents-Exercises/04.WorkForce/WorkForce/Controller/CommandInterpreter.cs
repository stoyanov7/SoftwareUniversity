namespace WorkForce.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Events;
    using Models;
    using Models.Employees;

    public class CommandInterpreter
    {
        private readonly IJobsList jobs;
        private readonly IList<IEmployee> employees;

        public CommandInterpreter()
        {
            this.jobs = new JobsList();
            this.employees = new List<IEmployee>();
        }

        public void CreateJob(string[] input)
        {
            var currentJob = new Job(input[1], int.Parse(input[2]), this.employees.FirstOrDefault(e => e.Name.Equals(input[3])));
            this.jobs.Add(currentJob);
            currentJob.JobDone += this.jobs.OnJobDone;
        }

        public void CreateStandartEmployee(string[] input)
        {
            var standartEmployee = new StandartEmployee(input[1]);
            this.employees.Add(standartEmployee);
        }

        public void CreatePartTimeEmployee(string[] input)
        {
            var parttimeEmployee = new PartTimeEmployee(input[1]);
            this.employees.Add(parttimeEmployee);
        }

        public void Pass()
        {
            foreach (var job in this.jobs.ToArray())
            {
                job.Update();
            }
        }

        public void Status()
        {
            foreach (var job in this.jobs)
            {
                Console.WriteLine(job);
            }
        }
    }
}