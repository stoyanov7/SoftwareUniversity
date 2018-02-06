namespace LineNumbers
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter path: ");
            var path = Console.ReadLine();

            try
            {
                using (var streamReader = new StreamReader(path))
                {
                    using (var streamWriter = new StreamWriter("newText.txt"))
                    {
                        var lineCount = 1;
                        var line = string.Empty;

                        while ((line = streamReader.ReadLine()) != null)
                        {
                            streamWriter.WriteLine($"Line {lineCount}: {line}");
                            lineCount++;
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
