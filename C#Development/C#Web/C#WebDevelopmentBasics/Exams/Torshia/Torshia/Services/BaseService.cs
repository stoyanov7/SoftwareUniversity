namespace Torshia.Services
{
    using Data;

    public abstract class BaseService
    {
        protected readonly TorshiaContext context;

        protected BaseService(TorshiaContext context)
        {
            this.context = context;
        }
    }
}