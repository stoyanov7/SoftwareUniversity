namespace _06.CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var employees = new List<Employee>();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var employeeTokens = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = employeeTokens[0];
                var salary = decimal.Parse(employeeTokens[1]);
                var position = employeeTokens[2];
                var department = employeeTokens[3];

                var currentEmployee = new Employee(name, salary, position, department);

                if (employeeTokens.Length > 5)
                {
                    currentEmployee.Age = int.Parse(employeeTokens[5]);
                }

                if (employeeTokens.Length > 4)
                {
                    var ageOrEmail = employeeTokens[4];

                    if (ageOrEmail.Contains("@"))
                    {
                        currentEmployee.Email = ageOrEmail;
                    }
                    else
                    {
                        currentEmployee.Age = int.Parse(ageOrEmail);
                    }
                }

                employees.Add(currentEmployee);
            }

            var result = employees
                .GroupBy(e => e.Department)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(emp => emp.Salary),
                    Employees = e.OrderByDescending(emp => emp.Salary)
                })
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Department}");

            foreach (var employee in result.Employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}