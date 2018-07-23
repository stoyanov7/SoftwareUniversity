namespace Banicharnica.Core.Commands
{
    using System.Text;
    using Contracts;

    public class ManagerInfoCommand : ICommand
    {
        private readonly IManagerController managerController;

        public ManagerInfoCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Execute(string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var managerDto = this.managerController.GetManagerInfo(employeeId);

            var sb = new StringBuilder();
            var fullName = $"{managerDto.FirstName} {managerDto.LastName}";
            var count = managerDto.EmployeesCount;

            sb.AppendLine($"{fullName} | {count}");

            foreach (var employee in managerDto.Employees)
            {
                sb.AppendLine($"    - {employee.FirstName} {employee.LastName} - ${employee.Salary}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}