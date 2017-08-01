namespace _06.MaxSequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxSequenceOfEqualElements
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var maxnumbers = 0;
            var count = 1;
            var maxcount = 1;
            var pos = 0;

            while (pos < numbers.Count - 1)
            {
                if (numbers[pos] == numbers[pos + 1])
                {
                    count++;

                    if (count > maxcount)
                    {
                        maxcount = count;
                        maxnumbers = numbers[pos];
                    }

                }
                else
                {
                    count = 1;
                }

                pos++;

                if (maxcount == 1)
                {
                    maxnumbers = numbers[0];
                }
            }

            for (var i = 0; i < maxcount; i++)
            {
                Console.Write(maxnumbers);
                Console.Write(" ");
            }
        }
    } 
}