namespace _08.MostFrequentNumber
{
    using System;
    using System.Linq;

    public class MostFrequentNumber
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var maxFrequentNumber = 0;
            var maxCounter = 0;

            for (var i = 0; i < numbers.Length; i++)
            {
                var counter = 0;

                for (var j = i; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        counter++;

                        if (counter > maxCounter)
                        {
                            maxCounter = counter;
                            maxFrequentNumber = numbers[i];
                        }
                    }
                }
            }

            Console.WriteLine(maxFrequentNumber);
        }
    } 
}