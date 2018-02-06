namespace CustomMinFunction
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Func<double[], double> min = n => n.Min();
            Console.WriteLine(min(numbers));
        }
    }
}
