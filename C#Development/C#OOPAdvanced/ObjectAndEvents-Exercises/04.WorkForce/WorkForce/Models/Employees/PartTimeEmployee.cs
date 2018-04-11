namespace WorkForce.Models.Employees
{
    public class PartTimeEmployee : Employee
    {
        private const int PartTimeEmployeeWorkHoursPerWeek = 20;

        public PartTimeEmployee(string name) 
            : base(name, PartTimeEmployeeWorkHoursPerWeek)
        {
        }
    }
}