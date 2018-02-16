namespace HotelReservation
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var priceCalculator = new PriceCalculator(Console.ReadLine);
            Console.WriteLine(priceCalculator.CalculatePrice());
        }
    }
}