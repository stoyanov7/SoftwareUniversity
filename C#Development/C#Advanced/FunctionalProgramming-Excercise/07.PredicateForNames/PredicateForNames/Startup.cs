namespace PredicateForNames
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var nameLength = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(' ')
                .ToList();

            var sortedNames = names.Where(n => n.Length <= nameLength);

            Console.WriteLine(string.Join(Environment.NewLine, sortedNames));
        }
    }
}
