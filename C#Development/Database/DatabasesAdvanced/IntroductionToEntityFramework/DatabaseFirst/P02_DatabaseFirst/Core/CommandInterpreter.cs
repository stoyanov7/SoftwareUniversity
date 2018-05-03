namespace P02_DatabaseFirst.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CommandInterpreter
    {
        private const string DepartmentNameConst = "Research and Development";
        private const string DateFormatConst = "M/d/yyyy h:mm:ss tt";


        private readonly StringBuilder sb;
        private readonly SoftUniContext context;

        public CommandInterpreter()
        {
            this.sb = new StringBuilder();
            this.context = new SoftUniContext();
        }

        public void EmployeesFullInformation()
        {
            using (this.context)
            {
                var employeesFullInformation = this.context
                    .Employees
                    .OrderBy(e => e.EmployeeId)
                    .Select(e => new
                    {
                        FullName = $"{e.FirstName} {e.LastName} {e.MiddleName}",
                        e.JobTitle,
                        e.Salary
                    });

                foreach (var e in employeesFullInformation)
                {
                    this.sb.AppendLine($"{e.FullName} {e.JobTitle} {e.Salary:F2}");
                }

                Console.WriteLine(this.sb.ToString().TrimEnd());
            }
        }

        public void EmployeesWithSalaryOver50000()
        {
            using (this.context)
            {
                var employeesWithSalary = this.context
                    .Employees
                    .Where(e => e.Salary > 50000)
                    .Select(e => e.FirstName)
                    .OrderBy(e => e);

                foreach (var e in employeesWithSalary)
                {
                    this.sb.AppendLine(e);
                }

                Console.WriteLine(this.sb.ToString().TrimEnd());
            }
        }

        public void EmployeesFromResearchAndDevelopment()
        {
            using (this.context)
            {
                var selectedEmployees = this.context
                    .Employees
                    .Where(e => e.Department.Name == DepartmentNameConst)
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .Select(e => new
                    {
                        FullName = $"{e.FirstName} {e.LastName}",
                        Department = DepartmentNameConst,
                        e.Salary
                    });

                foreach (var e in selectedEmployees)
                {
                    this.sb.AppendLine($"{e.FullName} from {e.Department} - ${e.Salary:F2}");
                }

                Console.WriteLine(this.sb.ToString().TrimEnd());
            }
        }

        public void AddingNewAddress()
        {
            using (this.context)
            {
                var address = new Address
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                this.context
                    .Addresses
                    .Add(address);

                var nakov = this.context
                    .Employees
                    .FirstOrDefault(e => e.LastName == "Nakov");

                if (nakov != null)
                {
                    nakov.Address = address;
                }

                this.context.SaveChanges();

                var result = this.context
                    .Employees
                    .OrderByDescending(e => e.AddressId)
                    .Take(10)
                    .Select(e => e.Address.AddressText);

                foreach (var a in result)
                {
                    this.sb.AppendLine(a);
                }

                Console.WriteLine(this.sb.ToString().TrimEnd());
            }
        }

        public void EmployeesAndProjects()
        {
            using (this.context)
            {
                var result = this.context
                    .Employees
                    .Where
                    (
                        e =>
                            e.EmployeesProjects.Any(ep =>
                                ep.Project.StartDate.Year >= 2001 &&
                                ep.Project.StartDate.Year <= 2003)
                    )
                    .Take(30)
                    .Select(e => new
                    {
                        EmployeeFullName = $"{e.FirstName} {e.LastName}",
                        ManagerFullName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                        Projects = e.EmployeesProjects
                            .Select(ep => new
                            {
                                ep.Project.Name,
                                ep.Project.StartDate,
                                ep.Project.EndDate
                            })
                    });

                foreach (var e in result)
                {
                    this.sb.AppendLine($"{e.EmployeeFullName} - Manager: {e.ManagerFullName}");

                    foreach (var p in e.Projects)
                    {
                        var startDate = p.StartDate
                            .ToString(DateFormatConst, CultureInfo.InvariantCulture);

                        var endDate = p.EndDate?
                            .ToString(DateFormatConst, CultureInfo.InvariantCulture) ?? "not finished";

                        this.sb.AppendLine($"--{p.Name} - {startDate} - {endDate}");
                    }
                }

                Console.WriteLine(this.sb.ToString().TrimEnd());
            }
        }

        public void AddressesByTown()
        {
            using (this.context)
            {
                var result = this.context
                    .Addresses
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.Town.Name)
                    .Take(10)
                    .Select(a => $"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees");

                foreach (var r in result)
                {
                    this.sb.AppendLine(r);
                }

                Console.WriteLine(this.sb.ToString().TrimEnd());
            }
        }

        public void Employee147()
        {
            using (this.context)
            {
                var result = this.context
                    .Employees
                    .Select(e => new
                    {
                        e.EmployeeId,
                        FullName = $"{e.FirstName} {e.LastName}",
                        e.JobTitle,
                        Projects = e.EmployeesProjects
                            .Select(ep => ep.Project.Name)
                            .OrderBy(ep => ep)
                            .ToList()
                    })
                    .FirstOrDefault(e => e.EmployeeId == 147); 

                if (result != null)
                {
                    this.sb.AppendLine($"{result.FullName} - {result.JobTitle}");
                    this.sb.AppendLine(string.Join(Environment.NewLine, result.Projects));

                }

                Console.WriteLine(this.sb.ToString().TrimEnd());
            }
        }

        public void DepartmentsWithMoreThan5Employees()
        {
            using (this.context)
            {
                var departmentSeparator = $"{Environment.NewLine}{new string('-', 10)}{Environment.NewLine}";

                Console.WriteLine(string.Join(departmentSeparator, context.Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .Select(d => $"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}{Environment.NewLine}" + $@"{string.Join(Environment.NewLine, d.Employees
                                     .OrderBy(e => e.FirstName)
                                     .ThenBy(e => e.LastName)
                                     .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle}"))}")));

                Console.WriteLine(new string('-', 10));
            }
        }

        public void FindLatest10Projects()
        {
            using (this.context)
            {
                var result = this.context
                    .Projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(10)
                    .OrderBy(p => p.Name)
                    .Select(p => new
                    {
                        p.Name,
                        p.Description,
                        p.StartDate
                    });

                foreach (var r in result)
                {
                    this.sb.AppendLine(r.Name)
                        .AppendLine(r.Description)
                        .AppendLine(r.StartDate.ToString(DateFormatConst, CultureInfo.InvariantCulture));
                }

                Console.WriteLine(this.sb.ToString().TrimEnd());
            }
        }

        public void IncreaseSalaries()
        {
            var departmentsName = new[]
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            using (this.context)
            {
                var result = this.context
                    .Employees
                    .Include(x => x.Department)
                    .Where(x => departmentsName.Contains(x.Department.Name))
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList();

                foreach (var r in result)
                {
                    r.Salary += r.Salary * 0.12m;
                }

                this.context.SaveChanges();

                foreach (var e in result)
                {
                    this.sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
                }

                Console.WriteLine(this.sb.ToString().TrimEnd());
            }
        }

        public void FindEmployeesFirstNameWithSa()
        {
            using (this.context)
            {
                var result = this.context
                    .Employees
                    .Where(e => e.FirstName.StartsWith("Sa"))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                        FullName = $"{e.FirstName} {e.LastName}",
                        e.Salary,
                        e.JobTitle
                    });

                foreach (var r in result)
                {
                    this.sb.AppendLine($"{r.FullName} - {r.JobTitle} - (${r.Salary:F2})");
                }

                Console.WriteLine(this.sb.ToString().TrimEnd());
            }
        }

        public void DeleteProject()
        {
            using (this.context)
            {
                var project = this.context
                    .Projects
                    .Find(2);

                if (project != null)
                {
                    this.context
                        .EmployeesProjects
                        .RemoveRange(this.context.EmployeesProjects.Where(ep => ep.Project == project));

                    this.context.Projects.Remove(project);
                    this.context.SaveChanges();
                }

                var result =  this.context.Projects
                    .OrderBy(p => p.ProjectId)
                    .Take(10)
                    .Select(p => p.Name);

                foreach (var r in result)
                {
                    this.sb.AppendLine(r);
                }

                Console.WriteLine(this.sb.ToString().TrimEnd());
            }
        }

        public void RemoveTowns()
        {
            var towns = new[] { "Sofia", "Seattle" };

            using (this.context)
            {
                foreach (var name in towns)
                {
                    var town = this.context
                        .Towns
                        .FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                    if (town == null)
                    {
                        Console.WriteLine($"There is not town with name: {name}");
                        continue;
                    }

                    this.context
                        .Employees
                        .Where(e => e.Address.Town.TownId == town.TownId)
                        .ToList()
                        .ForEach(e => e.Address = null);

                    var addresses = this.context
                        .Addresses
                        .Where(a => a.TownId == town.TownId)
                        .ToArray();

                    var addressesCount = addresses.Length;

                    this.context
                        .Addresses
                        .RemoveRange(addresses);

                    this.context
                        .Towns
                        .Remove(town);

                    this.context.SaveChanges();

                    var addressPluralisation = addressesCount == 1
                        ? "address"
                        : "addresses";

                    Console.WriteLine($"{addressesCount} {addressPluralisation} in {name} was deleted");
                }
            }
        }
    }
}