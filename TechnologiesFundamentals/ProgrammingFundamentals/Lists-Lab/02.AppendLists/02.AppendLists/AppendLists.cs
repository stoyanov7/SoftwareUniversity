namespace _02.AppendLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppendLists
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split('|')
                .ToList();

            input.Reverse();
            var result = new List<string>();

            foreach (var lines in input)
            {
                var numbers = lines
                    .Split(' ')
                    .ToList();

                foreach (var number in numbers)
                {
                    if (number != "")
                    {
                        result.Add(number);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    } 
}