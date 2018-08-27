namespace ByTheCake
{
    using Controllers;
    using WebServer.Contracts;
    using WebServer.Routing.Contracts;

    public class ByTheCakeApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get("/", req => new HomeController().Index());

            appRouteConfig.Get("Cake/Add", req => new CakeController().Add());
        }
    }
}