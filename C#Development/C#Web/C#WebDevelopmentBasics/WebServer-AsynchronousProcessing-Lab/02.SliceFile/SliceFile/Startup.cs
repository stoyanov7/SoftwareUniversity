namespace SliceFile
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var videoPath = Console.ReadLine();
            var destination = Console.ReadLine();
            var pieces = int.Parse(Console.ReadLine());

            SliceAsync(videoPath, destination, pieces);

            Console.WriteLine("Anything else?");

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
            }
        }

        private static async void SliceAsync(string sourceFile, string destinationPath, int parts)
        {
            await Task.Run(() =>
            {
                Slice(sourceFile, destinationPath, parts);
            });
        }

        private static void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                var fileInfo = new FileInfo(sourceFile);
                var partLength = (source.Length / parts) + 1;
                var currentByte = 0L;

                for (var currentPart = 1; currentPart <= parts; currentPart++)
                {
                    var filePath = $"{destinationPath}/Part-{currentPart}{fileInfo.Extension}";

                    using (var destination = new FileStream(filePath, FileMode.Create))
                    {
                        var buffer = new byte[1024];

                        while (currentByte <= partLength * currentPart)
                        {
                            var readBytesCount = source.Read(buffer, 0, buffer.Length);

                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }

                Console.WriteLine("Slice complete.");
            }
        }
    }
}
