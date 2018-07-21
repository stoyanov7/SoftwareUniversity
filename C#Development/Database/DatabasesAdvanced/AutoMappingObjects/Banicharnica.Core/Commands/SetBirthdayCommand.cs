namespace Banicharnica.Core.Commands
{
    using System;
    using System.Globalization;
    using Contracts;

    public class SetBirthdayCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public SetBirthdayCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }


        public string Execute(string[] args)
        {
            var id = int.Parse(args[0]);
            var date = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            this.employeeController.SetBirthday(id, date);

            return $"Birthdate - {date} set successfully!";
        }
    }
}