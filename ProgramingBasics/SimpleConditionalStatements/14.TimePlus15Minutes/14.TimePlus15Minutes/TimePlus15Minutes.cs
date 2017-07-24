using System;

namespace _14.TimePlus15Minutes
{
    public class TimePlus15Minutes
    {
        public static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());

            var totalTime = (hours * 60) + minutes + 15;
            var hoursAfter = totalTime / 60;

            if (hoursAfter == 24)
            {
                hoursAfter = 00;
            }

            Console.Write(hoursAfter);
            Console.Write(totalTime % 60 < 9 ? ":0{0}" : ":{0}", totalTime % 60);
        }
    }
}
