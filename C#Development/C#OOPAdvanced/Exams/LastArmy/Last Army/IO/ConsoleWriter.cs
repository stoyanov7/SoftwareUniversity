using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private readonly StringBuilder sb;

    public ConsoleWriter() => this.sb = new StringBuilder();

    public void AppendLine(string line) => this.sb.AppendLine(line);

    public void WriteLineAll() => Console.WriteLine(this.sb.ToString().Trim());
}