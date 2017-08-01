namespace _01.CountRealNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountRealNumbers
    {
        public static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var countsDictionary = new SortedDictionary<double, int>();

            foreach (var number in inputNumbers)
            {
                if (!countsDictionary.ContainsKey(number))
                {
                    countsDictionary[number] = 0;
                }

                countsDictionary[number]++;
            }

            foreach (var element in countsDictionary)
            {
                Console.WriteLine($"{element.Key} -> {element.Value}");
            }
        }
    } 
}