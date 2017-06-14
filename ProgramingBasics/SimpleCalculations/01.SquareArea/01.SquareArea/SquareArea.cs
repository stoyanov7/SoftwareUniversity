using System;

namespace _01.SquareArea
{
    public class SquareArea
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("a = ");
            var a = int.Parse(Console.ReadLine());
            Console.WriteLine($"Square = {a * a}");
        }
    }
}
