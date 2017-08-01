namespace _05.CompareCharArrays
{
    using System;
    using System.Linq;

    public class CompareCharArrays
    {
        public static void Main()
        {
            var first = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();

            var second = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();

            if (first.Length < second.Length)
            {
                Console.WriteLine($"{string.Join("", first)}\n{string.Join("", second)}");
            }
            else if (first.Length > second.Length)
            {
                Console.WriteLine($"{string.Join("", second)}\n{string.Join("", first)}");
            }
            else if (first.Length == second.Length)
            {
                var min = Math.Min(first.Length, second.Length);

                for (var i = 0; i < min; i++)
                {
                    if (first[i] > second[i])
                    {
                        Console.WriteLine($"{string.Join("", second)}\n{string.Join("", first)}");
                        break;
                    }

                    if (second[i] > first[i])
                    {
                        Console.WriteLine($"{string.Join("", first)}\n{string.Join("", second)}");
                        break;
                    }

                    if (second[i] == first[i])
                    {
                        Console.WriteLine($"{string.Join("", first)}\n{string.Join("", second)}");
                        break;
                    }
                }
            }
        }
    } 
}