namespace BashSoft
{
    using BashSoft.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            OutputWriter.PrintLogo();
            InputReader.StartReadingCommands();
        }
    }
}

