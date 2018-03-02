namespace Ferrari
{
    using System;
    using Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var driverName = Console.ReadLine();
            var ferrari = new Ferrari(driverName);

            Console.WriteLine(ferrari.ToString());
        }
    }
}