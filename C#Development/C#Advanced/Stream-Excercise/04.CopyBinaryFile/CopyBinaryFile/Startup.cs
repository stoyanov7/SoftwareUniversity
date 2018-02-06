namespace CopyBinaryFile
{
    using System.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using (var source = new FileStream("image.jpg", FileMode.Open))
            {
                using (var fileStream = new FileStream("newImage.jgp", FileMode.Create))
                {
                    var buffer = new byte[4096];
                    var len = 0;

                    while ((len = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, len);
                    }
                }
            }
        }
    }
}
