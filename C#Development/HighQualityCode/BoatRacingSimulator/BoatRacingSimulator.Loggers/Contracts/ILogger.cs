namespace BoatRacingSimulator.Loggers.Contracts
{
    public interface ILogger
    {
        void WriteLine(string message);

        string ReadLine();
    }
}
