namespace BarrackWars
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;

    public class Startup
    {
        public static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
