namespace ByTheCake
{
    using WebServer;
    using WebServer.Contracts;
    using WebServer.Routing;

    public class Startup : IRunnable
    {
        public static void Main(string[] args)
        {
            new Startup().Run();
        }

        public void Run()
        {
            var mainApplication = new ByTheCakeApp();

            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);

            var webServer = new WebServer(7777, appRouteConfig);

            webServer.Run();
        }
    }
}
