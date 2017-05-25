using System;
using System.Collections.Generic;

namespace _01.RemoveElementsAtOddPositions
{
    public class RemoveElementsAtOddPositions
    {
        public static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(' ');
            var oddPosition = new List<string>();

            for (int i = 1; i < words.Length; i++)
            {
                if (i % 2 != 0)
                {
                    oddPosition.Add(words[i]);
                }
            }

            Console.WriteLine(string.Join(string.Empty, oddPosition));
        }
    }
}
