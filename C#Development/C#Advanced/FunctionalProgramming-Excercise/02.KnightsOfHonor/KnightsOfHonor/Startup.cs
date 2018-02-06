namespace KnightsOfHonor
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new[] {' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string[]> print = n => Console.WriteLine(string.Join(Environment.NewLine, n.Select(name => $"Sir {name}")));

            print(names);
        }
    }
}
