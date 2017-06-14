using System;

namespace _07.FruitShop
{
    public class FruitShop
    {
        public static void Main(string[] args)
        {
            var fruit = Console.ReadLine();
            var dayOfWeek = Console.ReadLine();
            var quantity = double.Parse(Console.ReadLine());
            var price = 0.0;
            var isWorkDay = dayOfWeek.Equals("Monday") || dayOfWeek.Equals("Tuesday") || dayOfWeek.Equals("Wednesday") || dayOfWeek.Equals("Thursday") || dayOfWeek.Equals("Friday");
            var isWeekend = dayOfWeek.Equals("Saturday") || dayOfWeek.Equals("Sunday");
            var result = 0d;

            if (isWorkDay)
            {
                switch (fruit)
                {
                    case "banana":
                        price = 2.50;
                        result = price * quantity;
                        break;
                    case "apple":
                        price = 1.20;
                        result = price * quantity;
                        break;
                    case "orange":
                        price = 0.85;
                        result = price * quantity;
                        break;
                    case "grapefruit":
                        price = 1.45;
                        result = price * quantity;
                        break;
                    case "kiwi":
                        price = 2.70;
                        result = price * quantity;
                        break;
                    case "pineapple":
                        price = 5.50;
                        result = price * quantity;
                        break;
                    case "grapes":
                        price = 3.85;
                        result = price * quantity;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (isWeekend)
            {
                switch (fruit)
                {
                    case "banana":
                        price = 2.70;
                        result = price * quantity;
                        break;
                    case "apple":
                        price = 1.25;
                        result = price * quantity;
                        break;
                    case "orange":
                        price = 0.90;
                        result = price * quantity;
                        break;
                    case "grapefruit":
                        price = 1.60;
                        result = price * quantity;
                        break;
                    case "kiwi":
                        price = 3.00;
                        result = price * quantity;
                        break;
                    case "pineapple":
                        price = 5.60;
                        result = price * quantity;
                        break;
                    case "grapes":
                        price = 4.20;
                        result = price * quantity;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }

            Console.WriteLine(result);
        }
    }
}