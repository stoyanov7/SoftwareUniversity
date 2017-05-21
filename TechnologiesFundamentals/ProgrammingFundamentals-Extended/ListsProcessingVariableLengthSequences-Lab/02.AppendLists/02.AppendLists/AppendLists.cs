using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AppendLists
{
    public class AppendLists
    {
        public static void Main(string[] args)
        {
            var delimiter = " ".ToCharArray();

            var inputList = Console.ReadLine()
                .Split('|')
                .Reverse()
                .ToList();

            var reversedElements = new List<string>();

            for (var i = 0; i < inputList.Count; i++)
            {
                var currentElement = inputList[i]
                    .Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                reversedElements.AddRange(currentElement);
            }

            Console.WriteLine(string.Join(" ", reversedElements));
        }
    }
}
