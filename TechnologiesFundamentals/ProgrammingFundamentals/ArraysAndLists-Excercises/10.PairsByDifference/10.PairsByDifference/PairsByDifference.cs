namespace _10.PairsByDifference
{
    using System;
    using System.Linq;

    public class PairsByDifference
    {
        public static void Main(string[] args)
        {
            var elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var number = int.Parse(Console.ReadLine());
            var found = 0;

            for (var i = 0; i < elements.Length; i++)
            {
                for (var j = elements.Length - 1; j > i; j--)
                {
                    if (elements[i] - elements[j] == number || elements[j] - elements[i] == number)
                    {
                        found++;
                    }
                }
            }

            Console.WriteLine(found);
        }
    } 
}