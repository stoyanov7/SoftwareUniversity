namespace _03.CountUppercaseWords
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var result = text
                .Where(x => char.IsUpper(x[0]))
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
