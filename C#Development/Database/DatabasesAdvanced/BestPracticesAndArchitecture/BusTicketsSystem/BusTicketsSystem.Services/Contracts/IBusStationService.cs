namespace BusTicketsSystem.Services.Contracts
{
    public interface IBusStationService
    {
        TModel ById<TModel>(int id);
    }
}