namespace _01.StudentsResults
{
    using System;
    using System.Linq;
    using System.Text;

    public class StudentsResults
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            sb.AppendLine($"{"Name",-10}|{"CAdv",7}|{"COOP",7}|{"AdvOOP",7}|{"Average",7}|");

            for (var i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(new[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = line[0];
                var results = line
                    .Skip(1)
                    .Select(double.Parse)
                    .ToList();

                sb.AppendLine($"{name,-10}|{results[0],7:f2}|{results[1],7:f2}|{results[2],7:f2}|{results.Average(),7:f4}|");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
