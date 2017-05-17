using System;

namespace _07.FromTerabytesToBits
{
    public class FromTerabytesToBits
    {
        public static void Main(string[] args)
        {
            var terabytes = double.Parse(Console.ReadLine());

            Console.WriteLine(terabytes * 8796093022208);
        }
    }
}
