namespace P02_DatabaseFirst.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Project 
    {
        public Project() => this.EmployeesProjects = new HashSet<EmployeeProject>();

        public int ProjectId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public ICollection<EmployeeProject> EmployeesProjects { get; private set; }
    }
}
