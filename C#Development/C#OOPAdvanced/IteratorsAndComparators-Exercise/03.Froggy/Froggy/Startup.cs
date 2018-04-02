namespace Froggy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            var lake = new Lake(numbers);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
