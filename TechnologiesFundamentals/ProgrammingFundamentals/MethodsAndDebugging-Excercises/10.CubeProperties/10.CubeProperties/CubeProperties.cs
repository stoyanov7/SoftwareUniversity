namespace _10.CubeProperties
{
    using System;

    public class CubeProperties
    {
        public static void Main(string[] args)
        {
            var cubeSide = double.Parse(Console.ReadLine());
            var parameter = Console.ReadLine();
            CalculateCubeProperties(cubeSide, parameter);
        }

        private static void CalculateCubeProperties(double cubeSide, string parameter)
        {
            switch (parameter)
            {
                case "face":
                    var face = Math.Sqrt(Math.Pow(cubeSide, 2) * 2);
                    Console.WriteLine($"{face:F2}");
                    break;
                case "space":
                    var space = Math.Sqrt(Math.Pow(cubeSide, 2) * 3);
                    Console.WriteLine($"{space:F2}");
                    break;
                case "volume":
                    var volume = Math.Pow(cubeSide, 3);
                    Console.WriteLine($"{volume:F2}");
                    break;
                case "area":
                    var area = Math.Pow(cubeSide, 2) * 6;
                    Console.WriteLine($"{area:F2}");
                    break;
            }
        }
    } 
}