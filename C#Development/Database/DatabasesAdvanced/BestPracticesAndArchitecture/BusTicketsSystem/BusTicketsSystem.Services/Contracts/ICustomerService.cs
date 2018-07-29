namespace BusTicketsSystem.Services.Contracts
{
    public interface ICustomerService
    {
        TModel ById<TModel>(int id);
    }
}