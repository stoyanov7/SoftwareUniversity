using System;

namespace _05.InvalidNumber
{
    public class InvalidNumber
    {
        public static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            if (input >= 100 && input <= 200)
            {
                Console.WriteLine();
            }
            else if (input == 0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
