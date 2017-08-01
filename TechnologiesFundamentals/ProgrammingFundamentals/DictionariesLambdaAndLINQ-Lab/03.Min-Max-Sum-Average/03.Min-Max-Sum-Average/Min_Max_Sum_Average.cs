namespace _03.Min_Max_Sum_Average
{
    using System;
    using System.Linq;
    using System.Text;

    public class Min_Max_Sum_Average
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var inputNumbers = new int[n];

            for (var i = 0; i < n; i++)
            {
                inputNumbers[i] = int.Parse(Console.ReadLine());
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Sum = {inputNumbers.Sum()}");
            sb.AppendLine($"Min = {inputNumbers.Min()}");
            sb.AppendLine($"Max = {inputNumbers.Max()}");
            sb.AppendLine($"Average = {inputNumbers.Average()}");

            Console.WriteLine(sb.ToString());
        }
    } 
}