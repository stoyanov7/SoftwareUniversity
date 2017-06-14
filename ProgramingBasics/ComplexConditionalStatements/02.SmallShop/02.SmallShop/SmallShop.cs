using System;

namespace _02.SmallShop
{
    public class SmallShop
    {
        public static void Main(string[] args)
        {
            var product = Console.ReadLine();
            var town = Console.ReadLine();
            var quantity = double.Parse(Console.ReadLine());
            var result = 0d;

            if (town == "Sofia")
            {
                if (product == "coffee")
                {
                    result = quantity * 0.50;
                }
                else if (product == "water")
                {
                    result = quantity * 0.80;
                }
                else if (product == "beer")
                {
                    result = quantity * 1.20;
                }
                else if (product == "sweets")
                {
                    result = quantity * 1.45;
                }
                else if (product == "peanuts")
                {
                    result = quantity * 1.60;
                }
            }
            else if (town == "Plovdiv")
            {
                if (product == "coffee")
                {
                    result = quantity * 0.40;
                }
                else if (product == "water")
                {
                    result = quantity * 0.70;
                }
                else if (product == "beer")
                {
                    result = quantity * 1.15;
                }
                else if (product == "sweets")
                {
                    result = quantity * 1.30;
                }
                else if (product == "peanuts")
                {
                    result = quantity * 1.50;
                }
            }
            else if (town == "Varna")
            {
                if (product == "coffee")
                {
                    result = quantity * 0.45;
                }
                else if (product == "water")
                {
                    result = quantity * 0.70;
                }
                else if (product == "beer")
                {
                    result = quantity * 1.10;
                }
                else if (product == "sweets")
                {
                    result = quantity * 1.35;
                }
                else if (product == "peanuts")
                {
                    result = quantity * 1.55;
                }
            }

            Console.WriteLine(result);
        }
    }
}
