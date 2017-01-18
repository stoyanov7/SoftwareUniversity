using System;

public class RefactorVolumeOfPyramid
{
    public static void Main(string[] args)
    {
        Console.Write("Length: ");
        var length = float.Parse(Console.ReadLine());

        Console.Write("Width: ");
        var width = float.Parse(Console.ReadLine());

        Console.Write("Height: ");
        var height = float.Parse(Console.ReadLine());

        var volumе = (length * width * height) / 3;
        Console.Write("Pyramid Volume: {0:F2}", volumе);
    }
}