namespace _11.ConvertSpeedUnits
{
    using System;

    public class ConvertSpeedUnits
    {
        public static void Main(string[] args)
        {
            var distanceM = int.Parse(Console.ReadLine());
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            var seconds = int.Parse(Console.ReadLine());
            var secondsConverted = (((hours * 60) * 60) + minutes * 60 + seconds);
            var mPs = ((float)distanceM / (float)secondsConverted);
            var hoursConverted = (hours + ((double)minutes / 60) + ((double)((double)seconds / 60) / 60));
            var kmH = (((float)distanceM / 1000) / (float)hoursConverted);
            var mpH = (float)((double)distanceM / (double)1609) / (float)hoursConverted;

            Console.WriteLine($"{mPs}\n{kmH}\n{mpH}");
        }
    } 
}