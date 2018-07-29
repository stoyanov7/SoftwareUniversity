namespace BusTicketsSystem.Services.Contracts
{
    using Models;

    public interface IReviewService
    {
        Review Create(int customerId, float grade, string busCompanyName, string content);
    }
}