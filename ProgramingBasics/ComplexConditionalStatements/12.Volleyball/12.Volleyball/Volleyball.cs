using System;

namespace _12.Volleyball
{
    public class Volleyball
    {
        public static void Main(string[] args)
        {
            var year = Console.ReadLine();
            var p = int.Parse(Console.ReadLine());
            var homeVisits = int.Parse(Console.ReadLine());
            var weekends = 48 - homeVisits;

            var volleyballDays = weekends * 0.75;
            volleyballDays += homeVisits;
            var holidays = p * (2.0 / 3);
            volleyballDays = volleyballDays + holidays;

            if (year.Equals("leap"))
            {
                volleyballDays = volleyballDays * 1.15;
            }

            Console.WriteLine(TruncateDouble(volleyballDays, 0));
        }

        private static double TruncateDouble(double number, int numDigits)
        {
            var result = number;
            var arg = "" + number;
            var idx = arg.IndexOf('.');

            if (idx != -1)
            {
                if (arg.Length > idx + numDigits)
                {
                    arg = arg.Substring(0, idx + numDigits + 1);
                    result = double.Parse(arg);
                }
            }
            return result;
        }
    }
}