namespace DetailPrinter
{
    using System;
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        private readonly IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees) => this.employees = employees;

        public void PrintDetails()
        {
            foreach (var employee in this.employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
