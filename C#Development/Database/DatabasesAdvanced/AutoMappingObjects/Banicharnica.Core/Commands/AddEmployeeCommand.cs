namespace Banicharnica.Core.Commands
{
    using Contracts;
    using ModelsDto;

    public class AddEmployeeCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public AddEmployeeCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            var firstName = args[0];
            var lastName = args[1];
            var salary = decimal.Parse(args[2]);

            var employeeDto = new EmployeeDto
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.employeeController.AddEmployee(employeeDto);

            return $"Employee {firstName} {lastName} added successfully!";
        }
    }
}