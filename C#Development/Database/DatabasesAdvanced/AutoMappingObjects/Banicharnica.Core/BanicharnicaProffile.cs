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
        }
    }
}