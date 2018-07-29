namespace BusTicketsSystem.Models
{
    public class Ticket
    {
        public decimal Price { get; set; }

        public string Seat { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}