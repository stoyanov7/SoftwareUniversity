namespace DetailPrinter
{
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var employee = new Employee("Name");
            var manager = new Employee("Manager name");
            var employees = new List<Employee> { employee, manager };
            var printer = new DetailsPrinter(employees);

            printer.PrintDetails();
        }
    }
}
