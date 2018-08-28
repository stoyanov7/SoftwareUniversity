namespace WebServer.Contracts
{
    using Routing.Contracts;

    public interface IApplication
    {
        void Configure(IAppRouteConfig appRouteConfig);
    }
}
