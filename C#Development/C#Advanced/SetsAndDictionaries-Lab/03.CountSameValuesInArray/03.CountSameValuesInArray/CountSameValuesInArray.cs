namespace _03.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSameValuesInArray
    {
        public static void Main(string[] args)
        {
            var values = new SortedDictionary<double, int>();
        
            var line = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var number in line)
            {
                if (!values.ContainsKey(number))
                {
                    values.Add(number, 0);
                }

                values[number]++;
            }

            foreach (var kvp in values)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
