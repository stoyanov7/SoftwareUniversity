using System;

namespace _04.RefactorVolumeOfPyramid
{
    public class RefactorVolumeOfPyramid
    {
        public static void Main(string[] args)
        {
            Console.Write("Length: ");
            var length = double.Parse(Console.ReadLine());

            Console.Write("Width: ");
            var width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
            var height = double.Parse(Console.ReadLine());

            var volumе = (length * width * height) / 3;
            Console.Write("Pyramid Volume: {0:F2}", volumе);
        }
    }
}
