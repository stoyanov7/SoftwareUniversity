namespace _03.CamelsBack
{
    using System;
    using System.Linq;

    public class CamelsBack
    {
        public static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var size = int.Parse(Console.ReadLine());

            if (line.Count == size)
            {
                Console.WriteLine($"already stable: {string.Join(" ", line)}");
                return;
            }

            var rounds = (line.Count - size) / 2;
            var remaining = line
                .Skip(rounds)
                .Take(size);

            Console.WriteLine($"{rounds} rounds{Environment.NewLine}remaining: {string.Join(" ", remaining)}");
        }
    }
}
