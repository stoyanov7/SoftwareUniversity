using System;

public class Elevator
{
    public static void Main(string[] args)
    {
        var numberOfPeople = int.Parse(Console.ReadLine());
        var capacity = int.Parse(Console.ReadLine());

        var couses = (int)Math.Ceiling((double)numberOfPeople / capacity);
        Console.WriteLine(couses); 
    }
}