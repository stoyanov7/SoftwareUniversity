using System;

namespace _11.Cinema
{
    public class Cinema
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());
            var price = 0d; ;

            if (input.Equals("Premiere"))
            {
                price = 12.00;
                Console.WriteLine("{0:F2} leva", price * row * col);
            }
            else if (input.Equals("Normal"))
            {
                price = 7.50;
                Console.WriteLine("{0:F2} leva", price * row * col);
            }
            else if (input.Equals("Discount"))
            {
                price = 5.00;
                Console.WriteLine("{0:F2} leva", price * row * col);
            }
        }
    }
}
