namespace FDMC
{
    using Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var server = new WebServer(
                7777,
                new ControllerRouter(),
                new ResourceRouter());

            var dbContext = new KittenContext();

            MvcEngine.Run(server, dbContext);
        }
    }
}
