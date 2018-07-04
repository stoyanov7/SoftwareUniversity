namespace Stations.DataProcessor.Dto.Export
{
    public class CardDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public TicketDto[] Tickets { get; set; }
    }
}