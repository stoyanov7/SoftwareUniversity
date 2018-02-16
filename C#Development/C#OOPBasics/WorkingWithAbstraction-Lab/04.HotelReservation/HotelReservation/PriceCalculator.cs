namespace HotelReservation
{
    using System;
    using System.Linq;
    using Enums;

    public class PriceCalculator
    {
        private readonly decimal pricePerNight;
        private readonly int nights;
        private readonly Seasons season;
        private readonly Discounts discount;

        public PriceCalculator(Func<string> commandReader)
        {
            var commandTokens = commandReader().Split().ToArray();
            this.pricePerNight = decimal.Parse(commandTokens[0]);
            this.nights = int.Parse(commandTokens[1]);
            this.season = Enum.Parse<Seasons>(commandTokens[2]);

            this.discount = Discounts.None;

            if (commandTokens.Length > 3)
            {
                this.discount = Enum.Parse<Discounts>(commandTokens[3]);
            }
        }

        public string CalculatePrice()
        {
            var tempTotal = this.pricePerNight * this.nights * (int) this.season;
            var discountPercentage = ((decimal) 100 - (int) this.discount) / 100;
            var totalPrice = tempTotal * discountPercentage;

            return totalPrice.ToString("F2");
        }
    }
}