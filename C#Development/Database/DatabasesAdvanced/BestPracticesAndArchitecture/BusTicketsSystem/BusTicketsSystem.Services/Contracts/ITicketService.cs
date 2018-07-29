namespace BusTicketsSystem.Services.Contracts
{
    using Models;

    public interface ITicketService
    {
        Ticket Create(int customerId, int tripId, decimal price, string seat);
    }
}