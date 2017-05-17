using System;

namespace _01.TimeSinceBirthday
{
    public class TimeSinceBirthday
    {
        public static void Main(string[] args)
        {
            var years = int.Parse(Console.ReadLine());
            var days = years * 365;
            var hours = days * 24;
            var minutes = hours * 60;

            Console.WriteLine($"{years} years = {days} days = {hours} hours {minutes} minutes.");
        }
    }
}