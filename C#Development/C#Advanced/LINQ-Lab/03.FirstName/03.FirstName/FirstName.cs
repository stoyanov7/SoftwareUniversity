namespace _03.FirstName
{
    using System;
    using System.Linq;

    public class FirstName
    {
        public static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(' ')
                .ToList();

            var letters = Console.ReadLine()
                .ToLower()
                .ToCharArray()
                .Where(l => l != ' ')
                .ToArray();

            var filteredNames = names
                .Where(n => letters.Contains(char.ToLower(n[0])))
                .ToArray();

            if (filteredNames.Length == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine(filteredNames.OrderBy(n => n).First());
            }
        }
    }
}
