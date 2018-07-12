namespace FastFood.DataProcessor.Dto.Import
{
    using System.Xml.Serialization;

    [XmlType("Items")]
    public class ItemOrderDto
    {
        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}