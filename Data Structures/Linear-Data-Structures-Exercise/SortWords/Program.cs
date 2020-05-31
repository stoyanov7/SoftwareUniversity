namespace SortWords
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split()
                .ToList()
                .OrderBy(x => x);

            Console.WriteLine(string.Join(' ', words));
        }
    }
}