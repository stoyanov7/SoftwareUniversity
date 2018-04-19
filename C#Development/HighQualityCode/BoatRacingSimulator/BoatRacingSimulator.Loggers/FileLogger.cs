namespace BoatRacingSimulator.Loggers
{
    using System.IO;
    using Contracts;

    public class FileLogger : ILogger
    {
        public FileLogger(string input, string output)
        {
            this.Reader = new StreamReader(File.Open(input, FileMode.Open));
            this.Writer = new StreamWriter(File.Create(output));
        }

        public StreamReader Reader { get; private set; }

        public StreamWriter Writer { get; private set; }

        public void WriteLine(string message) => this.Writer.WriteLine(message);

        public string ReadLine() => this.Reader.ReadLine();

        public void Close()
        {
            this.Writer.Close();
            this.Reader.Close();
        }
    }
}