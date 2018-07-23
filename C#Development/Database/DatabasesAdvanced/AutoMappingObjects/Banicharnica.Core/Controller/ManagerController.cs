namespace Banicharnica.Core.Controller
{
    using System;
    using AutoMapper;
    using Contracts;
    using Data;
    using ModelsDto;

    public class ManagerController : IManagerController
    {
        private readonly BanicharnicaDbContext context;
        private readonly IMapper mapper;

        public ManagerController(BanicharnicaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.Find(employeeId);
            var manager = this.context.Employees.Find(managerId);

            if (employee == null || manager == null)
            {
                throw new ArgumentException("Invalid employee or manager id!");
            }

            employee.Manager = manager;
            this.context.SaveChanges();
        }

        public ManagerDto GetManagerInfo(int employeeId)
        {
            var employee = this.context
                .Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid id");
            }

            var managerDto = this.mapper.Map<ManagerDto>(employee);

            return managerDto;
        }
    }
}