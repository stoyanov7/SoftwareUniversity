using System;

namespace _11.USDToBGN
{
    public class USDToBGN
    {
        public static void Main(string[] args)
        {
            var BGN = decimal.Parse(Console.ReadLine());
            var rate = (decimal)1.79549;
            var USD = BGN * rate;

            Console.WriteLine($"{USD} BGN");
        }
    }
}
