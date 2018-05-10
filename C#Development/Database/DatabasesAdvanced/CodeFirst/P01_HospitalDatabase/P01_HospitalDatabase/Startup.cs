namespace P01_HospitalDatabase
{
    using Core;
    using Initializer;

    public class Startup
    {
        public static void Main()
        {
            //DatabaseInitializer.ResetDatabase();

            var engine = new Engine();
            engine.Run();
        }
    }
}
