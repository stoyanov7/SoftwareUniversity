﻿using System;

public class RectangleProperties
{
    public static void Main(string[] args)
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        double perimeter = 2 * (width + height);
        double area = width * height;
        double diagonal = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));

        Console.WriteLine($"{perimeter}\n{area}\n{diagonal}");
    }
}
