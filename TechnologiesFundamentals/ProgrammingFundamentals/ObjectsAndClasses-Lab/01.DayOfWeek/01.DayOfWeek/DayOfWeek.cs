using System;
using System.Globalization;

public class DayOfWeek
{
    public static void Main(string[] args)
    {
        DateTime dateTime = DateTime.ParseExact(Console.ReadLine(),
            "d-M-yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine(dateTime.DayOfWeek);
    }
}