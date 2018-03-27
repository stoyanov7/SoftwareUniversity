namespace Tuple
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            var name = $"{input[0]} {input[1]}";
            var address = input[2];

            Console.WriteLine(new Tuple<string, string>(name, address));

            input = Console.ReadLine().Split().ToArray();
            name = input[0];
            var litersOfBeer = int.Parse(input[1]);

            Console.WriteLine(new Tuple<string, int>(name, litersOfBeer));

            input = Console.ReadLine().Split().ToArray();
            var integer = int.Parse(input[0]);
            var doubleValue = double.Parse(input[1]);

            Console.WriteLine(new Tuple<int, double>(integer, doubleValue));
        }
    }
}