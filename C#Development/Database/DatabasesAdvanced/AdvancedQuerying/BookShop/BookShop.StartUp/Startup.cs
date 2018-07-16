namespace BookShop
{
    using Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //DbInitializer.ResetDatabase();

            var engine = new Engine();
            engine.Run();
        }
    }
}
