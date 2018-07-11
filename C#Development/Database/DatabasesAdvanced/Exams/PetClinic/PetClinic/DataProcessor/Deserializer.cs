namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Dto.Import;
    using Models;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public static class Deserializer
    {
        private const string ErrorMessage = "Error: Invalid data.";
        private const string SuccessfullMessage = "Record {0} successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var deserializeAnimalAids = JsonConvert.DeserializeObject<AnimalAidDto[]>(jsonString);
            var validAnimalAids = new List<AnimalAid>();

            foreach (var animalAidDto in deserializeAnimalAids)
            {
                // If any validation errors occur
                // (such as if an animal aid name is too long/ short),
                // do not import the entity
                var isValid = IsValid(animalAidDto);

                // If an animal aid already exists, do not import it
                var animalAlreadyExist = validAnimalAids.Any(a => a.Name == animalAidDto.Name);

                if (!isValid || animalAlreadyExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var animalAid = Mapper.Map<AnimalAid>(animalAidDto);
                validAnimalAids.Add(animalAid);
                sb.AppendLine(string.Format(SuccessfullMessage, animalAid.Name));
            }

            context.AnimalAids.AddRange(validAnimalAids);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var deserializedAnimals = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);
            var validAnimals = new List<Animal>();

            foreach (var animalDto in deserializedAnimals)
            {
                // If any validation errors occur do not import the entity
                var animalIsValid = IsValid(animalDto);
                var passportIsValid = IsValid(animalDto.Passport);

                // If a passport with the same serial number exists, do not import the entity
                var animalAlreadyExist = validAnimals
                    .Any(p => p.Passport.SerialNumber == animalDto.Passport.SerialNumber);

                if (!animalIsValid || !passportIsValid || animalAlreadyExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var animal = Mapper.Map<Animal>(animalDto);
                validAnimals.Add(animal);
                sb.AppendLine(
                    $"Record {animal.Name} Passport №: {animal.Passport.SerialNumber} successfully imported.");
            }

            context.Animals.AddRange(validAnimals);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(VetDto[]), new XmlRootAttribute("Vets"));
            var deserializeVets = (VetDto[])serializer
                .Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            var validVets = new List<Vet>();

            foreach (var vetDto in deserializeVets)
            {
                var vetIsValid = IsValid(vetDto);
                var vetAlreadyExist = validVets.Any(v => v.PhoneNumber == vetDto.PhoneNumber);

                if (!vetIsValid || vetAlreadyExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var vet = Mapper.Map<Vet>(vetDto);
                validVets.Add(vet);
                sb.AppendLine(string.Format(SuccessfullMessage, vet.Name));
            }

            context.Vets.AddRange(validVets);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var xDoc = XDocument.Parse(xmlString);
            var elements = xDoc.Root.Elements();

            var sb = new StringBuilder();
            var validEntries = new List<Procedure>();

            foreach (var el in elements)
            {
                var vetName = el.Element("Vet")?.Value;
                var passportId = el.Element("Animal")?.Value;
                var dateTimeString = el.Element("DateTime")?.Value;

                var vetId = context
                    .Vets
                    .SingleOrDefault(v => v.Name == vetName)
                    ?.Id;

                var passportExists = context
                    .Passports
                    .Any(p => p.SerialNumber == passportId);

                var dateIsValid = DateTime
                    .TryParseExact(dateTimeString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime);

                var animalAidElements = el.Element("AnimalAids")?.Elements();

                if (vetId == null || !passportExists || animalAidElements == null || !dateIsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var animalAidIds = new List<int>();
                var allAidsExist = true;

                foreach (var aid in animalAidElements)
                {
                    var aidName = aid
                        .Element("Name")
                        ?.Value;

                    var aidId = context
                        .AnimalAids
                        .SingleOrDefault(a => a.Name == aidName)
                        ?.Id;

                    if (aidId == null || animalAidIds.Any(id => id == aidId))
                    {
                        allAidsExist = false;
                        break;
                    }

                    animalAidIds.Add(aidId.Value);
                }

                if (!allAidsExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var procedure = new Procedure
                {
                    VetId = vetId.Value,
                    AnimalId = context
                        .Animals
                        .Single(a => a.PassportSerialNumber == passportId).Id,
                    DateTime = dateTime,
                };

                foreach (var id in animalAidIds)
                {
                    var mapping = new ProcedureAnimalAid
                    {
                        Procedure = procedure,
                        AnimalAidId = id
                    };

                    procedure.ProcedureAnimalAids.Add(mapping);
                }

                if (!IsValid(procedure))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validEntries.Add(procedure);
                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(validEntries);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

            return isValid;
        }
    }
}
