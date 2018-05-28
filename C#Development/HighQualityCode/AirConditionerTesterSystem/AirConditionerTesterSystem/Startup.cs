namespace AirConditionerTesterSystem
{
    using Core;
    using Core.Contracts;
    using Loggers;
    using Repositories;

    public class Startup
    {
        public static void Main(string[] args)
        {
            IAirConditionerTesterSystemData data = new AirConditionerTesterSystemData();
            IController controller = new Controller(data);
            IDispatcher dispatcher = new Dispatcher(controller);
            ILogger logger = new ConsoleLogger();
            IEngine engine = new Engine(dispatcher, logger);
            engine.Run();
        }
    }
}
