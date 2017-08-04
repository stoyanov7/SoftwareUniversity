namespace BashSoft
{
    using IO;

    public class StartUp
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        /// <param name="args"> A list of command line arguments.</param>
        public static void Main(string[] args)
        {
            OutputWriter.PrintLogo();
            InputReader.StartReadingCommands();
        }
    }
}