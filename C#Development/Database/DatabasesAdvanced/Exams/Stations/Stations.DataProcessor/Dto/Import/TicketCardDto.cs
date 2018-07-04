namespace Stations.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Card")]
    public class TicketCardDto
    {
        [Required]
        public string Name { get; set; }
    }
}