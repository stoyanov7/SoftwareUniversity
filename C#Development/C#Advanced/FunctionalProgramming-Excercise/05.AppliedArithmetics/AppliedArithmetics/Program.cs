namespace AppliedArithmetics
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var sb = new StringBuilder();

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(n => n + 1).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => n - 1).ToArray();
                        break;
                    case "multiply": 
                        numbers = numbers.Select(n => n * 2).ToArray();
                        break;
                    case "print":
                        sb.AppendLine(string.Join(" ", numbers));
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
