namespace P02_DatabaseFirst.Core
{
    using System;

    public class Engine
    {
        private bool isRunning;
        private readonly CommandInterpreter interpreter;

        public Engine()
        {
            this.isRunning = true;
            this.interpreter = new CommandInterpreter();
        }

        public void Run()
        {
            while (this.isRunning)
            {
                var line = Console.ReadLine();

                switch (line)
                {
                    case "EmployeesFullInformation":
                        this.interpreter.EmployeesFullInformation();
                        break;
                    case "EmployeesWithSalaryOver50000":
                        this.interpreter.EmployeesWithSalaryOver50000();
                        break;
                    case "EmployeesFromResearchAndDevelopment":
                        this.interpreter.EmployeesFromResearchAndDevelopment();
                        break;
                    case "AddingNewAddress":
                        this.interpreter.AddingNewAddress();
                        break;
                    case "EmployeesAndProjects":
                        this.interpreter.EmployeesAndProjects();
                        break;
                    case "AddressesByTown":
                        this.interpreter.AddressesByTown();
                        break;
                    case "Employee147":
                        this.interpreter.Employee147();
                        break;
                    case "DepartmentsWithMoreThan5Employees":
                        this.interpreter.DepartmentsWithMoreThan5Employees();
                        break;
                    case "FindLatest10Projects":
                        this.interpreter.FindLatest10Projects();
                        break;
                    case "IncreaseSalaries":
                        this.interpreter.IncreaseSalaries();
                        break;
                    case "FindEmployeesFirstNameWithSa":
                        this.interpreter.FindEmployeesFirstNameWithSa();
                        break;
                    case "DeleteProject":
                        this.interpreter.DeleteProject();
                        break;
                    case "RemoveTowns":
                        this.interpreter.RemoveTowns();
                        break;
                    case "Exit":
                        this.isRunning = false;
                        break;
                }
            }
        }
    }
}