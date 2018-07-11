namespace PetClinic.App
{
    using System;
    using System.Globalization;
    using AutoMapper;
    using DataProcessor.Dto.Import;
    using Models;

    public class PetClinicProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public PetClinicProfile()
        {
            this.CreateMap<AnimalAidDto, AnimalAid>();

            this.CreateMap<AnimalDto, Animal>()
                .ForMember(a => a.PassportSerialNumber,
                    id => id.MapFrom(dto => dto.Passport.SerialNumber));

            this.CreateMap<PassportDto, Passport>()
                .ForMember(p => p.RegistrationDate,
                    rd => rd.MapFrom(
                        dto => DateTime.ParseExact(dto.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)));

            this.CreateMap<VetDto, Vet>();
        }
    }
}
