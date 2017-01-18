using System;


class CentriesToMinutes
{
    static void Main(string[] args)
    {
        var centuries = int.Parse(Console.ReadLine());
        var years = centuries * 100;
        var days = (int)(years * 365.2422);
        var hours = days * 24;
        var minutes = hours * 60;

        Console.WriteLine($"{centuries} = {years} = {days} = {hours} = {minutes}");
    }
}
