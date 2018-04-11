namespace WorkForce.Models.Employees
{
    public interface IEmployee
    {
        string Name { get; }

        int WorkHoursPerWeek { get; }
    }
}