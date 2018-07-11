namespace PetClinic.DataProcessor.Dto.Import
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ProcedureDto
    {
        [Required]
        public string Vet { get; set; }

        [Required]
        public string Animal { get; set; }

        [Required]
        [XmlAttribute("DateTime")]
        public DateTime DateTime { get; set; }

        [XmlElement("AnimalAids")]
        public AnimalAidsProcedureDto[] AnimalAidsProcedureDto { get; set; } = new AnimalAidsProcedureDto[0];
    }
}