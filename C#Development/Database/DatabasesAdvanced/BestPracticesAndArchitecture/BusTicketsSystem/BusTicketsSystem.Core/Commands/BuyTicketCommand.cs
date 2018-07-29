namespace BusTicketsSystem.Core.Commands
{
    using Contracts;
    using Services.Contracts;

    public class BuyTicketCommand : ICommand
    {
        private readonly ITicketService ticketService;

        public BuyTicketCommand(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public string Execute(string[] args)
        {
            var customerId = int.Parse(args[0]);
            var tripId = int.Parse(args[1]);
            var price = decimal.Parse(args[2]);
            var seat = args[3];

            var ticket = this.ticketService.Create(customerId, tripId, price, seat);

            return $"Customer {ticket.Customer.FirstName} {ticket.Customer.LastName} bought ticket for trip {ticket.TripId} for {ticket.Price} on seat {ticket.Seat}";
        }
    }
}