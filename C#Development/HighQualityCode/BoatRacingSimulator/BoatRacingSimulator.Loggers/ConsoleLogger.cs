namespace BoatRacingSimulator.Loggers
{
    using System;
    using Contracts;

    public class ConsoleLogger : ILogger
    {
        public void WriteLine(string message) => Console.WriteLine(message);

        public string ReadLine() => Console.ReadLine();
    }
}