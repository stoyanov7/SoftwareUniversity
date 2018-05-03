namespace P02_DatabaseFirst.Data.Models
{
    using System.Collections.Generic;

    public class Department
    {
        public Department() => this.Employees = new HashSet<Employee>();

        public int DepartmentId { get; private set; }

        public string Name { get; private set; }

        public int ManagerId { get; private set; }

        public Employee Manager { get; private set; }

        public ICollection<Employee> Employees { get; private set; }
    }
}
