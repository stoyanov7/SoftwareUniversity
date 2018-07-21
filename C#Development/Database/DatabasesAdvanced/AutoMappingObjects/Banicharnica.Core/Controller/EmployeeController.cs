namespace Banicharnica.Core.Controller
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Models;
    using ModelsDto;

    public class EmployeeController : IEmployeeController
    {
        private const string InvalidId = "Invalid employee ID!";

        private readonly BanicharnicaDbContext context;
        private readonly IMapper mapper;

        public EmployeeController(BanicharnicaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = this.mapper.Map<Employee>(employeeDto);

            this.context.Employees.Add(employee);
            this.context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(InvalidId);
            }

            employee.Birtdate = date;
            this.context.SaveChanges();
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = this.context
                .Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(InvalidId);
            }

            employee.Address = address;
            this.context.SaveChanges();
        }

        public EmployeeDto GetEmployeeInfo(int employeeId)
        {
            var employee = this.context
                .Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(InvalidId);
            }

            var employeeDto = this.mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId)
        {
            var employee = this.context
                .Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(InvalidId);
            }

            var employeeDto = this.mapper.Map<EmployeePersonalInfoDto>(employee);
            
            return employeeDto;
        }
    }
}