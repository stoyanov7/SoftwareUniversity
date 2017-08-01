﻿namespace _01.DayОfWeek
{
    using System;

    public class DayOfWeekend
    {
        public static void Main(string[] args)
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(n > 0 && n < 8 ? daysOfWeek[n - 1] : "Invalid day");
        }
    } 
}