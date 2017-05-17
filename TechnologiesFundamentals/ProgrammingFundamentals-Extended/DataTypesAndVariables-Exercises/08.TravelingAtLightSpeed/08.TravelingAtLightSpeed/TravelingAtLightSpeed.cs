using System;

namespace _08.TravelingAtLightSpeed
{
    public class TravelingAtLightSpeed
    {
        public static void Main(string[] args)
        {
            var oneLightYear = 9450000000000;
            var speedOfLight = 300000;

            var lightYear = decimal.Parse(Console.ReadLine());

            var kilometers = lightYear * oneLightYear;

            var seconds = kilometers / speedOfLight;
            var minutes = seconds / 60;
            seconds %= 60;

            var hours = minutes / 60;
            minutes %= 60;

            var days = hours / 24;
            hours %= 24;

            var weeks = days / 7;
            days %= 7;

            Console.WriteLine($"{(int)weeks} weeks");
            Console.WriteLine($"{(int)days} days");
            Console.WriteLine($"{(int)hours} hours");
            Console.WriteLine($"{(int)minutes} minutes");
            Console.WriteLine($"{(int)seconds} seconds");
        }
    }
}