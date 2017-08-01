namespace _01.DayOfWeek
{
    using System;
    using System.Globalization;

    public class DayOfWeek
    {
        public static void Main(string[] args)
        {
            var dateTime = DateTime.ParseExact(Console.ReadLine(),
                "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(dateTime.DayOfWeek);
        }
    } 
}