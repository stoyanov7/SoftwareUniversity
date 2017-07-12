namespace _04.AddVAT
{
    using System;
    using System.Linq;

    public class AddVAT
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                  .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(double.Parse)
                  .Select(x => x + x * 0.2)
                  .ToList();

            numbers.ForEach(x => Console.WriteLine($"{x:F2}"));
        }
    }
}
