namespace Logger.Models
{
    using System;
    using System.IO;
    using Contracts;

    public class LogFile : ILogFile
    {
        private const string DefaultPath = "./data/";

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            this.InitializeFile();
            File.AppendAllText(this.Path, "");
            this.Size = 0;
        }

        public string Path { get; }

        public int Size { get; private set; }

        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            var addedSize = 0;

            for (var i = 0; i < errorLog.Length; i++)
            {
                addedSize += errorLog[i];
            }

            this.Size += addedSize;
        }

        private void InitializeFile()
        {
            Directory.CreateDirectory(DefaultPath);
            File.AppendAllText(this.Path, "");
        }
    }
}