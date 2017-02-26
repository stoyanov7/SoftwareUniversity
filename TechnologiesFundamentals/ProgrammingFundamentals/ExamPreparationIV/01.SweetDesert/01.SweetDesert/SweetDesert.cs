using System;

public class SweetDesert
{
    public static void Main(string[] args)
    {
        var amountOfCash = decimal.Parse(Console.ReadLine());
        var numberOfGuests = long.Parse(Console.ReadLine());
        var priceOfBananas = decimal.Parse(Console.ReadLine());
        var priceOfEggs = decimal.Parse(Console.ReadLine());
        var priceOfBerries = decimal.Parse(Console.ReadLine());

        var portionsCount = (int)Math.Ceiling(numberOfGuests / 6.0);

        var total = (portionsCount * 2 * priceOfBananas) + (portionsCount * 4 * priceOfEggs) + (portionsCount * 0.2m * priceOfBerries);

        if (total <= amountOfCash)
        {
            Console.WriteLine($"Ivancho has enough money - it would cost {total:F2}lv.");
        }
        else
        {
            Console.WriteLine($"Ivancho will have to withdraw money - he will need {(total - amountOfCash):F2}lv more.");
        }
    }
}