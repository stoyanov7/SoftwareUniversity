namespace StreamProgress
{
    using System;
    using Models;

    public class Startup
    {
        public static void Main()
        {   
            var progresInfo = new StreamProgressInfo(new File("File name", 100, 1000));
            var progresInfo2 = new StreamProgressInfo(new Music("Lili Ivanova", "Vetrove", 100, 1000));

            Console.WriteLine(progresInfo.CalculateCurrentPercent());
            Console.WriteLine(progresInfo2.CalculateCurrentPercent());
        }
    }
}
