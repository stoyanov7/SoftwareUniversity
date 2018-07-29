namespace BusTicketsSystem.Services.Contracts
{
    public interface ITripService
    {
        TModel ById<TModel>(int id);
    }
}