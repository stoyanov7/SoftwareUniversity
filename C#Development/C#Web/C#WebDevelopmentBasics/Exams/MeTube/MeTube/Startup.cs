namespace MeTube
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
                42420,
                new ControllerRouter(),
                new ResourceRouter());

            var context = new MeTubeContext();
            MvcEngine.Run(server, context);
        }
    }
}
