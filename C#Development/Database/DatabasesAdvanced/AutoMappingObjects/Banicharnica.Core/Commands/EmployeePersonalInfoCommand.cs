namespace Banicharnica.Core.Commands
{
    using System.Text;
    using Contracts;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeePersonalInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            var id = int.Parse(args[0]);
            var employeeDto = this.employeeController.GetEmployeePersonalInfo(id);

            var sb = new StringBuilder();
            sb.AppendLine($"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:F2}")
                .AppendLine($"Birthday: {employeeDto.Birtdate.Value:dd-MM-yyyy}")
                .AppendLine($"Address: {employeeDto.Address}");

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}