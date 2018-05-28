namespace AirConditionerTesterSystem.Loggers
{
    using System;

    public class ConsoleLogger : ILogger
    {
        public string ReadLine() => Console.ReadLine();

        public void WriteLine(string message) => Console.WriteLine(message);
    }
}