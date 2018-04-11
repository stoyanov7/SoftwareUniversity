namespace WorkForce.Models.Employees
{
    public class StandartEmployee : Employee
    {
        private const int StandartEmployeeWorkHoursPerWeek = 40;

        public StandartEmployee(string name)
            : base(name, StandartEmployeeWorkHoursPerWeek)
        {
        }
    }
}