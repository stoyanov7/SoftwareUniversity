namespace P02_DatabaseFirst
{
    using Core;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}