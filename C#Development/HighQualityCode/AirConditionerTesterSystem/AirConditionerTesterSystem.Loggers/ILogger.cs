namespace AirConditionerTesterSystem.Loggers
{
    public interface ILogger
    {
        string ReadLine();

        void WriteLine(string message);
    }
}