namespace BusTicketsSystem.Services
{
    using Contracts;
    using Data;
    using Models;

    public class TicketService : ITicketService
    {
        private readonly BusTicketsSystemContext context;
        private readonly ICustomerService customerService;
        private readonly ITripService tripService;

        public TicketService(BusTicketsSystemContext context, ICustomerService customerService, ITripService tripService)
        {
            this.context = context;
            this.customerService = customerService;
            this.tripService = tripService;
        }

        public Ticket Create(int customerId, int tripId, decimal price, string seat)
        {
            var customer = this.customerService.ById<Customer>(customerId);
            var trip = this.tripService.ById<Trip>(tripId);

            var ticket = new Ticket
            {
                Customer = customer,
                CustomerId = customerId,
                Trip = trip,
                TripId = tripId,
                Price = price,
                Seat = seat
            };

            this.context.Tickets.Add(ticket);
            this.context.SaveChanges();

            return ticket;
        }
    }
}