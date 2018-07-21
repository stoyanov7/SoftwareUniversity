namespace Banicharnica.Core.Commands
{
    using Contracts;

    public class SetAddressCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public SetAddressCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            var id = int.Parse(args[0]);
            var address = args[1];

            this.employeeController.SetAddress(id, address);

            return $"Address - {address} set successfully!";
        }
    }
}