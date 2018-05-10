namespace P03_SalesDatabase
{
    using Initializer;

    public class Startup
    {
        public static void Main(string[] args)
        {
            DatabaseInitializer.ResetDatabase();
        }
    }
}
