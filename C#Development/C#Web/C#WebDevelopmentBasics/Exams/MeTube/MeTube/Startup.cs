namespace MeTube
{
    using Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Startup
    {
        public static void Main()
        {
            var server = new WebServer(
                7777,
                new ControllerRouter(),
                new ResourceRouter());

            var dbContext = new MeTubeContext();

            MvcEngine.Run(server, dbContext);
        }
    }
}
