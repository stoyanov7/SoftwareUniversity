namespace _01.CountWorkingDays
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class CountWorkingDays
    {
        public static void Main(string[] args)
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(),
                "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var holidays = new DateTime[12];
            holidays[0] = new DateTime(2016, 01, 01);
            holidays[1] = new DateTime(2016, 03, 03);
            holidays[2] = new DateTime(2016, 05, 01);
            holidays[3] = new DateTime(2016, 05, 06);
            holidays[4] = new DateTime(2016, 05, 24);
            holidays[5] = new DateTime(2016, 09, 06);
            holidays[6] = new DateTime(2016, 09, 22);
            holidays[7] = new DateTime(2016, 11, 01);
            holidays[9] = new DateTime(2016, 12, 24);
            holidays[10] = new DateTime(2016, 12, 25);
            holidays[11] = new DateTime(2016, 12, 26);

            var workdaysCount = 0;

            for (var currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {
                var checkDate = new DateTime(2016, currentDate.Month, currentDate.Day);

                var isWeekend = currentDate.DayOfWeek != DayOfWeek.Saturday &&
                    currentDate.DayOfWeek != DayOfWeek.Sunday;

                var isHoliday = !holidays.Contains(checkDate);

                if (isWeekend && isHoliday)
                {
                    workdaysCount++;
                }
            }

            Console.WriteLine(workdaysCount);
        }
    } 
}