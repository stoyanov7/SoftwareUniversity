namespace BusTicketsSystem.Services.Contracts
{
    public interface IBusCompanyService
    {
        TModel ById<TModel>(int id);

        TModel ByName<TModel>(string name);
    }
}