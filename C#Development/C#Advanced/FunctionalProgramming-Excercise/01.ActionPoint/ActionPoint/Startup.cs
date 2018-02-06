namespace ActionPoint
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Action<string[]> print = n => Console.WriteLine(string.Join(Environment.NewLine, n));

            print(names);
        }
    }
}
