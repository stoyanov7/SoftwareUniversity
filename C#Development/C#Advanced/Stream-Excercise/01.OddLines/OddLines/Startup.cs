namespace OddLines
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
                using (var reader = new StreamReader(path))
                {
                    var lineCount = 0;
                    var line = string.Empty;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (lineCount % 2 == 1)
                        {
                            Console.WriteLine(line);
                        }

                        lineCount++;
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
