namespace _19.TheaThePhotographer
{
    using System;

    public class TheaThePhotographer
    {
        public static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var filterTime = long.Parse(Console.ReadLine());
            var filterFactor = long.Parse(Console.ReadLine());
            var uploadTime = long.Parse(Console.ReadLine());

            var totalFilteringTime = n * filterTime;
            var goodPictures = (long)(Math.Ceiling(n * filterFactor / 100d));
            var totalUploadTime = goodPictures * uploadTime;

            var totalTime = totalFilteringTime + totalUploadTime;

            var projectTime = TimeSpan.FromSeconds(totalTime);

            Console.WriteLine("{0:D1}:{1:D2}:{2:D2}:{3:D2}",
                projectTime.Days,
                projectTime.Hours,
                projectTime.Minutes,
                projectTime.Seconds);
        }
    } 
}