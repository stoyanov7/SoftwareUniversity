namespace _03.ShortWordsSorted
{
    using System;
    using System.Linq;

    public class ShortWordsSorted
    {

        public static void Main(string[] args)
        {
            var separators = new[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };

            var text = Console.ReadLine()
                .ToLower()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var result = text
                .Where(x => x.Length < 5)
                .OrderBy(x => x)
                .Distinct();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}