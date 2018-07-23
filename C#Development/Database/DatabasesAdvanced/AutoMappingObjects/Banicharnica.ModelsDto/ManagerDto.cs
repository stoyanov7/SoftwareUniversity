namespace Banicharnica.ModelsDto
{
    using System.Collections.Generic;

    public class ManagerDto
    {
        public ManagerDto()
        {
            this.Employees = new List<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmployeesCount => this.Employees.Count.ToString();

        public ICollection<EmployeeDto> Employees { get; set; }
    }
}