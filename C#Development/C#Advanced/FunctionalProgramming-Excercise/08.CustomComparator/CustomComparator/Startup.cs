namespace CustomComparator
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> comparator = (n1, n2) =>
                (n1 % 2 == 0 && n2 % 2 != 0) ? -1 :
                (n1 % 2 != 0 && n2 % 2 == 0) ? 1 :
                n1.CompareTo(n2);

            Array.Sort(numbers, new Comparison<int>(comparator));

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
