namespace RotateImages
{
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var images = new DirectoryInfo("../../Images").GetFiles();

            var tasks = images
                .Select(image => Task.Run(() =>
                {
                    var currentImage = Image.FromFile(image.Name);

                    currentImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                    currentImage.Save(image.Name + "rotated");
                }))
                .ToList();

            Task.WaitAll(tasks.ToArray());
        }
    }
}
