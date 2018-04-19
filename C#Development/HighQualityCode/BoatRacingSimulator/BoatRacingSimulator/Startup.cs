namespace BoatRacingSimulator
{
    using Controllers;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
