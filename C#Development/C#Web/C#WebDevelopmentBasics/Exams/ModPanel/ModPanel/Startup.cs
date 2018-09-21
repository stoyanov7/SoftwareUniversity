namespace ModPanel
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

            var context = new ModPanelContext();

            MvcEngine.Run(server, context);
        }
    }
}
