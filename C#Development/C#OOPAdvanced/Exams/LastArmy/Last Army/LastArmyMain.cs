public class LastArmyMain
{
    public static void Main()
    {
        var engine = new Engine(new ConsoleReader(), new ConsoleWriter());
        engine.Run();
    }
}
