namespace Banicharnica.Core
{
    using AutoMapper;
    using Models;
    using ModelsDto;

    public class BanicharnicaProffile : Profile
    {
        public BanicharnicaProffile()
        {
            this.CreateMap<Employee, EmployeeDto>()
                .ReverseMap();

            this.CreateMap<Employee, EmployeePersonalInfoDto>()
                .ReverseMap();

            this.CreateMap<Employee, ManagerDto>()
                .ForMember(dest => dest.Employees, from => from.MapFrom(x => x.ManagerEmployees))
                .ReverseMap();
        }
    }
}