namespace Banicharnica.Core.Commands
{
    using Contracts;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeeInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            var id = int.Parse(args[0]);
            var employeeDto = this.employeeController.GetEmployeeInfo(id);

            return $"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} -  ${employeeDto.Salary:f2}";
        }
    }
}